Imports System.Configuration
Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class F_Print_Sub_Housou

    Dim fnc As New Function_Class

    Private _mitsumoriNo As Integer
    Private _mode As Integer

    ' コンストラクタを追加
    Public Sub New(mitsumoriNo As Integer, mode As Integer)
        InitializeComponent()
        _mitsumoriNo = mitsumoriNo
        _mode = mode
    End Sub

    'ページロード時
    Private Sub F_Print_Sub_Housou_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'GridViewのフォントサイズ変更
            GV_Search.RowsDefaultCellStyle.Font = New Font("ＭＳ ゴシック", 14)
            GV_Search.ColumnHeadersDefaultCellStyle.Font = New Font("ＭＳ ゴシック", 14, FontStyle.Bold)

            '呼び出し元によってタイトル変更
            If _mode = 1 Then
                Me.Text = "包装仕様一覧_印刷"
                GV_Search.Columns("包装ロットNo").Visible = False
            Else
                Me.Text = "包装資材明細(定量、不定量共通)_印刷"
                GV_Search.Columns("包装ロットNo").Visible = True
            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Housou_F_Print_Sub_Housou_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '印刷ボタンクリック時
    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click

        Try

            Dim ta_1lot As New DS_TTableAdapters.TA_T_CCC_Lot

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Application.DoEvents()    ' ★ UIを即時更新

            Dim chk_flg As Boolean = True
            Dim chk_data As Integer = 0
            Dim chk_dt_ccc As New DataTable
            Dim chk_dt_kow As New DataTable
            Dim gv_flg As Boolean = False

            'コンフィグのコネクトストリング取得
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            'GVに入力された条件でそもそも1Lotに存在するかチェック
            For Each row As DataGridViewRow In GV_Search.Rows

                If row.IsNewRow Then Continue For

                Dim DIST As String = ""
                Dim nendo As String = ""
                Dim model As String = ""
                Dim type As String = ""
                Dim OP As String = ""
                Dim housou_lot_no As String = ""

                gv_flg = True

                If row.Cells("DIST").Value Is Nothing Then DIST = "" Else DIST = row.Cells("DIST").Value
                If row.Cells("年度").Value Is Nothing Then nendo = "" Else nendo = row.Cells("年度").Value
                If row.Cells("モデル").Value Is Nothing Then model = "" Else model = row.Cells("モデル").Value
                If row.Cells("タイプ").Value Is Nothing Then type = "" Else type = row.Cells("タイプ").Value
                If row.Cells("OP").Value Is Nothing Then OP = "" Else OP = row.Cells("OP").Value
                If row.Cells("包装ロットNo").Value Is Nothing Then housou_lot_no = "" Else housou_lot_no = row.Cells("包装ロットNo").Value

                '検索条件の必須チェック
                If DIST = "" Or nendo = "" Or model = "" Then
                    MessageBox.Show("DIST、年度、モデルは必須項目です。")
                    Exit Sub
                End If



                Dim CommandString As String

                'CCC1Lotの存在チェック
                'SQL作成
                If _mode = 1 Then
                    CommandString = MakeSQL_search(DIST, nendo, model, type, OP, "")
                Else
                    CommandString = MakeSQL_search(DIST, nendo, model, type, OP, housou_lot_no)
                End If

                'テーブルアダプター作成
                Dim DataAdapter As New SqlClient.SqlDataAdapter(CommandString, connectionString)

                'SQLを実行
                DataAdapter.Fill(chk_dt_ccc)

                If chk_dt_ccc.Rows.Count = 0 Then

                    MessageBox.Show("条件に一致する1Lotデータが存在しません。" & vbLf & "DIST: " & DIST & vbLf & "年度: " & nendo & vbLf & "モデル: " & model & vbLf & "タイプ: " & type & vbLf & "OP: " & OP)
                    Exit Sub
                End If

                ''Kowの存在チェック
                ''SQL作成
                'If _mode = 1 Then
                '    CommandString = MakeSQL_search_kow(nendo, model, type, OP, "")
                'Else
                '    CommandString = MakeSQL_search_kow(nendo, model, type, OP, housou_lot_no)
                'End If

                ''テーブルアダプター作成
                'Dim DataAdapter2 As New SqlClient.SqlDataAdapter(CommandString, connectionString)

                ''SQLを実行
                'DataAdapter2.Fill(chk_dt_kow)

                'If chk_dt_kow.Rows.Count = 0 Then

                '    MessageBox.Show("条件に一致するKowデータが存在しません。" & vbLf & "DIST: " & DIST & vbLf & "年度: " & nendo & vbLf & "モデル: " & model & vbLf & "タイプ: " & type & vbLf & "OP: " & OP)
                '    Exit Sub
                'End If

            Next

            If gv_flg = False Then
                MessageBox.Show("条件を入力してください。")
                Exit Sub
            End If

            Dim dt As New DataTable
            Dim ds As New DataSet()
            Dim dt_result As New DataTable
            Dim dt_kosou As New DataTable
            Dim dt_naisou As New DataTable
            Dim dt_gaisou As New DataTable

            '呼び出し元によってキックするストアドを変更
            If _mode = 1 Then

                ' ストアド実行
                Using conn As New SqlConnection(connectionString)

                    '入力された行数分実行する
                    For Each row As DataGridViewRow In GV_Search.Rows

                        If row.IsNewRow Then Continue For

                        Using cmd As New SqlCommand("Proc5_包装仕様一覧", conn)
                            cmd.CommandTimeout = 1200
                            cmd.CommandType = CommandType.StoredProcedure

                            ' ★引数セット（毎回クリアされる）
                            cmd.Parameters.Add("@Debug", SqlDbType.Bit).Value = 0
                            cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = _mitsumoriNo
                            cmd.Parameters.Add("@Dist", SqlDbType.NVarChar, 100).Value = If(row.Cells("DIST").Value Is Nothing, DBNull.Value, row.Cells("DIST").Value)
                            cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 100).Value = If(row.Cells("年度").Value Is Nothing, DBNull.Value, row.Cells("年度").Value)
                            cmd.Parameters.Add("@Model", SqlDbType.NVarChar, 100).Value = If(row.Cells("モデル").Value Is Nothing, DBNull.Value, row.Cells("モデル").Value)
                            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 100).Value = If(row.Cells("タイプ").Value Is Nothing, DBNull.Value, row.Cells("タイプ").Value)
                            cmd.Parameters.Add("@Op", SqlDbType.NVarChar, 100).Value = If(row.Cells("OP").Value Is Nothing, DBNull.Value, row.Cells("OP").Value)

                            Dim da As New SqlDataAdapter(cmd)
                            da.Fill(ds)

                        End Using

                    Next

                    dt_result = ds.Tables(0)
                    dt_kosou = ds.Tables(1)
                    dt_naisou = ds.Tables(2)
                    dt_gaisou = ds.Tables(3)

                    'Excelに描画
                    ExportToExcel1(dt_result, dt_kosou, dt_naisou, dt_gaisou)

                End Using
            Else
                ' ストアド実行
                Using conn As New SqlConnection(connectionString)

                    '入力された行数分実行する
                    For Each row As DataGridViewRow In GV_Search.Rows

                        If row.IsNewRow Then Continue For

                        Using cmd As New SqlCommand("Proc6_包装資材明細", conn)
                            cmd.CommandTimeout = 1200
                            cmd.CommandType = CommandType.StoredProcedure

                            ' ★引数セット（毎回クリアされる）
                            cmd.Parameters.Add("@Debug", SqlDbType.Bit).Value = 0
                            cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = _mitsumoriNo
                            cmd.Parameters.Add("@Dist", SqlDbType.NVarChar, 100).Value = If(row.Cells("DIST").Value Is Nothing, DBNull.Value, row.Cells("DIST").Value)
                            cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 100).Value = If(row.Cells("年度").Value Is Nothing, DBNull.Value, row.Cells("年度").Value)
                            cmd.Parameters.Add("@Model", SqlDbType.NVarChar, 100).Value = If(row.Cells("モデル").Value Is Nothing, DBNull.Value, row.Cells("モデル").Value)
                            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 100).Value = If(row.Cells("タイプ").Value Is Nothing, DBNull.Value, row.Cells("タイプ").Value)
                            cmd.Parameters.Add("@Op", SqlDbType.NVarChar, 100).Value = If(row.Cells("OP").Value Is Nothing, DBNull.Value, row.Cells("OP").Value)
                            cmd.Parameters.Add("@Lot", SqlDbType.NVarChar, 100).Value = If(row.Cells("包装ロットNo").Value Is Nothing, DBNull.Value, row.Cells("包装ロットNo").Value)

                            Dim da As New SqlDataAdapter(cmd)
                            da.Fill(dt)

                        End Using

                    Next

                    'Excelに描画
                    ExportToExcel2(dt)

                End Using

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Housou_Btn_Print_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '******************************************************************************
    'GVイベント
    '******************************************************************************

    'リンクがクリックされたら
    Private Sub GV_Search_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Search.CellContentClick

        Try

            ' ヘッダー（-1）の時などは無視
            If e.RowIndex < 0 Then Exit Sub

            ' コピー列かどうかを判定
            If GV_Search.Columns(e.ColumnIndex).Name = "コピー" Then

                ' 元の行を取得
                Dim sourceRow As DataGridViewRow = GV_Search.Rows(e.RowIndex)

                ' 新規行を作成
                Dim newIndex As Integer = GV_Search.Rows.Add()
                Dim newRow As DataGridViewRow = GV_Search.Rows(newIndex)

                ' セルをコピー（リンク列以外）
                For i As Integer = 0 To GV_Search.Columns.Count - 1
                    If GV_Search.Columns(i).Name <> "コピー" Then
                        newRow.Cells(i).Value = sourceRow.Cells(i).Value
                    End If
                Next

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Housou_GV_Search_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    '******************************************************************************
    '関数
    '******************************************************************************

    '包装仕様一覧作成処理
    Private Sub ExportToExcel1(_dt_result As DataTable, _dt_kosou As DataTable, _dt_naisou As DataTable, _dt_gaisou As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\包装仕様一覧.xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(_mitsumoriNo)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "包装仕様一覧_" & nendo & "年度.xlsx",
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
                Dim endCol As Integer = 17   ' Q列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(_dt_result.Rows(0)(0)), "", "■" & _dt_result.Rows(0)(0).ToString)
                ws.Cell(2, 7).Value = If(IsDBNull(_dt_result.Rows(0)(1)), "", _dt_result.Rows(0)(1).ToString)
                ws.Cell(2, 10).Value = If(IsDBNull(_dt_result.Rows(0)(2)), "", _dt_result.Rows(0)(2).ToString)
                ws.Cell(2, 13).Value = If(IsDBNull(_dt_result.Rows(0)(3)), "", _dt_result.Rows(0)(3).ToString)

                Dim old_value As String = ""
                Dim new_value As String = ""

                '親DTの行数
                Dim dt_row_count As Integer = 1

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In _dt_result.Rows

                    new_value = If(IsDBNull(row("Col2")), "", row("Col2").ToString) &
                        If(IsDBNull(row("Col3")), "", row("Col3").ToString) &
                        If(IsDBNull(row("Col4")), "", row("Col4").ToString) &
                        If(IsDBNull(row("Col5")), "", row("Col5").ToString) &
                        If(IsDBNull(row("Col6")), "", row("Col6").ToString) &
                        If(IsDBNull(row("Col7")), "", row("Col7").ToString) &
                        If(IsDBNull(row("Col8")), "", row("Col8").ToString) &
                        If(IsDBNull(row("Col9")), "", row("Col9").ToString)

                    '同じ値の場合は出力しない
                    If old_value <> new_value Then


                    End If

                    ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                    ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col6")), "", row("Col6").ToString)
                    ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col7")), "", row("Col7").ToString)
                    ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col8")), "", row("Col8").ToString)
                    ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col9")), "", row("Col9").ToString)
                    ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col10")), 0, Integer.Parse(row("Col10").ToString))
                    'ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col11")), 0, Integer.Parse(row("Col11").ToString))
                    'ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col12")), "", row("Col12").ToString)
                    'ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col13")), 0, Integer.Parse(row("Col13").ToString))
                    'ws.Cell(currentRow, 11).Value = If(IsDBNull(row("Col14")), "", row("Col14").ToString)
                    'ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Col15")), "", row("Col15").ToString)

                    'ws.Cell(currentRow, 13).Value = If(IsDBNull(row("Col17")), "", row("Col17").ToString)
                    'ws.Cell(currentRow, 14).Value = If(IsDBNull(row("Col18")), 0, Integer.Parse(row("Col18").ToString))
                    'ws.Cell(currentRow, 15).Value = If(IsDBNull(row("Col19")), 0, Integer.Parse(row("Col19").ToString))
                    'ws.Cell(currentRow, 16).Value = If(IsDBNull(row("Col20")), "", row("Col20").ToString)
                    'ws.Cell(currentRow, 17).Value = If(IsDBNull(row("Col21")), 0, Integer.Parse(row("Col21").ToString))

                    Dim kosou_row = 0
                    Dim naisou_row = 0
                    Dim gaisou_row = 0
                    Dim meisai_max_row = 0

                    '個装の明細表示
                    kosou_row = currentRow

                    Dim childRows = _dt_kosou.AsEnumerable().
                    Where(Function(r) r.Field(Of Integer)("GroupNo") = dt_row_count)

                    For Each cRow In childRows

                        ' 子DTの値を取得
                        Dim val1 As String = cRow("Col1")
                        Dim val2 As Decimal = cRow("Col2")
                        Dim val3 As Decimal = cRow("Col3")
                        Dim val4 As Decimal = cRow("Col4")

                        ' 処理
                        ws.Cell(kosou_row, 8).Value = val1
                        ws.Cell(kosou_row, 9).Value = val2
                        ws.Cell(kosou_row, 10).Value = val3
                        ws.Cell(kosou_row, 11).Value = val4

                        kosou_row += 1

                    Next

                    meisai_max_row = kosou_row



                    '内装の明細表示



                    '外装の明細表示



                    '書き込む行数を再設定する
                    If currentRow < meisai_max_row Then
                        currentRow = meisai_max_row
                    End If

                    currentRow += 1

                    old_value = new_value

                Next

                ' -------------------------------
                ' B5:R最終行まで罫線
                ' -------------------------------
                Dim endRow As Integer = currentRow - 1
                Dim range = ws.Range(startRow, startCol, endRow, endCol)

                ' 全体罫線
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin

                ' Excel 保存
                wb.SaveAs(savePath)

            End Using

            MessageBox.Show("Excel へ出力しました：" & vbCrLf & savePath)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    '包装資材明細(定量、不定量共通)作成処理
    Private Sub ExportToExcel2(dt As DataTable)

        Try

            ' プロジェクト内テンプレートのパス
            Dim templatePath As String = IO.Path.Combine(Application.StartupPath, "Excel_Format\包装資材明細(定量、不定量共通).xlsx")

            'ファイル名に付ける年度の取得
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim nendo As String = ta_ccc.Q_年度取得(_mitsumoriNo)

            ' -------------------------
            ' 保存ダイアログ
            ' -------------------------
            Dim sfd As New SaveFileDialog With {
            .Title = "Excelファイルの保存",
            .Filter = "Excelファイル (*.xlsx)|*.xlsx",
            .FileName = "包装資材明細(定量、不定量共通)_" & nendo & "年度.xlsx",
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
                Dim endCol As Integer = 14   ' R列
                Dim currentRow As Integer = startRow

                'ヘッダ項目を書き込む
                ws.Cell(2, 2).Value = If(IsDBNull(dt.Rows(0)(0)), "", "■" & dt.Rows(0)(0).ToString)

                Dim old_value As String = ""
                Dim new_value As String = ""

                ' DataTable の中身を Excel に書き込む
                For Each row As DataRow In dt.Rows

                    new_value = If(IsDBNull(row("Col2")), "", row("Col2").ToString) &
                        If(IsDBNull(row("Col3")), "", row("Col3").ToString) &
                        If(IsDBNull(row("Col4")), "", row("Col4").ToString) &
                        If(IsDBNull(row("Col5")), "", row("Col5").ToString) &
                        If(IsDBNull(row("Col6")), "", row("Col6").ToString) &
                        If(IsDBNull(row("Col7")), "", row("Col7").ToString) &
                        If(IsDBNull(row("Col8")), "", row("Col8").ToString) &
                        If(IsDBNull(row("Col9")), "", row("Col9").ToString)

                    '同じ値の場合は出力しない
                    If old_value <> new_value Then

                        ws.Cell(currentRow, 2).Value = If(IsDBNull(row("Col2")), "", row("Col2").ToString)
                        ws.Cell(currentRow, 3).Value = If(IsDBNull(row("Col3")), "", row("Col3").ToString)
                        ws.Cell(currentRow, 4).Value = If(IsDBNull(row("Col4")), "", row("Col4").ToString)
                        ws.Cell(currentRow, 5).Value = If(IsDBNull(row("Col5")), "", row("Col5").ToString)
                        ws.Cell(currentRow, 6).Value = If(IsDBNull(row("Col6")), "", row("Col6").ToString)
                        ws.Cell(currentRow, 7).Value = If(IsDBNull(row("Col7")), "", row("Col7").ToString)
                        ws.Cell(currentRow, 8).Value = If(IsDBNull(row("Col8")), "", row("Col8").ToString)
                        ws.Cell(currentRow, 9).Value = If(IsDBNull(row("Col9")), "", row("Col9").ToString)

                    End If

                    ws.Cell(currentRow, 10).Value = If(IsDBNull(row("Col10")), "", row("Col10").ToString)
                    ws.Cell(currentRow, 11).Value = If(IsDBNull(row("Col11")), "", row("Col11").ToString)
                    ws.Cell(currentRow, 12).Value = If(IsDBNull(row("Col12")), 0, Decimal.Parse(row("Col12").ToString))
                    ws.Cell(currentRow, 13).Value = If(IsDBNull(row("Col13")), 0, Decimal.Parse(row("Col13").ToString))
                    ws.Cell(currentRow, 14).Value = If(IsDBNull(row("Col14")), 0, Decimal.Parse(row("Col14").ToString))

                    currentRow += 1

                    old_value = new_value

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
                ' B列～K列を結合して「合計」文字
                ' -------------------------------
                Dim mergeRange = ws.Range(totalRow, 2, totalRow, 13) ' B=2, M=13
                mergeRange.Merge()
                mergeRange.Value = "合計"
                mergeRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                mergeRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                mergeRange.Style.Fill.BackgroundColor = XLColor.LightGray
                mergeRange.Style.Font.Bold = True

                ' -------------------------------
                ' SUM関数を入れる
                ' -------------------------------
                For col As Integer = 14 To 14 ' N=14, N=14
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

    '**********************************************************************************
    '共通関数
    '**********************************************************************************

    'ccc_検索用SQL作成処理
    Function MakeSQL_search(_DIST, _nendo, _model, _type, _OP, _housou_lot_no) As String
        Try

            Dim strtemp As String = Nothing
            Dim Retstr As String = Nothing

            'Where区作成
            strtemp = " 見積No = " & _mitsumoriNo & " AND 代表DIST = '" & _DIST & "' AND 年度2 = '" & _nendo & "' AND モデル2 = '" & _model & "'"


            'タイプ
            If (_type.Length > 0) Then
                strtemp = strtemp & " AND タイプ1 = '" & _type & "'"
            End If

            'OP
            If (_OP.Length > 0) Then
                strtemp = strtemp & " AND オプション1 = '" & _OP & "'"
            End If

            '包装ロットNo
            If (_housou_lot_no.Length > 0) Then
                strtemp = strtemp & " AND 包装ロットNo = '" & _housou_lot_no & "'"
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM T_CCC_Lot"
            Retstr = Retstr & strtemp       'Where句


            Return Retstr

        Catch ex As Exception
            Throw New Exception("SQL作成時にエラーが発生しました。")

        End Try

    End Function

    'kow_検索用SQL作成処理
    Function MakeSQL_search_kow( _nendo, _model, _type, _OP, _housou_lot_no) As String
        Try

            Dim strtemp As String = Nothing
            Dim Retstr As String = Nothing

            'Where区作成
            strtemp = " 見積No = " & _mitsumoriNo & " AND 年度 = '" & _nendo & "' AND モデル = '" & _model & "'"

            'タイプ
            If (_type.Length > 0) Then
                strtemp = strtemp & " AND タイプ = '" & _type & "'"
            End If

            'OP
            If (_OP.Length > 0) Then
                strtemp = strtemp & " AND オプション = '" & _OP & "'"
            End If

            '包装ロットNo
            If (_housou_lot_no.Length > 0) Then
                strtemp = strtemp & " AND 包装ロットNo = '" & _housou_lot_no & "'"
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM T_KOW46"
            Retstr = Retstr & strtemp       'Where句


            Return Retstr

        Catch ex As Exception
            Throw New Exception("SQL作成時にエラーが発生しました。")

        End Try

    End Function

End Class