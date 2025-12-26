Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Print_Sub_Module

    Dim fnc As New Function_Class

    Private _mitsumoriNo As Integer

    ' コンストラクタを追加
    Public Sub New(mitsumoriNo As Integer)
        InitializeComponent()
        _mitsumoriNo = mitsumoriNo
    End Sub

    'ページロード時
    Private Sub F_Print_Sub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Mitsumori_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '定量/不定量ボタンクリック時
    Private Sub Btn_Output1_Click(sender As Object, e As EventArgs) Handles Btn_Output1.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            'Excelに描画
            ExportToExcel1(1)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '定量のみボタンクリック時
    Private Sub Btn_Output2_Click(sender As Object, e As EventArgs) Handles Btn_Output2.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            'Excelに描画
            ExportToExcel1(2)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output2_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try


    End Sub

    '不定量のみボタンクリック時
    Private Sub Btn_Output3_Click(sender As Object, e As EventArgs) Handles Btn_Output3.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            'Excelに描画
            ExportToExcel1(3)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output3_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '******************************************************************************
    '関数
    '******************************************************************************

    '機種摘要モジュール一覧作成処理
    Private Sub ExportToExcel1(_mode As Integer)

        Try

            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            'クリックしたボタンによってファイル名を変更する
            Dim file_nm As String = ""
            Dim kbn1 As String = ""
            Dim kbn2 As String = ""

            If _mode = 1 Then '定量/不定量
                file_nm = "機種摘要モジュール一覧_出力.xlsx"
                kbn1 = "定量"
                kbn2 = "不定量"
            ElseIf _mode = 2 Then '定量のみ
                file_nm = "機種摘要モジュール一覧_定量_出力.xlsx"
                kbn1 = "定量"
                kbn2 = Nothing
            Else '不定量のみ
                file_nm = "機種摘要モジュール一覧_不定量_出力.xlsx"
                kbn1 = "不定量"
                kbn2 = Nothing
            End If

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc1_機種摘要モジュール", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", _mitsumoriNo)
                    cmd.Parameters.AddWithValue("@kbn1", kbn1)
                    'cmd.Parameters.AddWithValue("@kbn2", kbn2)
                    If kbn2 Is Nothing Then
                        cmd.Parameters.Add("@kbn2", SqlDbType.NVarChar, 20).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@kbn2", SqlDbType.NVarChar, 20).Value = kbn2
                    End If

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

            End Using

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\機種摘要モジュール一覧.xlsx")

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = file_nm,
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 4 ' データ開始行（ヘッダが1行目なら2）
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(1, 4).Value = If(IsDBNull(dt.Rows(0)(1)), "", "年次 " & dt.Rows(0)(1).ToString)
                ws.Cell(1, 6).Value = If(IsDBNull(dt.Rows(0)(2)), "", dt.Rows(0)(2).ToString & "月度 ")
                ws.Cell(1, 21).Value = If(IsDBNull(dt.Rows(0)(3)), "", dt.Rows(0)(3).ToString)

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col26").ToString), "", row("Col26").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col4").ToString), "", row("Col4").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col5").ToString), "", row("Col5").ToString)
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col6").ToString), "", row("Col6").ToString)
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col7").ToString), "", row("Col7").ToString)
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col8").ToString), "", row("Col8").ToString)
                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col9").ToString), "", row("Col9").ToString)
                    ws.Cell(currentRow, 11).Value = If(IsDBNull(row("Col10").ToString), "", row("Col10").ToString)
                    ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Col11").ToString), "", row("Col11").ToString)
                    ws.Cell(currentRow, 13).Value = If(IsDBNull(row("Col12").ToString), "", row("Col12").ToString)
                    ws.Cell(currentRow, 14).Value = If(IsDBNull(row("Col13").ToString), "", row("Col13").ToString)
                    ws.Cell(currentRow, 15).Value = If(IsDBNull(row("Col14").ToString), "", row("Col14").ToString)
                    ws.Cell(currentRow, 16).Value = If(IsDBNull(row("Col15").ToString), "", row("Col15").ToString)
                    ws.Cell(currentRow, 17).Value = If(IsDBNull(row("Col16").ToString), "", row("Col16").ToString)
                    ws.Cell(currentRow, 18).Value = If(IsDBNull(row("Col17").ToString), "", row("Col17").ToString)
                    ws.Cell(currentRow, 19).Value = If(IsDBNull(row("Col18").ToString), "", row("Col18").ToString)
                    ws.Cell(currentRow, 20).Value = If(IsDBNull(row("Col19").ToString), "", row("Col19").ToString)
                    ws.Cell(currentRow, 21).Value = If(IsDBNull(row("Col20").ToString), "", row("Col20").ToString)
                    ws.Cell(currentRow, 22).Value = If(IsDBNull(row("Col21").ToString), "", row("Col21").ToString)
                    ws.Cell(currentRow, 23).Value = If(IsDBNull(row("Col22").ToString), "", row("Col22").ToString)
                    ws.Cell(currentRow, 24).Value = If(IsDBNull(row("Col23").ToString), "", row("Col23").ToString)
                    ws.Cell(currentRow, 25).Value = If(IsDBNull(row("Col24").ToString), "", row("Col24").ToString)
                    ws.Cell(currentRow, 26).Value = If(IsDBNull(row("Col25").ToString), "", row("Col25").ToString)

                    currentRow += 2

                Next

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)

        Catch ex As Exception
            Throw
        End Try

    End Sub

End Class