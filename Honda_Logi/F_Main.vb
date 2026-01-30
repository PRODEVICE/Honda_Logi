Public Class F_Main

    Private _mode As Integer

    ' コンストラクタを追加
    Public Sub New(mode As Integer)
        InitializeComponent()
        _mode = mode
    End Sub

    'ページロード時
    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            'ログイン画面の権限を参照して表示制御
            If F_Login.kengen = "1" Then '管理者
                Lbl_Data.Visible = True
                Lbl_Master.Visible = True
                Pnl_Data.Visible = True
                Pnl_Master.Visible = True

            Else '一般
                Lbl_Data.Visible = False
                Lbl_Master.Visible = False
                Pnl_Data.Visible = False
                Pnl_Master.Visible = False
            End If

            'モードによって表示制御
            If _mode = 1 Then
                Lbl_Mode.Visible = False

            ElseIf _mode = 2 Then
                Lbl_Mode.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'ページクローズ時
    Private Sub F_Main_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Dim OpenForm As New F_Select_Main
        OpenForm.Show()

    End Sub

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    'データ取込ボタンクリック時
    Private Sub Btn_Receive_Click(sender As Object, e As EventArgs) Handles Btn_Receive.Click
        Dim OpenForm As New F_Receive(_mode)
        OpenForm.ShowDialog()
    End Sub

    'データ出力ボタンクリック時
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click
        Dim OpenForm As New F_Print_Main(_mode)
        OpenForm.ShowDialog()
    End Sub

    'マスタ編集ボタンクリック時
    Private Sub Btn_Master_Click(sender As Object, e As EventArgs) Handles Btn_Master.Click
        Dim OpenForm As New F_Master_Main
        OpenForm.ShowDialog()
    End Sub

    '変換ボタンクリック時
    Private Sub Btn_Change_Click(sender As Object, e As EventArgs) Handles Btn_Change.Click
        Dim OpenForm As New F_Make_1Lot(_mode)
        OpenForm.ShowDialog()
    End Sub


End Class
