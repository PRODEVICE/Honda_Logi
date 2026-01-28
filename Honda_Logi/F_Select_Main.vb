Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Select_Main

    Dim fnc As New Function_Class

    Private Sub F_Select_Main_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '新見積システムボタンクリック時
    Private Sub Btn_Normal_Click(sender As Object, e As EventArgs) Handles Btn_Normal.Click

        Try

            'メインメニューへ遷移
            Dim OpenForm As New F_Main(1)
            OpenForm.Show()

            Me.Close() '閉じる

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Select_Main_Main_Btn_Normal_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '新見積システム_見積依頼用ボタンクリック時
    Private Sub Btn_Tokushu_Click(sender As Object, e As EventArgs) Handles Btn_Tokushu.Click

        Try

            'メインメニューへ遷移
            Dim OpenForm As New F_Main(2)
            OpenForm.Show()

            Me.Close() '閉じる

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Select_Main_Btn_Tokushu")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class