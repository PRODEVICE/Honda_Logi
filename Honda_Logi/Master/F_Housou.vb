Imports System.Configuration
Imports System.IO
Imports System.Text

Public Class F_Housou

    Dim fnc As Function_Class

    'ページロード時
    Private Sub F_Housou_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'TODO: このコード行はデータを 'DS_M.DT_M_Kubun' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            Me.TA_M_Kubun.Fill(Me.DS_M.DT_M_Kubun)

            'TODO: このコード行はデータを 'DS_M.DT_M_Housou_Kbn' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            Me.TA_M_Housou_Kbn.Fill(Me.DS_M.DT_M_Housou_Kbn)

            fnc = New Function_Class

            'ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Housou_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_housou As New DS_MTableAdapters.TA_M_Housou_Kbn

            Dim line As String = Cmb_Line.Text
            Dim DIST As String = Txt_DIST.Text.Trim
            Dim housou_kbn As String = Cmb_Housou_Kbn.Text
            Dim kbn As String = Cmb_Kubun.Text
            Dim teiryou As String = Cmb_Teiryou.Text
            Dim id As String = Txt_id.Text.Trim

            '入力チェック
            If DIST = "" Then

                MessageBox.Show("DISTを入力してください")
                Exit Sub

            End If

            Dim chk_count As String = ""

            '新規モード
            If Btn_Touroku.Text = "登　録" Then

                '存在チェック
                chk_count = ta_housou.Q_存在チェック(DIST, housou_kbn)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みのDIST、個装内装の組み合わせです。")
                    Exit Sub
                End If

                '登録処理
                ta_housou.Q_包装登録(line, DIST, housou_kbn, kbn, teiryou)

            Else '更新モード

                '存在チェック
                chk_count = ta_housou.Q_更新存在チェック(DIST, housou_kbn, id)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みのDIST、個装内装の組み合わせです。")
                    Exit Sub
                End If

                ta_housou.Q_包装更新(line, DIST, housou_kbn, kbn, teiryou, id)

            End If

            'GV更新
            Me.TA_M_Housou_Kbn.Fill(Me.DS_M.DT_M_Housou_Kbn)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Housou_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

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
            Me.DS_M.DT_M_Mitsumori.Clear()
            DataAdapter.Fill(Me.DS_M.DT_M_Mitsumori)
            GV_Master.DataSource = Me.DS_M.DT_M_Mitsumori

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

            '入力項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Housou_Btn_Search_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'クリアボタンクリック時
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        clear()
    End Sub

    'CSV取込ボタンクリック時
    Private Sub Btn_Import_Click(sender As Object, e As EventArgs) Handles Btn_Import.Click

        Try

            Dim dt_From As New DS_M.DT_M_Housou_KbnDataTable
            Dim ta As New DS_MTableAdapters.TA_M_Housou_Kbn
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
            Me.TA_M_Housou_Kbn.Fill(Me.DS_M.DT_M_Housou_Kbn)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Housou_Btn_Import_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'CSV出力ボタンクリック
    Private Sub Btn_Output_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DS_M.DT_M_Housou_KbnDataTable
            Dim ta As New DS_MTableAdapters.TA_M_Housou_Kbn

            ta.Fill(dt)

            Dim out_path As String = MakeOutPath()

            If out_path = "" Then
                Exit Sub
            End If

            ConvertDataTableToCsv(dt, out_path, True)

            MessageBox.Show("ファイルの出力が完了しました。", "ファイル出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Housou_Btn_Output_Click")
            MessageBox.Show(ex.Message)

        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    'CSVファイル取り込み処理
    Function Import_CSV(_file_path As String) As DataTable

        Dim dt As New DS_M.DT_M_Housou_KbnDataTable

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
                        Dim dr As DataRow = dt.NewDT_M_Housou_KbnRow()

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

    '******************************************************************************
    'GVイベント
    '******************************************************************************

    'リンクボタンがクリックされたら
    Private Sub GV_Master_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Master.CellContentClick

        Try

            Dim ta_housou As New DS_MTableAdapters.TA_M_Housou_Kbn

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

                Txt_DIST.Text = grid.Rows(e.RowIndex).Cells("DIST").Value.ToString()
                Cmb_Line.SelectedValue = grid.Rows(e.RowIndex).Cells("ライン").Value.ToString()
                Cmb_Housou_Kbn.SelectedValue = grid.Rows(e.RowIndex).Cells("個装内装区分").Value.ToString()
                Cmb_Kubun.SelectedValue = grid.Rows(e.RowIndex).Cells("区分").Value.ToString()
                Cmb_Teiryou.SelectedValue = grid.Rows(e.RowIndex).Cells("定量_不定量").Value.ToString()

                Btn_Touroku.Text = "更　新"

            End If

            '削除ボタン
            If grid.Columns(e.ColumnIndex).Name = "削除" Then

                If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'データソースから削除
                    grid.Rows.RemoveAt(e.RowIndex)

                    'DBからも削除
                    ta_housou.Q_包装削除(target_id)

                    MessageBox.Show("削除完了しました。")

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Housou_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    '関数
    '******************************************************************************

    '画面項目クリア処理
    Sub clear()

        Txt_id.Text = ""
        Cmb_Line.SelectedIndex = 0
        Txt_DIST.Text = ""
        'Cmb_Housou_Kbn.SelectedIndex = 0

        Btn_Touroku.Text = "登　録"

    End Sub

    Function MakeSQL_Search() As String

        Try

            Dim line As String = Txt_S_Line.Text.Trim
            Dim DIST As String = Txt_S_DIST.Text.Trim
            Dim housou_kbn As String = Cmb_S_Housou_Kbn.Text
            Dim kbn As String = Cmb_S_Kubun.Text
            Dim teiryou As String = Cmb_S_Teiryou.Text

            Dim Retstr As String = Nothing
            Dim strtemp As String = Nothing

            'Where区作成

            'ライン
            If (line.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "ライン like '%" & line & "%'"
                Else
                    strtemp = strtemp & " AND ライン like '%" & line & "%'"
                End If
            End If

            'DIST
            If (DIST.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "DIST like '%" & DIST & "%'"
                Else
                    strtemp = strtemp & " AND DIST like '%" & DIST & "%'"
                End If
            End If

            '個装内装区分
            If (housou_kbn.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "個装内装区分 like '%" & housou_kbn & "%'"
                Else
                    strtemp = strtemp & " AND 個装内装区分 like '%" & housou_kbn & "%'"
                End If
            End If

            '区分
            If (kbn.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "区分 like '%" & kbn & "%'"
                Else
                    strtemp = strtemp & " AND 区分 like '%" & kbn & "%'"
                End If
            End If

            '定量
            If (teiryou.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "定量_不定量 like '%" & teiryou & "%'"
                Else
                    strtemp = strtemp & " AND 定量_不定量 like '%" & teiryou & "%'"
                End If
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM M_Housou_Kbn "
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

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
            sfd.FileName = "個装内装登録早見表" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
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