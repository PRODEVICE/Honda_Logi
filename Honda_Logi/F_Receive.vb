Imports System.IO
Imports System.Configuration
Imports System.Text
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Receive

    Dim fnc As New Function_Class

    Private _mode As Integer

    ' コンストラクタを追加
    Public Sub New(mode As Integer)
        InitializeComponent()
        _mode = mode
    End Sub

    'ページロード時
    Private Sub F_Receive_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'TODO: このコード行はデータを 'DS_M.DT_M_Kubun' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            'Me.TA_M_Kubun.Fill(Me.DS_M.DT_M_Kubun)

            'CCCのファイルパスを初期セット
            Txt_File_Path.Text = My.Settings.Input_Path

            Dtp_Nengetu.Format = DateTimePickerFormat.Custom
            Dtp_Nengetu.CustomFormat = "yyyy年MM月"

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Receive_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    '参照ボタンクリック時
    Private Sub Btn_Sanshou_Click(sender As Object, e As EventArgs) Handles Btn_Sanshou.Click

        Try

            '上部に表示する説明テキストを指定する
            FolderBrowserDialog1.Description = "フォルダを指定してください。"
            'ルートフォルダを指定する
            ''デフォルトでDesktop
            'FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
            '最初に選択するフォルダを指定する
            'RootFolder以下にあるフォルダである必要がある
            FolderBrowserDialog1.SelectedPath = Txt_File_Path.Text
            'ユーザーが新しいフォルダを作成できるようにする
            'デフォルトでTrue
            FolderBrowserDialog1.ShowNewFolderButton = True

            'ダイアログを表示する
            If FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
                '選択されたフォルダを表示する
                Txt_File_Path.Text = FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Receive_Btn_Sanshou_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '取込ボタンクリック時
    Private Sub Btn_Receive_Click(sender As Object, e As EventArgs) Handles Btn_Receive.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim targetFolder As String = Txt_File_Path.Text.Trim
            Dim nengetu As String = Dtp_Nengetu.Value.Year.ToString & "/" & Dtp_Nengetu.Value.Month.ToString.PadLeft(2, "0")

            My.Settings.Input_Path = Txt_File_Path.Text.Trim

            'フォルダ内のファイル一覧取得
            Dim files As String() = Directory.GetFiles(targetFolder)

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            Using conn As New SqlConnection(connectionString)

                conn.Open()

                Using tran As SqlTransaction = conn.BeginTransaction()

                    '通常モードなら
                    If _mode = 1 Then

                        Try

                            '取込が行われたかを判別
                            Dim ccc_flg As Boolean = False
                            Dim kow46_flg As Boolean = False
                            Dim kit60_flg As Boolean = False
                            Dim gyoumu_flg As Boolean = False
                            Dim order_flg As Boolean = False

                            '見積番号取得
                            Dim mitsumori_no_old As Integer '1個前の値も後の処理の為に取得しておく
                            Dim mitsumori_no As Integer = Get_No(conn, tran, mitsumori_no_old)

                            '1ファイルずつ処理
                            For Each filePath As String In files

                                Dim fileName As String = Path.GetFileName(filePath)

                                If fileName.Contains("CCC") Then

                                    Import_CCC(filePath, nengetu, mitsumori_no, conn, tran)
                                    ccc_flg = True

                                ElseIf fileName.Contains("KOW46") Then

                                    Import_KOW46(filePath, nengetu, mitsumori_no, conn, tran)
                                    kow46_flg = True

                                ElseIf fileName.Contains("KIT60") Then

                                    Import_KIT60(filePath, nengetu, mitsumori_no, conn, tran)
                                    kit60_flg = True

                                ElseIf fileName.Contains("業務量") Then

                                    Import_Gyoumu(filePath, nengetu, mitsumori_no, conn, tran)
                                    gyoumu_flg = True

                                ElseIf fileName.Contains("部品単位") Then

                                    Import_Order(filePath, nengetu, mitsumori_no, conn, tran)
                                    order_flg = True

                                End If

                            Next

                            '取り込んでいないファイルがある場合は、直前の見積Noの値をインサートする
                            If ccc_flg = False Then
                                Copy_Tran(conn, tran, "T_CCC", mitsumori_no_old, mitsumori_no)
                            End If
                            If kow46_flg = False Then
                                Copy_Tran(conn, tran, "T_KOW46", mitsumori_no_old, mitsumori_no)
                            End If
                            If kit60_flg = False Then
                                Copy_Tran(conn, tran, "T_KIT60", mitsumori_no_old, mitsumori_no)
                            End If
                            If gyoumu_flg = False Then
                                Copy_Tran(conn, tran, "T_Gyomu_Plan", mitsumori_no_old, mitsumori_no)
                            End If
                            If order_flg = False Then
                                Copy_Tran(conn, tran, "T_Buhin_Order_List", mitsumori_no_old, mitsumori_no)
                            End If

                            '履歴テーブルに登録
                            Import_Rireki(conn, tran, mitsumori_no, nengetu)

                            ' 全て成功したらコミット
                            tran.Commit()

                            '対象ファイルをBKフォルダに移動
                            File_Move(targetFolder, files)

                        Catch ex As Exception
                            ' どれか失敗したらロールバック
                            tran.Rollback()
                            Throw
                        End Try


                    ElseIf _mode = 2 Then '見積依頼モードなら

                        Try

                            '見積番号取得
                            Dim mitsumori_no_old As Integer
                            Dim mitsumori_no As Integer = Get_No(conn, tran, mitsumori_no_old)

                            '1ファイルずつ処理
                            For Each filePath As String In files

                                Dim fileName As String = Path.GetFileName(filePath)

                                If fileName.Contains("CCC") Then

                                    Import_CCC_Manual(filePath, nengetu, mitsumori_no, conn, tran)

                                End If

                            Next

                            '履歴テーブルに登録
                            Import_Rireki(conn, tran, mitsumori_no, nengetu)

                            ' 全て成功したらコミット
                            tran.Commit()

                            '対象ファイルをBKフォルダに移動
                            File_Move(targetFolder, files)

                        Catch ex As Exception
                            ' どれか失敗したらロールバック
                            tran.Rollback()
                            Throw
                        End Try

                    End If


                End Using

            End Using

            MessageBox.Show("取り込み完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Receive_Btn_Receive_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '**********************************************************************************
    '関数
    '**********************************************************************************

    'CCCファイル取り込み処理
    Sub Import_CCC(_file_path As String, _nengetu As String, _mitsumori_no As Integer, conn As SqlConnection, tran As SqlTransaction)

        Try

            Dim dt_ccc As New DS_T.DT_T_CCCDataTable
            Dim batchSize As Integer = 5000
            Dim batchCount As Integer = 0

            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)

                bulk.DestinationTableName = "T_CCC"
                bulk.BatchSize = batchSize

                Dim dtBatch As DataTable = dt_ccc.Clone()

                For Each line As String In File.ReadLines(_file_path, Encoding.Default)

                    If String.IsNullOrWhiteSpace(line) Then
                        Continue For
                    End If

                    Dim dr As DataRow = dtBatch.NewRow()
                    dr("工程管理ｼｽﾃﾑ日付") = NormalizeString(Mid(line, 1, 8))
                    dr("処理ID") = NormalizeString(Mid(line, 9, 3))
                    dr("包装指示1") = NormalizeString(Mid(line, 12, 1))
                    dr("コンテンツ1") = NormalizeString(Mid(line, 13, 1))
                    dr("パッケージコンテンツ1") = NormalizeString(Mid(line, 14, 1))
                    dr("パッキングチェックシート1") = NormalizeString(Mid(line, 15, 1))
                    dr("ケースマーク1") = NormalizeString(Mid(line, 16, 1))
                    dr("部品管理エフ1") = NormalizeString(Mid(line, 17, 1))
                    dr("包装指示2") = NormalizeString(Mid(line, 18, 4))
                    dr("コンテンツ2") = NormalizeString(Mid(line, 22, 5))
                    dr("パッケージコンテンツ2") = NormalizeString(Mid(line, 27, 4))
                    dr("パッキングチェックシート2") = NormalizeString(Mid(line, 31, 4))
                    dr("ケースマーク2") = NormalizeString(Mid(line, 35, 4))
                    dr("部品管理エフ2") = NormalizeString(Mid(line, 39, 4))
                    dr("包装指示3") = NormalizeString(Mid(line, 43, 1))
                    dr("コンテンツ3") = NormalizeString(Mid(line, 44, 1))
                    dr("パッケージコンテンツ3") = NormalizeString(Mid(line, 45, 1))
                    dr("パッキングチェックシート3") = NormalizeString(Mid(line, 46, 1))
                    dr("ケースマーク3") = NormalizeString(Mid(line, 47, 1))
                    dr("部品管理エフ3") = NormalizeString(Mid(line, 48, 1))
                    dr("包装指示4") = NormalizeString(Mid(line, 49, 1))
                    dr("コンテンツ4") = NormalizeString(Mid(line, 50, 1))
                    dr("パッケージコンテンツ4") = NormalizeString(Mid(line, 51, 1))
                    dr("パッキングチェックシート4") = NormalizeString(Mid(line, 52, 1))
                    dr("ケースマーク4") = NormalizeString(Mid(line, 53, 1))
                    dr("部品管理エフ4") = NormalizeString(Mid(line, 54, 1))
                    dr("予約1") = NormalizeString(Mid(line, 55, 1))
                    dr("予約2") = NormalizeString(Mid(line, 56, 1))
                    dr("予約3") = NormalizeString(Mid(line, 57, 1))
                    dr("予約4") = NormalizeString(Mid(line, 58, 1))
                    dr("予約5") = NormalizeString(Mid(line, 59, 1))
                    dr("アイテムNO表示") = NormalizeString(Mid(line, 60, 1))
                    dr("KD部番表示区分") = NormalizeString(Mid(line, 61, 1))
                    dr("C_M重量表示要否") = NormalizeString(Mid(line, 62, 1))
                    dr("A_Sフォーマット") = NormalizeString(Mid(line, 63, 1))
                    dr("A_S日本表示形式") = NormalizeString(Mid(line, 64, 1))
                    dr("A_S現地表示形式") = NormalizeString(Mid(line, 65, 1))
                    dr("A_S輸出部品名称") = NormalizeString(Mid(line, 66, 1))
                    dr("P_ﾘｽﾄ2ND記述") = NormalizeString(Mid(line, 67, 1))
                    dr("包装資材表示要否") = NormalizeString(Mid(line, 68, 1))
                    dr("オプション表示区分") = NormalizeString(Mid(line, 69, 1))
                    dr("機種コード表示区分") = NormalizeString(Mid(line, 70, 1))
                    dr("予約6") = NormalizeString(Mid(line, 71, 1))
                    dr("原産国表示要否") = NormalizeString(Mid(line, 72, 1))
                    dr("対応要否_10_2") = NormalizeString(Mid(line, 73, 1))
                    dr("対応要否_5品目") = NormalizeString(Mid(line, 74, 1))
                    dr("包装SS") = NormalizeString(Mid(line, 75, 1))
                    dr("汎区分24") = NormalizeString(Mid(line, 76, 1))
                    dr("PC_NO") = NormalizeString(Mid(line, 77, 11))
                    dr("ｺﾝﾄﾛｰﾙNO") = NormalizeString(Mid(line, 88, 4))
                    dr("年度1") = NormalizeString(Mid(line, 92, 1))
                    dr("モデル1") = NormalizeString(Mid(line, 93, 3))
                    dr("モデフNO") = NormalizeString(Mid(line, 96, 4))
                    dr("ケースNO1") = NormalizeString(Mid(line, 100, 5))
                    dr("レコードID") = NormalizeString(Mid(line, 105, 1))
                    dr("バッチ処理エラーコード") = NormalizeString(Mid(line, 106, 2))
                    dr("量産_枠外区分") = NormalizeString(Mid(line, 108, 1))
                    dr("インボイスNO") = NormalizeString(Mid(line, 109, 12))
                    dr("代表DIST") = NormalizeString(Mid(line, 121, 3))
                    dr("部品群") = NormalizeString(Mid(line, 124, 3))
                    dr("包装ロットNO") = NormalizeString(Mid(line, 127, 10))
                    dr("包装ロット連番") = NormalizeString(Mid(line, 137, 2))
                    dr("現地工場コード") = NormalizeString(Mid(line, 139, 1))
                    dr("現地ラインNO1") = NormalizeString(Mid(line, 140, 1))
                    dr("年1") = NormalizeString(Mid(line, 141, 4))
                    dr("月1") = NormalizeString(Mid(line, 145, 2))
                    dr("連番1") = NormalizeString(Mid(line, 147, 4))
                    dr("サフィックス") = NormalizeString(Mid(line, 151, 2))
                    dr("K_Y_KD1") = NormalizeString(Mid(line, 153, 1))
                    dr("年度2") = NormalizeString(Mid(line, 154, 1))
                    dr("モデル2") = NormalizeString(Mid(line, 155, 3))
                    dr("タイプ1") = NormalizeString(Mid(line, 158, 3))
                    dr("オプション1") = NormalizeString(Mid(line, 161, 3))
                    dr("外装HES1") = NormalizeString(Mid(line, 164, 4))
                    dr("内装タイプ1") = NormalizeString(Mid(line, 168, 8))
                    dr("K_Y_KD2") = NormalizeString(Mid(line, 176, 1))
                    dr("年度3") = NormalizeString(Mid(line, 177, 1))
                    dr("モデル3") = NormalizeString(Mid(line, 178, 3))
                    dr("タイプ2") = NormalizeString(Mid(line, 181, 3))
                    dr("群") = NormalizeString(Mid(line, 184, 3))
                    dr("外装HES2") = NormalizeString(Mid(line, 187, 4))
                    dr("内装タイプ2") = NormalizeString(Mid(line, 191, 8))
                    dr("K_Y_KD3") = NormalizeString(Mid(line, 199, 1))
                    dr("年度4") = NormalizeString(Mid(line, 200, 1))
                    dr("モデル4") = NormalizeString(Mid(line, 201, 3))
                    dr("タイプ3") = NormalizeString(Mid(line, 204, 3))
                    dr("オプション2") = NormalizeString(Mid(line, 207, 3))
                    dr("外装HES3") = NormalizeString(Mid(line, 210, 4))
                    dr("内装タイプ3") = NormalizeString(Mid(line, 214, 8))
                    dr("MIX区分") = NormalizeString(Mid(line, 222, 1))
                    dr("代表区分1") = NormalizeString(Mid(line, 223, 1))
                    dr("包装仕様有無区分") = NormalizeString(Mid(line, 224, 1))
                    dr("包装場") = NormalizeString(Mid(line, 225, 4))
                    dr("オーダー区分") = NormalizeString(Mid(line, 229, 1))
                    dr("オーダー経歴NO") = NormalizeString(Mid(line, 230, 3))
                    dr("配送先DIST") = NormalizeString(Mid(line, 233, 3))
                    dr("オーダー元プラント") = NormalizeString(Mid(line, 236, 1))
                    dr("現地ラインNO2") = NormalizeString(Mid(line, 237, 1))
                    dr("モデル年度") = NormalizeString(Mid(line, 238, 2))
                    dr("オーダー理由コード") = NormalizeString(Mid(line, 240, 1))
                    dr("オーダー年月日SEQ") = NormalizeString(Mid(line, 241, 11))
                    dr("シップメントNO") = NormalizeString(Mid(line, 252, 2))
                    dr("基本生産計画区分") = NormalizeString(Mid(line, 254, 1))
                    dr("計画年月") = NormalizeString(Mid(line, 255, 6))
                    dr("計画改訂NO") = NormalizeString(Mid(line, 261, 2))
                    dr("計画コード") = NormalizeString(Mid(line, 263, 6))
                    dr("包装予定日") = NormalizeString(Mid(line, 269, 8))
                    dr("計画確定区分") = NormalizeString(Mid(line, 277, 1))
                    dr("SS") = NormalizeString(Mid(line, 278, 1))
                    dr("本社製品区分") = NormalizeString(Mid(line, 279, 1))
                    dr("年2") = NormalizeString(Mid(line, 280, 4))
                    dr("月2") = NormalizeString(Mid(line, 284, 2))
                    dr("連番2") = NormalizeString(Mid(line, 286, 2))
                    dr("包装数量") = NormalizeString(Mid(line, 288, 7))
                    dr("個装ライン") = NormalizeString(Mid(line, 295, 2))
                    dr("内装ライン") = NormalizeString(Mid(line, 297, 6))
                    dr("包装ライン_外装") = NormalizeString(Mid(line, 303, 2))
                    dr("ケース順位") = NormalizeString(Mid(line, 306, 13))
                    dr("包装ロット台数") = NormalizeString(Mid(line, 319, 7))
                    dr("ケース保税区分") = NormalizeString(Mid(line, 326, 1))
                    dr("ケースグロスL") = NormalizeString(Mid(line, 327, 5))
                    dr("ケースグロスW") = NormalizeString(Mid(line, 332, 5))
                    dr("ケースグロスH") = NormalizeString(Mid(line, 337, 5))
                    dr("ケースグロス容量M3") = NormalizeString(Mid(line, 342, 9))
                    dr("ケースネットL") = NormalizeString(Mid(line, 351, 5))
                    dr("ケースネットW") = NormalizeString(Mid(line, 356, 5))
                    dr("ケースネットH") = NormalizeString(Mid(line, 361, 5))
                    dr("ケースネット容量M3") = NormalizeString(Mid(line, 366, 9))
                    dr("ケースネット重量") = NormalizeString(Mid(line, 375, 10))
                    dr("ケース重量計画値") = NormalizeString(Mid(line, 385, 8))
                    dr("ケース実績重量") = NormalizeString(Mid(line, 393, 9))
                    dr("ケース重量測定要求") = NormalizeString(Mid(line, 402, 1))
                    dr("初物部品ケースサイン") = NormalizeString(Mid(line, 403, 1))
                    dr("エンジンASSYサイン") = NormalizeString(Mid(line, 404, 1))
                    dr("K_Y_KD4") = NormalizeString(Mid(line, 405, 1))
                    dr("年度5") = NormalizeString(Mid(line, 406, 1))
                    dr("モデル5") = NormalizeString(Mid(line, 407, 3))
                    dr("タイプ4") = NormalizeString(Mid(line, 410, 3))
                    dr("オプション3") = NormalizeString(Mid(line, 413, 3))
                    dr("外装HES4") = NormalizeString(Mid(line, 416, 4))
                    dr("内装タイプ4") = NormalizeString(Mid(line, 420, 8))
                    dr("エンジン入り数") = NormalizeString(Mid(line, 428, 3))
                    dr("パッキングNO") = NormalizeString(Mid(line, 431, 3))
                    dr("FILLER1") = NormalizeString(Mid(line, 434, 2))
                    dr("オーダーアイテムNO") = NormalizeString(Mid(line, 436, 5))
                    dr("ITEM") = NormalizeString(Mid(line, 441, 5))
                    dr("基本部番") = NormalizeString(Mid(line, 446, 15))
                    dr("設変部番") = NormalizeString(Mid(line, 461, 15))
                    dr("KD部番") = NormalizeString(Mid(line, 476, 9))
                    dr("部品色") = NormalizeString(Mid(line, 485, 11))
                    dr("輸出部品名称") = NormalizeString(Mid(line, 496, 95))
                    dr("第二外国語名称") = ""
                    dr("主管SS") = ""
                    dr("現地ロケーションNO") = ""
                    dr("部品単位重量") = NormalizeString(Mid(line, 591, 9))
                    dr("個装資材記号") = NormalizeString(Mid(line, 600, 5))
                    dr("個装手順SEQ") = NormalizeString(Mid(line, 605, 4))
                    dr("部品収容数") = NormalizeString(Mid(line, 609, 6))
                    dr("個装担当NO") = NormalizeString(Mid(line, 615, 7))
                    dr("内装資材記号") = NormalizeString(Mid(line, 622, 5))
                    dr("内装手順SEQ") = NormalizeString(Mid(line, 627, 3))
                    dr("内装NO") = NormalizeString(Mid(line, 630, 2))
                    dr("個装入り数") = NormalizeString(Mid(line, 632, 7))
                    dr("内装担当NO") = NormalizeString(Mid(line, 639, 7))
                    dr("外装資材記号") = NormalizeString(Mid(line, 646, 5))
                    dr("モジュール手順SEQ") = NormalizeString(Mid(line, 651, 3))
                    dr("内装入り数") = NormalizeString(Mid(line, 654, 7))
                    dr("外装担当NO1") = NormalizeString(Mid(line, 661, 7))
                    dr("外装担当NO2") = NormalizeString(Mid(line, 668, 7))
                    dr("台当り使用個数") = NormalizeString(Mid(line, 675, 5))
                    dr("包装指示数") = NormalizeString(Mid(line, 680, 5))
                    dr("ケース個内装荷姿必要") = NormalizeString(Mid(line, 685, 3))
                    dr("コンテンツ必要枚数") = NormalizeString(Mid(line, 688, 3))
                    dr("要否区分") = NormalizeString(Mid(line, 691, 1))
                    dr("品質チェック要否") = NormalizeString(Mid(line, 692, 1))
                    dr("取引先NO") = NormalizeString(Mid(line, 693, 3))
                    dr("搬入ホーム") = NormalizeString(Mid(line, 697, 6))
                    dr("海事専用機種名称") = NormalizeString(Mid(line, 703, 14))
                    dr("包装特性1") = NormalizeString(Mid(line, 717, 7))
                    dr("包装特性2") = NormalizeString(Mid(line, 724, 1))
                    dr("包装特性3") = NormalizeString(Mid(line, 725, 1))
                    dr("包装特性4") = NormalizeString(Mid(line, 726, 1))
                    dr("包装特性5") = NormalizeString(Mid(line, 727, 1))
                    dr("FILLER2") = NormalizeString(Mid(line, 728, 1))
                    dr("部品包装特性1") = NormalizeString(Mid(line, 729, 2))
                    dr("部品包装特性2") = NormalizeString(Mid(line, 731, 2))
                    dr("部品包装特性3") = NormalizeString(Mid(line, 733, 2))
                    dr("部品包装特性4") = NormalizeString(Mid(line, 735, 2))
                    dr("部品包装特性5") = NormalizeString(Mid(line, 737, 2))
                    dr("内装総重量") = NormalizeString(Mid(line, 739, 9))
                    dr("代表区分2") = NormalizeString(Mid(line, 748, 1))
                    dr("副資材1") = NormalizeString(Mid(line, 749, 5))
                    dr("必要数1") = NormalizeString(Mid(line, 754, 3))
                    dr("代表区分3") = NormalizeString(Mid(line, 757, 1))
                    dr("副資材2") = NormalizeString(Mid(line, 758, 5))
                    dr("必要数2") = NormalizeString(Mid(line, 763, 3))
                    dr("代表区分4") = NormalizeString(Mid(line, 766, 1))
                    dr("副資材3") = NormalizeString(Mid(line, 767, 5))
                    dr("必要数3") = NormalizeString(Mid(line, 772, 3))
                    dr("代表区分5") = NormalizeString(Mid(line, 775, 1))
                    dr("副資材4") = NormalizeString(Mid(line, 776, 5))
                    dr("必要数4") = NormalizeString(Mid(line, 781, 3))
                    dr("代表区分6") = NormalizeString(Mid(line, 784, 1))
                    dr("副資材5") = NormalizeString(Mid(line, 785, 5))
                    dr("必要数5") = NormalizeString(Mid(line, 790, 3))
                    dr("代表区分7") = NormalizeString(Mid(line, 793, 1))
                    dr("副資材6") = NormalizeString(Mid(line, 794, 5))
                    dr("必要数6") = NormalizeString(Mid(line, 799, 3))
                    dr("代表区分8") = NormalizeString(Mid(line, 802, 1))
                    dr("副資材7") = NormalizeString(Mid(line, 803, 5))
                    dr("必要数7") = NormalizeString(Mid(line, 808, 3))
                    dr("代表区分9") = NormalizeString(Mid(line, 811, 1))
                    dr("副資材8") = NormalizeString(Mid(line, 812, 5))
                    dr("必要数8") = NormalizeString(Mid(line, 817, 3))
                    dr("代表区分10") = NormalizeString(Mid(line, 820, 1))
                    dr("副資材9") = NormalizeString(Mid(line, 821, 5))
                    dr("必要数9") = NormalizeString(Mid(line, 826, 3))
                    dr("代表区分11") = NormalizeString(Mid(line, 829, 1))
                    dr("副資材10") = NormalizeString(Mid(line, 830, 5))
                    dr("必要数10") = NormalizeString(Mid(line, 835, 3))
                    dr("代表区分12") = NormalizeString(Mid(line, 838, 1))
                    dr("副資材11") = NormalizeString(Mid(line, 839, 5))
                    dr("必要数11") = NormalizeString(Mid(line, 844, 3))
                    dr("代表区分13") = NormalizeString(Mid(line, 847, 1))
                    dr("副資材12") = NormalizeString(Mid(line, 848, 5))
                    dr("必要数12") = NormalizeString(Mid(line, 853, 3))
                    dr("代表区分14") = NormalizeString(Mid(line, 856, 1))
                    dr("副資材13") = NormalizeString(Mid(line, 857, 5))
                    dr("必要数13") = NormalizeString(Mid(line, 862, 3))
                    dr("代表区分15") = NormalizeString(Mid(line, 865, 1))
                    dr("副資材14") = NormalizeString(Mid(line, 866, 5))
                    dr("必要数14") = NormalizeString(Mid(line, 871, 3))
                    dr("代表区分16") = NormalizeString(Mid(line, 874, 1))
                    dr("副資材15") = NormalizeString(Mid(line, 875, 5))
                    dr("必要数15") = NormalizeString(Mid(line, 880, 3))
                    dr("代表区分17") = NormalizeString(Mid(line, 883, 1))
                    dr("副資材16") = NormalizeString(Mid(line, 884, 5))
                    dr("必要数16") = NormalizeString(Mid(line, 889, 3))
                    dr("代表区分18") = NormalizeString(Mid(line, 892, 1))
                    dr("副資材17") = NormalizeString(Mid(line, 893, 5))
                    dr("必要数17") = NormalizeString(Mid(line, 898, 3))
                    dr("代表区分19") = NormalizeString(Mid(line, 901, 1))
                    dr("副資材18") = NormalizeString(Mid(line, 902, 5))
                    dr("必要数18") = NormalizeString(Mid(line, 907, 3))
                    dr("代表区分20") = NormalizeString(Mid(line, 910, 1))
                    dr("副資材19") = NormalizeString(Mid(line, 911, 5))
                    dr("必要数19") = NormalizeString(Mid(line, 916, 3))
                    dr("代表区分21") = NormalizeString(Mid(line, 919, 1))
                    dr("副資材20") = NormalizeString(Mid(line, 920, 5))
                    dr("必要数20") = NormalizeString(Mid(line, 925, 3))
                    dr("ダイレクト包装記号1") = NormalizeString(Mid(line, 928, 1))
                    dr("リターナブル区分1") = NormalizeString(Mid(line, 929, 1))
                    dr("ダイレクト包装記号2") = NormalizeString(Mid(line, 930, 1))
                    dr("リターナブル区分2") = NormalizeString(Mid(line, 931, 1))
                    dr("ダイレクト包装記号3") = NormalizeString(Mid(line, 932, 1))
                    dr("リターナブル区分3") = NormalizeString(Mid(line, 933, 1))
                    dr("HNS") = NormalizeString(Mid(line, 934, 1))
                    dr("保税区分") = NormalizeString(Mid(line, 935, 3))
                    dr("エンジンASSY区分") = NormalizeString(Mid(line, 938, 1))
                    dr("部品特性3") = NormalizeString(Mid(line, 939, 1))
                    dr("部品特性4") = NormalizeString(Mid(line, 940, 1))
                    dr("部品特性5") = NormalizeString(Mid(line, 941, 1))
                    dr("部品特性6") = NormalizeString(Mid(line, 942, 1))
                    dr("原産国コード1") = NormalizeString(Mid(line, 943, 15))
                    dr("外産品区分1") = NormalizeString(Mid(line, 958, 11))
                    dr("部品特性10") = NormalizeString(Mid(line, 969, 1))
                    dr("FILLER3") = NormalizeString(Mid(line, 970, 1))
                    dr("DIST名称") = NormalizeString(Mid(line, 971, 30))
                    dr("基本部番ハイフン付") = NormalizeString(Mid(line, 1001, 18))
                    dr("設変部番ハイフン付") = NormalizeString(Mid(line, 1019, 23))
                    dr("部品特性フラブ") = NormalizeString(Mid(line, 1042, 1))
                    dr("部品属性4") = NormalizeString(Mid(line, 1043, 1))
                    dr("輸送手段") = NormalizeString(Mid(line, 1044, 4))
                    dr("実績有無区分") = NormalizeString(Mid(line, 1048, 1))
                    dr("実績数量") = NormalizeString(Mid(line, 1049, 7))
                    dr("種別NO") = NormalizeString(Mid(line, 1056, 9))
                    dr("原産国コード2") = NormalizeString(Mid(line, 1065, 3))
                    dr("外産品区分2") = NormalizeString(Mid(line, 1068, 11))
                    dr("モジュールコード") = NormalizeString(Mid(line, 1079, 1))
                    dr("ケースNO2") = NormalizeString(Mid(line, 1080, 5))
                    dr("転送日時") = NormalizeString(Mid(line, 1085, 34))
                    dr("FILLER4") = NormalizeString(Mid(line, 1119, 1))
                    dr("取込年月") = _nengetu
                    dr("見積No") = _mitsumori_no

                    '群の変換処理
                    Dim gun As String = ""
                    Dim last_moji As String = ""
                    Dim result As Integer

                    '代表DISTが157、321以外
                    If dr("代表DIST") <> "157" And dr("代表DIST") <> "321" Then

                        '60列目の部品群から=と@を除外した値を群としてセット
                        gun = dr("部品群").ToString.Replace("=", "").Replace("@", "")

                    Else '代表DISTが157、321の場合

                        '60列目の部品群から=と@を除外した値を群としてセット
                        gun = dr("部品群").ToString.Replace("=", "").Replace("@", "")

                        '先頭の3桁を取得
                        gun = gun.Substring(0, 3)
                        last_moji = gun.Substring(2, 1)

                        '3桁目が数値の場合は-2をする　0の場合はスルー
                        If Integer.TryParse(last_moji, result) Then

                            ' 数値の場合
                            If result = 0 Or result = 1 Then
                                '何もしない
                            Else
                                result = result - 2
                                gun = gun.Substring(0, 2) & result.ToString
                            End If

                        Else ' 数値ではない
                            '何もしない
                            result = 0
                        End If
                    End If

                    dr("群") = gun

                    dtBatch.Rows.Add(dr)
                    batchCount += 1

                    '規定値を超えたらインサート処理
                    If batchCount >= batchSize Then
                        bulk.WriteToServer(dtBatch)
                        dtBatch.Clear()
                        batchCount = 0
                    End If

                Next

                ' 残りのレコードを挿入
                If dtBatch.Rows.Count > 0 Then
                    bulk.WriteToServer(dtBatch)
                End If

            End Using 'SqlBulkCopy

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    '見積依頼用_CCCファイル取り込み処理
    Sub Import_CCC_Manual(_file_path As String, _nengetu As String, _mitsumori_no As Integer, conn As SqlConnection, tran As SqlTransaction)

        Try

            Dim dt_ccc As New DS_T.DT_T_CCC_ManualDataTable
            Dim batchSize As Integer = 5000
            Dim batchCount As Integer = 0

            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)

                bulk.DestinationTableName = "T_CCC_Manual"
                bulk.BatchSize = batchSize

                Dim dtBatch As DataTable = dt_ccc.Clone()

                ' Excel 読み込み
                Using wb As New XLWorkbook(_file_path)

                    Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                    Dim startRow As Integer = 8 ' データ開始行（ヘッダが1行目なら2）
                    Dim endRow As Integer = ws.Column(50).LastCellUsed().Address.RowNumber '50列のコントロールNoに値が入っている最終行を取得
                    Dim startCol As Integer = 1  ' A列
                    Dim endCol As Integer = 282   ' IP列
                    Dim currentRow As Integer = startRow

                    For r As Integer = startRow To endRow

                        Dim dr As DataRow = dtBatch.NewRow()

                        dr("工程管理ｼｽﾃﾑ日付") = ""
                        dr("処理ID") = ""
                        dr("包装指示1") = ""
                        dr("コンテンツ1") = ""
                        dr("パッケージコンテンツ1") = ""
                        dr("パッキングチェックシート1") = ""
                        dr("ケースマーク1") = ""
                        dr("部品管理エフ1") = ""
                        dr("包装指示2") = ""
                        dr("コンテンツ2") = ""
                        dr("パッケージコンテンツ2") = ""
                        dr("パッキングチェックシート2") = ""
                        dr("ケースマーク2") = ""
                        dr("部品管理エフ2") = ""
                        dr("包装指示3") = ""
                        dr("コンテンツ3") = ""
                        dr("パッケージコンテンツ3") = ""
                        dr("パッキングチェックシート3") = ""
                        dr("ケースマーク3") = ""
                        dr("部品管理エフ3") = ""
                        dr("包装指示4") = ""
                        dr("コンテンツ4") = ""
                        dr("パッケージコンテンツ4") = ""
                        dr("パッキングチェックシート4") = ""
                        dr("ケースマーク4") = ""
                        dr("部品管理エフ4") = ""
                        dr("予約1") = ""
                        dr("予約2") = ""
                        dr("予約3") = ""
                        dr("予約4") = ""
                        dr("予約5") = ""
                        dr("アイテムNO表示") = ""
                        dr("KD部番表示区分") = ""
                        dr("C_M重量表示要否") = ""
                        dr("A_Sフォーマット") = ""
                        dr("A_S日本表示形式") = ""
                        dr("A_S現地表示形式") = ""
                        dr("A_S輸出部品名称") = ""
                        dr("P_ﾘｽﾄ2ND記述") = ""
                        dr("包装資材表示要否") = ""
                        dr("オプション表示区分") = ""
                        dr("機種コード表示区分") = ""
                        dr("予約6") = ""
                        dr("原産国表示要否") = ""
                        dr("対応要否_10_2") = ""
                        dr("対応要否_5品目") = ""
                        dr("包装SS") = ""
                        dr("汎区分24") = ""
                        dr("PC_NO") = ""
                        dr("ｺﾝﾄﾛｰﾙNO") = ws.Cell(currentRow, 50).Value
                        dr("年度1") = ""
                        dr("モデル1") = ""
                        dr("モデフNO") = ""
                        dr("ケースNO1") = ws.Cell(currentRow, 54).Value
                        dr("レコードID") = ""
                        dr("バッチ処理エラーコード") = ""
                        dr("量産_枠外区分") = ""
                        dr("インボイスNO") = ""
                        dr("代表DIST") = ws.Cell(currentRow, 59).Value
                        dr("部品群") = ""
                        dr("包装ロットNO") = ""
                        dr("包装ロット連番") = ""
                        dr("現地工場コード") = ""
                        dr("現地ラインNO1") = ""
                        dr("年1") = ""
                        dr("月1") = ""
                        dr("連番1") = ""
                        dr("サフィックス") = ""
                        dr("K_Y_KD1") = ""
                        dr("年度2") = ws.Cell(currentRow, 70).Value
                        dr("モデル2") = ws.Cell(currentRow, 71).Value
                        dr("タイプ1") = ws.Cell(currentRow, 72).Value
                        dr("オプション1") = ws.Cell(currentRow, 73).Value
                        dr("外装HES1") = ""
                        dr("内装タイプ1") = ""
                        dr("K_Y_KD2") = ""
                        dr("年度3") = ""
                        dr("モデル3") = ""
                        dr("タイプ2") = ""
                        dr("群") = ""
                        dr("外装HES2") = ""
                        dr("内装タイプ2") = ""
                        dr("K_Y_KD3") = ""
                        dr("年度4") = ""
                        dr("モデル4") = ""
                        dr("タイプ3") = ""
                        dr("オプション2") = ""
                        dr("外装HES3") = ""
                        dr("内装タイプ3") = ""
                        dr("MIX区分") = ""
                        dr("代表区分1") = ""
                        dr("包装仕様有無区分") = ""
                        dr("包装場") = ""
                        dr("オーダー区分") = ""
                        dr("オーダー経歴NO") = ""
                        dr("配送先DIST") = ""
                        dr("オーダー元プラント") = ""
                        dr("現地ラインNO2") = ""
                        dr("モデル年度") = ""
                        dr("オーダー理由コード") = ""
                        dr("オーダー年月日SEQ") = ""
                        dr("シップメントNO") = ""
                        dr("基本生産計画区分") = ""
                        dr("計画年月") = ""
                        dr("計画改訂NO") = ""
                        dr("計画コード") = ""
                        dr("包装予定日") = ""
                        dr("計画確定区分") = ""
                        dr("SS") = ""
                        dr("本社製品区分") = ""
                        dr("年2") = ""
                        dr("月2") = ""
                        dr("連番2") = ""
                        dr("包装数量") = ws.Cell(currentRow, 114).Value
                        dr("個装ライン") = ""
                        dr("内装ライン") = ""
                        dr("包装ライン_外装") = ws.Cell(currentRow, 117).Value
                        dr("ケース順位") = ""
                        dr("包装ロット台数") = ""
                        dr("ケース保税区分") = ""
                        dr("ケースグロスL") = ""
                        dr("ケースグロスW") = ""
                        dr("ケースグロスH") = ""
                        dr("ケースグロス容量M3") = ""
                        dr("ケースネットL") = ""
                        dr("ケースネットW") = ""
                        dr("ケースネットH") = ""
                        dr("ケースネット容量M3") = ""
                        dr("ケースネット重量") = ""
                        dr("ケース重量計画値") = ws.Cell(currentRow, 130).Value
                        dr("ケース実績重量") = ""
                        dr("ケース重量測定要求") = ""
                        dr("初物部品ケースサイン") = ""
                        dr("エンジンASSYサイン") = ""
                        dr("K_Y_KD4") = ""
                        dr("年度5") = ""
                        dr("モデル5") = ""
                        dr("タイプ4") = ""
                        dr("オプション3") = ""
                        dr("外装HES4") = ""
                        dr("内装タイプ4") = ""
                        dr("エンジン入り数") = ""
                        dr("パッキングNO") = ""
                        dr("FILLER1") = ""
                        dr("オーダーアイテムNO") = ""
                        dr("ITEM") = ""
                        dr("基本部番") = ws.Cell(currentRow, 147).Value
                        dr("設変部番") = ""
                        dr("KD部番") = ""
                        dr("部品色") = ""
                        dr("輸出部品名称") = ws.Cell(currentRow, 151).Value
                        dr("第二外国語名称") = ""
                        dr("主管SS") = ""
                        dr("現地ロケーションNO") = ""
                        dr("部品単位重量") = ""
                        dr("個装資材記号") = ws.Cell(currentRow, 156).Value
                        dr("個装手順SEQ") = ""
                        dr("部品収容数") = ws.Cell(currentRow, 158).Value
                        dr("個装担当NO") = ""
                        dr("内装資材記号") = ws.Cell(currentRow, 160).Value
                        dr("内装手順SEQ") = ""
                        dr("内装NO") = ""
                        dr("個装入り数") = ws.Cell(currentRow, 163).Value
                        dr("内装担当NO") = ""
                        dr("外装資材記号") = ws.Cell(currentRow, 165).Value
                        dr("モジュール手順SEQ") = ""
                        dr("内装入り数") = ws.Cell(currentRow, 167).Value
                        dr("外装担当NO1") = ""
                        dr("外装担当NO2") = ""
                        dr("台当り使用個数") = ""
                        dr("包装指示数") = ""
                        dr("ケース個内装荷姿必要") = ""
                        dr("コンテンツ必要枚数") = ""
                        dr("要否区分") = ""
                        dr("品質チェック要否") = ""
                        dr("取引先NO") = ""
                        dr("搬入ホーム") = ""
                        dr("海事専用機種名称") = ""
                        dr("包装特性1") = ""
                        dr("包装特性2") = ""
                        dr("包装特性3") = ""
                        dr("包装特性4") = ""
                        dr("包装特性5") = ""
                        dr("FILLER2") = ""
                        dr("部品包装特性1") = ""
                        dr("部品包装特性2") = ""
                        dr("部品包装特性3") = ""
                        dr("部品包装特性4") = ""
                        dr("部品包装特性5") = ""
                        dr("内装総重量") = ""
                        dr("代表区分2") = ws.Cell(currentRow, 191).Value
                        dr("副資材1") = ws.Cell(currentRow, 192).Value
                        dr("必要数1") = ws.Cell(currentRow, 193).Value
                        dr("代表区分3") = ws.Cell(currentRow, 194).Value
                        dr("副資材2") = ws.Cell(currentRow, 195).Value
                        dr("必要数2") = ws.Cell(currentRow, 196).Value
                        dr("代表区分4") = ws.Cell(currentRow, 197).Value
                        dr("副資材3") = ws.Cell(currentRow, 198).Value
                        dr("必要数3") = ws.Cell(currentRow, 199).Value
                        dr("代表区分5") = ws.Cell(currentRow, 200).Value
                        dr("副資材4") = ws.Cell(currentRow, 201).Value
                        dr("必要数4") = ws.Cell(currentRow, 202).Value
                        dr("代表区分6") = ws.Cell(currentRow, 203).Value
                        dr("副資材5") = ws.Cell(currentRow, 204).Value
                        dr("必要数5") = ws.Cell(currentRow, 205).Value
                        dr("代表区分7") = ws.Cell(currentRow, 206).Value
                        dr("副資材6") = ws.Cell(currentRow, 207).Value
                        dr("必要数6") = ws.Cell(currentRow, 208).Value
                        dr("代表区分8") = ws.Cell(currentRow, 209).Value
                        dr("副資材7") = ws.Cell(currentRow, 210).Value
                        dr("必要数7") = ws.Cell(currentRow, 211).Value
                        dr("代表区分9") = ws.Cell(currentRow, 212).Value
                        dr("副資材8") = ws.Cell(currentRow, 213).Value
                        dr("必要数8") = ws.Cell(currentRow, 214).Value
                        dr("代表区分10") = ws.Cell(currentRow, 215).Value
                        dr("副資材9") = ws.Cell(currentRow, 216).Value
                        dr("必要数9") = ws.Cell(currentRow, 217).Value
                        dr("代表区分11") = ws.Cell(currentRow, 218).Value
                        dr("副資材10") = ws.Cell(currentRow, 219).Value
                        dr("必要数10") = ws.Cell(currentRow, 220).Value
                        dr("代表区分12") = ws.Cell(currentRow, 221).Value
                        dr("副資材11") = ws.Cell(currentRow, 222).Value
                        dr("必要数11") = ws.Cell(currentRow, 223).Value
                        dr("代表区分13") = ws.Cell(currentRow, 224).Value
                        dr("副資材12") = ws.Cell(currentRow, 225).Value
                        dr("必要数12") = ws.Cell(currentRow, 226).Value
                        dr("代表区分14") = ws.Cell(currentRow, 227).Value
                        dr("副資材13") = ws.Cell(currentRow, 228).Value
                        dr("必要数13") = ws.Cell(currentRow, 229).Value
                        dr("代表区分15") = ws.Cell(currentRow, 230).Value
                        dr("副資材14") = ws.Cell(currentRow, 231).Value
                        dr("必要数14") = ws.Cell(currentRow, 232).Value
                        dr("代表区分16") = ws.Cell(currentRow, 233).Value
                        dr("副資材15") = ws.Cell(currentRow, 234).Value
                        dr("必要数15") = ws.Cell(currentRow, 235).Value
                        dr("代表区分17") = ws.Cell(currentRow, 236).Value
                        dr("副資材16") = ws.Cell(currentRow, 237).Value
                        dr("必要数16") = ws.Cell(currentRow, 238).Value
                        dr("代表区分18") = ws.Cell(currentRow, 239).Value
                        dr("副資材17") = ws.Cell(currentRow, 240).Value
                        dr("必要数17") = ws.Cell(currentRow, 241).Value
                        dr("代表区分19") = ws.Cell(currentRow, 242).Value
                        dr("副資材18") = ws.Cell(currentRow, 243).Value
                        dr("必要数18") = ws.Cell(currentRow, 244).Value
                        dr("代表区分20") = ws.Cell(currentRow, 245).Value
                        dr("副資材19") = ws.Cell(currentRow, 246).Value
                        dr("必要数19") = ws.Cell(currentRow, 247).Value
                        dr("代表区分21") = ws.Cell(currentRow, 248).Value
                        dr("副資材20") = ws.Cell(currentRow, 249).Value
                        dr("必要数20") = ws.Cell(currentRow, 250).Value
                        dr("ダイレクト包装記号1") = ""
                        dr("リターナブル区分1") = ""
                        dr("ダイレクト包装記号2") = ""
                        dr("リターナブル区分2") = ""
                        dr("ダイレクト包装記号3") = ""
                        dr("リターナブル区分3") = ""
                        dr("HNS") = ""
                        dr("保税区分") = ""
                        dr("エンジンASSY区分") = ""
                        dr("部品特性3") = ""
                        dr("部品特性4") = ""
                        dr("部品特性5") = ""
                        dr("部品特性6") = ""
                        dr("原産国コード1") = ""
                        dr("外産品区分1") = ""
                        dr("部品特性10") = ""
                        dr("FILLER3") = ""
                        dr("DIST名称") = ""
                        dr("基本部番ハイフン付") = ""
                        dr("設変部番ハイフン付") = ""
                        dr("部品特性フラブ") = ""
                        dr("部品属性4") = ""
                        dr("輸送手段") = ""
                        dr("実績有無区分") = ""
                        dr("実績数量") = ""
                        dr("種別NO") = ""
                        dr("原産国コード2") = ""
                        dr("外産品区分2") = ""
                        dr("モジュールコード") = ""
                        dr("ケースNO2") = ""
                        dr("転送日時") = ""
                        dr("FILLER4") = ""
                        dr("取込年月") = _nengetu
                        dr("見積No") = _mitsumori_no

                        dtBatch.Rows.Add(dr)
                        batchCount += 1

                        '規定値を超えたらインサート処理
                        If batchCount >= batchSize Then
                            bulk.WriteToServer(dtBatch)
                            dtBatch.Clear()
                            batchCount = 0
                        End If

                    Next

                    ' 残りのレコードを挿入
                    If dtBatch.Rows.Count > 0 Then
                        bulk.WriteToServer(dtBatch)
                    End If

                End Using

            End Using 'SqlBulkCopy

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'KOW46ファイル取り込み処理
    Sub Import_KOW46(_file_path As String, _nengetu As String, _mitsumori_no As Integer, conn As SqlConnection, tran As SqlTransaction)

        Try
            Dim dt_kow As New DS_T.DT_T_KOW46DataTable

            Dim batchSize As Integer = 5000
            Dim batchCount As Integer = 0
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)

                bulk.DestinationTableName = "T_KOW46"
                bulk.BatchSize = batchSize

                Dim dtBatch As DataTable = dt_kow.Clone()

                For Each line As String In File.ReadLines(_file_path, Encoding.Default)

                    If String.IsNullOrWhiteSpace(line) Then
                        Continue For
                    End If

                    Dim dr As DataRow = dtBatch.NewRow()
                    dr("包装ロットNo") = NormalizeString(Mid(line, 71, 12))
                    dr("MUDULE") = NormalizeString(Mid(line, 83, 4))
                    dr("本C_No") = NormalizeString(Mid(line, 95, 4))
                    dr("内装手順") = Mid(line, 109, 3).Trim
                    dr("手順識別") = Mid(line, 117, 4).Trim
                    dr("資材規格") = NormalizeString(Mid(line, 121, 5))
                    dr("使用数") = NormalizeString(Mid(line, 127, 7))
                    dr("主資材") = NormalizeString(Mid(line, 134, 1))
                    dr("その他1") = NormalizeString(Mid(line, 18, 4))
                    dr("その他2") = dr("包装ロットNo") & dr("MUDULE") & dr("本C_No") & dr("内装手順") & dr("資材規格")
                    dr("年度") = ""
                    dr("モデル") = ""
                    dr("タイプ") = ""
                    dr("オプション") = ""
                    dr("資材単価表示") = ""
                    dr("資材費") = ""
                    dr("ケース当たりの内装資材費") = ""
                    dr("ケース当たりの外装資材費") = ""
                    dr("内装入数_カートン数") = ""
                    dr("ケース内必要資材数") = ""
                    dr("取込年月") = _nengetu
                    dr("見積No") = _mitsumori_no

                    dtBatch.Rows.Add(dr)
                    batchCount += 1

                    '規定値を超えたらインサート処理
                    If batchCount >= batchSize Then
                        bulk.WriteToServer(dtBatch)
                        dtBatch.Clear()
                        batchCount = 0
                    End If

                Next

                ' 残りのレコードを挿入
                If dtBatch.Rows.Count > 0 Then
                    bulk.WriteToServer(dtBatch)
                End If

            End Using 'SqlBulkCopy

            'その他２の値のレコードカウントを取得してその他１を更新する
            Dim sql As String = "WITH CountCTE AS (
                                                        SELECT その他2,COUNT(*) AS cnt
                                                        FROM T_KOW46
                                                        GROUP BY その他2
                                                    )
                                                    UPDATE t
                                                    SET t.その他1 = c.cnt
                                                    FROM T_KOW46 t
                                                    INNER JOIN CountCTE c
                                                        ON t.その他2 = c.その他2;"
            'SQL実行
            Using cmd As New SqlClient.SqlCommand(sql, conn, tran)
                cmd.ExecuteNonQuery()
            End Using


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'KIT60ファイル取り込み処理
    Sub Import_KIT60(_file_path As String, _nengetu As String, _mitsumori_no As Integer, conn As SqlConnection, tran As SqlTransaction)

        Try

            ' 1. Excel から読み込み
            Dim dt_kit As New DS_T.DT_T_KIT60DataTable
            Using workbook As New XLWorkbook(_file_path)
                Dim ws = workbook.Worksheet(1) ' 1枚目のシート
                Dim firstRow As Boolean = True
                Dim count As Integer = 0

                For Each row In ws.RowsUsed()
                    If firstRow Then

                        If count <= 2 Then
                            count = count + 1
                        Else
                            firstRow = False
                        End If

                    Else

                        ' データ行を追加
                        Dim dr = dt_kit.NewRow()
                        Dim i As Integer = 1


                        For Each cell In row.Cells(2, 47)
                            dr(i) = cell.Value
                            i += 1
                        Next

                        '最後に取込年月をセット
                        dr("取込年月") = _nengetu
                        dr("見積No") = _mitsumori_no
                        dr("材料費") = row.Cell(54).Value

                        dt_kit.Rows.Add(dr)
                    End If

                Next

            End Using

            'DBへインサート
            Dim batchSize As Integer = 5000
            Dim batchCount As Integer = 0

            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)

                bulk.DestinationTableName = "T_KIT60"
                bulk.BatchSize = batchSize

                Dim dtBatch As DataTable = dt_kit.Clone()

                For Each row In dt_kit.Rows

                    dtBatch.ImportRow(row)
                    batchCount += 1

                    '規定値を超えたらインサート処理
                    If batchCount >= batchSize Then
                        bulk.WriteToServer(dtBatch)
                        dtBatch.Clear()
                        batchCount = 0
                    End If

                Next

                ' 残りのレコードを挿入
                If dtBatch.Rows.Count > 0 Then
                    bulk.WriteToServer(dtBatch)
                End If

            End Using 'SqlBulkCopy

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    '業務ファイル取り込み処理
    Sub Import_Gyoumu(_file_path As String, _nengetu As String, _mitsumori_no As Integer, conn As SqlConnection, tran As SqlTransaction)

        Try

            ' 1. Excel から読み込み
            Dim dt_gyoumu As New DS_T.DT_T_Gyomu_PlanDataTable

            Using workbook As New XLWorkbook(_file_path)

                Dim ws = workbook.Worksheet(1) ' 1枚目のシート
                Dim firstRow As Boolean = True
                Dim count As Integer = 0

                For Each row In ws.RowsUsed()
                    If firstRow Then

                        If count <= 2 Then
                            count = count + 1
                        Else
                            firstRow = False
                        End If

                    Else

                        ' データ行を追加
                        Dim dr = dt_gyoumu.NewRow()
                        Dim i As Integer = 1

                        For Each cell In row.Cells(2, 78)
                            dr(i) = cell.Value
                            i += 1
                        Next

                        '最後に取込年月をセット
                        dr("取込年月") = _nengetu
                        dr("見積No") = _mitsumori_no

                        dt_gyoumu.Rows.Add(dr)
                    End If
                Next
            End Using

            'DBへインサート
            Dim batchSize As Integer = 5000
            Dim batchCount As Integer = 0

            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)

                bulk.DestinationTableName = "T_Gyomu_Plan"
                bulk.BatchSize = batchSize

                Dim dtBatch As DataTable = dt_gyoumu.Clone()

                For Each row In dt_gyoumu.Rows

                    dtBatch.ImportRow(row)
                    batchCount += 1

                    '規定値を超えたらインサート処理
                    If batchCount >= batchSize Then
                        bulk.WriteToServer(dtBatch)
                        dtBatch.Clear()
                        batchCount = 0
                    End If

                Next

                ' 残りのレコードを挿入
                If dtBatch.Rows.Count > 0 Then
                    bulk.WriteToServer(dtBatch)
                End If

            End Using 'SqlBulkCopy

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    '部品オーダーリストファイル取り込み処理
    Sub Import_Order(_file_path As String, _nengetu As String, _mitsumori_no As Integer, conn As SqlConnection, tran As SqlTransaction)

        Try

            ' 1. Excel から読み込み
            Dim dt_gyoumu As New DS_T.DT_T_Buhin_Order_ListDataTable

            Using workbook As New XLWorkbook(_file_path)

                Dim ws = workbook.Worksheet(1) ' 1枚目のシート
                Dim firstRow As Boolean = True
                Dim count As Integer = 0

                For Each row In ws.RowsUsed()

                    If firstRow Then

                        If count <> 1 Then
                            count = count + 1
                        Else
                            firstRow = False
                        End If

                    Else

                        ' データ行を追加
                        Dim dr = dt_gyoumu.NewRow()
                        Dim i As Integer = 1

                        For Each cell In row.Cells(1, 53)

                            '数量列の場合
                            If i = 21 Or i = 23 Or i = 25 Or i = 27 Or i = 29 Or i = 31 Or i = 33 Or i = 35 Or i = 37 _
                                 Or i = 39 Or i = 41 Or i = 43 Or i = 45 Or i = 47 Or i = 49 Or i = 51 Then

                                '値無しの場合は0をセットする
                                If cell.GetValue(Of String)() = "" Then
                                    dr(i) = 0
                                Else
                                    dr(i) = cell.GetValue(Of Integer)()
                                End If

                            Else 'その他はそのまま
                                dr(i) = cell.GetValue(Of String)()
                            End If

                            i += 1
                        Next

                        '最後に取込年月をセット
                        dr("取込年月") = _nengetu
                        dr("見積No") = _mitsumori_no

                        dt_gyoumu.Rows.Add(dr)

                    End If

                Next

            End Using

            'DBへインサート
            Dim batchSize As Integer = 5000
            Dim batchCount As Integer = 0

            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)

                bulk.DestinationTableName = "T_Buhin_Order_List"
                bulk.BatchSize = batchSize

                Dim dtBatch As DataTable = dt_gyoumu.Clone()

                For Each row In dt_gyoumu.Rows

                    dtBatch.ImportRow(row)
                    batchCount += 1

                    '規定値を超えたらインサート処理
                    If batchCount >= batchSize Then
                        bulk.WriteToServer(dtBatch)
                        dtBatch.Clear()
                        batchCount = 0
                    End If

                Next

                ' 残りのレコードを挿入
                If dtBatch.Rows.Count > 0 Then
                    bulk.WriteToServer(dtBatch)
                End If

            End Using 'SqlBulkCopy

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    '空白と先頭の0を外す処理
    Public Function NormalizeString(ByVal input As String) As String

        If input Is Nothing Then
            Return String.Empty
        End If

        ' 前後の空白を除去
        Dim trimmed As String = input.Trim()

        ' 数値のみか判定（負号・小数点なしの整数想定）
        If System.Text.RegularExpressions.Regex.IsMatch(trimmed, "^\d+$") Then

            ' 数値変換して戻す（0パディング除去）
            Return CLng(trimmed).ToString()

        Else
            Return trimmed
        End If

    End Function

    '見積No取得
    Public Function Get_No(conn As SqlConnection, tran As SqlTransaction, ByRef _mitsumori_no_old As Integer) As Integer

        Try

            Dim dt_bangou As New DS_M.DT_M_BangouDataTable
            Dim mitsumori_no As Integer = 0

            'SQL作成
            Dim CommandString As String

            CommandString = "SELECT * FROM M_Bangou"

            'トランザクションを引き継いでSQL実行
            Using cmd As New SqlClient.SqlCommand(CommandString, conn, tran)
                Using adapter As New SqlClient.SqlDataAdapter(cmd)
                    adapter.Fill(dt_bangou)
                End Using
            End Using

            mitsumori_no = dt_bangou.Rows(0)(0)
            _mitsumori_no_old = mitsumori_no - 1

            '即更新
            Dim updateSql As String =
            "UPDATE M_Bangou SET 見積No = @NewNo"

            Using cmd As New SqlClient.SqlCommand(updateSql, conn, tran)
                cmd.Parameters.AddWithValue("@NewNo", mitsumori_no + 1)
                cmd.ExecuteNonQuery()
            End Using

            Return mitsumori_no

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '過去のトランコピー処理
    Private Sub Copy_Tran(conn As SqlConnection, tran As SqlTransaction, _from As String, _mitsumori_no_old As Integer, _mitumori_no_new As Integer)

        Try

            '1. コピー元データを取得
            Dim dt
            If _from = "T_CCC" Then
                dt = New DS_T.DT_T_CCCDataTable
            ElseIf _from = "T_KOW46" Then
                dt = New DS_T.DT_T_KOW46DataTable
            ElseIf _from = "T_KIT60" Then
                dt = New DS_T.DT_T_KIT60DataTable
            ElseIf _from = "T_Gyomu_Plan" Then
                dt = New DS_T.DT_T_Gyomu_PlanDataTable
            ElseIf _from = "T_Buhin_Order_List" Then
                dt = New DS_T.DT_T_Buhin_Order_ListDataTable
            End If

            Dim selectSql As String = "SELECT * FROM " & _from & " WHERE 見積No = " & _mitsumori_no_old

            'トランザクションを引き継いでSQL実行
            Using cmd As New SqlClient.SqlCommand(selectSql, conn, tran)
                Using adapter As New SqlClient.SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            'コピー用に見積Noを書き換え
            For Each row As DataRow In dt.Rows
                row("見積No") = _mitumori_no_new
            Next

            'インサート処理実行
            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)
                bulk.DestinationTableName = _from
                bulk.WriteToServer(dt)
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'インポート履歴の登録
    Sub Import_Rireki(conn As SqlConnection, tran As SqlTransaction, _mitumori_no As Integer, _nengestu As String)

        Try

            Dim insert_sql As String =
                "INSERT INTO T_Import_Rireki (見積No, 取込年月, 取込日時, ユーザーid, 変換フラグ,モード区分) " &
                "VALUES (@見積No, @取込年月, @取込日時, @ユーザーid, @変換フラグ,@モード区分)"

            Using cmd As New SqlClient.SqlCommand(insert_sql, conn, tran)

                ' パラメータ設定
                cmd.Parameters.AddWithValue("@見積No", _mitumori_no)
                cmd.Parameters.AddWithValue("@取込年月", _nengestu)
                cmd.Parameters.AddWithValue("@取込日時", Now.ToString("yyyy/MM/dd HH:mm:ss"))
                cmd.Parameters.AddWithValue("@ユーザーid", "")
                cmd.Parameters.AddWithValue("@変換フラグ", "0")
                cmd.Parameters.AddWithValue("@モード区分", _mode)

                ' 実行
                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'ファイルバックアップ
    Sub File_Move(_targetFolder As String, _files As String())

        Try

            ' 日付フォルダ作成（例：BK\20251112）
            Dim backupFolder As String = Path.Combine(_targetFolder, "BK", DateTime.Now.ToString("yyyyMMddHHmmss"))
            If Not Directory.Exists(backupFolder) Then
                Directory.CreateDirectory(backupFolder)
            End If

            ' ファイルを移動
            For Each filePath In _files

                ' ファイル名だけ取得
                Dim fileName As String = Path.GetFileName(filePath)

                ' 移動先パス
                Dim destPath As String = Path.Combine(backupFolder, fileName)

                If fileName.Contains("CCC") Or fileName.Contains("KOW46") Or fileName.Contains("KIT60") Or fileName.Contains("業務量") Or fileName.Contains("部品単位") Then

                    ' ファイル移動
                    File.Move(filePath, destPath)

                End If

            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class