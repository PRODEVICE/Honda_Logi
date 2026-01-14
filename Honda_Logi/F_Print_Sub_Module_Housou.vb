Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Print_Sub_Module_Housou

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
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Module_Housou_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    'モジュール別包装費明細ボタンクリック時
    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim dt As New DataTable
            Dim dt_second As New DS_M.DT_M_SecondDataTable
            Dim ta_second As New DS_MTableAdapters.TA_M_Second
            Dim dt_ccc_chk As New DS_T.DT_T_CCC_LotDataTable
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot

            '秒数取得
            ta_second.Q_工数一覧取得(dt_second)

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            Dim yeat As String = Txt_Year.Text.Trim
            Dim month As String = Txt_Month.Text.Trim.PadLeft(2, "0")
            Dim dist As String = Txt_DIST.Text.Trim
            Dim kishu As String = Txt_Kishu.Text.Trim
            Dim module_str As String = Txt_Module.Text.Trim
            Dim modefu As String = Txt_Modefu.Text.Trim
            Dim type As String = Txt_Type.Text.Trim
            Dim nendo As String = Txt_Nendo.Text.Trim
            Dim nengetu As String = yeat & month

            '必須チェック_一旦保留


            'CCC1Lotに存在するかチェック
            ta_ccc.Q_印刷_存在チェック_モジュール別包装費用(dt_ccc_chk, nengetu, dist, nendo, kishu, type, module_str, modefu)

            If dt_ccc_chk.Rows.Count = 0 Then
                MessageBox.Show("条件に一致する1Lotデータが存在しません。")
                Exit Sub
            End If

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc9_モジュール別包装費明細", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", _mitsumoriNo)
                    cmd.Parameters.AddWithValue("@Year", yeat)
                    cmd.Parameters.AddWithValue("@Month", month)
                    cmd.Parameters.AddWithValue("@Dist", dist)
                    cmd.Parameters.AddWithValue("@Kishu", nendo & kishu & type)
                    cmd.Parameters.AddWithValue("@Module", module_str)
                    cmd.Parameters.AddWithValue("@Modefu", modefu)

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel1(dt, dt_second)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Module_Housou_Btn_Print_Click")
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

    'モジュール別包装費明細作成処理
    Private Sub ExportToExcel1(dt As DataTable, _dt_second As DS_M.DT_M_SecondDataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\モジュール別包装費明細.xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(_mitsumoriNo)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "モジュール別包装費明細_" & nendo & "年度.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 9 ' データ開始行（ヘッダが1行目なら2）
                Dim currentRow As Integer = startRow

                '固定値の秒数をセット
                Dim seconds(18) As Integer   ' 0～18 → second1～second19

                For i As Integer = 0 To 18
                    seconds(i) = CInt(_dt_second.Rows(i)("秒数"))
                Next

                ws.Cell(9, 4).Value = seconds(0)
                ws.Cell(10, 4).Value = seconds(1)
                ws.Cell(12, 4).Value = seconds(2)
                ws.Cell(13, 4).Value = seconds(3)
                ws.Cell(15, 4).Value = seconds(4)
                ws.Cell(16, 4).Value = seconds(5)
                ws.Cell(17, 4).Value = seconds(6)
                ws.Cell(18, 4).Value = seconds(7)
                ws.Cell(19, 4).Value = seconds(8)
                ws.Cell(21, 4).Value = seconds(9)
                ws.Cell(22, 4).Value = seconds(10)
                ws.Cell(23, 4).Value = seconds(11)
                ws.Cell(24, 4).Value = seconds(12)
                ws.Cell(25, 4).Value = seconds(13)
                ws.Cell(26, 4).Value = seconds(14)
                ws.Cell(27, 4).Value = seconds(15)
                ws.Cell(28, 4).Value = seconds(16)
                ws.Cell(29, 4).Value = seconds(17)
                ws.Cell(30, 4).Value = seconds(18)

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", dt.Rows(0)(0).ToString)
                ws.Cell(3, 3).Value = Txt_DIST.Text.Trim
                ws.Cell(4, 3).Value = Txt_Nendo.Text.Trim & Txt_Kishu.Text.Trim & " " & Txt_Type.Text.Trim
                ws.Cell(5, 3).Value = Txt_Module.Text.Trim
                ws.Cell(6, 3).Value = Txt_Modefu.Text.Trim

                Dim colNames As String() = {"Col6", "Col7", "Col8", "Col9", "Col10", "Col11", "Col12", "Col13", "Col13_1", "Col14", "Col15", "Col16",
                                            "Col17", "Col18", "Col19", "Col20", "Col21", "Col22", "Col23", "Col24", "Col25", "Col25_1", "Col26", "Col27"}

                Dim col As Integer = 6

                For Each row As DataRow In dt.Rows

                    For i As Integer = 0 To colNames.Length - 1

                        Dim value As Integer = 0

                        If Not IsDBNull(row(colNames(i))) Then
                            Integer.TryParse(row(colNames(i)).ToString(), value)
                        End If

                        ws.Cell(startRow + i, col).Value = value

                    Next
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