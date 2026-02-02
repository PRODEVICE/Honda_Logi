Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Print_Main

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Print_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim dt As New DS_T.DT_T_Import_RirekiDataTable
            Dim ta As New DS_TTableAdapters.TA_T_Import_Rireki

            ta.Q_取込履歴_呼び出し(dt, "1")

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
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output5_Click")
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
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output6_Click")
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


            Dim dt_result As New DataTable
            Dim dt_module As New DataTable
            Dim ds As New DataSet()
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
                    da.Fill(ds)

                End Using

                dt_result = ds.Tables(0)
                dt_module = ds.Tables(1)

                'Excelに描画
                ExportToExcel7(dt_result, dt_module)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output7_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    'KIT60(最終加工)クリック時
    Private Sub Btn_Output10_Click(sender As Object, e As EventArgs) Handles Btn_Output10.Click

        Try

            '待機状態
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DS_T.DT_T_KIT60DataTable
            Dim ta As New DS_TTableAdapters.DT_T_KIT60TableAdapter
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                conn.Open()

                Using cmd As New SqlCommand("Proc7_KIT60", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", Cmb_Target.SelectedValue)

                    ' ★ 実行（戻り値なし）
                    cmd.ExecuteNonQuery()

                End Using

            End Using

            ta.Q_KIT情報取得(dt, Cmb_Target.SelectedValue)

            'Excelに描画
            ExportToExcel10(dt)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output10_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '請求明細クリック時
    Private Sub Btn_Output11_Click(sender As Object, e As EventArgs) Handles Btn_Output11.Click

        Try

            '待機状態
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc8_請求明細", conn)

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
                ExportToExcel11(dt)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Main_Btn_Output11_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    'モジュール別包装費明細クリック時
    Private Sub Btn_Output12_Click(sender As Object, e As EventArgs) Handles Btn_Output12.Click

        Dim mitsumori_no As Integer = Cmb_Target.SelectedValue
        Dim OpenForm As New F_Print_Sub_Module_Housou(mitsumori_no)
        OpenForm.ShowDialog()

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

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(Cmb_Target.SelectedValue)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "部品単位包装費一覧(内装)_" & nendo & "年度.xlsx",
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

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(Cmb_Target.SelectedValue)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "部品単位包装費一覧(外装)_" & nendo & "年度.xlsx",
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
    Private Sub ExportToExcel7(dt As DataTable, dt_module As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\包装費変動表.xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(Cmb_Target.SelectedValue)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "包装費変動表_" & nendo & "年度.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            'dt_moduleのGroupNoのカウントを取得して、その最大値をもらう
            Dim maxCount As Integer =
                                    dt_module.AsEnumerable().
                                       GroupBy(Function(r) r.Field(Of Integer)("GroupNo")).
                                       Select(Function(g) g.Count()).
                                       Max()

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                'DTにカラム数によってExcelのヘッダ欄を増やす
                'Dim col_count As Integer = dt.Columns.Count
                Dim max_col As Integer = 23

                '初期セットしてあるヘッダより多ければ
                If maxCount >= 4 Then

                    '増加するブロック数を計算
                    Dim add_count As Integer = maxCount
                    Dim add_col As Integer = 24

                    For i = 4 To add_count

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

                    max_col = add_col - 1

                End If

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）

                'Excelの書き込みターゲット行数
                Dim currentRow As Integer = startRow

                '親DTの行数
                Dim dt_row_count As Integer = 1
                Dim select_modual_dt As New DataTable

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■ " & dt.Rows(0)(0).ToString)

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    Dim currentCol As Integer = 2

                    For Each col As DataColumn In dt.Columns

                        ws.Cell(currentRow, currentCol).Value = If(IsDBNull(row("Col" & currentCol).ToString), "", row("Col" & currentCol).ToString)

                        If 11 = currentCol Then
                            Exit For
                        End If

                        currentCol = currentCol + 1

                    Next

                    'ModualDTより対象行を取得してExcelに書き込む
                    currentCol = currentCol + 1

                    Dim childRows = dt_module.AsEnumerable().
                    Where(Function(r) r.Field(Of Integer)("GroupNo") = dt_row_count)

                    For Each cRow In childRows

                        ' 子DTの値を取得
                        Dim val1 As String = cRow("Col1")
                        Dim val2 As Decimal = cRow("Col2")
                        Dim val3 As Decimal = cRow("Col3")
                        Dim val4 As Decimal = cRow("Col4")

                        ' 処理
                        ws.Cell(currentRow, currentCol).Value = val1
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

                        currentCol = currentCol + 1
                        ws.Cell(currentRow, currentCol).Value = val2
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right

                        currentCol = currentCol + 1
                        ws.Cell(currentRow, currentCol).Value = val3
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right

                        currentCol = currentCol + 1
                        ws.Cell(currentRow, currentCol).Value = val4
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right

                        currentCol = currentCol + 1

                    Next



                    currentRow += 1
                    dt_row_count += 1
                Next

                ' -------------------------------
                ' B5:R最終行まで罫線
                ' -------------------------------
                Dim endRow As Integer = currentRow - 1
                Dim range

                If max_col >= 23 Then
                    range = ws.Range(startRow, 2, endRow, max_col)
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

    'KIT60(最終加工)作成処理
    Private Sub ExportToExcel10(dt As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\KIT60(最終加工).xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(Cmb_Target.SelectedValue)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "KIT60(最終加工)_" & nendo & "年度.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 6 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 54   ' BB列
                Dim currentRow As Integer = startRow

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("包装SS")), "", row("包装SS").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("汎24")), 0, Integer.Parse(row("汎24").ToString))
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("ModelYear")), "", row("ModelYear").ToString)
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Dist")), "", row("Dist").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("機種")), "", row("機種").ToString)
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("TYPE")), "", row("TYPE").ToString)
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("ｵﾌﾟｼｮﾝ")), "", row("ｵﾌﾟｼｮﾝ").ToString)
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("部品群")), "", row("部品群").ToString)
                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Lot_no")), "", row("Lot_no").ToString)
                    ws.Cell(currentRow, 11).Value = If(IsDBNull(row("枝")), "", row("枝").ToString)
                    ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Module")), "", row("Module").ToString)
                    ws.Cell(currentRow, 13).Value = If(IsDBNull(row("ﾓﾃﾞﾌ")), "", row("ﾓﾃﾞﾌ").ToString)
                    ws.Cell(currentRow, 14).Value = If(IsDBNull(row("仮C_no")), "", row("仮C_no").ToString)
                    ws.Cell(currentRow, 15).Value = If(IsDBNull(row("定量f_不定量x区分")), "", row("定量f_不定量x区分").ToString)
                    ws.Cell(currentRow, 16).Value = If(IsDBNull(row("P_C_No")), "", row("P_C_No").ToString)
                    ws.Cell(currentRow, 17).Value = If(IsDBNull(row("包装日")), "", row("包装日").ToString)
                    ws.Cell(currentRow, 18).Value = If(IsDBNull(row("包装Lot台数")), "", row("包装Lot台数").ToString)
                    ws.Cell(currentRow, 19).Value = If(IsDBNull(row("外装Line")), "", row("外装Line").ToString)
                    ws.Cell(currentRow, 20).Value = If(IsDBNull(row("係")), "", row("係").ToString)
                    ws.Cell(currentRow, 21).Value = If(IsDBNull(row("Line")), "", row("Line").ToString)
                    ws.Cell(currentRow, 22).Value = If(IsDBNull(row("その他1")), "", row("その他1").ToString)
                    ws.Cell(currentRow, 23).Value = If(IsDBNull(row("その他2")), "", row("その他2").ToString)
                    ws.Cell(currentRow, 24).Value = If(IsDBNull(row("包装場")), "", row("包装場").ToString)
                    ws.Cell(currentRow, 25).Value = If(IsDBNull(row("GWT")), "", row("GWT").ToString)
                    ws.Cell(currentRow, 26).Value = If(IsDBNull(row("外装規格")), "", row("外装規格").ToString)
                    ws.Cell(currentRow, 27).Value = If(IsDBNull(row("Ｌ")), "", row("Ｌ").ToString)
                    ws.Cell(currentRow, 28).Value = If(IsDBNull(row("W")), "", row("W").ToString)
                    ws.Cell(currentRow, 29).Value = If(IsDBNull(row("Ｈ")), "", row("Ｈ").ToString)
                    ws.Cell(currentRow, 30).Value = If(IsDBNull(row("計画年")), "", row("計画年").ToString)
                    ws.Cell(currentRow, 31).Value = If(IsDBNull(row("計画月")), "", row("計画月").ToString)
                    ws.Cell(currentRow, 32).Value = If(IsDBNull(row("オーダーロットNo")), "", row("オーダーロットNo").ToString)
                    ws.Cell(currentRow, 33).Value = If(IsDBNull(row("計画確定Bit")), "", row("計画確定Bit").ToString)
                    ws.Cell(currentRow, 34).Value = If(IsDBNull(row("ケースマーク発行Bit")), "", row("ケースマーク発行Bit").ToString)
                    ws.Cell(currentRow, 35).Value = If(IsDBNull(row("部品群機種コード")), "", row("部品群機種コード").ToString)
                    ws.Cell(currentRow, 36).Value = If(IsDBNull(row("ベース機種コード")), "", row("ベース機種コード").ToString)
                    ws.Cell(currentRow, 37).Value = If(IsDBNull(row("包装ロットNo")), "", row("包装ロットNo").ToString)
                    ws.Cell(currentRow, 38).Value = If(IsDBNull(row("オーダー区分")), "", row("オーダー区分").ToString)
                    ws.Cell(currentRow, 39).Value = If(IsDBNull(row("予備１")), "", row("予備１").ToString)
                    ws.Cell(currentRow, 40).Value = If(IsDBNull(row("予備２")), "", row("予備２").ToString)
                    ws.Cell(currentRow, 41).Value = If(IsDBNull(row("予備３")), "", row("予備３").ToString)
                    ws.Cell(currentRow, 42).Value = If(IsDBNull(row("予備４")), "", row("予備４").ToString)
                    ws.Cell(currentRow, 43).Value = If(IsDBNull(row("予備５")), "", row("予備５").ToString)
                    ws.Cell(currentRow, 44).Value = If(IsDBNull(row("本C_No")), "", row("本C_No").ToString)
                    ws.Cell(currentRow, 45).Value = If(IsDBNull(row("予備７")), "", row("予備７").ToString)

                    ws.Cell(currentRow, 49).Value = If(IsDBNull(row("個装数")), 0, Integer.Parse(row("個装数").ToString))
                    ws.Cell(currentRow, 50).Value = If(IsDBNull(row("ｶｰﾄﾝ")), 0, Integer.Parse(row("ｶｰﾄﾝ").ToString))
                    ws.Cell(currentRow, 51).Value = If(IsDBNull(row("工数")), 0, Integer.Parse(row("工数").ToString))
                    ws.Cell(currentRow, 52).Value = If(IsDBNull(row("部品点数")), 0, Integer.Parse(row("部品点数").ToString))
                    ws.Cell(currentRow, 53).Value = If(IsDBNull(row("部品総数")), 0, Integer.Parse(row("部品総数").ToString))
                    ws.Cell(currentRow, 54).Value = If(IsDBNull(row("材料費")), 0, Decimal.Parse(row("材料費").ToString))

                    currentRow += 1

                Next

                ' -------------------------------
                ' 関数を入れる
                ' -------------------------------
                Dim endRow As Integer = currentRow - 1
                For row As Integer = startRow To endRow
                    ws.Cell(row, 46).FormulaA1 = $"=E{row}&I{row}&J{row}&L{row}&N{row}"
                    ws.Cell(row, 47).FormulaA1 = $"=IF(MID(AJ{row},6,1)="" "",MID(AJ{row},2,4)&MID(AJ{row},7,2),MID(AJ{row},2,7))"
                    ws.Cell(row, 48).FormulaA1 = $"=ROUND(ROUND(AA{row}/1000,2)*ROUND(AB{row}/1000,2)*ROUND(AC{row}/1000,2),6)"
                Next

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    '請求明細作成処理
    Private Sub ExportToExcel11(dt As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\請求明細.xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(Cmb_Target.SelectedValue)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "請求明細_" & nendo & "年度.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 20   ' U列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString)

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), "", row("Col6").ToString)
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), 0, Integer.Parse(row("Col7").ToString))
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col8")), 0, Integer.Parse(row("Col8").ToString))
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col9")), "", row("Col9").ToString)
                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col11")), 0, Integer.Parse(row("Col11").ToString))
                    ws.Cell(currentRow, 11).Value = If(IsDBNull(row("Col12")), 0, Decimal.Parse(row("Col12").ToString))
                    ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Col13")), 0, Decimal.Parse(row("Col13").ToString))
                    ws.Cell(currentRow, 13).Value = If(IsDBNull(row("Col14")), 0, Decimal.Parse(row("Col14").ToString))
                    ws.Cell(currentRow, 14).Value = If(IsDBNull(row("Col15")), 0, Decimal.Parse(row("Col15").ToString))
                    ws.Cell(currentRow, 15).Value = If(IsDBNull(row("Col16")), 0, Integer.Parse(row("Col16").ToString))
                    ws.Cell(currentRow, 16).Value = If(IsDBNull(row("Col17")), 0, Integer.Parse(row("Col17").ToString))
                    ws.Cell(currentRow, 17).Value = If(IsDBNull(row("Col18")), 0, Decimal.Parse(row("Col18").ToString))
                    ws.Cell(currentRow, 18).Value = If(IsDBNull(row("Col19")), 0, Decimal.Parse(row("Col19").ToString))
                    ws.Cell(currentRow, 19).Value = If(IsDBNull(row("Col20")), 0, Decimal.Parse(row("Col20").ToString))
                    ws.Cell(currentRow, 20).Value = If(IsDBNull(row("Col21")), 0, Decimal.Parse(row("Col21").ToString))

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
                Dim mergeRange = ws.Range(totalRow, startCol, totalRow, 14) ' B=2, O=14
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

                For col As Integer = 15 To 20 ' P=15, U=20
                    Dim colLetter As String = ws.Column(col).ColumnLetter
                    ws.Cell(totalRow, col).FormulaA1 = $"=SUM({colLetter}{startRow}:{colLetter}{endRow})"
                    ws.Cell(totalRow, col).Style.Font.Bold = True
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

End Class