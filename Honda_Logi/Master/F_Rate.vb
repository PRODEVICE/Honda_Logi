Public Class F_Rate

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Rate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim ta As New DS_MTableAdapters.TA_M_Rate

            Txt_Rate.Text = ta.Q_賃率取得

        Catch ex As Exception

            fnc.ERR_LOG(ex.Message, "F_Rate_F_Rate_Load")
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    '更新ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim hankaku_suji As New System.Text.RegularExpressions.Regex(“^[0-9.]+$”)
            Dim ta As New DS_MTableAdapters.TA_M_Rate

            If Txt_Rate.Text = "" Then
                MessageBox.Show("賃率を入力してください。")
                Exit Sub
            End If

            '半角数字チェック
            If hankaku_suji.IsMatch(Txt_Rate.Text) = False Then
                MessageBox.Show("半角数字で入力してください。")
                Exit Sub
            End If

            ta.Q_賃率更新(Txt_Rate.Text)

            MessageBox.Show("更新完了しました。")

        Catch ex As Exception

            fnc.ERR_LOG(ex.Message, "F_Rate_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)

        End Try

    End Sub
End Class