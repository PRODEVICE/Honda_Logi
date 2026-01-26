Imports System.Configuration
Imports System.IO

Public Class F_Keisu

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Keisu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'DS_M.DT_M_Keisu' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Keisu.Fill(Me.DS_M.DT_M_Keisu)

    End Sub

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    '検索ボタンクリック時
    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click

        Try

            'コンフィグのコネクトストリング取得
            Dim con As New SqlClient.SqlConnection
            con.ConnectionString = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            'SQL作成
            Dim CommandString As String

            CommandString = MakeSQL_Search()

            'GVをクリア
            GV_Master.DataSource = Nothing

            'テーブルアダプター作成
            Dim DataAdapter As New SqlClient.SqlDataAdapter(CommandString, con)

            'SQLを実行
            Me.DS_M.DT_M_Keisu.Clear()
            DataAdapter.Fill(Me.DS_M.DT_M_Keisu)
            GV_Master.DataSource = Me.DS_M.DT_M_Keisu

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

            '入力項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Keisu_Btn_Search_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_keisu As New DS_MTableAdapters.TA_M_Keisu

            Dim kishu As String = Txt_Kishu.Text.Trim
            Dim gun As String = Txt_Gun.Text.Trim
            Dim keisu As String = Txt_Keisu.Text.Trim
            Dim shimuke As String = Txt_Shimuke.Text.Trim
            Dim id As String = Txt_id.Text.Trim
            Dim qty As Decimal

            '入力チェック
            If kishu = "" Or gun = "" Or keisu = "" Or shimuke = "" Then
                MessageBox.Show("全項目入力してください")
                Exit Sub
            End If

            If Not Decimal.TryParse(keisu, qty) Then
                MessageBox.Show("係数は数値で入力してください。")
                Exit Sub
            End If

            Dim chk_count As String = ""

            '新規モード
            If Btn_Touroku.Text = "登　録" Then

                '存在チェック
                chk_count = ta_keisu.Q_存在チェック(kishu, shimuke, gun)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの機種、タイプです。")
                    Exit Sub
                End If

                '登録処理
                ta_keisu.Q_係数登録(kishu, keisu, shimuke, gun)

            Else '更新モード

                '存在チェック
                chk_count = ta_keisu.Q_更新存在チェック(id, kishu, shimuke, gun)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの機種、タイプです。")
                    Exit Sub
                End If

                ta_keisu.Q_係数更新(kishu, keisu, shimuke, gun, id)

            End If

            'GV更新
            ta_keisu.Fill(Me.DS_M.DT_M_Keisu)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Keisu_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'クリアボタンクリック時
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click

        Try
            clear()
        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Keisu_Btn_Clear_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'CSV取込ボタンクリック時
    Private Sub Btn_Import_Click(sender As Object, e As EventArgs) Handles Btn_Import.Click

        Try

            Dim dt_From As New DS_M.DT_M_KeisuDataTable
            Dim ta As New DS_MTableAdapters.TA_M_Keisu
            Dim target_file As String = ""

            '取込ファイル選択ダイアログ
            Using ofd As New OpenFileDialog()

                'ダイアログのタイトル
                ofd.Title = "ファイルを指定してください"

                '初期フォルダ（テキストボックスにパスがある場合はそこを開く）
                ofd.InitialDirectory = "C:\"

                '選択できるファイルの種類（必要に応じて調整）
                ofd.Filter = "すべてのファイル (*.*)|*.*"

                '複数選択を許可する場合
                ofd.Multiselect = False

                'OKが押されたらファイルパスをテキストボックスに表示
                If ofd.ShowDialog(Me) = DialogResult.OK Then
                    target_file = ofd.FileName
                End If

            End Using

            If target_file = "" Then
                Exit Sub
            End If

            'CSVの取込
            dt_From = Import_CSV(target_file)

            'トランザクションの始まり
            Using scope As New System.Transactions.TransactionScope()

                '全件削除
                ta.Q_全件削除()

                '新規インサート
                ta.Update(dt_From)

                'コミット処理
                scope.Complete()

                'トランザクション終了
                scope.Dispose()

            End Using

            MessageBox.Show("取込完了しました。")

            'GV更新
            Me.TA_M_Keisu.Fill(Me.DS_M.DT_M_Keisu)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Keisu_Btn_Import_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'CSV出力ボタンクリック
    Private Sub Btn_Output_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DS_M.DT_M_KeisuDataTable
            Dim ta As New DS_MTableAdapters.TA_M_Keisu

            ta.Fill(dt)

            Dim out_path As String = MakeOutPath()

            If out_path = "" Then
                Exit Sub
            End If

            ConvertDataTableToCsv(dt, out_path, True)

            MessageBox.Show("ファイルの出力が完了しました。", "ファイル出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Keisu_Btn_Output_Click")
            MessageBox.Show(ex.Message)

        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    '******************************************************************************
    'GVイベント
    '******************************************************************************

    'リンクボタンがクリックされたら
    Private Sub GV_Master_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Master.CellContentClick

        Try

            Dim ta_keisu As New DS_MTableAdapters.TA_M_Keisu

            'ヘッダークリックは無視
            If e.RowIndex < 0 Then
                Return
            End If

            Dim grid As DataGridView = CType(sender, DataGridView)

            '対象ID取得
            Dim target_id As String = grid.Rows(e.RowIndex).Cells("ID").Value.ToString()

            '選択ボタン
            If grid.Columns(e.ColumnIndex).Name = "選択" Then

                Txt_id.Text = target_id

                Txt_Kishu.Text = grid.Rows(e.RowIndex).Cells("機種").Value.ToString()
                Txt_Gun.Text = grid.Rows(e.RowIndex).Cells("群").Value.ToString()
                Txt_Shimuke.Text = grid.Rows(e.RowIndex).Cells("仕向").Value.ToString()
                Txt_Keisu.Text = grid.Rows(e.RowIndex).Cells("係数").Value.ToString()

                Btn_Touroku.Text = "更　新"

            End If

            '削除ボタン
            If grid.Columns(e.ColumnIndex).Name = "削除" Then

                If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'データソースから削除
                    grid.Rows.RemoveAt(e.RowIndex)

                    'DBからも削除
                    ta_keisu.Q_係数削除(target_id)

                    MessageBox.Show("削除完了しました。")

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Keisu_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    '関数
    '******************************************************************************

    Function MakeSQL_Search() As String

        Try

            Dim kishu As String = Txt_S_Kishu.Text.Trim
            Dim gun As String = Txt_S_Gun.Text.Trim
            Dim shimuke As String = Txt_S_Shimuke.Text.Trim

            Dim Retstr As String = Nothing
            Dim strtemp As String = Nothing

            'Where区作成区作成

            '機種
            If (kishu.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "機種 like '%" & kishu & "%'"
                Else
                    strtemp = strtemp & " AND 機種 like '%" & kishu & "%'"
                End If
            End If

            'タイプ
            If (gun.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "群 like '%" & gun & "%'"
                Else
                    strtemp = strtemp & " AND 群 like '%" & gun & "%'"
                End If
            End If

            '仕向
            If (shimuke.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "仕向 like '%" & shimuke & "%'"
                Else
                    strtemp = strtemp & " AND 仕向 like '%" & shimuke & "%'"
                End If
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM M_Keisu "
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    '画面項目クリア処理
    Sub clear()

        Txt_id.Text = ""
        Txt_Kishu.Text = ""
        Txt_Gun.Text = ""
        Txt_Keisu.Text = ""
        Txt_Shimuke.Text = ""

        Btn_Touroku.Text = "登　録"

    End Sub

    'CSVファイル取り込み処理
    Function Import_CSV(_file_path As String) As DataTable

        Dim dt As New DS_M.DT_M_KeisuDataTable

        Try

            Using sr As New StreamReader(_file_path, System.Text.Encoding.Default) ' Shift-JIS等も自動判別されやすい
                Dim isFirstLine As Boolean = True

                While Not sr.EndOfStream
                    Dim line As String = sr.ReadLine()

                    ' CSV の1行をパース（ダブルクォート対応）
                    Dim fields As String() = ParseCsvLine(line)

                    ' 最初の行はヘッダー
                    If isFirstLine Then

                        isFirstLine = False

                    Else

                        ' DataRow を作成
                        Dim dr As DataRow = dt.NewDT_M_KeisuRow()

                        'CSV の各フィールドを id 以外の列に順にセット
                        For i As Integer = 0 To fields.Length - 1
                            dr(i + 1) = fields(i) ' ← +1 で id をスキップ
                        Next

                        dt.Rows.Add(dr)

                    End If

                End While

            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ParseCsvLine(line As String) As String()
        Dim result As New List(Of String)()
        Dim current As String = ""
        Dim inQuotes As Boolean = False

        For i As Integer = 0 To line.Length - 1
            Dim c As Char = line(i)

            If c = """"c Then
                ' ダブルクォートの開始/終了
                inQuotes = Not inQuotes
            ElseIf c = ","c AndAlso Not inQuotes Then
                ' カンマ区切り（クォート外のみ）
                result.Add(current)
                current = ""
            Else
                current &= c
            End If
        Next

        result.Add(current)
        Return result.ToArray()
    End Function


#Region "CSV作成処理"

    '保存先選択ダイアログ
    Function MakeOutPath() As String
        MakeOutPath = ""
        Try
            'SaveFileDialogクラスのインスタンスを作成
            Dim sfd As New SaveFileDialog()
            'はじめのファイル名を指定する
            'はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = "係数マスタ" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            'はじめに表示されるフォルダを指定する
            '指定しない（空の文字列）の時は、現在のディレクトリが表示される
            'sfd.InitialDirectory = "C:\"
            '[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
            '[ファイルの種類]ではじめに選択されるものを指定する
            '2番目の「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 1
            'タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください"
            'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = True
            '既に存在するファイル名を指定したとき警告する
            'デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = True
            '存在しないパスが指定されたとき警告を表示する
            'デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = True
            'ダイアログを表示する
            If sfd.ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき、選択されたファイル名をリターン
                Return sfd.FileName
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    'DTをCSVデータに変換
    Public Sub ConvertDataTableToCsv(
dt As DataTable, csvPath As String, writeHeader As Boolean)
        'CSVファイルに書き込むときに使うEncoding
        Dim enc As System.Text.Encoding =
            System.Text.Encoding.GetEncoding("Shift_JIS")
        '書き込むファイルを開く
        Dim sr As New System.IO.StreamWriter(csvPath, False, enc)
        Dim colCount As Integer = dt.Columns.Count
        Dim lastColIndex As Integer = colCount - 1
        Dim i As Integer
        'ヘッダを書き込む
        If writeHeader Then
            For i = 1 To colCount - 1
                'ヘッダの取得
                Dim field As String = dt.Columns(i).Caption
                '"で囲む
                field = EncloseDoubleQuotesIfNeed(field)
                'フィールドを書き込む
                sr.Write(field)
                'カンマを書き込む
                If lastColIndex > i Then
                    sr.Write(","c)
                End If
            Next
            '改行する
            sr.Write(vbCrLf)
        End If
        'レコードを書き込む
        Dim row As DataRow
        For Each row In dt.Rows
            For i = 1 To colCount - 1
                'フィールドの取得
                Dim field As String = row(i).ToString()
                '"で囲む
                field = EncloseDoubleQuotesIfNeed(field)
                'フィールドを書き込む
                sr.Write(field)
                'カンマを書き込む
                If lastColIndex > i Then
                    sr.Write(","c)
                End If
            Next
            '改行する
            sr.Write(vbCrLf)
        Next
        '閉じる
        sr.Close()
    End Sub

    Private Function EncloseDoubleQuotesIfNeed(field As String) As String
        If NeedEncloseDoubleQuotes(field) Then
            Return EncloseDoubleQuotes(field)
        End If
        Return field
    End Function

    Private Function NeedEncloseDoubleQuotes(field As String) As Boolean
        Return field.IndexOf(""""c) > -1 OrElse
            field.IndexOf(","c) > -1 OrElse
            field.IndexOf(ControlChars.Cr) > -1 OrElse
            field.IndexOf(ControlChars.Lf) > -1 OrElse
            field.StartsWith(" ") OrElse
            field.StartsWith(vbTab) OrElse
            field.EndsWith(" ") OrElse
            field.EndsWith(vbTab)
    End Function

    Private Function EncloseDoubleQuotes(field As String) As String
        If field.IndexOf(""""c) > -1 Then
            '"を""とする
            field = field.Replace("""", """""")
        End If
        Return """" & field & """"
    End Function

#End Region
End Class