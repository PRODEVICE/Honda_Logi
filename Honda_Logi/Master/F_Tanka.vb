Imports System.Configuration
Imports System.IO

Public Class F_Tanka

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Tanka_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: このコード行はデータを 'DS_M.DT_M_Tanka' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Tanka.Fill(Me.DS_M.DT_M_Tanka)

        'ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
        GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_tanka As New DS_MTableAdapters.TA_M_Tanka
            Dim hankaku_suji As New System.Text.RegularExpressions.Regex(“^[0-9.]+$”)

            Dim shizai_cd As String = Txt_Shizai_CD.Text.Trim
            Dim shizai_nm As String = Txt_Shizai_NM.Text.Trim
            Dim tanka As String = Txt_Tanka.Text.Trim
            Dim maker As String = Txt_Maker.Text.Trim
            Dim id As String = Txt_id.Text.Trim

            '入力チェック
            If shizai_cd = "" Then

                MessageBox.Show("資材コードを入力してください")
                Exit Sub

            ElseIf tanka = "" Then

                MessageBox.Show("単価を入力してください")
                Exit Sub

            ElseIf hankaku_suji.IsMatch(tanka) = False Then
                MessageBox.Show("単価は半角数字で入力してください。")
                Exit Sub

            End If

            Dim chk_count As String = ""

            '新規モード
            If Btn_Touroku.Text = "登　録" Then

                '存在チェック
                chk_count = ta_tanka.Q_存在チェック(shizai_cd)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの資材コードです。")
                    Exit Sub
                End If

                '登録処理
                ta_tanka.Q_単価登録(shizai_cd, shizai_nm, tanka, maker)

            Else '更新モード

                '存在チェック
                chk_count = ta_tanka.Q_更新存在チェック(shizai_cd, id)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの資材コードです。")
                    Exit Sub
                End If

                ta_tanka.Q_単価更新(shizai_cd, shizai_nm, tanka, maker, id)

            End If

            'GV更新
            Me.TA_M_Tanka.Fill(Me.DS_M.DT_M_Tanka)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Tanka_Btn_Touroku_Click")
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
            Me.DS_M.DT_M_Tanka.Clear()
            DataAdapter.Fill(Me.DS_M.DT_M_Tanka)
            GV_Master.DataSource = Me.DS_M.DT_M_Tanka

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

            '入力項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Tanka_Btn_Search_Click")
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

            Dim dt_From As New DS_M.DT_M_TankaDataTable
            Dim ta As New DS_MTableAdapters.TA_M_Tanka
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
            Me.TA_M_Tanka.Fill(Me.DS_M.DT_M_Tanka)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Tanka_Btn_Import_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'GVイベント
    '******************************************************************************

    'リンクボタンがクリックされたら
    Private Sub GV_Master_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Master.CellContentClick

        Try

            Dim ta_tanka As New DS_MTableAdapters.TA_M_Tanka

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

                Txt_Shizai_CD.Text = grid.Rows(e.RowIndex).Cells("資材コード").Value.ToString()
                Txt_Shizai_NM.Text = grid.Rows(e.RowIndex).Cells("資材名").Value.ToString()
                Txt_Tanka.Text = grid.Rows(e.RowIndex).Cells("単価").Value.ToString()
                Txt_Maker.Text = grid.Rows(e.RowIndex).Cells("メーカーコード").Value.ToString()

                Btn_Touroku.Text = "更　新"

            End If

            '削除ボタン
            If grid.Columns(e.ColumnIndex).Name = "削除" Then

                If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'データソースから削除
                    grid.Rows.RemoveAt(e.RowIndex)

                    'DBからも削除
                    ta_tanka.Q_単価削除(target_id)

                    MessageBox.Show("削除完了しました。")

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Tanka_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    '関数
    '******************************************************************************

    '画面項目クリア処理
    Sub clear()

        Txt_id.Text = ""
        Txt_Shizai_CD.Text = ""
        Txt_Shizai_NM.Text = ""
        Txt_Tanka.Text = ""
        Txt_Maker.Text = ""

        Btn_Touroku.Text = "登　録"
    End Sub

    Function MakeSQL_Search() As String

        Try

            Dim shizai_cd As String = Txt_S_Shizai_CD.Text.Trim
            Dim shizai_nm As String = Txt_S_Shizai_NM.Text.Trim
            Dim tanka As String = Txt_S_Tanka.Text.Trim
            Dim maker As String = Txt_S_Maker.Text.Trim

            Dim Retstr As String = Nothing
            Dim strtemp As String = Nothing

            'Where区作成区作成

            '資材コード
            If (shizai_cd.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "資材コード like '%" & shizai_cd & "%'"
                Else
                    strtemp = strtemp & " AND 資材コード like '%" & shizai_cd & "%'"
                End If
            End If

            '資材名
            If (shizai_nm.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "資材名 like '%" & shizai_nm & "%'"
                Else
                    strtemp = strtemp & " AND 資材名 like '%" & shizai_nm & "%'"
                End If
            End If

            '単価
            If (tanka.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "単価 like '%" & tanka & "%'"
                Else
                    strtemp = strtemp & " AND 単価 like '%" & tanka & "%'"
                End If
            End If

            'メーカーコード
            If (maker.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "メーカーコード like '%" & maker & "%'"
                Else
                    strtemp = strtemp & " AND メーカーコード like '%" & maker & "%'"
                End If
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM M_Tanka "
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function


    'CSVファイル取り込み処理
    Function Import_CSV(_file_path As String) As DataTable

        Dim dt As New DS_M.DT_M_TankaDataTable

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
                        Dim dr As DataRow = dt.NewDT_M_TankaRow()

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

End Class