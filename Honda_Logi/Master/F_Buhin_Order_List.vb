Public Class F_Buhin_Order_List
    Private Sub F_Buhin_Order_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'DS_M.DT_M_Buhin_Order_List' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Buhin_Order_List.Fill(Me.DS_M.DT_M_Buhin_Order_List)

    End Sub
End Class