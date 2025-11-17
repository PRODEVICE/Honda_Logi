Public Class F_Master_Main


    Private Sub F_Master_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    '資材マスタボタンクリック時
    Private Sub Btn_M_Shizai_Click(sender As Object, e As EventArgs) Handles Btn_M_Shizai.Click
        Dim OpenForm As New F_Shizai
        OpenForm.ShowDialog()
    End Sub

    '見積コードマスタボタンクリック時
    Private Sub Btn_M_Mitsumori_Click(sender As Object, e As EventArgs) Handles Btn_M_Mitsumori.Click
        Dim OpenForm As New F_Mitsumori
        OpenForm.ShowDialog()
    End Sub

    '賃率マスタボタンクリック時
    Private Sub Btn_M_Tinritsu_Click(sender As Object, e As EventArgs) Handles Btn_M_Tinritsu.Click
        Dim OpenForm As New F_Rate
        OpenForm.ShowDialog()
    End Sub

    '資材単価マスタボタンクリック時
    Private Sub Btn_M_Tanka_Click(sender As Object, e As EventArgs) Handles Btn_M_Tanka.Click
        Dim OpenForm As New F_Tanka
        OpenForm.ShowDialog()
    End Sub

    '個装/内装登録早見表ボタンクリック時
    Private Sub Btn_M_Hayami_Click(sender As Object, e As EventArgs) Handles Btn_M_Hayami.Click
        Dim OpenForm As New F_Housou
        OpenForm.ShowDialog()
    End Sub

    '工数マスタボタンクリック時
    Private Sub Btn_M_Kousu_Click(sender As Object, e As EventArgs) Handles Btn_M_Kousu.Click
        Dim OpenForm As New F_Second
        OpenForm.ShowDialog()
    End Sub

    '機種係数マスタボタンクリック時
    Private Sub Btn_M_Keisu_Click(sender As Object, e As EventArgs) Handles Btn_M_Keisu.Click

    End Sub

    '部品単位オーダーリストボタンクリック時
    Private Sub Btn_M_Order_Click(sender As Object, e As EventArgs) Handles Btn_M_Order.Click
        Dim OpenForm As New F_Buhin_Order_List
        OpenForm.ShowDialog()
    End Sub

    Private Sub Btn_Tantou_Click(sender As Object, e As EventArgs) Handles Btn_Tantou.Click
        Dim OpenForm As New F_User
        OpenForm.ShowDialog()
    End Sub
End Class