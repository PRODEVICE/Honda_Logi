Public Class Function_Class



    '***********************************************************************************
    'エラーログ作成
    '***********************************************************************************
    '引数
    '1:エラーメッセージ
    '2:発生個所
    '3:発生日時

    Public Sub ERR_LOG(ByVal _err_msg As String, ByVal _err_place As String)
        Try
            Dim date_now As DateTime = System.DateTime.Now
            Dim ta As New DS_TTableAdapters.TA_T_ERR_LOG

            'エラーログ出力
            ta.Q_エラーログ登録(_err_place, _err_msg, date_now)

        Catch ex As Exception
            Throw New Exception("エラーログ登録時にエラーが発生しました。")
        End Try
    End Sub

End Class
