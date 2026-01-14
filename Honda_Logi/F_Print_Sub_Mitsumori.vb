Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Print_Sub_Mitsumori

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

    '2R/ATVボタンクリック時
    Private Sub Btn_Output1_Click(sender As Object, e As EventArgs) Handles Btn_Output1.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim keisu_flg As Boolean = Chk_Keisu_Flg.Checked

            Dim dt As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc2_1_見積書_機種", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", _mitsumoriNo)
                    cmd.Parameters.AddWithValue("@Kbn", "2R/ATV")
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                '受け取った

                'Excelに描画
                ExportToExcel2(dt, keisu_flg, 1)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Mitsumori_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '汎用機種ボタンクリック時
    Private Sub Btn_Output2_Click(sender As Object, e As EventArgs) Handles Btn_Output2.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim keisu_flg As Boolean = Chk_Keisu_Flg.Checked

            Dim dt As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            ' ストアド実行
            Using conn As New SqlConnection(connectionString)

                Using cmd As New SqlCommand("Proc2_1_見積書_機種", conn)

                    'タイムアウト設定
                    cmd.CommandTimeout = 1200
                    cmd.CommandType = CommandType.StoredProcedure

                    ' ★ 必要なら引数を追加
                    cmd.Parameters.AddWithValue("@Debug", 0)
                    cmd.Parameters.AddWithValue("@QuoteNo", _mitsumoriNo)
                    cmd.Parameters.AddWithValue("@Kbn", "汎用機種")

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel2(dt, keisu_flg, 2)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Mitsumori_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try


    End Sub

    '部単内装ボタンクリック時
    Private Sub Btn_Output3_Click(sender As Object, e As EventArgs) Handles Btn_Output3.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim keisu_flg As Boolean = Chk_Keisu_Flg.Checked

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
                    cmd.Parameters.AddWithValue("@QuoteNo", _mitsumoriNo)

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel3(dt, keisu_flg)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Mitsumori_Btn_Output1_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try


    End Sub

    '部単外装ボタンクリック時
    Private Sub Btn_Output4_Click(sender As Object, e As EventArgs) Handles Btn_Output4.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim keisu_flg As Boolean = Chk_Keisu_Flg.Checked

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
                    cmd.Parameters.AddWithValue("@QuoteNo", _mitsumoriNo)

                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                End Using

                'Excelに描画
                ExportToExcel4(dt, keisu_flg)

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Mitsumori_Btn_Output1_Click")
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

    '見積書(機種)作成処理
    Private Sub ExportToExcel2(dt As DataTable, _keisu_flg As Boolean, _mode As Integer)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String
            Dim file_name As String

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(_mitsumoriNo)

            If _mode = 1 Then
                templatePath = IO.Path.Combine(Application.StartupPath, "Excel_Format\見積書(2R_ATV).xlsx")
                file_name = "見積書(2R_ATV)_" & nendo & "年度.xlsx"
            Else
                templatePath = IO.Path.Combine(Application.StartupPath, "Excel_Format\見積書(汎用機種).xlsx")
                file_name = "見積書(汎用機種)__" & nendo & "年度.xlsx"
            End If

            Dim dt_mitsumori As New DataTable
            Dim dt_keisu As New DS_M.DT_M_KeisuDataTable
            Dim ta_keisu As New DS_MTableAdapters.TA_M_Keisu
            Dim ta_rate As New DS_MTableAdapters.TA_M_Rate
            Dim keisu As Decimal = 0
            Dim rate As Decimal = ta_rate.Q_賃率取得

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = file_name,
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            '機種係数マスタの辞書作成
            ta_keisu.Fill(dt_keisu)
            Dim keisuDict As New Dictionary(Of String, Decimal)
            For Each dr As DataRow In dt_keisu.Rows
                Dim key As String = dr("仕向").ToString() & dr("機種").ToString() & dr("群").ToString()
                Dim value As Decimal = CDec(dr("係数"))
                If Not keisuDict.ContainsKey(key) Then
                    keisuDict(key) = value
                End If
            Next

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 18   ' R列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                If _mode = 1 Then
                    ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString & "　見積書(2R_ATV)")
                Else
                    ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString & "　見積書(汎用機種)")
                End If


                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    Dim shimuke As String = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    Dim kishu As String = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                    Dim type As String = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                    Dim gun As String = If(IsDBNull(row("Col6")), "", row("Col6").ToString)

                    Dim junbi_kousu As Decimal = If(IsDBNull(row("Col12")), 0, Decimal.Parse(row("Col12").ToString))
                    Dim kosou_kousu As Decimal = If(IsDBNull(row("Col13")), 0, Decimal.Parse(row("Col13").ToString))
                    Dim naisou_kousu As Decimal = If(IsDBNull(row("Col14")), 0, Decimal.Parse(row("Col14").ToString))
                    Dim gaisou_kousu As Decimal = If(IsDBNull(row("Col15")), 0, Decimal.Parse(row("Col15").ToString))
                    Dim choku_kousu As Decimal = If(IsDBNull(row("Col11")), 0, Decimal.Parse(row("Col11").ToString))

                    Dim shizai_hi As Decimal = If(IsDBNull(row("Col16")), 0, Decimal.Parse(row("Col16").ToString))
                    Dim koutin As Decimal = If(IsDBNull(row("Col17")), 0, Decimal.Parse(row("Col17").ToString))
                    Dim koutin_kanri_hi As Decimal = If(IsDBNull(row("Col18")), 0, Decimal.Parse(row("Col18").ToString))
                    Dim total_sum As Decimal = If(IsDBNull(row("Col19")), 0, Decimal.Parse(row("Col19").ToString))

                    '係数フラグが立っている場合
                    If _keisu_flg = True Then

                        '係数マスタを参照して存在すれば係数をかける
                        If keisuDict.ContainsKey(shimuke & kishu & gun) Then

                            keisu = keisuDict(shimuke & kishu & gun)

                            '各工数に係数をかける
                            junbi_kousu = junbi_kousu * keisu
                            kosou_kousu = kosou_kousu * keisu
                            naisou_kousu = naisou_kousu * keisu
                            gaisou_kousu = gaisou_kousu * keisu

                            '直接工数の計算をやり直す
                            choku_kousu = junbi_kousu + kosou_kousu + naisou_kousu + gaisou_kousu

                            koutin = Math.Round(choku_kousu * 1.1D * rate / 60D, 2, MidpointRounding.AwayFromZero)
                            koutin_kanri_hi = Math.Round(choku_kousu * 0.1D * rate / 60D, 2, MidpointRounding.AwayFromZero)
                            total_sum = shizai_hi + koutin + koutin_kanri_hi
                        End If

                    End If

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    ws.Cell(currentRow, 3).Value = kishu
                    ws.Cell(currentRow, 4).Value = type
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), "", row("Col6").ToString)
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), "", row("Col7").ToString)
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col8")), "", row("Col8").ToString)
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col9")), "", row("Col9").ToString)
                    ws.Cell(currentRow, 10).Value = choku_kousu
                    ws.Cell(currentRow, 11).Value = junbi_kousu
                    ws.Cell(currentRow, 12).Value = kosou_kousu
                    ws.Cell(currentRow, 13).Value = naisou_kousu
                    ws.Cell(currentRow, 14).Value = gaisou_kousu
                    ws.Cell(currentRow, 15).Value = shizai_hi
                    ws.Cell(currentRow, 16).Value = koutin
                    ws.Cell(currentRow, 17).Value = koutin_kanri_hi
                    ws.Cell(currentRow, 18).Value = total_sum

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
                Dim mergeRange = ws.Range(totalRow, 2, totalRow, 9) ' B=2, I=9
                mergeRange.Merge()
                mergeRange.Value = "合計"
                mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                mergeRange.Style.Fill.BackgroundColor = XLColor.LightGray
                mergeRange.Style.Font.Bold = True

                ' -------------------------------
                ' SUM関数を入れる
                ' -------------------------------
                For col As Integer = 10 To 18 ' J=10, R=18
                    Dim colLetter As String = ws.Column(col).ColumnLetter
                    ws.Cell(totalRow, col).FormulaA1 = $"=SUM({colLetter}{startRow}:{colLetter}{endRow})"
                    ws.Cell(totalRow, col).Style.Font.Bold = True
                    ws.Cell(totalRow, col).Style.Fill.BackgroundColor = XLColor.LightGray
                Next

                ' -------------------------------
                ' 集計行全体に罫線
                ' -------------------------------
                ws.Range(totalRow, 2, totalRow, 18).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range(totalRow, 2, totalRow, 18).Style.Border.InsideBorder = XLBorderStyleValues.Thin

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)


        Catch ex As Exception
            Throw
        End Try

    End Sub

    '見積書(部単内装)作成処理
    Private Sub ExportToExcel3(dt As DataTable, _keisu_flg As Boolean)

        Try

            Dim dt_keisu As New DS_M.DT_M_KeisuDataTable
            Dim ta_keisu As New DS_MTableAdapters.TA_M_Keisu
            Dim ta_rate As New DS_MTableAdapters.TA_M_Rate
            Dim keisu As Decimal = 0
            Dim rate As Decimal = ta_rate.Q_賃率取得

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\見積書(部単内装).xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(_mitsumoriNo)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "見積書(部単内装)_" & nendo & "年度.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            '機種係数マスタの辞書作成
            ta_keisu.Fill(dt_keisu)
            Dim keisuDict As New Dictionary(Of String, Decimal)
            For Each dr As DataRow In dt_keisu.Rows
                Dim key As String = dr("仕向").ToString() & dr("機種").ToString() & dr("群").ToString()
                Dim value As Decimal = CDec(dr("係数"))
                If Not keisuDict.ContainsKey(key) Then
                    keisuDict(key) = value
                End If
            Next

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 14   ' R列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString & "　見積書(部単内装)")

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), "", row("Col6").ToString)

                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), 0, Decimal.Parse(row("Col7").ToString))
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col8")), 0, Decimal.Parse(row("Col8").ToString))
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col9")), 0, Decimal.Parse(row("Col9").ToString))
                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col10")), 0, Decimal.Parse(row("Col10").ToString))
                    ws.Cell(currentRow, 11).Value = If(IsDBNull(row("Col11")), 0, Decimal.Parse(row("Col11").ToString))
                    ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Col12")), 0, Decimal.Parse(row("Col12").ToString))
                    ws.Cell(currentRow, 13).Value = If(IsDBNull(row("Col13")), 0, Decimal.Parse(row("Col13").ToString))
                    ws.Cell(currentRow, 14).Value = If(IsDBNull(row("Col14")), 0, Decimal.Parse(row("Col14").ToString))

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
                Dim mergeRange = ws.Range(totalRow, 2, totalRow, 6) ' B=2, F=6
                mergeRange.Merge()
                mergeRange.Value = "合計"
                mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                mergeRange.Style.Fill.BackgroundColor = XLColor.LightGray
                mergeRange.Style.Font.Bold = True

                ' -------------------------------
                ' SUM関数を入れる
                ' -------------------------------
                For col As Integer = 7 To 14 ' G=7, N=14
                    Dim colLetter As String = ws.Column(col).ColumnLetter
                    ws.Cell(totalRow, col).FormulaA1 = $"=SUM({colLetter}{startRow}:{colLetter}{endRow})"
                    ws.Cell(totalRow, col).Style.Font.Bold = True
                    ws.Cell(totalRow, col).Style.Fill.BackgroundColor = XLColor.LightGray
                Next

                ' -------------------------------
                ' 集計行全体に罫線
                ' -------------------------------
                ws.Range(totalRow, 2, totalRow, 14).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range(totalRow, 2, totalRow, 14).Style.Border.InsideBorder = XLBorderStyleValues.Thin

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    '見積書(部単外装)作成処理
    Private Sub ExportToExcel4(dt As DataTable, _keisu_flg As Boolean)

        Try

            Dim dt_keisu As New DS_M.DT_M_KeisuDataTable
            Dim ta_keisu As New DS_MTableAdapters.TA_M_Keisu
            Dim ta_rate As New DS_MTableAdapters.TA_M_Rate
            Dim keisu As Decimal = 0
            Dim rate As Decimal = ta_rate.Q_賃率取得

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\見積書(部単外装).xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(_mitsumoriNo)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "見積書(部単外装)_" & nendo & "年度.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }

            If sfd.ShowDialog() <> DialogResult.OK Then
                Return ' キャンセル
            End If

            Dim savePath As String = sfd.FileName

            '機種係数マスタの辞書作成
            ta_keisu.Fill(dt_keisu)
            Dim keisuDict As New Dictionary(Of String, Decimal)
            For Each dr As DataRow In dt_keisu.Rows
                Dim key As String = dr("仕向").ToString() & dr("機種").ToString() & dr("群").ToString()
                Dim value As Decimal = CDec(dr("係数"))
                If Not keisuDict.ContainsKey(key) Then
                    keisuDict(key) = value
                End If
            Next

            ' Excel 読み込み
            Using wb As New XLWorkbook(templatePath)

                Dim ws = wb.Worksheet(1)    ' 1枚目のシートと仮定

                Dim startRow As Integer = 5 ' データ開始行（ヘッダが1行目なら2）
                Dim startCol As Integer = 2  ' B列
                Dim endCol As Integer = 10   ' J列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString & "　見積書(部単外装)")

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                    'ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 5).Value = 1

                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), 0, Decimal.Parse(row("Col6").ToString))
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), 0, Decimal.Parse(row("Col7").ToString))
                    ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col8")), 0, Decimal.Parse(row("Col8").ToString))
                    ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col9")), 0, Decimal.Parse(row("Col9").ToString))
                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col9")), 0, Decimal.Parse(row("Col9").ToString))
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
                Dim mergeRange = ws.Range(totalRow, 2, totalRow, 4) ' B=2, D=4
                mergeRange.Merge()
                mergeRange.Value = "合計"
                mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                mergeRange.Style.Fill.BackgroundColor = XLColor.LightGray
                mergeRange.Style.Font.Bold = True

                ' -------------------------------
                ' SUM関数を入れる
                ' -------------------------------
                For row As Integer = startRow To endRow
                    ws.Cell(row, 10).FormulaA1 = $"=SUM(F{row},I{row})"
                Next

                For col As Integer = 5 To 10 ' E=5, J=10
                    Dim colLetter As String = ws.Column(col).ColumnLetter
                    ws.Cell(totalRow, col).FormulaA1 = $"=SUM({colLetter}{startRow}:{colLetter}{endRow})"
                    ws.Cell(totalRow, col).Style.Font.Bold = True
                    ws.Cell(totalRow, col).Style.Fill.BackgroundColor = XLColor.LightGray
                Next



                ' -------------------------------
                ' 集計行全体に罫線
                ' -------------------------------
                ws.Range(totalRow, 2, totalRow, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range(totalRow, 2, totalRow, 10).Style.Border.InsideBorder = XLBorderStyleValues.Thin

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)


        Catch ex As Exception
            Throw
        End Try

    End Sub


End Class