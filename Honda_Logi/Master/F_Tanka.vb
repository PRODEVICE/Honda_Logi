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

            '新規モード
            If Btn_Touroku.Text = "登　録" Then

                Dim chk_count As String = ""

                '存在チェック
                chk_count = ta_tanka.Q_存在チェック(shizai_cd)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの資材コードです。")
                    Exit Sub
                End If

                '登録処理
                ta_tanka.Q_単価登録(shizai_cd, shizai_nm, tanka, maker)

            Else '更新モード

                ta_tanka.Q_単価更新(shizai_cd, shizai_nm, tanka, maker, id)

            End If

            'GV更新
            Me.TA_M_Tanka.Fill(Me.DS_M.DT_M_Tanka)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception

            fnc.ERR_LOG(ex.Message, "F_Tanka_Load_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    'クリアボタンクリック時
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        clear()
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

End Class