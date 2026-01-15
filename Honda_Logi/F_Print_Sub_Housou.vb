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

                    'ケースNo違いで同一レコードが発生するので重複を削除
                    Dim dv As New DataView(dt_result)
                    Dim distinctDT As DataTable = dv.ToTable(True)

                    '後の処理の為に行番号を付与
                    Dim no As Integer = 1
                    For Each row As DataRow In distinctDT.Rows
                        row("Col11") = no
                        no += 1
                    Next

                    '個装、内装、外装の各データを検索する
                    lord_data(distinctDT, dt_kosou, dt_naisou, dt_gaisou)


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


    '包装資材明細(定量、不定量共通)作成処理
    Private Sub lord_data(_dt_ccc As DataTable, ByRef dt_kosou As DataTable, ByRef dt_naisou As DataTable, ByRef dt_gaisou As DataTable)

        Try

            Dim dt_kow As New DS_T.DT_T_KOW46DataTable
            Dim ta_kow As New DS_TTableAdapters.DT_T_KOW46TableAdapter
            Dim dt_housou_kbn As New DS_M.DT_M_Housou_KbnDataTable
            Dim ta_housou_kbn As New DS_MTableAdapters.TA_M_Housou_Kbn
            Dim dt_M_naisou As New DS_M.DT_M_Naisou_ShizaiDataTable
            Dim ta_M_naisou As New DS_MTableAdapters.TA_M_Naisou_Shizai
            Dim dt_M_kosou As New DS_M.DT_M_Kosou_ShizaiDataTable
            Dim ta_M_kosou As New DS_MTableAdapters.TA_M_Kosou_Shizai


            'CCC辞書
            Dim search_ccc_Dict As New Dictionary(Of String, List(Of F_Make_1Lot.CCCInfo))(StringComparer.Ordinal)

            ' まず DataRow 配列にする（高速化）
            Dim rows_kow3 As DataRow() = _dt_ccc.Select()

            For Each dr As DataRow In rows_kow3

                Dim key As String = String.Concat(
                SafeGetString(dr, "年度"),
                SafeGetString(dr, "モデル"),
                SafeGetString(dr, "タイプ"),
                SafeGetString(dr, "オプション"),
                SafeGetString(dr, "MUDULE"),
                SafeGetString(dr, "モジュール手順SEQ")
            )

                Dim info As New F_Make_1Lot.CCCInfo With {
                    .年度2 = SafeGetString(dr, "年度"),
                    .モデル2 = SafeGetString(dr, "モデル"),
                    .タイプ1 = SafeGetString(dr, "タイプ"),
                    .オプション1 = SafeGetString(dr, "オプション"),
                    .ｺﾝﾄﾛｰﾙNO = SafeGetString(dr, "MUDULE"),
                    .モジュール手順SEQ = SafeGetString(dr, "モジュール手順SEQ"),
                    .部品収容数 = SafeGetString(dr, "部品収容数")
                }

                ' 辞書に追加
                If Not search_ccc_Dict.ContainsKey(key) Then
                    search_ccc_Dict(key) = New List(Of F_Make_1Lot.CCCInfo)
                End If

                search_ccc_Dict(key).Add(info)

            Next

            'KOW辞書
            ta_kow.Q_KOW取得(dt_kow, _mitsumoriNo)
            Dim search_KOW_Dict As New Dictionary(Of String, List(Of F_Make_1Lot.KowInfo))(StringComparer.Ordinal)

            ' まず DataRow 配列にする（高速化）
            Dim rows_kow As DataRow() = dt_kow.Select()
            For Each dr As DataRow In rows_kow
                Dim key As String = String.Concat(
                SafeGetString(dr, "年度"),
                SafeGetString(dr, "モデル"),
                SafeGetString(dr, "タイプ"),
                SafeGetString(dr, "MUDULE")
            )

                Dim info As New F_Make_1Lot.KowInfo With {
                    .包装ロットNo = SafeGetString(dr, "包装ロットNo"),
                    .MUDULE = SafeGetString(dr, "MUDULE"),
                    .本C_No = SafeGetString(dr, "本C_No"),
                    .内装手順 = SafeGetString(dr, "内装手順"),
                    .手順識別 = SafeGetString(dr, "手順識別"),
                    .資材規格 = SafeGetString(dr, "資材規格"),
                    .使用数 = SafeGetString(dr, "使用数"),
                    .主資材 = SafeGetString(dr, "主資材"),
                    .その他1 = SafeGetString(dr, "その他1"),
                    .その他2 = SafeGetString(dr, "その他2"),
                    .年度 = SafeGetString(dr, "年度"),
                    .モデル = SafeGetString(dr, "モデル"),
                    .タイプ = SafeGetString(dr, "タイプ"),
                    .オプション = SafeGetString(dr, "オプション"),
                    .資材単価表示 = SafeGetString(dr, "資材単価表示"),
                    .資材費 = SafeGetString(dr, "資材費"),
                    .ケース当たりの内装資材費 = SafeGetString(dr, "ケース当たりの内装資材費"),
                    .ケース当たりの外装資材費 = SafeGetDecimal(dr, "ケース当たりの外装資材費"),
                    .内装入数_カートン数 = SafeGetDecimal(dr, "内装入数_カートン数"),
                    .ケース内必要資材数 = SafeGetString(dr, "ケース内必要資材数"),
                    .取込年月 = SafeGetDecimal(dr, "取込年月"),
                    .見積No = SafeGetString(dr, "見積No")
                }



                ' 辞書に追加
                If Not search_KOW_Dict.ContainsKey(key) Then
                    search_KOW_Dict(key) = New List(Of F_Make_1Lot.KowInfo)
                End If

                search_KOW_Dict(key).Add(info)
            Next


            'KOW辞書_存在チェック用
            Dim kowExistSet As New HashSet(Of String)(StringComparer.Ordinal)

            For Each dr As DataRow In dt_kow.Rows
                Dim existKey As String = String.Concat(
                                                        SafeGetString(dr, "年度"),
                                                        SafeGetString(dr, "モデル"),
                                                        SafeGetString(dr, "タイプ"),
                                                        SafeGetString(dr, "オプション"),
                                                        SafeGetString(dr, "MUDULE"),
                                                        SafeGetString(dr, "内装手順")
                                                      )

                kowExistSet.Add(existKey)
            Next

            '個装内装登録早見表マスタの辞書作成
            ta_housou_kbn.Fill(dt_housou_kbn)
            Dim housouDict As New Dictionary(Of String, List(Of String))()

            For Each dr As DataRow In dt_housou_kbn.Rows
                Dim key As String = dr("DIST").ToString()
                Dim value As String = dr("個装内装区分").ToString()

                If Not housouDict.ContainsKey(key) Then
                    housouDict(key) = New List(Of String)
                End If

                housouDict(key).Add(value)
            Next

            '内装資材マスタの辞書作成
            ta_M_naisou.Fill(dt_M_naisou)
            Dim naisouDict As New Dictionary(Of String, Decimal)
            For Each dr As DataRow In dt_M_naisou.Rows
                Dim key As String = dr("内装資材コード").ToString()
                Dim value As Decimal = CDec(dr("数量"))
                If Not naisouDict.ContainsKey(key) Then
                    naisouDict(key) = value
                End If
            Next

            '個装資材マスタの辞書作成
            ta_M_kosou.Fill(dt_M_kosou)
            Dim kosouDict As New Dictionary(Of String, String)
            For Each dr As DataRow In dt_M_kosou.Rows
                Dim key As String = dr("個装資材コード").ToString()
                Dim value As String = dr("個装資材コード").ToString()
                If Not kosouDict.ContainsKey(key) Then
                    kosouDict(key) = value
                End If
            Next



            For Each row In _dt_ccc.Rows

                '内装か外装かを判別する
                Dim housou_kbn As String = ""
                Dim distKey As String = row("Col2").ToString

                If Not String.IsNullOrEmpty(distKey) AndAlso housouDict.ContainsKey(distKey) Then
                    ' 複数件をカンマ区切りで連結
                    housou_kbn = String.Join(",", housouDict(distKey))
                End If


                '個装内装両方登録されている場合
                If housou_kbn = "個装,内装" Or housou_kbn = "内装,個装" Then

                    '117:「包装ライン/外装」にMが含まれていれば個装
                    Dim housou_line As String = SafeGetString(row, "包装ライン_外装")

                    If housou_line.Contains("M") Then
                        housou_kbn = "個装"
                    Else
                        housou_kbn = "内装"
                    End If

                End If

                '********************************************************
                '個装データの収集処理
                '********************************************************

                Dim kowKey As String = String.Concat(
                                                        SafeGetString(row, "年度"),
                                                        SafeGetString(row, "モデル"),
                                                        SafeGetString(row, "タイプ"),
                                                        SafeGetString(row, "MUDULE")
                                                    )

                Dim kowKey_exit As String = String.Concat(
                                                        SafeGetString(row, "年度"),
                                                        SafeGetString(row, "モデル"),
                                                        SafeGetString(row, "タイプ"),
                                                        SafeGetString(row, "オプション"),
                                                        SafeGetString(row, "MUDULE"),
                                                        SafeGetString(row, "モジュール手順SEQ")
                                                    )

                If housou_kbn = "個装" Then




                    If Not kowExistSet.Contains(kowKey_exit) Then
                        Continue For ' KOWなし
                    End If



                    If Not search_KOW_Dict.ContainsKey(kowKey) Then Continue For

                    '========================
                    ' KOW抽出 → 最小包装ロット
                    '========================
                    Dim kowList = search_KOW_Dict(kowKey)


                    Dim minLot As String = kowList.Min(Function(x) x.包装ロットNo)

                    Dim targetKow =
                        kowList.
                            Where(Function(x) x.包装ロットNo = minLot).
                            OrderBy(Function(x) x.内装手順).
                            ToList()

                    '========================
                    ' KOW処理開始
                    '========================
                    Dim i As Integer = 0

                    While i < targetKow.Count

                        Dim k = targetKow(i)

                        ' 個装資材マスタ存在チェック
                        If Not kosouDict.ContainsKey(k.資材規格) Then
                            i += 1
                            Continue While
                        End If

                        '========================
                        ' 主資材が出るまでスキップ
                        '========================
                        If String.IsNullOrEmpty(k.主資材) Then
                            i += 1
                            Continue While
                        End If


                        '元ネタのCCCより部品収容数を逆引き
                        Dim hitList As List(Of F_Make_1Lot.CCCInfo) = Nothing

                        ' 検索用複合キー
                        Dim cccKey As String = String.Concat(
                                                        k.年度,
                                                        k.モデル,
                                                        k.タイプ,
                                                        k.オプション,
                                                        k.MUDULE,
                                                       k.内装手順
                                                    )
                        Dim buhin_shuyou_su As String = ""

                        'CCCに存在するかチェック
                        If search_ccc_Dict.TryGetValue(cccKey, hitList) Then

                            '存在する
                            For Each info In hitList

                                buhin_shuyou_su = info.部品収容数

                                'CCCで複数件ヒットしても1件分で十分
                                Exit For

                            Next

                        End If





                        '========================
                        ' 上段（主資材）表示
                        '========================
                        Dim baseNaisouNo As String = k.内装手順

                        '--- 上段行追加 ---
                        Dim rowTop As DataRow = dt_kosou.NewRow()
                        rowTop("GroupNo") = row("Col11")
                        rowTop("Col11") = ""
                        rowTop("Col12") = k.資材規格
                        rowTop("Col13") = buhin_shuyou_su
                        rowTop("Col14") = ""
                        dt_kosou.Rows.Add(rowTop)

                        i += 1

                        '========================
                        ' 下段表示（次の主資材が出るまで）
                        '========================
                        While i < targetKow.Count

                            Dim nextK = targetKow(i)

                            ' 内装手順が変わったら終了
                            If nextK.内装手順 <> baseNaisouNo Then Exit While

                            ' 次の主資材が出たら終了
                            If Not String.IsNullOrEmpty(nextK.主資材) Then Exit While

                            '--- 下段行追加 ---
                            Dim rowSub As DataRow = dt_kosou.NewRow()
                            rowSub("GroupNo") = row("Col11")
                            rowSub("Col11") = ""
                            rowSub("Col12") = nextK.資材規格
                            rowSub("Col13") = nextK.使用数
                            rowSub("Col14") = ""
                            dt_kosou.Rows.Add(rowSub)

                            i += 1
                        End While


                    End While

                End If


                Dim test = 123

                '********************************************************
                '内装データの収集処理
                '********************************************************




                '********************************************************
                '外装データの収集処理
                '********************************************************




            Next

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Print_Sub_Housou_lord_data")
            Throw
        End Try

    End Sub

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
    Function MakeSQL_search_kow(_nendo, _model, _type, _OP, _housou_lot_no) As String
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

    ' ---- ヘルパー関数（Null 安全に値を取り出す） ----
    Private Function SafeGetString(row As DataRow, colName As String) As String
        If row.Table.Columns.Contains(colName) = False Then Return String.Empty
        If IsDBNull(row(colName)) Then Return String.Empty
        Return row(colName).ToString().Trim()
    End Function

    Private Function SafeGetDecimal(row As DataRow, colName As String, Optional defaultValue As Decimal = 0D) As Decimal
        If row.Table.Columns.Contains(colName) = False Then Return defaultValue
        If IsDBNull(row(colName)) Then Return defaultValue
        Dim v As Decimal = 0D
        If Decimal.TryParse(row(colName).ToString(), v) Then
            Return v
        Else
            Return defaultValue
        End If
    End Function

End Class