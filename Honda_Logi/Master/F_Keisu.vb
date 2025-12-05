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
            Dim type As String = Txt_Type.Text.Trim
            Dim keisu As String = Txt_Keisu.Text.Trim
            Dim id As String = Txt_id.Text.Trim
            Dim qty As Decimal

            '入力チェック
            If kishu = "" Or type = "" Or keisu = "" Then
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
                chk_count = ta_keisu.Q_存在チェック(kishu, type)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの機種、タイプです。")
                    Exit Sub
                End If

                '登録処理
                ta_keisu.Q_係数登録(kishu, type, keisu)

            Else '更新モード

                '存在チェック
                chk_count = ta_keisu.Q_更新存在チェック(kishu, type, id)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの機種、タイプです。")
                    Exit Sub
                End If

                ta_keisu.Q_係数更新(kishu, type, keisu, id)

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
                Txt_Type.Text = grid.Rows(e.RowIndex).Cells("タイプ").Value.ToString()
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
            Dim type As String = Txt_S_Type.Text.Trim

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
            If (type.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "タイプ like '%" & type & "%'"
                Else
                    strtemp = strtemp & " AND タイプ like '%" & type & "%'"
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
        Txt_Type.Text = ""
        Txt_Keisu.Text = ""

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
End Class