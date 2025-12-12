Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Print_Main

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Print_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim dt As New DS_T.DT_T_Inport_RirekiDataTable
            Dim ta As New DS_TTableAdapters.TA_T_Inport_Rireki

            ta.Q_取込履歴_呼び出し(dt)

            ' ComboBox に設定
            With Cmb_Target
                .DataSource = dt
                .DisplayMember = "取込日時"
                .ValueMember = "見積No"
            End With

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '部品単位包装費一覧(内装)クリック時
    Private Sub Btn_Output5_Click(sender As Object, e As EventArgs) Handles Btn_Output5.Click

        Try

            '待機状態
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Cursor.Current = Cursors.WaitCursor


            Dim dt As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc2_2_見積書_部単内装", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", Cmb_Target.SelectedValue)

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel5(dt)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '部品単位包装費一覧(外装)ボタンクリック時
    Private Sub Btn_Output6_Click(sender As Object, e As EventArgs) Handles Btn_Output6.Click

        Try

            '待機状態
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc2_3_見積書_部単外装", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", Cmb_Target.SelectedValue)

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel6(dt)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub


    '包装費変動表
    Private Sub Btn_Output7_Click(sender As Object, e As EventArgs) Handles Btn_Output7.Click

        Try

            '待機状態
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Cursor.Current = Cursors.WaitCursor


            Dim dt As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc3_包装費変動表", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", Cmb_Target.SelectedValue)

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel7(dt)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub


    Private Sub Btn_Output10_Click(sender As Object, e As EventArgs) Handles Btn_Output10.Click

    End Sub

    Private Sub Btn_Output11_Click(sender As Object, e As EventArgs) Handles Btn_Output11.Click

    End Sub

    Private Sub Btn_Output12_Click(sender As Object, e As EventArgs) Handles Btn_Output12.Click

    End Sub

    '機種摘要モジュール一覧
    Private Sub Btn_Output1_Click(sender As Object, e As EventArgs) Handles Btn_Output1.Click

        Try

            Dim mitsumori_no As Integer = Cmb_Target.SelectedValue
            Dim OpenForm As New F_Print_Sub_Module(mitsumori_no)
            OpenForm.ShowDialog()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '見積書系
    Private Sub Btn_Output2_Click(sender As Object, e As EventArgs) Handles Btn_Output2.Click

        Try
            Dim mitsumori_no As Integer = Cmb_Target.SelectedValue
            Dim OpenForm As New F_Print_Sub_Mitsumori(mitsumori_no)
            OpenForm.ShowDialog()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output2_Click")
            MessageBox.Show(ex.Message)
        Finally

        End Try

    End Sub

    '包装仕様一覧
    Private Sub Btn_Output8_Click(sender As Object, e As EventArgs) Handles Btn_Output8.Click

        Try
            Dim mitsumori_no As Integer = Cmb_Target.SelectedValue
            Dim OpenForm As New F_Print_Sub_Housou(mitsumori_no, 1)
            OpenForm.ShowDialog()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output8_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '包装資材明細(定量、不定量共通)
    Private Sub Btn_Output9_Click(sender As Object, e As EventArgs) Handles Btn_Output9.Click

        Try
            Dim mitsumori_no As Integer = Cmb_Target.SelectedValue
            Dim OpenForm As New F_Print_Sub_Housou(mitsumori_no, 2)
            OpenForm.ShowDialog()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output9_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '部品単位包装費一覧(内装)作成処理
    Private Sub ExportToExcel5(dt As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\部品単位包装費一覧(内装).xlsx")

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "部品単位包装費一覧(内装)_出力.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 12   ' L列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString & "　部品単位包装費一覧(内装)")

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), "", row("Col6").ToString)
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), 0, Decimal.Parse(row("Col7").ToString))
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col9")), 0, Decimal.Parse(row("Col9").ToString))
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col10")), 0, Decimal.Parse(row("Col10").ToString))
                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col11")), 0, Decimal.Parse(row("Col11").ToString))
                    ws.Cell(currentRow, 11).Value = If(IsDBNull(row("Col13")), 0, Decimal.Parse(row("Col13").ToString))
                    ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Col14")), 0, Decimal.Parse(row("Col14").ToString))
                    currentRow += 1

                Next

                ' -------------------------------
                ' B5:R最終行まで罫線
                ' -------------------------------
                Dim endRow As Integer = currentRow - 1
                Dim range = ws.Range(startRow, startCol, endRow, endCol)

                ' 全体罫線
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin


                ' 集計行の行番号
                Dim totalRow As Integer = endRow + 1

                ' -------------------------------
                ' B列～I列を結合して「合計」文字
                ' -------------------------------
                Dim mergeRange = ws.Range(totalRow, 2, totalRow, 7) ' B=2,G=7
                mergeRange.Merge()
                mergeRange.Value = "合計"
                mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                mergeRange.Style.Fill.BackgroundColor = XLColor.LightGray
                mergeRange.Style.Font.Bold = True

                ' -------------------------------
                ' SUM関数を入れる
                ' -------------------------------
                For col As Integer = 7 To endCol ' G=7, L=12
                    Dim colLetter As String = ws.Column(col).ColumnLetter
                    ws.Cell(totalRow, col).FormulaA1 = $"=SUM({colLetter}{startRow}:{colLetter}{endRow})"
                    ws.Cell(totalRow, col).Style.Font.Bold = True
                    ws.Cell(totalRow, col).Style.Fill.BackgroundColor = XLColor.LightGray
                Next

                ' -------------------------------
                ' 集計行全体に罫線
                ' -------------------------------
                ws.Range(totalRow, 2, totalRow, endCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range(totalRow, 2, totalRow, endCol).Style.Border.InsideBorder = XLBorderStyleValues.Thin

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    '部品単位包装費一覧(外装)作成処理
    Private Sub ExportToExcel6(dt As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\部品単位包装費一覧(外装).xlsx")

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "部品単位包装費一覧(外装)_出力.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 9   ' I列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString & "　部品単位包装費一覧(外装)")

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), 0, Decimal.Parse(row("Col6").ToString))
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), 0, Decimal.Parse(row("Col7").ToString))
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col8")), 0, Decimal.Parse(row("Col8").ToString))
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col6")), 0, Decimal.Parse(row("Col6").ToString)) + If(IsDBNull(row("Col9")), 0, Decimal.Parse(row("Col9").ToString))
                    currentRow += 1

                Next

                ' -------------------------------
                ' B5:R最終行まで罫線
                ' -------------------------------
                Dim endRow As Integer = currentRow - 1
                Dim range = ws.Range(startRow, startCol, endRow, endCol)

                ' 全体罫線
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin


                ' 集計行の行番号
                Dim totalRow As Integer = endRow + 1

                ' -------------------------------
                ' B列～E列を結合して「合計」文字
                ' -------------------------------
                Dim mergeRange = ws.Range(totalRow, startCol, totalRow, 5) ' B=2, E=5
                mergeRange.Merge()
                mergeRange.Value = "合計"
                mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                mergeRange.Style.Fill.BackgroundColor = XLColor.LightGray
                mergeRange.Style.Font.Bold = True

                ' -------------------------------
                ' SUM関数を入れる
                ' -------------------------------

                'For row As Integer = startRow To endRow
                '    ws.Cell(row, 9).FormulaA1 = $"=SUM(F{row},I{row})"
                'Next

                For col As Integer = 6 To 9 ' F=6, I=9
                    Dim colLetter As String = ws.Column(col).ColumnLetter
                    ws.Cell(totalRow, col).FormulaA1 = $"=SUM({colLetter}{startRow}:{colLetter}{endRow})"
                    ws.Cell(totalRow, col).Style.Font.Bold = True
                    ws.Cell(totalRow, col).Style.Fill.BackgroundColor = XLColor.LightGray
                Next



                ' -------------------------------
                ' 集計行全体に罫線
                ' -------------------------------
                ws.Range(totalRow, startCol, totalRow, endCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range(totalRow, startCol, totalRow, endCol).Style.Border.InsideBorder = XLBorderStyleValues.Thin

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)


        Catch ex As Exception
            Throw
        End Try

    End Sub

    '包装費変動表作成処理
    Private Sub ExportToExcel7(dt As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\包装費変動表.xlsx")

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "包装費変動表_出力.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                'DTにカラム数によってExcelのヘッダ欄を増やす
                Dim col_count As Integer = dt.Columns.Count

                '初期セットしてあるヘッダより多ければ
                If col_count >= 23 Then

                    '増加するブロック数を計算
                    Dim add_count As Integer = (col_count - 22) / 4
                    Dim add_col As Integer = 24

                    For i = 4 To add_count + 3

                        ws.Cell(3, add_col).Value = "モジュール" & i
                        ws.Cell(4, add_col).Value = "モジュール№"
                        ws.Cell(4, add_col + 1).Value = "資材計/台"
                        ws.Cell(4, add_col + 2).Value = "工賃計/台"
                        ws.Cell(4, add_col + 3).Value = "合計/台"

                        ' セルの結合
                        Dim mergeRange = ws.Range(3, add_col, 3, add_col + 3)
                        mergeRange.Merge()
                        mergeRange.Value = "モジュール" & i
                        mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                        mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center

                        ' 罫線
                        ws.Range(3, add_col, 4, add_col + 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                        ws.Range(3, add_col, 4, add_col + 3).Style.Border.InsideBorder = XLBorderStyleValues.Thin

                        '背景色
                        ws.Range(3, add_col, 4, add_col + 3).Style.Fill.BackgroundColor = XLColor.FromArgb(234, 234, 234) ' 淡い灰色
                        ws.Range(3, add_col, 4, add_col + 3).Style.Fill.BackgroundColor = XLColor.FromArgb(234, 234, 234) ' 淡い灰色

                        add_col = add_col + 4
                    Next

                End If

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim currentRow As Integer = startRow


                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■ " & dt.Rows(0)(0).ToString)

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    Dim currentCol As Integer = 2

                    For Each col As DataColumn In dt.Columns

                        ws.Cell(currentRow, currentCol).Value = If(IsDBNull(row("Col" & currentCol).ToString), "", row("Col" & currentCol).ToString)

                        If col_count = currentCol Then
                            Exit For
                        End If

                        currentCol = currentCol + 1

                    Next

                    currentRow += 1

                Next

                ' -------------------------------
                ' B5:R最終行まで罫線
                ' -------------------------------
                Dim endRow As Integer = currentRow - 1
                Dim range

                If col_count >= 23 Then
                    range = ws.Range(startRow, 2, endRow, col_count)
                Else
                    range = ws.Range(startRow, 2, endRow, 23)
                End If

                ' 全体罫線
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin


                ' 集計行の行番号
                Dim totalRow As Integer = endRow + 1

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)

        Catch ex As Exception
            Throw
        End Try

    End Sub


End Class