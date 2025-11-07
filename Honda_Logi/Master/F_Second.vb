Public Class F_Second

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Second_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'DS_M.DT_M_Second' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Second.Fill(Me.DS_M.DT_M_Second)

        'ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
        GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '更新ボタンクリック時

    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_second As New DS_MTableAdapters.TA_M_Second
            Dim hankaku_suji As New System.Text.RegularExpressions.Regex(“^[0-9]+$”)

            Dim byousu As String = Txt_Byousu.Text.Trim
            Dim id As String = Txt_id.Text.Trim

            '入力チェック
            If byousu = "" Then

                MessageBox.Show("秒数を入力してください")
                Exit Sub

            ElseIf hankaku_suji.IsMatch(byousu) = False Then
                MessageBox.Show("秒数は半角数字で入力してください。")
                Exit Sub

            End If

            '更新モード
            ta_second.Q_工数更新(byousu, id)

            'GV更新
            Me.TA_M_Second.Fill(Me.DS_M.DT_M_Second)

            'クリア
            Txt_Byousu.Text = ""
            Txt_id.Text = ""

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Second_Btn_Touroku_Click")
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

                Txt_Byousu.Text = grid.Rows(e.RowIndex).Cells("秒数").Value.ToString()

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Second_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try


    End Sub

End Class