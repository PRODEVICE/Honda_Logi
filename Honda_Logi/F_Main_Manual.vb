Public Class F_Main_Manual

    'ページロード時
    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            'ログイン画面の権限を参照して表示制御
            If F_Login.kengen = "1" Then '管理者
                Lbl_Data.Visible = True
                Pnl_Data.Visible = True

            Else '一般
                Lbl_Data.Visible = False
                Pnl_Data.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'ページクローズ時
    Private Sub F_Main_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'たまにゴミが残るので
        Application.Exit()
        Environment.Exit(0)

    End Sub

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    'データ取込ボタンクリック時
    Private Sub Btn_Receive_Click(sender As Object, e As EventArgs) Handles Btn_Receive.Click
        Dim OpenForm As New F_Receive
        OpenForm.ShowDialog()
    End Sub

    'データ出力ボタンクリック時
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click
        Dim OpenForm As New F_Print_Main
        OpenForm.ShowDialog()
    End Sub

    '変換ボタンクリック時
    Private Sub Btn_Change_Click(sender As Object, e As EventArgs) Handles Btn_Change.Click
        Dim OpenForm As New F_Make_1Lot
        OpenForm.ShowDialog()
    End Sub


End Class
