Public Class F_Login

    Public Shared tantou_cd As String
    Public Shared tantou_nm As String
    Public Shared kengen As String
    Dim fnc As New Function_Class

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************


    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click

        Try
            Dim ta_user As New DS_MTableAdapters.TA_M_User
            Dim dt_user As New DS_M.DT_M_UserDataTable

            Dim id As String = Txt_ID.Text.Trim
            Dim pass As String = Txt_Password.Text.Trim

            ta_user.Q_ログインチェック(dt_user, id, pass)

            If dt_user.Rows.Count = 0 Then

                MessageBox.Show("ID、もしくはパスワードに誤りがあります。")
                Exit Sub

            Else

                '担当者名取得
                tantou_cd = id
                tantou_nm = dt_user.Rows(0)("User_NM")
                kengen = dt_user.Rows(0)("Kengen")

                If kengen = "1" Then


                    '管理者ならメインメニューへ遷移
                    Dim OpenForm As New F_Main
                    OpenForm.Show()

                Else

                    'メインメニューへ遷移
                    Dim OpenForm As New F_Print_Main
                    OpenForm.Show()

                End If


                Me.Close() ' ログイン成功で閉じる

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'キャンセルボタンクリック時
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class