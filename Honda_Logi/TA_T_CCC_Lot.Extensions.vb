Namespace DS_TTableAdapters
    Partial Public Class TA_T_CCC_Lot
        Public Sub SetCommandTimeout(seconds As Integer)
            If Me.CommandCollection IsNot Nothing Then
                For Each cmd As Global.System.Data.SqlClient.SqlCommand In Me.CommandCollection
                    If cmd IsNot Nothing Then
                        cmd.CommandTimeout = seconds
                    End If
                Next
            End If
        End Sub
    End Class
End Namespace