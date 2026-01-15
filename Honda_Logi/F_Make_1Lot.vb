Imports System.Configuration
Imports System.Data.SqlClient

Public Class F_Make_1Lot

    Dim fnc As New Function_Class

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    '変換ボタンクリック時
    Private Sub Btn_Change_Click(sender As Object, e As EventArgs) Handles Btn_Change.Click

        '待機状態
        Cursor.Current = Cursors.WaitCursor
        Lbl_Messege.Visible = True
        Lbl_Messege.Text = "変換中"
        Application.DoEvents()    ' ★ UIを即時更新

        Try
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC
            Dim ta_ccc_1lot As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim ta_ccc_work As New DS_TTableAdapters.TA_T_CCC_Work
            Dim ta_rireki As New DS_TTableAdapters.TA_T_Inport_Rireki
            Dim ta_second As New DS_MTableAdapters.TA_M_Second
            Dim ta_M_naisou As New DS_MTableAdapters.TA_M_Naisou_Shizai

            '対象見積No取得　CCCから最大値取得（全トランの見積Noは揃っているはず）　
            Dim target_mitsumori_no As String = ta_ccc.Q_Max見積No取得
            Dim one_lot_count As String = ""

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            '①workテーブルにグループバイしたデータをインサート

            'SQL生成
            Dim sql As String = MakeSQL(target_mitsumori_no)
            Dim make_1lot_sql As String = MakeSQL2(target_mitsumori_no)
            Dim master_delete_sql As String = MakeSQL3(target_mitsumori_no)
            Dim master_insert_sql As String = MakeSQL4(target_mitsumori_no)
            Dim ccc_update_sql As String = ""
            Dim kow_update_sql As String = ""

            ' SQL実行
            Using conn As New SqlConnection(connectionString)

                conn.Open()

                ' トランザクション開始
                Dim transaction As SqlTransaction = conn.BeginTransaction()

                'TAを使えるように接続とトランザクション情報をセットする
                ta_ccc_1lot.Connection = conn
                ta_ccc_1lot.Transaction = transaction
                ta_ccc_work.Connection = conn
                ta_ccc_work.Transaction = transaction
                ta_rireki.Connection = conn
                ta_rireki.Transaction = transaction
                ta_second.Connection = conn
                ta_second.Transaction = transaction

                '後で必要な工数（秒数）を取得しておく
                Dim panel_case As String = ta_second.Q_工数取得(10)
                Dim sukashi_case As String = ta_second.Q_工数取得(11)
                Dim gaisou_danboru As String = ta_second.Q_工数取得(12)
                Dim gaisou_pori As String = ta_second.Q_工数取得(13)
                Dim gaisou_bolt As String = ta_second.Q_工数取得(14)
                Dim gaisou_fukushizai As String = ta_second.Q_工数取得(15)
                Dim gaichoku_bousabi As String = ta_second.Q_工数取得(17)
                Dim gaichoku_case As String = ta_second.Q_工数取得(18)

                'Update用SQL作成
                ccc_update_sql = MakeSQL5(target_mitsumori_no, panel_case, sukashi_case, gaisou_danboru, gaisou_pori, gaisou_bolt, gaisou_fukushizai, gaichoku_bousabi, gaichoku_case)
                kow_update_sql = MakeSQL6(target_mitsumori_no)

                Try
                    '*******************
                    '①Workテーブル
                    '*******************

                    'workテーブルのDELETE実行
                    ta_ccc_work.Q_work削除()

                    'cccテーブルのデータをGroupByしてworkテーブルにインサート
                    Using cmdIns As New SqlCommand(sql, conn, transaction)
                        Dim rowsAffected As Integer = cmdIns.ExecuteNonQuery()
                    End Using

                    '*******************
                    '②マスタ系テーブル
                    '*******************

                    '該当見積Noのデータはデリート
                    Using cmd_master_del As New SqlCommand(master_delete_sql, conn, transaction)
                        Dim rowsAffected As Integer = cmd_master_del.ExecuteNonQuery()
                    End Using


                    'インサート処理
                    Using cmd_master_insert As New SqlCommand(master_insert_sql, conn, transaction)
                        Dim rowsAffected As Integer = cmd_master_insert.ExecuteNonQuery()
                    End Using

                    '*******************
                    '③1lotテーブル
                    '*******************

                    '1lotテーブルにすでに最新の見積Noが存在するかチェック
                    one_lot_count = ta_ccc_1lot.Q_見積No_存在チェック(target_mitsumori_no)

                    '存在するなら該当見積Noのデータはデリート
                    If one_lot_count > 0 Then
                        ta_ccc_1lot.Q_1lot_削除(target_mitsumori_no)
                    End If

                    ' 必要情報を関連テーブルから収集して本番テーブルへインサート
                    Using cmdIns2 As New SqlCommand(make_1lot_sql, conn, transaction)
                        Dim rowsAffected As Integer = cmdIns2.ExecuteNonQuery()
                    End Using

                    'SQLでUpdate
                    Using cmdUp1 As New SqlCommand(ccc_update_sql, conn, transaction)
                        Dim rowsAffected As Integer = cmdUp1.ExecuteNonQuery()
                    End Using

                    ' さらに複雑なものの更新処理
                    change_1lot(conn, transaction, target_mitsumori_no)

                    '*******************
                    '④KOWテーブル
                    '*******************
                    Using cmdUp_kow As New SqlCommand(kow_update_sql, conn, transaction)
                        Dim rowsAffected As Integer = cmdUp_kow.ExecuteNonQuery()
                    End Using

                    ' さらに複雑なものの更新処理
                    change_kow(conn, transaction, target_mitsumori_no)

                    '*******************
                    '⑤取込履歴
                    '*******************

                    '変換フラグを更新
                    ta_rireki.Q_取込履歴更新("1", target_mitsumori_no)

                    ' コミット
                    transaction.Commit()

                    MessageBox.Show("変換完了しました。")

                Catch ex As Exception
                    ' エラー時はロールバック
                    transaction.Rollback()
                    Throw ex
                End Try

            End Using

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Make_1Lot_Btn_Change_Click")
            MessageBox.Show(ex.Message)
        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub

    '出力ボタンクリック時
    Private Sub Btn_Output_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor
            Lbl_Messege.Visible = True
            Lbl_Messege.Text = "出力中"
            Application.DoEvents()    ' ★ UIを即時更新

            Dim dt As New DS_T.DT_T_CCC_LotDataTable
            Dim ta As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim ta_ccc As New DS_TTableAdapters.TA_T_CCC

            Dim target_mitsumori_no As String = ta_ccc.Q_Max見積No取得
            ta.Q_CCC_Lot取得(dt, target_mitsumori_no)

            Dim out_path As String = MakeOutPath()
            ConvertDataTableToCsv(dt, out_path, True)

            MessageBox.Show("ファイルの出力が完了しました。", "ファイル出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Make_1Lot_Btn_Output_Click")
            MessageBox.Show(ex.Message)

        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
            Lbl_Messege.Visible = False
        End Try

    End Sub


    '**********************************************************************************
    '関数
    '**********************************************************************************

    '1Lotデータの複雑な更新処理

    Sub change_1lot(conn As SqlConnection, transaction As SqlTransaction, _target_mitsumori_no As Integer)

        Try

            Dim dt_ccc_lot As New DS_T.DT_T_CCC_LotDataTable
            Dim ta_ccc_lot As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim dt_second As New DS_M.DT_M_SecondDataTable
            Dim ta_second As New DS_MTableAdapters.TA_M_Second

            Dim dt_M_naisou As New DS_M.DT_M_Naisou_ShizaiDataTable
            Dim ta_M_naisou As New DS_MTableAdapters.TA_M_Naisou_Shizai

            Dim dt_order_list As New DS_T.DT_T_Buhin_Order_ListDataTable
            Dim ta_order_list As New DS_TTableAdapters.TA_T_Buhin_Order_List
            Dim dt_kow As New DS_T.DT_T_KOW46DataTable
            Dim ta_kow As New DS_TTableAdapters.DT_T_KOW46TableAdapter
            Dim dt_tanak As New DS_M.DT_M_TankaDataTable
            Dim ta_tanka As New DS_MTableAdapters.TA_M_Tanka

            Dim dt_housou_kbn As New DS_M.DT_M_Housou_KbnDataTable
            Dim ta_housou_kbn As New DS_MTableAdapters.TA_M_Housou_Kbn

            'TAを使えるように接続とトランザクション情報をセットする
            ta_ccc_lot.Connection = conn
            ta_ccc_lot.Transaction = transaction
            ta_M_naisou.Connection = conn
            ta_M_naisou.Transaction = transaction
            ta_second.Connection = conn
            ta_second.Transaction = transaction
            ta_order_list.Connection = conn
            ta_order_list.Transaction = transaction
            ta_tanka.Connection = conn
            ta_tanka.Transaction = transaction
            ta_housou_kbn.Connection = conn
            ta_housou_kbn.Transaction = transaction

            '変換対象の1lotデータを取得
            ta_ccc_lot.Q_CCC_Lot取得(dt_ccc_lot, _target_mitsumori_no)

            '秒数取得
            Dim naisou_second As String = ta_second.Q_工数取得(5)
            Dim carton_second As Decimal = ta_second.Q_工数取得(6)
            Dim return_able_second As Decimal = ta_second.Q_工数取得(7)

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

            '単価マスタの辞書作成
            ta_tanka.Fill(dt_tanak)
            Dim tankaDict As New Dictionary(Of String, Decimal)
            For Each dr As DataRow In dt_tanak.Rows
                Dim key As String = dr("資材コード").ToString()
                Dim value As Decimal = CDec(dr("単価"))
                If Not tankaDict.ContainsKey(key) Then
                    tankaDict(key) = value
                End If
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

            'ユニーク判定用辞書
            Dim lotDict As New Dictionary(Of String, Integer)(StringComparer.Ordinal)
            ' まず DataRow 配列にする（高速化）
            Dim rows As DataRow() = dt_ccc_lot.Select()
            For Each dr As DataRow In rows
                Dim key As String = String.Concat(
                SafeGetString(dr, "ｺﾝﾄﾛｰﾙNO"),
                SafeGetString(dr, "年度1"),
                SafeGetString(dr, "モデル1"),
                SafeGetString(dr, "モデフNO"),
                SafeGetString(dr, "ケースNO1"),
                SafeGetString(dr, "包装ロットNO"),
                SafeGetString(dr, "包装ロット連番"),
                SafeGetString(dr, "モジュール手順SEQ"),
                SafeGetString(dr, "内装資材記号")
            )
                If lotDict.ContainsKey(key) Then
                    lotDict(key) += 1
                Else
                    lotDict(key) = 1
                End If
            Next

            '部品オーダーリスト辞書
            ta_order_list.Q_オーダーリスト取得(dt_order_list, _target_mitsumori_no)
            Dim searchDict As New Dictionary(Of String, List(Of OrderInfo))(StringComparer.Ordinal)

            ' まず DataRow 配列にする（高速化）
            Dim rows_order As DataRow() = dt_order_list.Select()
            For Each dr As DataRow In rows_order
                Dim key As String = String.Concat(
                SafeGetString(dr, "DIST"),
                SafeGetString(dr, "Basic_Part_No"),
                SafeGetString(dr, "個装適用袋")
            )

                Dim info As New OrderInfo With {
                    .DIST = SafeGetString(dr, "DIST"),
                    .No = SafeGetString(dr, "No"),
                    .変更フラグ = SafeGetString(dr, "変更フラグ"),
                    .GR = SafeGetString(dr, "GR"),
                    .Basic_Part_No = SafeGetString(dr, "Basic_Part_No"),
                    .Export_Name = SafeGetString(dr, "Export_Name"),
                    .Order_Lot = SafeGetString(dr, "Order_Lot"),
                    .LOTカートン数 = SafeGetString(dr, "LOTカートン数"),
                    .個装入数 = SafeGetString(dr, "個装入数"),
                    .OS = SafeGetString(dr, "OS"),
                    .内装適用 = SafeGetString(dr, "内装適用"),
                    .L = SafeGetString(dr, "L"),
                    .W = SafeGetString(dr, "W"),
                    .H = SafeGetString(dr, "H"),
                    .防錆 = SafeGetString(dr, "防錆"),
                    .個装適用袋 = SafeGetString(dr, "個装適用袋"),
                    .袋必要数 = SafeGetString(dr, "袋必要数"),
                    .単品重量 = SafeGetDecimal(dr, "単品重量"),
                    .内装重量 = SafeGetDecimal(dr, "内装重量")
                }

                info.資材コード = New String(15) {}
                info.数量 = New Integer(15) {}

                ' 資材コード & 数量をぶっこむ
                For i As Integer = 1 To 16
                    info.資材コード(i - 1) = SafeGetString(dr, $"資材コード{i}")
                    info.数量(i - 1) = SafeGetInt(dr, $"数量{i}")
                Next

                ' 辞書に追加
                If Not searchDict.ContainsKey(key) Then
                    searchDict(key) = New List(Of OrderInfo)
                End If

                searchDict(key).Add(info)
            Next

            'KOW辞書
            ta_kow.Q_KOW取得(dt_kow, _target_mitsumori_no)
            Dim search_KOW_Dict As New Dictionary(Of String, List(Of KowInfo))(StringComparer.Ordinal)

            ' まず DataRow 配列にする（高速化）
            Dim rows_kow As DataRow() = dt_kow.Select()
            For Each dr As DataRow In rows_kow
                Dim key As String = String.Concat(
                SafeGetString(dr, "包装ロットNo"),
                SafeGetString(dr, "MUDULE"),
                SafeGetString(dr, "本C_No"),
                SafeGetString(dr, "内装手順")
            )

                Dim info As New KowInfo With {
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
                    search_KOW_Dict(key) = New List(Of KowInfo)
                End If

                search_KOW_Dict(key).Add(info)
            Next

            ' 更新データを貯めるリスト（更新数量, id）
            Dim updates As New List(Of KeyValuePair(Of Decimal, String))(rows.Length)
            Dim updates2 As New List(Of KeyValuePair(Of Decimal, String))(rows.Length)
            Dim updates3 As New List(Of KeyValuePair(Of Decimal, String))(rows.Length)

            '重複更新チェック用
            Dim updatedLots As New HashSet(Of String)

            For Each row In dt_ccc_lot

                Dim carton_su As Decimal = 0
                Dim return_able_su As Decimal = 0
                Dim naisou_shizai_su As Decimal = 0
                Dim naisou_master_suryou As Decimal = 0
                Dim naisou_master_suryou2 As Decimal = 0
                Dim naisou_master_cd As String = ""
                Dim naisou_master_cd2 As String = ""

                '必要な材料をDTより取得
                Dim target_id As String = row("id")
                Dim controll_no As String = SafeGetString(row, "ｺﾝﾄﾛｰﾙNO") '50
                Dim nendo As String = SafeGetString(row, "年度1") '51
                Dim model As String = SafeGetString(row, "モデル1") '52
                Dim modefu As String = SafeGetString(row, "モデフNO") '53
                Dim case_no As String = SafeGetString(row, "ケースNO1") '54

                Dim dist As String = SafeGetString(row, "代表DIST") '59
                Dim housou_lot_no As String = SafeGetString(row, "包装ロットNO") '61
                Dim housou_lot_eda_no As String = SafeGetString(row, "包装ロット連番") '62
                Dim houzou_line_gaisou As String = SafeGetString(row, "包装ライン_外装") '117
                Dim kosou_shizai_cd As String = SafeGetString(row, "個装資材記号") '156
                Dim naisou_shizai_cd As String = SafeGetString(row, "内装資材記号") '160
                Dim gaisou_shizai_cd As String = SafeGetString(row, "外装資材記号") '165
                Dim module_seq As String = SafeGetString(row, "モジュール手順SEQ") '166
                Dim naisou_irisu As String = SafeGetString(row, "内装入り数") '167

                '192列目～220
                Dim fuku_shizai1 As String = SafeGetString(row, "副資材1")
                Dim hitsuyou_su1 As Decimal = SafeGetDecimal(row, "必要数1")
                Dim fuku_shizai2 As String = SafeGetString(row, "副資材2")
                Dim hitsuyou_su2 As Decimal = SafeGetDecimal(row, "必要数2")
                Dim fuku_shizai3 As String = SafeGetString(row, "副資材3")
                Dim hitsuyou_su3 As Decimal = SafeGetDecimal(row, "必要数3")
                Dim fuku_shizai4 As String = SafeGetString(row, "副資材4")
                Dim hitsuyou_su4 As Decimal = SafeGetDecimal(row, "必要数4")
                Dim fuku_shizai5 As String = SafeGetString(row, "副資材5")
                Dim hitsuyou_su5 As Decimal = SafeGetDecimal(row, "必要数5")
                Dim fuku_shizai6 As String = SafeGetString(row, "副資材6")
                Dim hitsuyou_su6 As Decimal = SafeGetDecimal(row, "必要数6")
                Dim fuku_shizai7 As String = SafeGetString(row, "副資材7")
                Dim hitsuyou_su7 As Decimal = SafeGetDecimal(row, "必要数7")
                Dim fuku_shizai8 As String = SafeGetString(row, "副資材8")
                Dim hitsuyou_su8 As Decimal = SafeGetDecimal(row, "必要数8")
                Dim fuku_shizai9 As String = SafeGetString(row, "副資材9")
                Dim hitsuyou_su9 As Decimal = SafeGetDecimal(row, "必要数9")
                Dim fuku_shizai10 As String = SafeGetString(row, "副資材10")
                Dim hitsuyou_su10 As Decimal = SafeGetDecimal(row, "必要数10")


                '225列目～249
                Dim fuku_shizai12 As String = SafeGetString(row, "副資材12")
                Dim hitsuyou_su12 As Decimal = SafeGetDecimal(row, "必要数12")
                Dim fuku_shizai13 As String = SafeGetString(row, "副資材13")
                Dim hitsuyou_su13 As Decimal = SafeGetDecimal(row, "必要数13")
                Dim fuku_shizai14 As String = SafeGetString(row, "副資材14")
                Dim hitsuyou_su14 As Decimal = SafeGetDecimal(row, "必要数14")
                Dim fuku_shizai15 As String = SafeGetString(row, "副資材15")
                Dim hitsuyou_su15 As Decimal = SafeGetDecimal(row, "必要数15")
                Dim fuku_shizai16 As String = SafeGetString(row, "副資材16")
                Dim hitsuyou_su16 As Decimal = SafeGetDecimal(row, "必要数16")
                Dim fuku_shizai17 As String = SafeGetString(row, "副資材17")
                Dim hitsuyou_su17 As Decimal = SafeGetDecimal(row, "必要数17")
                Dim fuku_shizai18 As String = SafeGetString(row, "副資材18")
                Dim hitsuyou_su18 As Decimal = SafeGetDecimal(row, "必要数18")
                Dim fuku_shizai19 As String = SafeGetString(row, "副資材19")
                Dim hitsuyou_su19 As Decimal = SafeGetDecimal(row, "必要数19")
                Dim fuku_shizai20 As String = SafeGetString(row, "副資材20")
                Dim hitsuyou_su20 As Decimal = SafeGetDecimal(row, "必要数20")

                Dim fuku_shizaiSmall(8) As String    ' 12～20 → 9個
                Dim hitsuyou_suSmall(8) As Decimal

                For i As Integer = 12 To 20
                    fuku_shizaiSmall(i - 12) = SafeGetString(row, ("副資材" & i))
                    hitsuyou_suSmall(i - 12) = SafeGetString(row, ("必要数" & i))
                Next


                'カートン数の計算

                '包装ライン_外装にA0が含まれているか
                If houzou_line_gaisou.Contains("A0") Then

                    '含まれている場合、カートン数は0
                    carton_su = 0

                Else '含まれていない場合

                    '各資材記号が内装資材マスタに存在するかチェック

                    ' 内装資材マスタ参照
                    '156列目の個装資材記号
                    If naisouDict.ContainsKey(kosou_shizai_cd) Then
                        naisou_master_suryou = naisouDict(kosou_shizai_cd)
                    Else
                        naisou_master_suryou = -1
                    End If

                    '160列目の内装資材記号
                    If naisou_master_suryou = -1 Then

                        If naisouDict.ContainsKey(naisou_shizai_cd) Then
                            naisou_master_suryou = naisouDict(naisou_shizai_cd)
                        Else
                            naisou_master_suryou = -1
                        End If

                    End If

                    '165列目の外装資材記号
                    If naisouDict.ContainsKey(gaisou_shizai_cd) Then
                        naisou_master_suryou2 = naisouDict(gaisou_shizai_cd)
                    Else
                        naisou_master_suryou2 = -1
                    End If

                    '個装資材記号、内装資材記号で一致した場合の計算
                    If naisou_master_suryou = -1 Then

                        '存在しない

                    Else '存在する

                        '1lotデータにユニーク条件に合致、かつ内装資材記号が一致するデータがあるか

                        ' ユニークチェック
                        Dim lotKey As String = controll_no & nendo & model & modefu _
                            & case_no & housou_lot_no & housou_lot_eda_no & module_seq & naisou_shizai_cd

                        If Not lotDict.ContainsKey(lotKey) OrElse lotDict(lotKey) <= 1 Then
                            carton_su = naisou_irisu * naisou_master_suryou * carton_second
                        Else
                            carton_su = naisou_master_suryou * carton_second
                        End If

                    End If

                    '外装資材記号で一致した場合の計算
                    If naisou_master_suryou2 = -1 Then

                        '存在しない

                    Else '存在する

                        '個装資材記号、内装資材記号で一致していなければ
                        If naisou_master_suryou <> -1 Then

                            ' ユニークチェック
                            Dim lotKey As String = controll_no & nendo & model & modefu _
                                & case_no & housou_lot_no & housou_lot_eda_no & module_seq & naisou_shizai_cd

                            If Not lotDict.ContainsKey(lotKey) OrElse lotDict(lotKey) <= 1 Then
                                carton_su = naisou_irisu * naisou_master_suryou2 * carton_second
                            Else
                                carton_su = naisou_master_suryou2 * carton_second
                            End If


                        Else '個装資材記号、内装資材記号で一致済み

                            carton_su = carton_su + naisou_master_suryou2 * carton_second

                        End If


                    End If


                    '225列目～249列目の中に内装主資材データ記載の資材が存在するかチェック
                    For i As Integer = 0 To fuku_shizaiSmall.Length - 1
                        Dim shizai_cd As String = fuku_shizaiSmall(i)
                        Dim qty As Decimal = hitsuyou_suSmall(i)
                        Dim suryou As Decimal = 0
                        ' 空チェック
                        If Not String.IsNullOrEmpty(shizai_cd) AndAlso qty > 0 Then

                            If naisouDict.ContainsKey(shizai_cd) Then
                                suryou = naisouDict(shizai_cd)
                            Else
                                suryou = -1
                            End If
                            'suryou = ta_M_naisou.Q_数量取得(shizai_cd)

                            If suryou <> -1 Then
                                carton_su = carton_su + qty * suryou * carton_second
                            End If


                        End If
                    Next

                    ' 更新データを蓄積（後で一括的にプリペアドコマンドで更新）
                    If carton_su <> 0 Then
                        updates.Add(New KeyValuePair(Of Decimal, String)(carton_su, target_id))
                    End If


                    '1lotのカートン数を更新
                    'ta_ccc_lot.Q_カートン数更新(carton_su, target_id)

                End If


                'リターナブル容器数の計算

                '包装ライン_外装にA0が含まれているか
                If houzou_line_gaisou.Contains("A0") Then

                    '含まれている場合、リターナブル容器数は0
                    return_able_su = 0

                Else '含まれていない場合

                    '各資材記号が内装資材マスタに存在するかチェック

                    ' 内装資材マスタ参照
                    If naisouDict.ContainsKey(kosou_shizai_cd) Then
                        naisou_master_suryou = naisouDict(kosou_shizai_cd)
                        naisou_master_cd = kosou_shizai_cd
                    Else
                        naisou_master_suryou = -1
                    End If

                    If naisou_master_suryou = -1 Then

                        If naisouDict.ContainsKey(naisou_shizai_cd) Then
                            naisou_master_suryou = naisouDict(naisou_shizai_cd)
                            naisou_master_cd = naisou_shizai_cd
                        Else
                            naisou_master_suryou = -1
                        End If

                    End If

                    If naisou_master_suryou = -1 Then

                        If naisouDict.ContainsKey(gaisou_shizai_cd) Then
                            naisou_master_suryou = naisouDict(gaisou_shizai_cd)
                            naisou_master_cd = gaisou_shizai_cd
                        Else
                            naisou_master_suryou = -1
                        End If

                    End If

                    If naisou_master_suryou = -1 Then

                        '存在しない


                    Else '存在する

                        'マスタの数量を取得
                        'naisou_master_suryou = dt_M_naisou.Rows(0)("数量")

                        '資材コードにRTが含まれているか
                        If Not String.IsNullOrEmpty(naisou_master_cd) AndAlso naisou_master_cd.Trim().ToUpper().Contains("RT") Then

                            '含まれている場合

                            ' ユニークチェック
                            Dim lotKey As String = controll_no & nendo & model & modefu _
                                & case_no & housou_lot_no & housou_lot_eda_no & module_seq & naisou_shizai_cd

                            If Not lotDict.ContainsKey(lotKey) OrElse lotDict(lotKey) <= 1 Then
                                carton_su = naisou_irisu * naisou_master_suryou * return_able_second
                            Else
                                carton_su = naisou_master_suryou * return_able_second
                            End If

                        Else '含まれていない場合、リターナブル容器数は0

                            return_able_su = 0

                        End If

                    End If

                    '225列目～249列目の中に内装主資材データ記載の資材が存在するかチェック
                    For i As Integer = 0 To fuku_shizaiSmall.Length - 1
                        Dim shizai_cd As String = fuku_shizaiSmall(i)
                        Dim qty As Decimal = hitsuyou_suSmall(i)
                        Dim suryou As Decimal = 0
                        ' 空チェック
                        If Not String.IsNullOrEmpty(shizai_cd) AndAlso qty > 0 Then

                            '資材コードにRTが含まれていれば
                            If shizai_cd.Contains("RT") Then

                                'suryou = ta_M_naisou.Q_数量取得(shizai_cd)
                                If naisouDict.ContainsKey(shizai_cd) Then
                                    suryou = naisouDict(shizai_cd)

                                Else
                                    suryou = -1
                                End If

                                If suryou <> -1 Then
                                    return_able_su = return_able_su + qty * suryou * return_able_second
                                End If

                            End If

                        End If
                    Next

                    '1lotのカートン数を更新
                    'ta_ccc_lot.Q_リターナブル容器数更新(return_able_su, target_id)

                    ' 更新データを蓄積（後で一括更新）
                    If return_able_su <> 0 Then
                        updates2.Add(New KeyValuePair(Of Decimal, String)(return_able_su, target_id))
                    End If

                End If

                '内装資材数の計算

                ' 検索用複合キー
                Dim searchKey As String = dist & houzou_line_gaisou & "無し"
                Dim searchKey_housou As String = dist
                Dim searchKey_kow As String = housou_lot_no & housou_lot_eda_no.ToString.PadLeft(2, "0"c) & controll_no & case_no & module_seq


                '検索結果格納用変数
                Dim hitList As List(Of OrderInfo) = Nothing
                Dim hitList_kow As List(Of KowInfo) = Nothing

                '部品単位オーダーリストに存在する、かつ値が「無し」か
                If searchDict.TryGetValue(searchKey, hitList) Then

                    '存在する
                    For Each info In hitList

                        '資材1～16の資材が単価マスタに存在するかチェック、存在すればヒットした数量を加算していく
                        Dim totalPrice As Decimal = CalcOrderPrice(info, tankaDict)

                        '合計値×内装入り数×秒数
                        naisou_shizai_su = totalPrice * naisou_irisu * naisou_second

                    Next


                Else '存在しない

                    '内装か外装かを判別する
                    Dim housou_kbn As String = ""
                    Dim distKey As String = dist

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

                    '内装の場合の計算
                    If housou_kbn = "内装" Then

                        Dim naisou_total As Decimal = 0


                        ' 内装資材マスタ参照
                        If naisouDict.ContainsKey(kosou_shizai_cd) Then
                            naisou_master_suryou = naisouDict(kosou_shizai_cd)
                        Else
                            naisou_master_suryou = -1
                        End If

                        If naisou_master_suryou = -1 Then

                            If naisouDict.ContainsKey(naisou_shizai_cd) Then
                                naisou_master_suryou = naisouDict(naisou_shizai_cd)
                            Else
                                naisou_master_suryou = -1
                            End If

                        End If

                        If naisou_master_suryou = -1 Then
                            naisou_shizai_su = 0
                        Else

                            ' ユニークチェック
                            Dim lotKey As String = controll_no & nendo & model & modefu _
                                & case_no & housou_lot_no & housou_lot_eda_no & module_seq & naisou_shizai_cd

                            '１Lotのデータから必要数を加算していく
                            If Not fuku_shizai1.Contains("TA") And Not fuku_shizai1.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su1
                            End If
                            If Not fuku_shizai2.Contains("TA") And Not fuku_shizai2.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su2
                            End If
                            If Not fuku_shizai3.Contains("TA") And Not fuku_shizai3.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su3
                            End If
                            If Not fuku_shizai4.Contains("TA") And Not fuku_shizai4.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su4
                            End If
                            If Not fuku_shizai5.Contains("TA") And Not fuku_shizai5.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su5
                            End If
                            If Not fuku_shizai6.Contains("TA") And Not fuku_shizai6.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su6
                            End If
                            If Not fuku_shizai7.Contains("TA") And Not fuku_shizai7.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su7
                            End If
                            If Not fuku_shizai8.Contains("TA") And Not fuku_shizai8.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su8
                            End If
                            If Not fuku_shizai9.Contains("TA") And Not fuku_shizai9.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su9
                            End If
                            If Not fuku_shizai10.Contains("TA") And Not fuku_shizai10.Contains("ZW") Then
                                naisou_total = naisou_total + hitsuyou_su10
                            End If

                            If naisou_total = 0 Then
                                naisou_total = 1
                            End If

                            ' lotDict に存在するか
                            If lotDict.ContainsKey(lotKey) Then

                                ' 複数件の場合は最初の1件のみ更新
                                If lotDict(lotKey) > 1 Then

                                    '既に更新済みかチェック
                                    If Not updatedLots.Contains(lotKey) Then

                                        naisou_shizai_su = naisou_total * naisou_irisu * naisou_second
                                        updatedLots.Add(lotKey) ' 更新済みとして記録

                                    Else
                                        naisou_shizai_su = 0 ' 2件目以降は0で更新
                                    End If

                                Else
                                    ' 1件だけの場合は通常計算
                                    naisou_shizai_su = naisou_total * naisou_irisu * naisou_second
                                End If

                            End If

                        End If

                    ElseIf housou_kbn = "個装" Then '個装の場合の計算

                        'KOWに存在するかチェック
                        If search_KOW_Dict.TryGetValue(searchKey_kow, hitList_kow) Then

                            Dim target_flg As Boolean = False
                            Dim total_shiyou_su As Decimal = 0

                            '存在する
                            For Each info In hitList_kow

                                Dim main_flg As String = info.主資材
                                Dim shizai_cd As String = info.資材規格
                                Dim strNumber As String = info.使用数
                                Dim shiyou_su As Decimal = Decimal.Parse(strNumber)

                                If Decimal.TryParse(strNumber, shiyou_su) Then

                                Else
                                    shiyou_su = 1
                                End If

                                'メイン資材
                                If main_flg = "*" Then

                                    ' 内装資材マスタ参照
                                    If naisouDict.ContainsKey(shizai_cd) Then
                                        naisou_master_suryou = naisouDict(shizai_cd)
                                    Else
                                        naisou_master_suryou = -1
                                    End If

                                    'マスタに存在すればターゲットフラグを立てる
                                    If naisou_master_suryou <> -1 Then

                                        target_flg = True

                                        '使用数を加算する
                                        total_shiyou_su = total_shiyou_su + shiyou_su

                                    Else
                                        target_flg = False
                                    End If

                                Else '副資材

                                    If target_flg = True Then

                                        If Not shizai_cd.Contains("TA") And Not shizai_cd.Contains("ZW") Then

                                            '使用数を加算する
                                            total_shiyou_su = total_shiyou_su + shiyou_su

                                        End If
                                    End If

                                End If
                            Next

                            naisou_shizai_su = total_shiyou_su * naisou_irisu * naisou_second

                        Else 'KOWに存在しない

                            naisou_shizai_su = 0

                        End If

                    End If

                    ' 更新データを蓄積（後で一括更新）
                    If naisou_shizai_su <> 0 Then
                        updates3.Add(New KeyValuePair(Of Decimal, String)(naisou_shizai_su, target_id))
                    End If

                End If

            Next

            '1lotのカートン数を更新

            ' 1. DataTable を作る
            Dim dtUpdate As New DataTable()
            dtUpdate.Columns.Add("id", GetType(String))
            dtUpdate.Columns.Add("carton", GetType(Decimal))

            For Each kvp In updates
                dtUpdate.Rows.Add(kvp.Value, kvp.Key)
            Next

            ' 2. SQLServer の一時テーブル作成
            Using cmd As New SqlCommand("
                                        CREATE TABLE #TmpUpdate (
                                            id VARCHAR(50),
                                            carton DECIMAL(16,2)
                                        )
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 3. BulkCopy で #TmpUpdate に超高速挿入（数万件でも 0.1～0.3秒）
            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction)
                bulk.DestinationTableName = "#TmpUpdate"
                bulk.WriteToServer(dtUpdate)
            End Using

            ' 4. JOIN UPDATE で一括更新（SQL 1回）→ 爆速
            Using cmd As New SqlCommand("
                                        UPDATE C
                                        SET C.カートン数 = T.carton
                                        FROM T_CCC_Lot C
                                        INNER JOIN #TmpUpdate T
                                            ON C.id = T.id
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 5. 一時テーブル削除
            Using cmd As New SqlCommand("DROP TABLE #TmpUpdate", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            '1lotのリターナブル容器数を更新

            ' 1. DataTable を作る
            Dim dtUpdate2 As New DataTable()
            dtUpdate2.Columns.Add("id", GetType(String))
            dtUpdate2.Columns.Add("return_able_su", GetType(Decimal))

            For Each kvp In updates2
                dtUpdate2.Rows.Add(kvp.Value, kvp.Key)
            Next

            ' 2. SQLServer の一時テーブル作成
            Using cmd As New SqlCommand("
                                        CREATE TABLE #TmpUpdate (
                                            id VARCHAR(50),
                                            return_able_su DECIMAL(16,2)
                                        )
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 3. BulkCopy で #TmpUpdate に超高速挿入（数万件でも 0.1～0.3秒）
            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction)
                bulk.DestinationTableName = "#TmpUpdate"
                bulk.WriteToServer(dtUpdate)
            End Using

            ' 4. JOIN UPDATE で一括更新（SQL 1回）→ 爆速
            Using cmd As New SqlCommand("
                                        UPDATE C
                                        SET C.リターナブル容器数 = T.return_able_su
                                        FROM T_CCC_Lot C
                                        INNER JOIN #TmpUpdate T
                                            ON C.id = T.id
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 5. 一時テーブル削除
            Using cmd As New SqlCommand("DROP TABLE #TmpUpdate", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using


            '1lotの内装資材数を更新

            ' 1. DataTable を作る
            Dim dtUpdate3 As New DataTable()
            dtUpdate3.Columns.Add("id", GetType(String))
            dtUpdate3.Columns.Add("naisou_shizai_su", GetType(Decimal))

            For Each kvp In updates3
                dtUpdate3.Rows.Add(kvp.Value, kvp.Key)
            Next

            ' 2. SQLServer の一時テーブル作成
            Using cmd As New SqlCommand("
                                        CREATE TABLE #TmpUpdate (
                                            id VARCHAR(50),
                                            naisou_shizai_su DECIMAL(16,2)
                                        )
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 3. BulkCopy で #TmpUpdate に超高速挿入（数万件でも 0.1～0.3秒）
            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction)
                bulk.DestinationTableName = "#TmpUpdate"
                bulk.WriteToServer(dtUpdate3)
            End Using

            ' 4. JOIN UPDATE で一括更新（SQL 1回）→ 爆速
            Using cmd As New SqlCommand("
                                        UPDATE C
                                        SET C.内装資材数 = T.naisou_shizai_su
                                        FROM T_CCC_Lot C
                                        INNER JOIN #TmpUpdate T
                                            ON C.id = T.id
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 5. 一時テーブル削除
            Using cmd As New SqlCommand("DROP TABLE #TmpUpdate", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'KOWデータの複雑な更新処理

    Sub change_kow(conn As SqlConnection, transaction As SqlTransaction, _target_mitsumori_no As Integer)

        Try

            Dim dt_ccc_lot As New DS_T.DT_T_CCC_LotDataTable
            Dim ta_ccc_lot As New DS_TTableAdapters.TA_T_CCC_Lot
            Dim dt_M_naisou As New DS_M.DT_M_Naisou_ShizaiDataTable
            Dim ta_M_naisou As New DS_MTableAdapters.TA_M_Naisou_Shizai
            Dim dt_M_kosou As New DS_M.DT_M_Kosou_ShizaiDataTable
            Dim ta_M_kosou As New DS_MTableAdapters.TA_M_Kosou_Shizai
            Dim dt_kow As New DS_T.DT_T_KOW46DataTable
            Dim ta_kow As New DS_TTableAdapters.DT_T_KOW46TableAdapter
            Dim dt_housou_kbn As New DS_M.DT_M_Housou_KbnDataTable
            Dim ta_housou_kbn As New DS_MTableAdapters.TA_M_Housou_Kbn

            'TAを使えるように接続とトランザクション情報をセットする
            ta_ccc_lot.Connection = conn
            ta_ccc_lot.Transaction = transaction
            ta_M_naisou.Connection = conn
            ta_M_naisou.Transaction = transaction
            ta_M_kosou.Connection = conn
            ta_M_kosou.Transaction = transaction

            ta_housou_kbn.Connection = conn
            ta_housou_kbn.Transaction = transaction

            '変換対象のKOWデータを取得
            Using cmd As New SqlCommand("
                                        SELECT
                                            id,包装ロットNo,MUDULE,本C_No,内装手順,手順識別,資材規格,使用数,主資材,その他1,その他2,年度,モデル,タイプ,
                                            オプション,資材単価表示,資材費,ケース当たりの内装資材費,ケース当たりの外装資材費,
                                            内装入数_カートン数,ケース内必要資材数,取込年月,見積No
                                        FROM T_KOW46
                                        WHERE 見積No = @見積No
                                        ORDER BY id
                                    ", conn, transaction)

                ' タイムアウトを延長（必要に応じて秒数を変更）
                cmd.CommandTimeout = 300

                ' パラメータ設定
                cmd.Parameters.Add("@見積No", SqlDbType.Int).Value = _target_mitsumori_no

                ' DataAdapter で DataTable に取得
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt_kow)
                End Using

            End Using

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
            Dim kosouDict As New Dictionary(Of String, Decimal)
            For Each dr As DataRow In dt_M_kosou.Rows
                Dim key As String = dr("個装資材コード").ToString()
                Dim value As Decimal = CDec(dr("id"))
                If Not kosouDict.ContainsKey(key) Then
                    kosouDict(key) = value
                End If
            Next

            'ユニーク判定用辞書
            Dim lotDict As New Dictionary(Of String, Integer)(StringComparer.Ordinal)
            ' まず DataRow 配列にする（高速化）
            Dim rows As DataRow() = dt_kow.Select()
            For Each dr As DataRow In rows
                Dim key As String = String.Concat(
                SafeGetString(dr, "年度"),
                SafeGetString(dr, "モデル"),
                SafeGetString(dr, "タイプ"),
                SafeGetString(dr, "MUDULE"),
                SafeGetString(dr, "内装手順")
            )
                If lotDict.ContainsKey(key) Then
                    lotDict(key) += 1
                Else
                    lotDict(key) = 1
                End If
            Next

            'CCC辞書
            ta_ccc_lot.Q_CCC_Lot取得(dt_ccc_lot, _target_mitsumori_no)

            Dim search_ccc_Dict As New Dictionary(Of String, List(Of CCCInfo))(StringComparer.Ordinal)

            ' まず DataRow 配列にする（高速化）
            Dim rows_kow As DataRow() = dt_ccc_lot.Select()

            For Each dr As DataRow In rows_kow

                Dim key As String = String.Concat(
                SafeGetString(dr, "年度2"),
                SafeGetString(dr, "モデル2"),
                SafeGetString(dr, "タイプ1"),
                SafeGetString(dr, "ｺﾝﾄﾛｰﾙNO"),
                 SafeGetString(dr, "モジュール手順SEQ")
            )

                Dim info As New CCCInfo With {
                    .年度2 = SafeGetString(dr, "年度2"),
                    .モデル2 = SafeGetString(dr, "モデル2"),
                    .タイプ1 = SafeGetString(dr, "タイプ1"),
                    .ｺﾝﾄﾛｰﾙNO = SafeGetString(dr, "ｺﾝﾄﾛｰﾙNO"),
                    .モジュール手順SEQ = SafeGetString(dr, "モジュール手順SEQ"),
                    .個装入り数 = SafeGetString(dr, "個装入り数"),
                    .内装入り数 = SafeGetString(dr, "内装入り数")
                }

                ' 辞書に追加
                If Not search_ccc_Dict.ContainsKey(key) Then
                    search_ccc_Dict(key) = New List(Of CCCInfo)
                End If

                search_ccc_Dict(key).Add(info)

            Next

            ' 更新データを貯めるリスト（更新数量, id）
            Dim updates As New List(Of KeyValuePair(Of Decimal, String))(rows.Length)

            '重複更新チェック用
            Dim updatedLots As New HashSet(Of String)

            Dim target_flg As Boolean = False
            Dim old_searchKey As String = ""
            Dim update_id As String = ""
            Dim main_shizai As String = ""

            Dim naisou_irisu As Decimal = 0
            Dim gaisou_irisu As Decimal = 0

            'ケース当たりの内装資材費
            Dim case_naisou_shizai_hi As Decimal
            Dim total_shizai_hi As Decimal = 0

            For Each row In dt_kow.Rows

                '必要な材料をDTより取得
                Dim target_id As String = row("id")
                Dim nendo As String = SafeGetString(row, "年度") '50
                Dim model As String = SafeGetString(row, "モデル") '51
                Dim type As String = SafeGetString(row, "タイプ") '52
                Dim MUDULE As String = SafeGetString(row, "MUDULE") '53
                Dim naisou_tejun As String = SafeGetString(row, "内装手順") '54
                main_shizai = SafeGetString(row, "主資材") '59
                Dim shizai_kikaku As String = SafeGetString(row, "資材規格") '61
                Dim shizai_hi As String = SafeGetDecimal(row, "資材費") '62

                case_naisou_shizai_hi = 0

                ' 検索用複合キー
                Dim searchKey As String = nendo & model & type & MUDULE & naisou_tejun

                If old_searchKey = "" Then
                    target_flg = False

                ElseIf old_searchKey <> searchKey Then
                    target_flg = False
                End If


                ''検索結果格納用変数
                Dim hitList As List(Of CCCInfo) = Nothing

                'CCCに存在するかチェック
                If search_ccc_Dict.TryGetValue(searchKey, hitList) Then

                    '存在する
                    For Each info In hitList

                        naisou_irisu = info.内装入り数
                        gaisou_irisu = info.個装入り数

                        If naisou_irisu = 0 Then
                            naisou_irisu = 1
                        End If

                        If gaisou_irisu = 0 Then
                            gaisou_irisu = 1
                        End If

                        'メイン資材
                        If main_shizai = "*" Then

                            total_shizai_hi = 0

                            ' 内装資材マスタ参照
                            If kosouDict.ContainsKey(shizai_kikaku) Then

                                '存在する
                                target_flg = True
                                total_shizai_hi = total_shizai_hi + shizai_hi
                                update_id = target_id
                            Else

                                If naisouDict.ContainsKey(shizai_kikaku) Then

                                    '存在する
                                    target_flg = True
                                    total_shizai_hi = total_shizai_hi + shizai_hi
                                    update_id = target_id
                                Else

                                    '存在しない
                                    target_flg = False
                                    update_id = ""
                                End If

                            End If





                        Else '副資材

                            If target_flg = True Then

                                '使用数を加算する
                                total_shizai_hi = total_shizai_hi + shizai_hi

                            Else
                                case_naisou_shizai_hi = 0
                                update_id = ""
                            End If

                        End If

                        'CCCで複数件ヒットしても1件分で十分
                        Exit For

                    Next

                Else 'CCCに存在しない

                    case_naisou_shizai_hi = 0

                End If


                If old_searchKey <> "" Then

                    If old_searchKey <> searchKey Then

                        If update_id <> "" Then

                            case_naisou_shizai_hi = total_shizai_hi * naisou_irisu * gaisou_irisu

                            If case_naisou_shizai_hi <> 0 Then

                                ' 更新データを蓄積（後で一括更新）
                                updates.Add(New KeyValuePair(Of Decimal, String)(case_naisou_shizai_hi, update_id))

                                update_id = ""
                                total_shizai_hi = 0

                            End If

                        End If

                    End If

                Else

                End If

                old_searchKey = searchKey

            Next


            '最後の1件を登録
            If update_id <> "" Then

                If case_naisou_shizai_hi <> 0 Then

                    ' 更新データを蓄積（後で一括更新）
                    updates.Add(New KeyValuePair(Of Decimal, String)(case_naisou_shizai_hi, update_id))

                    update_id = ""
                End If

            End If


            '1lotの内装資材数を更新

            ' 1. DataTable を作る
            Dim dtUpdate As New DataTable()
            dtUpdate.Columns.Add("id", GetType(String))
            dtUpdate.Columns.Add("naisou_shizai_su", GetType(Decimal))

            For Each kvp In updates
                dtUpdate.Rows.Add(kvp.Value, kvp.Key)
            Next

            ' 2. SQLServer の一時テーブル作成
            Using cmd As New SqlCommand("
                                        CREATE TABLE #TmpUpdate (
                                            id VARCHAR(50),
                                            ケース当たりの内装資材費 DECIMAL(16,2)
                                        )
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 3. BulkCopy で #TmpUpdate に超高速挿入（数万件でも 0.1～0.3秒）
            Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction)
                bulk.DestinationTableName = "#TmpUpdate"
                bulk.WriteToServer(dtUpdate)
            End Using

            ' 4. JOIN UPDATE で一括更新（SQL 1回）→ 爆速
            Using cmd As New SqlCommand("
                                        UPDATE C
                                        SET C.ケース当たりの内装資材費 = T.ケース当たりの内装資材費
                                        FROM T_KOW46 C
                                        INNER JOIN #TmpUpdate T
                                            ON C.id = T.id
                                    ", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

            ' 5. 一時テーブル削除
            Using cmd As New SqlCommand("DROP TABLE #TmpUpdate", conn, transaction)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#Region "SQL作成処理"
    Function MakeSQL(_target_mitsumori_no As String) As String

        ' SQL文（INSERT文）
        Dim sql As String = "
                            ;WITH MinLot AS (
                                SELECT
                                    ｺﾝﾄﾛｰﾙNO,
                                    ケースNO1,
                                    代表DIST,
                                    年度2,
                                    モデル2,
                                    タイプ1,
                                    オプション1,
                                    群,
                                    MIN(包装ロットNO) AS MinLotNo,
                                    基本部番ハイフン付
                                FROM [dbo].[T_CCC]
                                WHERE 見積No = '" & _target_mitsumori_no & "'
                                GROUP BY
                                    ｺﾝﾄﾛｰﾙNO,
                                    ケースNO1,
                                    代表DIST,
                                    年度2,
                                    モデル2,
                                    タイプ1,
                                    オプション1,
                                    群,
                                    基本部番ハイフン付
                            ),
                            TargetData AS (
                                SELECT C.*
                                FROM [dbo].[T_CCC] C
                                INNER JOIN MinLot M ON
                                    C.ｺﾝﾄﾛｰﾙNO = M.ｺﾝﾄﾛｰﾙNO AND
                                    C.ケースNO1 = M.ケースNO1 AND
                                    C.代表DIST = M.代表DIST AND
                                    C.年度2 = M.年度2 AND
                                    C.モデル2 = M.モデル2 AND
                                    C.タイプ1 = M.タイプ1 AND
                                    C.オプション1 = M.オプション1 AND
                                    C.群 = M.群 AND
                                    C.包装ロットNO = M.MinLotNo AND
                                    C.基本部番ハイフン付 = M.基本部番ハイフン付
                                WHERE C.見積No = '" & _target_mitsumori_no & "'
                            )

                            INSERT INTO [dbo].[T_CCC_Work] (

                                工程管理ｼｽﾃﾑ日付,
                                処理ID,
                                包装指示1,
                                コンテンツ1,
                                パッケージコンテンツ1,
                                パッキングチェックシート1,
                                ケースマーク1,
                                部品管理エフ1,
                                包装指示2,
                                コンテンツ2,
                                パッケージコンテンツ2,
                                パッキングチェックシート2,
                                ケースマーク2,
                                部品管理エフ2,
                                包装指示3,
                                コンテンツ3,
                                パッケージコンテンツ3,
                                パッキングチェックシート3,
                                ケースマーク3,
                                部品管理エフ3,
                                包装指示4,
                                コンテンツ4,
                                パッケージコンテンツ4,
                                パッキングチェックシート4,
                                ケースマーク4,
                                部品管理エフ4,
                                予約1,
                                予約2,
                                予約3,
                                予約4,
                                予約5,
                                アイテムNO表示,
                                KD部番表示区分,
                                C_M重量表示要否,
                                A_Sフォーマット,
                                A_S日本表示形式,
                                A_S現地表示形式,
                                A_S輸出部品名称,
                                P_ﾘｽﾄ2ND記述,
                                包装資材表示要否,
                                オプション表示区分,
                                機種コード表示区分,
                                予約6,
                                原産国表示要否,
                                対応要否_10_2,
                                対応要否_5品目,
                                包装SS,
                                汎区分24,
                                PC_NO,
                                ｺﾝﾄﾛｰﾙNO,
                                年度1,
                                モデル1,
                                モデフNO,
                                ケースNO1,
                                レコードID,
                                バッチ処理エラーコード,
                                量産_枠外区分,
                                インボイスNO,
                                代表DIST,
                                部品群,
                                包装ロットNO,
                                包装ロット連番,
                                現地工場コード,
                                現地ラインNO1,
                                年1,
                                月1,
                                連番1,
                                サフィックス,
                                K_Y_KD1,
                                年度2,
                                モデル2,
                                タイプ1,
                                オプション1,
                                外装HES1,
                                内装タイプ1,
                                K_Y_KD2,
                                年度3,
                                モデル3,
                                タイプ2,
                                群,
                                外装HES2,
                                内装タイプ2,
                                K_Y_KD3,
                                年度4,
                                モデル4,
                                タイプ3,
                                オプション2,
                                外装HES3,
                                内装タイプ3,
                                MIX区分,
                                代表区分1,
                                包装仕様有無区分,
                                包装場,
                                オーダー区分,
                                オーダー経歴NO,
                                配送先DIST,
                                オーダー元プラント,
                                現地ラインNO2,
                                モデル年度,
                                オーダー理由コード,
                                オーダー年月日SEQ,
                                シップメントNO,
                                基本生産計画区分,
                                計画年月,
                                計画改訂NO,
                                計画コード,
                                包装予定日,
                                計画確定区分,
                                SS,
                                本社製品区分,
                                年2,
                                月2,
                                連番2,
                                包装数量,
                                個装ライン,
                                内装ライン,
                                包装ライン_外装,
                                ケース順位,
                                包装ロット台数,
                                ケース保税区分,
                                ケースグロスL,
                                ケースグロスW,
                                ケースグロスH,
                                ケースグロス容量M3,
                                ケースネットL,
                                ケースネットW,
                                ケースネットH,
                                ケースネット容量M3,
                                ケースネット重量,
                                ケース重量計画値,
                                ケース実績重量,
                                ケース重量測定要求,
                                初物部品ケースサイン,
                                エンジンASSYサイン,
                                K_Y_KD4,
                                年度5,
                                モデル5,
                                タイプ4,
                                オプション3,
                                外装HES4,
                                内装タイプ4,
                                エンジン入り数,
                                パッキングNO,
                                FILLER1,
                                オーダーアイテムNO,
                                ITEM,
                                基本部番,
                                設変部番,
                                KD部番,
                                部品色,
                                輸出部品名称,
                                第二外国語名称,
                                主管SS,
                                現地ロケーションNO,
                                部品単位重量,
                                個装資材記号,
                                個装手順SEQ,
                                部品収容数,
                                個装担当NO,
                                内装資材記号,
                                内装手順SEQ,
                                内装NO,
                                個装入り数,
                                内装担当NO,
                                外装資材記号,
                                モジュール手順SEQ,
                                内装入り数,
                                外装担当NO1,
                                外装担当NO2,
                                台当り使用個数,
                                包装指示数,
                                ケース個内装荷姿必要,
                                コンテンツ必要枚数,
                                要否区分,
                                品質チェック要否,
                                取引先NO,
                                搬入ホーム,
                                海事専用機種名称,
                                包装特性1,
                                包装特性2,
                                包装特性3,
                                包装特性4,
                                包装特性5,
                                FILLER2,
                                部品包装特性1,
                                部品包装特性2,
                                部品包装特性3,
                                部品包装特性4,
                                部品包装特性5,
                                内装総重量,
                                代表区分2,
                                副資材1,
                                必要数1,
                                代表区分3,
                                副資材2,
                                必要数2,
                                代表区分4,
                                副資材3,
                                必要数3,
                                代表区分5,
                                副資材4,
                                必要数4,
                                代表区分6,
                                副資材5,
                                必要数5,
                                代表区分7,
                                副資材6,
                                必要数6,
                                代表区分8,
                                副資材7,
                                必要数7,
                                代表区分9,
                                副資材8,
                                必要数8,
                                代表区分10,
                                副資材9,
                                必要数9,
                                代表区分11,
                                副資材10,
                                必要数10,
                                代表区分12,
                                副資材11,
                                必要数11,
                                代表区分13,
                                副資材12,
                                必要数12,
                                代表区分14,
                                副資材13,
                                必要数13,
                                代表区分15,
                                副資材14,
                                必要数14,
                                代表区分16,
                                副資材15,
                                必要数15,
                                代表区分17,
                                副資材16,
                                必要数16,
                                代表区分18,
                                副資材17,
                                必要数17,
                                代表区分19,
                                副資材18,
                                必要数18,
                                代表区分20,
                                副資材19,
                                必要数19,
                                代表区分21,
                                副資材20,
                                必要数20,
                                ダイレクト包装記号1,
                                リターナブル区分1,
                                ダイレクト包装記号2,
                                リターナブル区分2,
                                ダイレクト包装記号3,
                                リターナブル区分3,
                                HNS,
                                保税区分,
                                エンジンASSY区分,
                                部品特性3,
                                部品特性4,
                                部品特性5,
                                部品特性6,
                                原産国コード1,
                                外産品区分1,
                                部品特性10,
                                FILLER3,
                                DIST名称,
                                基本部番ハイフン付,
                                設変部番ハイフン付,
                                部品特性フラブ,
                                部品属性4,
                                輸送手段,
                                実績有無区分,
                                実績数量,
                                種別NO,
                                原産国コード2,
                                外産品区分2,
                                モジュールコード,
                                ケースNO2,
                                転送日時,
                                FILLER4,
                                取込年月,
                                見積No
                            )
                            SELECT
                                工程管理ｼｽﾃﾑ日付,
                                処理ID,
                                包装指示1,
                                コンテンツ1,
                                パッケージコンテンツ1,
                                パッキングチェックシート1,
                                ケースマーク1,
                                部品管理エフ1,
                                包装指示2,
                                コンテンツ2,
                                パッケージコンテンツ2,
                                パッキングチェックシート2,
                                ケースマーク2,
                                部品管理エフ2,
                                包装指示3,
                                コンテンツ3,
                                パッケージコンテンツ3,
                                パッキングチェックシート3,
                                ケースマーク3,
                                部品管理エフ3,
                                包装指示4,
                                コンテンツ4,
                                パッケージコンテンツ4,
                                パッキングチェックシート4,
                                ケースマーク4,
                                部品管理エフ4,
                                予約1,
                                予約2,
                                予約3,
                                予約4,
                                予約5,
                                アイテムNO表示,
                                KD部番表示区分,
                                C_M重量表示要否,
                                A_Sフォーマット,
                                A_S日本表示形式,
                                A_S現地表示形式,
                                A_S輸出部品名称,
                                P_ﾘｽﾄ2ND記述,
                                包装資材表示要否,
                                オプション表示区分,
                                機種コード表示区分,
                                予約6,
                                原産国表示要否,
                                対応要否_10_2,
                                対応要否_5品目,
                                包装SS,
                                汎区分24,
                                PC_NO,
                                ｺﾝﾄﾛｰﾙNO,
                                年度1,
                                モデル1,
                                モデフNO,
                                ケースNO1,
                                レコードID,
                                バッチ処理エラーコード,
                                量産_枠外区分,
                                インボイスNO,
                                代表DIST,
                                部品群,
                                包装ロットNO,
                                包装ロット連番,
                                現地工場コード,
                                現地ラインNO1,
                                年1,
                                月1,
                                連番1,
                                サフィックス,
                                K_Y_KD1,
                                年度2,
                                モデル2,
                                タイプ1,
                                オプション1,
                                外装HES1,
                                内装タイプ1,
                                K_Y_KD2,
                                年度3,
                                モデル3,
                                タイプ2,
                                群,
                                外装HES2,
                                内装タイプ2,
                                K_Y_KD3,
                                年度4,
                                モデル4,
                                タイプ3,
                                オプション2,
                                外装HES3,
                                内装タイプ3,
                                MIX区分,
                                代表区分1,
                                包装仕様有無区分,
                                包装場,
                                オーダー区分,
                                オーダー経歴NO,
                                配送先DIST,
                                オーダー元プラント,
                                現地ラインNO2,
                                モデル年度,
                                オーダー理由コード,
                                オーダー年月日SEQ,
                                シップメントNO,
                                基本生産計画区分,
                                計画年月,
                                計画改訂NO,
                                計画コード,
                                包装予定日,
                                計画確定区分,
                                SS,
                                本社製品区分,
                                年2,
                                月2,
                                連番2,
                                包装数量,
                                個装ライン,
                                内装ライン,
                                包装ライン_外装,
                                ケース順位,
                                包装ロット台数,
                                ケース保税区分,
                                ケースグロスL,
                                ケースグロスW,
                                ケースグロスH,
                                ケースグロス容量M3,
                                ケースネットL,
                                ケースネットW,
                                ケースネットH,
                                ケースネット容量M3,
                                ケースネット重量,
                                ケース重量計画値,
                                ケース実績重量,
                                ケース重量測定要求,
                                初物部品ケースサイン,
                                エンジンASSYサイン,
                                K_Y_KD4,
                                年度5,
                                モデル5,
                                タイプ4,
                                オプション3,
                                外装HES4,
                                内装タイプ4,
                                エンジン入り数,
                                パッキングNO,
                                FILLER1,
                                オーダーアイテムNO,
                                ITEM,
                                基本部番,
                                設変部番,
                                KD部番,
                                部品色,
                                輸出部品名称,
                                第二外国語名称,
                                主管SS,
                                現地ロケーションNO,
                                部品単位重量,
                                個装資材記号,
                                個装手順SEQ,
                                部品収容数,
                                個装担当NO,
                                内装資材記号,
                                内装手順SEQ,
                                内装NO,
                                個装入り数,
                                内装担当NO,
                                外装資材記号,
                                モジュール手順SEQ,
                                内装入り数,
                                外装担当NO1,
                                外装担当NO2,
                                台当り使用個数,
                                包装指示数,
                                ケース個内装荷姿必要,
                                コンテンツ必要枚数,
                                要否区分,
                                品質チェック要否,
                                取引先NO,
                                搬入ホーム,
                                海事専用機種名称,
                                包装特性1,
                                包装特性2,
                                包装特性3,
                                包装特性4,
                                包装特性5,
                                FILLER2,
                                部品包装特性1,
                                部品包装特性2,
                                部品包装特性3,
                                部品包装特性4,
                                部品包装特性5,
                                内装総重量,
                                代表区分2,
                                副資材1,
                                必要数1,
                                代表区分3,
                                副資材2,
                                必要数2,
                                代表区分4,
                                副資材3,
                                必要数3,
                                代表区分5,
                                副資材4,
                                必要数4,
                                代表区分6,
                                副資材5,
                                必要数5,
                                代表区分7,
                                副資材6,
                                必要数6,
                                代表区分8,
                                副資材7,
                                必要数7,
                                代表区分9,
                                副資材8,
                                必要数8,
                                代表区分10,
                                副資材9,
                                必要数9,
                                代表区分11,
                                副資材10,
                                必要数10,
                                代表区分12,
                                副資材11,
                                必要数11,
                                代表区分13,
                                副資材12,
                                必要数12,
                                代表区分14,
                                副資材13,
                                必要数13,
                                代表区分15,
                                副資材14,
                                必要数14,
                                代表区分16,
                                副資材15,
                                必要数15,
                                代表区分17,
                                副資材16,
                                必要数16,
                                代表区分18,
                                副資材17,
                                必要数17,
                                代表区分19,
                                副資材18,
                                必要数18,
                                代表区分20,
                                副資材19,
                                必要数19,
                                代表区分21,
                                副資材20,
                                必要数20,
                                ダイレクト包装記号1,
                                リターナブル区分1,
                                ダイレクト包装記号2,
                                リターナブル区分2,
                                ダイレクト包装記号3,
                                リターナブル区分3,
                                HNS,
                                保税区分,
                                エンジンASSY区分,
                                部品特性3,
                                部品特性4,
                                部品特性5,
                                部品特性6,
                                原産国コード1,
                                外産品区分1,
                                部品特性10,
                                FILLER3,
                                DIST名称,
                                基本部番ハイフン付,
                                設変部番ハイフン付,
                                部品特性フラブ,
                                部品属性4,
                                輸送手段,
                                実績有無区分,
                                実績数量,
                                種別NO,
                                原産国コード2,
                                外産品区分2,
                                モジュールコード,
                                ケースNO2,
                                転送日時,
                                FILLER4,
                                取込年月,
                                " & _target_mitsumori_no &
                            "FROM TargetData;"

        Return sql

    End Function

    Function MakeSQL2(_target_mitsumori_no As String) As String

        ' SQL文（INSERT文）
        Dim sql As String = "INSERT INTO [dbo].[T_CCC_Lot] (
                            工程管理ｼｽﾃﾑ日付,
                            処理ID,
                            包装指示1,
                            コンテンツ1,
                            パッケージコンテンツ1,
                            パッキングチェックシート1,
                            ケースマーク1,
                            部品管理エフ1,
                            包装指示2,
                            コンテンツ2,
                            パッケージコンテンツ2,
                            パッキングチェックシート2,
                            ケースマーク2,
                            部品管理エフ2,
                            包装指示3,
                            コンテンツ3,
                            パッケージコンテンツ3,
                            パッキングチェックシート3,
                            ケースマーク3,
                            部品管理エフ3,
                            包装指示4,
                            コンテンツ4,
                            パッケージコンテンツ4,
                            パッキングチェックシート4,
                            ケースマーク4,
                            部品管理エフ4,
                            予約1,
                            予約2,
                            予約3,
                            予約4,
                            予約5,
                            アイテムNO表示,
                            KD部番表示区分,
                            C_M重量表示要否,
                            A_Sフォーマット,
                            A_S日本表示形式,
                            A_S現地表示形式,
                            A_S輸出部品名称,
                            P_ﾘｽﾄ2ND記述,
                            包装資材表示要否,
                            オプション表示区分,
                            機種コード表示区分,
                            予約6,
                            原産国表示要否,
                            対応要否_10_2,
                            対応要否_5品目,
                            包装SS,
                            汎区分24,
                            PC_NO,
                            ｺﾝﾄﾛｰﾙNO,
                            年度1,
                            モデル1,
                            モデフNO,
                            ケースNO1,
                            レコードID,
                            バッチ処理エラーコード,
                            量産_枠外区分,
                            インボイスNO,
                            代表DIST,
                            部品群,
                            包装ロットNO,
                            包装ロット連番,
                            現地工場コード,
                            現地ラインNO1,
                            年1,
                            月1,
                            連番1,
                            サフィックス,
                            K_Y_KD1,
                            年度2,
                            モデル2,
                            タイプ1,
                            オプション1,
                            外装HES1,
                            内装タイプ1,
                            K_Y_KD2,
                            年度3,
                            モデル3,
                            タイプ2,
                            群,
                            外装HES2,
                            内装タイプ2,
                            K_Y_KD3,
                            年度4,
                            モデル4,
                            タイプ3,
                            オプション2,
                            外装HES3,
                            内装タイプ3,
                            MIX区分,
                            代表区分1,
                            包装仕様有無区分,
                            包装場,
                            オーダー区分,
                            オーダー経歴NO,
                            配送先DIST,
                            オーダー元プラント,
                            現地ラインNO2,
                            モデル年度,
                            オーダー理由コード,
                            オーダー年月日SEQ,
                            シップメントNO,
                            基本生産計画区分,
                            計画年月,
                            計画改訂NO,
                            計画コード,
                            包装予定日,
                            計画確定区分,
                            SS,
                            本社製品区分,
                            年2,
                            月2,
                            連番2,
                            包装数量,
                            個装ライン,
                            内装ライン,
                            包装ライン_外装,
                            ケース順位,
                            包装ロット台数,
                            ケース保税区分,
                            ケースグロスL,
                            ケースグロスW,
                            ケースグロスH,
                            ケースグロス容量M3,
                            ケースネットL,
                            ケースネットW,
                            ケースネットH,
                            ケースネット容量M3,
                            ケースネット重量,
                            ケース重量計画値,
                            ケース実績重量,
                            ケース重量測定要求,
                            初物部品ケースサイン,
                            エンジンASSYサイン,
                            K_Y_KD4,
                            年度5,
                            モデル5,
                            タイプ4,
                            オプション3,
                            外装HES4,
                            内装タイプ4,
                            エンジン入り数,
                            パッキングNO,
                            FILLER1,
                            オーダーアイテムNO,
                            ITEM,
                            基本部番,
                            設変部番,
                            KD部番,
                            部品色,
                            輸出部品名称,
                            第二外国語名称,
                            主管SS,
                            現地ロケーションNO,
                            部品単位重量,
                            個装資材記号,
                            個装手順SEQ,
                            部品収容数,
                            個装担当NO,
                            内装資材記号,
                            内装手順SEQ,
                            内装NO,
                            個装入り数,
                            内装担当NO,
                            外装資材記号,
                            モジュール手順SEQ,
                            内装入り数,
                            外装担当NO1,
                            外装担当NO2,
                            台当り使用個数,
                            包装指示数,
                            ケース個内装荷姿必要,
                            コンテンツ必要枚数,
                            要否区分,
                            品質チェック要否,
                            取引先NO,
                            搬入ホーム,
                            海事専用機種名称,
                            包装特性1,
                            包装特性2,
                            包装特性3,
                            包装特性4,
                            包装特性5,
                            FILLER2,
                            部品包装特性1,
                            部品包装特性2,
                            部品包装特性3,
                            部品包装特性4,
                            部品包装特性5,
                            内装総重量,
                            代表区分2,
                            副資材1,
                            必要数1,
                            代表区分3,
                            副資材2,
                            必要数2,
                            代表区分4,
                            副資材3,
                            必要数3,
                            代表区分5,
                            副資材4,
                            必要数4,
                            代表区分6,
                            副資材5,
                            必要数5,
                            代表区分7,
                            副資材6,
                            必要数6,
                            代表区分8,
                            副資材7,
                            必要数7,
                            代表区分9,
                            副資材8,
                            必要数8,
                            代表区分10,
                            副資材9,
                            必要数9,
                            代表区分11,
                            副資材10,
                            必要数10,
                            代表区分12,
                            副資材11,
                            必要数11,
                            代表区分13,
                            副資材12,
                            必要数12,
                            代表区分14,
                            副資材13,
                            必要数13,
                            代表区分15,
                            副資材14,
                            必要数14,
                            代表区分16,
                            副資材15,
                            必要数15,
                            代表区分17,
                            副資材16,
                            必要数16,
                            代表区分18,
                            副資材17,
                            必要数17,
                            代表区分19,
                            副資材18,
                            必要数18,
                            代表区分20,
                            副資材19,
                            必要数19,
                            代表区分21,
                            副資材20,
                            必要数20,
                            ダイレクト包装記号1,
                            リターナブル区分1,
                            ダイレクト包装記号2,
                            リターナブル区分2,
                            ダイレクト包装記号3,
                            リターナブル区分3,
                            HNS,
                            保税区分,
                            エンジンASSY区分,
                            部品特性3,
                            部品特性4,
                            部品特性5,
                            部品特性6,
                            原産国コード1,
                            外産品区分1,
                            部品特性10,
                            FILLER3,
                            DIST名称,
                            基本部番ハイフン付,
                            設変部番ハイフン付,
                            部品特性フラブ,
                            部品属性4,
                            輸送手段,
                            実績有無区分,
                            実績数量,
                            種別NO,
                            原産国コード2,
                            外産品区分2,
                            モジュールコード,
                            ケースNO2,
                            転送日時,
                            FILLER4,
                            取込年月,
                            見積No,
                            単品部品総数,
                            部品点数,
                            防錆回数,
                            個装数,
                            内装資材数,
                            カートン数,
                            リターナブル容器数,
                            ENG発泡材数,
                            積み付け回数,
                            パネルケース数,
                            スカシケース数,
                            外装用段ボールパット使用数,
                            外装用箱型ポリ袋,
                            外装用ボルト使用数,
                            外装用副資材使用数,
                            外直部品総数,
                            外直の防錆回数,
                            外装ケース数,
                            部品点数_集計,
                            個装資材費,
                            内装資材費,
                            外装資材費,
                            個装作業,
                            内装作業,
                            外装作業,
                            作業計,
                            個_内装資材,
                            外装資材,
                            資材計

                            )
                            SELECT 
                            Main.工程管理ｼｽﾃﾑ日付,
                            Main.処理ID,
                            Main.包装指示1,
                            Main.コンテンツ1,
                            Main.パッケージコンテンツ1,
                            Main.パッキングチェックシート1,
                            Main.ケースマーク1,
                            Main.部品管理エフ1,
                            Main.包装指示2,
                            Main.コンテンツ2,
                            Main.パッケージコンテンツ2,
                            Main.パッキングチェックシート2,
                            Main.ケースマーク2,
                            Main.部品管理エフ2,
                            Main.包装指示3,
                            Main.コンテンツ3,
                            Main.パッケージコンテンツ3,
                            Main.パッキングチェックシート3,
                            Main.ケースマーク3,
                            Main.部品管理エフ3,
                            Main.包装指示4,
                            Main.コンテンツ4,
                            Main.パッケージコンテンツ4,
                            Main.パッキングチェックシート4,
                            Main.ケースマーク4,
                            Main.部品管理エフ4,
                            Main.予約1,
                            Main.予約2,
                            Main.予約3,
                            Main.予約4,
                            Main.予約5,
                            Main.アイテムNO表示,
                            Main.KD部番表示区分,
                            Main.C_M重量表示要否,
                            Main.A_Sフォーマット,
                            Main.A_S日本表示形式,
                            Main.A_S現地表示形式,
                            Main.A_S輸出部品名称,
                            Main.P_ﾘｽﾄ2ND記述,
                            Main.包装資材表示要否,
                            Main.オプション表示区分,
                            Main.機種コード表示区分,
                            Main.予約6,
                            Main.原産国表示要否,
                            Main.対応要否_10_2,
                            Main.対応要否_5品目,
                            Main.包装SS,
                            Main.汎区分24,
                            Main.PC_NO,
                            Main.ｺﾝﾄﾛｰﾙNO,
                            Main.年度1,
                            Main.モデル1,
                            Main.モデフNO,
                            Main.ケースNO1,
                            Main.レコードID,
                            Main.バッチ処理エラーコード,
                            Main.量産_枠外区分,
                            Main.インボイスNO,
                            Main.代表DIST,
                            Main.部品群,
                            Main.包装ロットNO,
                            Main.包装ロット連番,
                            Main.現地工場コード,
                            Main.現地ラインNO1,
                            Main.年1,
                            Main.月1,
                            Main.連番1,
                            Main.サフィックス,
                            Main.K_Y_KD1,
                            Main.年度2,
                            Main.モデル2,
                            Main.タイプ1,
                            Main.オプション1,
                            Main.外装HES1,
                            Main.内装タイプ1,
                            Main.K_Y_KD2,
                            Main.年度3,
                            Main.モデル3,
                            Main.タイプ2,
                            Main.群,
                            Main.外装HES2,
                            Main.内装タイプ2,
                            Main.K_Y_KD3,
                            Main.年度4,
                            Main.モデル4,
                            Main.タイプ3,
                            Main.オプション2,
                            Main.外装HES3,
                            Main.内装タイプ3,
                            Main.MIX区分,
                            Main.代表区分1,
                            Main.包装仕様有無区分,
                            Main.包装場,
                            Main.オーダー区分,
                            Main.オーダー経歴NO,
                            Main.配送先DIST,
                            Main.オーダー元プラント,
                            Main.現地ラインNO2,
                            Main.モデル年度,
                            Main.オーダー理由コード,
                            Main.オーダー年月日SEQ,
                            Main.シップメントNO,
                            Main.基本生産計画区分,
                            Main.計画年月,
                            Main.計画改訂NO,
                            Main.計画コード,
                            Main.包装予定日,
                            Main.計画確定区分,
                            Main.SS,
                            Main.本社製品区分,
                            Main.年2,
                            Main.月2,
                            Main.連番2,
                            Main.包装数量,
                            Main.個装ライン,
                            Main.内装ライン,
                            Main.包装ライン_外装,
                            Main.ケース順位,
                            Main.包装ロット台数,
                            Main.ケース保税区分,
                            Main.ケースグロスL,
                            Main.ケースグロスW,
                            Main.ケースグロスH,
                            Main.ケースグロス容量M3,
                            Main.ケースネットL,
                            Main.ケースネットW,
                            Main.ケースネットH,
                            Main.ケースネット容量M3,
                            Main.ケースネット重量,
                            Main.ケース重量計画値,
                            Main.ケース実績重量,
                            Main.ケース重量測定要求,
                            Main.初物部品ケースサイン,
                            Main.エンジンASSYサイン,
                            Main.K_Y_KD4,
                            Main.年度5,
                            Main.モデル5,
                            Main.タイプ4,
                            Main.オプション3,
                            Main.外装HES4,
                            Main.内装タイプ4,
                            Main.エンジン入り数,
                            Main.パッキングNO,
                            Main.FILLER1,
                            Main.オーダーアイテムNO,
                            Main.ITEM,
                            Main.基本部番,
                            Main.設変部番,
                            Main.KD部番,
                            Main.部品色,
                            Main.輸出部品名称,
                            Main.第二外国語名称,
                            Main.主管SS,
                            Main.現地ロケーションNO,
                            Main.部品単位重量,
                            Main.個装資材記号,
                            Main.個装手順SEQ,
                            Main.部品収容数,
                            Main.個装担当NO,
                            Main.内装資材記号,
                            Main.内装手順SEQ,
                            Main.内装NO,
                            Main.個装入り数,
                            Main.内装担当NO,
                            Main.外装資材記号,
                            Main.モジュール手順SEQ,
                            Main.内装入り数,
                            Main.外装担当NO1,
                            Main.外装担当NO2,
                            Main.台当り使用個数,
                            Main.包装指示数,
                            Main.ケース個内装荷姿必要,
                            Main.コンテンツ必要枚数,
                            Main.要否区分,
                            Main.品質チェック要否,
                            Main.取引先NO,
                            Main.搬入ホーム,
                            Main.海事専用機種名称,
                            Main.包装特性1,
                            Main.包装特性2,
                            Main.包装特性3,
                            Main.包装特性4,
                            Main.包装特性5,
                            Main.FILLER2,
                            Main.部品包装特性1,
                            Main.部品包装特性2,
                            Main.部品包装特性3,
                            Main.部品包装特性4,
                            Main.部品包装特性5,
                            Main.内装総重量,
                            Main.代表区分2,
                            Main.副資材1,
                            Main.必要数1,
                            Main.代表区分3,
                            Main.副資材2,
                            Main.必要数2,
                            Main.代表区分4,
                            Main.副資材3,
                            Main.必要数3,
                            Main.代表区分5,
                            Main.副資材4,
                            Main.必要数4,
                            Main.代表区分6,
                            Main.副資材5,
                            Main.必要数5,
                            Main.代表区分7,
                            Main.副資材6,
                            Main.必要数6,
                            Main.代表区分8,
                            Main.副資材7,
                            Main.必要数7,
                            Main.代表区分9,
                            Main.副資材8,
                            Main.必要数8,
                            Main.代表区分10,
                            Main.副資材9,
                            Main.必要数9,
                            Main.代表区分11,
                            Main.副資材10,
                            Main.必要数10,
                            Main.代表区分12,
                            Main.副資材11,
                            Main.必要数11,
                            Main.代表区分13,
                            Main.副資材12,
                            Main.必要数12,
                            Main.代表区分14,
                            Main.副資材13,
                            Main.必要数13,
                            Main.代表区分15,
                            Main.副資材14,
                            Main.必要数14,
                            Main.代表区分16,
                            Main.副資材15,
                            Main.必要数15,
                            Main.代表区分17,
                            Main.副資材16,
                            Main.必要数16,
                            Main.代表区分18,
                            Main.副資材17,
                            Main.必要数17,
                            Main.代表区分19,
                            Main.副資材18,
                            Main.必要数18,
                            Main.代表区分20,
                            Main.副資材19,
                            Main.必要数19,
                            Main.代表区分21,
                            Main.副資材20,
                            Main.必要数20,
                            Main.ダイレクト包装記号1,
                            Main.リターナブル区分1,
                            Main.ダイレクト包装記号2,
                            Main.リターナブル区分2,
                            Main.ダイレクト包装記号3,
                            Main.リターナブル区分3,
                            Main.HNS,
                            Main.保税区分,
                            Main.エンジンASSY区分,
                            Main.部品特性3,
                            Main.部品特性4,
                            Main.部品特性5,
                            Main.部品特性6,
                            Main.原産国コード1,
                            Main.外産品区分1,
                            Main.部品特性10,
                            Main.FILLER3,
                            Main.DIST名称,
                            Main.基本部番ハイフン付,
                            Main.設変部番ハイフン付,
                            Main.部品特性フラブ,
                            Main.部品属性4,
                            Main.輸送手段,
                            Main.実績有無区分,
                            Main.実績数量,
                            Main.種別NO,
                            Main.原産国コード2,
                            Main.外産品区分2,
                            Main.モジュールコード,
                            Main.ケースNO2,
                            Main.転送日時,
                            Main.FILLER4,
                            Main.取込年月," &
                            _target_mitsumori_no & "
		
		                    --単品部品総数
		                    ,CASE WHEN OrderList1.id IS  NULL THEN
		
			                    CASE WHEN Naisou1.内装資材コード IS NOT NULL THEN
				 	                    CONVERT(decimal,CASE WHEN Main.部品収容数 = '0' THEN '1' ELSE Main.部品収容数 END) * 
					                    CONVERT(decimal,CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE Main.個装入り数 END) * 
					                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second1.秒数 
			                    ELSE 
					                    CASE WHEN Naisou2.内装資材コード IS NOT NULL THEN
						                    CONVERT(decimal,CASE WHEN Main.部品収容数 = '0' THEN '1' ELSE Main.部品収容数 END) * 
						                    CONVERT(decimal,CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE Main.個装入り数 END) * 
						                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second1.秒数  
					                    ELSE 0 END
			                    END
				 
		                     ELSE 0 END AS 単品部品総数
		 
		                     --部品点数
		                    ,CASE WHEN OrderList1.id IS NULL THEN Second2.秒数  ELSE 0 END AS 部品点数
		
		                     --防錆回数
		                    ,0  AS 防錆回数
		
		                    --個装数
		                    ,CASE WHEN OrderList1.id IS  NULL THEN
		
			                    CASE WHEN Kosou.個装資材コード IS NOT NULL THEN
			 	                    CONVERT(decimal,CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE Main.個装入り数 END) * 
				                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second4.秒数  
			                    ELSE 
					                    0
			                    END
				 
		                     ELSE 
		 
		 	                    CONVERT(decimal,CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE Main.個装入り数 END) * 
			                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second4.秒数  
			
		                     END AS 個装数
		 
		                     --内装資材数
		                     ,0 AS 内装資材数
		                     --カートン数
		                     ,0 AS カートン数
		                     --リターナブル容器数
		                     ,0 AS リターナブル容器数
		                     --ENG発泡材数
		                     ,CASE WHEN Main.包装ライン_外装 = 'A0' THEN
		 
			                    CASE WHEN Naisou1.内装資材コード IS NOT NULL THEN
					                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second8.秒数 
			                    ELSE 
					                    CASE WHEN Naisou2.内装資材コード IS NOT NULL THEN
						                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second8.秒数  
					                    ELSE 
						                    CASE WHEN Naisou3.内装資材コード IS NOT NULL THEN
							                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second8.秒数  
						                    ELSE 
							                    0
						                    END
					                    END
			                    END
		 
		                     ELSE 0 
		                     END AS ENG発泡材数

		                     --積み付け回数
		                     ,CASE WHEN Main.包装ライン_外装 NOT LIKE '%4%' THEN
		 
			                    CASE WHEN Naisou1.内装資材コード IS NOT NULL THEN
					                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second9.秒数 
			                    ELSE 
					                    CASE WHEN Naisou2.内装資材コード IS NOT NULL THEN
						                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second9.秒数  
					                    ELSE 
						                    0
					                    END
			                    END
		 
		                     ELSE 0 
		                     END AS 積み付け回数
		 
		                     --パネルケース数
		                     ,0 AS パネルケース数
		 
		                     --スカシケース数
		                     ,0 AS スカシケース数

		                    --外装用段ボールパット使用数
		                    ,0 AS 外装用段ボールパット使用数
		                    --外装用箱型ポリ袋
		                    ,0 AS 外装用箱型ポリ袋
		                    --外装用ボルト使用数
		                    ,0 AS 外装用ボルト使用数
		                    --外装用副資材使用数
		                    ,0 AS 外装用副資材使用数
		
		                    --外直部品総数
		                     ,CASE WHEN Main.包装ライン_外装  LIKE '%4%' THEN
		 
			                    CONVERT(decimal,CASE WHEN Main.部品収容数 = '0' THEN '1' ELSE Main.部品収容数 END) * 
			                    CONVERT(decimal,CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE Main.個装入り数 END) *
			                    CONVERT(decimal,CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE Main.内装入り数 END) * Second16.秒数
		 
		                     ELSE 0 
		                     END AS 外直部品総数
		
		                    --外直の防錆回数
		                    ,0 AS 外直の防錆回数
		
		                    --外装ケース数
		                    ,Second18.秒数 AS 外装ケース数
		
		                    --部品点数2
		                    ,CASE WHEN OrderList2.id IS NOT NULL THEN
			                    Second19.秒数 
		                     ELSE 0
		                     END AS 部品点数_集計

		                    --個装資材費
		                    ,CASE WHEN Housou_Kbn_Kosou.個装内装区分 = '個装' THEN
		                        CASE WHEN Housou_Kbn_Naisou.個装内装区分 = '内装' THEN
		                            CASE WHEN Main.包装ライン_外装 LIKE '%M%' THEN
		                                ISNULL(KOW46.ケース当たりの内装資材費, 0)
		                            ELSE
		                                ISNULL(CONVERT(decimal, CASE WHEN Kosou_Tanka.単価 = '0' THEN '1' ELSE ISNULL(Kosou_Tanka.単価,'1') END), 1) *
		                                ISNULL(CONVERT(decimal, CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE ISNULL(Main.個装入り数,'1') END), 1) *
		                                ISNULL(CONVERT(decimal, CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE ISNULL(Main.内装入り数,'1') END), 1)
		                            END
		                        ELSE
		                            ISNULL(KOW46.ケース当たりの内装資材費, 0)
		                        END
		                    ELSE
		                        CASE WHEN Housou_Kbn_Naisou.個装内装区分 = '内装' THEN
		                            ISNULL(CONVERT(decimal, CASE WHEN Kosou_Tanka.単価 = '0' THEN '1' ELSE ISNULL(Kosou_Tanka.単価,'1') END), 1) *
		                            ISNULL(CONVERT(decimal, CASE WHEN Main.個装入り数 = '0' THEN '1' ELSE ISNULL(Main.個装入り数,'1') END), 1) *
		                            ISNULL(CONVERT(decimal, CASE WHEN Main.内装入り数 = '0' THEN '1' ELSE ISNULL(Main.内装入り数,'1') END), 1)
		                        ELSE 
		                            0
		                        END
		                    END AS 個装資材費

                            ,0 AS 内装資材費
                            ,0 AS 外装資材費
                            ,0 AS 個装作業
                            ,0 AS 内装作業
                            ,0 AS 外装作業
                            ,0 AS 作業計
                            ,0 AS 個_内装資材
                            ,0 AS 外装資材
                            ,0 AS 資材計
				
		                    FROM T_CCC_Work Main
		                    LEFT JOIN M_Naisou_Shizai Naisou1
		                    ON Main.個装資材記号 = Naisou1.内装資材コード

		                    LEFT JOIN M_Naisou_Shizai Naisou2
		                    ON Main.内装資材記号 = Naisou2.内装資材コード

		                    LEFT JOIN M_Naisou_Shizai Naisou3
		                    ON Main.外装資材記号 = Naisou3.内装資材コード

		                    LEFT JOIN M_Kosou_Shizai Kosou
		                    ON Main.個装資材記号 = Kosou.個装資材コード

		                    LEFT JOIN M_Housou_Kbn Housou_Kbn_Naisou
		                    ON Main.代表DIST = Housou_Kbn_Naisou.DIST
		                    AND Housou_Kbn_Naisou.個装内装区分 = '内装'
		
		                    LEFT JOIN M_Housou_Kbn Housou_Kbn_Kosou	
		                    ON Main.代表DIST = Housou_Kbn_Kosou.DIST
		                    AND Housou_Kbn_Kosou.個装内装区分 = '個装'
		
		                    LEFT JOIN M_Tanka Kosou_Tanka
		                    ON Main.個装資材記号 = Kosou_Tanka.資材コード

		                    LEFT JOIN T_KOW46 KOW46
		                    ON Main.包装ロットNO + RIGHT('00' + CAST(Main.包装ロット連番 AS VARCHAR(2)), 2) = KOW46.包装ロットNo
		                    AND Main.ｺﾝﾄﾛｰﾙNO = KOW46.MUDULE
		                    AND Main.ケースNO1= KOW46.本C_No
		                    AND Main.モジュール手順SEQ = KOW46.内装手順
                            AND Main.見積No = KOW46.見積No

		                    LEFT JOIN T_Buhin_Order_List OrderList1
		                    ON Main.代表DIST = OrderList1.DIST
		                    AND Main.基本部番 = OrderList1.Basic_Part_No
                            AND Main.見積No = OrderList1.見積No
		                    AND (
		                            OrderList1.資材コード1  LIKE '%ZW%' OR OrderList1.資材コード1  LIKE '%RT%' OR
		                            OrderList1.資材コード2  LIKE '%ZW%' OR OrderList1.資材コード2  LIKE '%RT%' OR
		                            OrderList1.資材コード3  LIKE '%ZW%' OR OrderList1.資材コード3  LIKE '%RT%' OR
		                            OrderList1.資材コード4  LIKE '%ZW%' OR OrderList1.資材コード4  LIKE '%RT%' OR
		                            OrderList1.資材コード5  LIKE '%ZW%' OR OrderList1.資材コード5  LIKE '%RT%' OR
		                            OrderList1.資材コード6  LIKE '%ZW%' OR OrderList1.資材コード6  LIKE '%RT%' OR
		                            OrderList1.資材コード7  LIKE '%ZW%' OR OrderList1.資材コード7  LIKE '%RT%' OR
		                            OrderList1.資材コード8  LIKE '%ZW%' OR OrderList1.資材コード8  LIKE '%RT%' OR
		                            OrderList1.資材コード9  LIKE '%ZW%' OR OrderList1.資材コード9  LIKE '%RT%' OR
		                            OrderList1.資材コード10 LIKE '%ZW%' OR OrderList1.資材コード10 LIKE '%RT%' OR
		                            OrderList1.資材コード11 LIKE '%ZW%' OR OrderList1.資材コード11 LIKE '%RT%' OR
		                            OrderList1.資材コード12 LIKE '%ZW%' OR OrderList1.資材コード12 LIKE '%RT%' OR
		                            OrderList1.資材コード13 LIKE '%ZW%' OR OrderList1.資材コード13 LIKE '%RT%' OR
		                            OrderList1.資材コード14 LIKE '%ZW%' OR OrderList1.資材コード14 LIKE '%RT%' OR
		                            OrderList1.資材コード15 LIKE '%ZW%' OR OrderList1.資材コード15 LIKE '%RT%'
		                    )

		                    LEFT JOIN T_Buhin_Order_List OrderList2
		                    ON Main.代表DIST = OrderList2.DIST
		                    AND Main.基本部番 = OrderList2.Basic_Part_No
                            AND Main.見積No = OrderList2.見積No
		                    LEFT JOIN M_Second Second1  ON Second1.作業区分 = 1
		                    LEFT JOIN M_Second Second2  ON Second2.作業区分 = 2
		                    LEFT JOIN M_Second Second3  ON Second3.作業区分 = 3
		                    LEFT JOIN M_Second Second4  ON Second4.作業区分 = 4
		                    LEFT JOIN M_Second Second5  ON Second5.作業区分 = 5
		                    LEFT JOIN M_Second Second6  ON Second6.作業区分 = 6
		                    LEFT JOIN M_Second Second7  ON Second7.作業区分 = 7
		                    LEFT JOIN M_Second Second8  ON Second8.作業区分 = 8
		                    LEFT JOIN M_Second Second9  ON Second9.作業区分 = 9
		                    LEFT JOIN M_Second Second10 ON Second10.作業区分 = 10
		                    LEFT JOIN M_Second Second11 ON Second11.作業区分 = 11
		                    LEFT JOIN M_Second Second12 ON Second12.作業区分 = 12
		                    LEFT JOIN M_Second Second13 ON Second13.作業区分 = 13
		                    LEFT JOIN M_Second Second14 ON Second14.作業区分 = 14
		                    LEFT JOIN M_Second Second15 ON Second15.作業区分 = 15
		                    LEFT JOIN M_Second Second16 ON Second16.作業区分 = 16
		                    LEFT JOIN M_Second Second17 ON Second17.作業区分 = 17
		                    LEFT JOIN M_Second Second18 ON Second18.作業区分 = 18
		                    LEFT JOIN M_Second Second19 ON Second19.作業区分 = 19;"

        Return sql

    End Function

    Function MakeSQL3(_target_mitsumori_no As String) As String

        ' SQL文
        Dim sql As String = ""

        sql = "DELETE FROM M_Bolt_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Bolt_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Gaisou_Box_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Gaisou_Danboru_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Housou_Kbn_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Kosou_Shizai_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Mitsumori_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Naisou_Shizai_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Rate_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Second_BK WHERE 見積No = '" & _target_mitsumori_no & "';"
        sql = sql & " DELETE FROM M_Tanka_BK WHERE 見積No = '" & _target_mitsumori_no & "';"

        Return sql

    End Function

    Function MakeSQL4(_target_mitsumori_no As String) As String

        ' SQL文
        Dim sql As String = ""

        sql = "INSERT INTO M_Bolt_BK (個装資材コード, 見積No) SELECT 個装資材コード, " & _target_mitsumori_no & " FROM M_Bolt;"
        sql = sql & " INSERT INTO M_Gaisou_Box_BK (内装資材コード, 見積No) SELECT 内装資材コード, " & _target_mitsumori_no & " FROM M_Gaisou_Box;"
        sql = sql & " INSERT INTO M_Gaisou_Danboru_BK (内装資材コード, 見積No) SELECT 内装資材コード, " & _target_mitsumori_no & " FROM M_Gaisou_Danboru;"
        sql = sql & " INSERT INTO M_Housou_Kbn_BK (ライン,DIST,個装内装区分,区分,定量_不定量, 見積No) SELECT ライン,DIST,個装内装区分,区分,定量_不定量, " & _target_mitsumori_no & " FROM M_Housou_Kbn;"
        sql = sql & " INSERT INTO M_Kosou_Shizai_BK (個装資材コード, 見積No) SELECT 個装資材コード, " & _target_mitsumori_no & " FROM M_Kosou_Shizai;"
        sql = sql & " INSERT INTO M_Mitsumori_BK (見積コード,仕向,機種,タイプ,OP, 見積No) SELECT 見積コード,仕向,機種,タイプ,OP, " & _target_mitsumori_no & " FROM M_Mitsumori;"
        sql = sql & " INSERT INTO M_Naisou_Shizai_BK (内装資材コード,数量, 見積No) SELECT 内装資材コード,数量, " & _target_mitsumori_no & " FROM M_Naisou_Shizai;"
        sql = sql & " INSERT INTO M_Rate_BK (賃率, 見積No) SELECT 賃率, " & _target_mitsumori_no & " FROM M_Rate;"
        sql = sql & " INSERT INTO M_Second_BK (作業区分,作業単位,秒数, 見積No) SELECT 作業区分,作業単位,秒数, " & _target_mitsumori_no & " FROM M_Second;"
        sql = sql & " INSERT INTO M_Tanka_BK (資材コード,資材名,単価,メーカーコード, 見積No) SELECT 資材コード,資材名,単価,メーカーコード, " & _target_mitsumori_no & " FROM M_Tanka;"
        sql = sql & " INSERT INTO M_Keisu_BK (仕向,機種,群,係数, 見積No) SELECT 仕向,機種,群,係数, " & _target_mitsumori_no & " FROM M_Keisu;"
        Return sql

    End Function

    Function MakeSQL5(_target_mitsumori_no As String, _panel_case As String, _sukashi_case As String, gaisou_danboru As String,
                      gaisou_pori As String, gaisou_bolt As String, _gaisou_fukushizai As String, _gaichoku_bousabi As String, _gaichoku_case As String) As String

        ' SQL文
        Dim sql As String = ""

        'パネルケース数
        sql = "WITH cte AS (
                    SELECT t.*,
                           ROW_NUMBER() OVER (PARTITION BY t.ｺﾝﾄﾛｰﾙNO, t.ケースNO1, t.包装ロットNO
                                              ORDER BY t.id) AS rn
                    FROM T_CCC_Lot t
                    WHERE t.見積No = " & _target_mitsumori_no & "
                      AND EXISTS (
                          SELECT 1
                          FROM T_CCC_Lot tt
                          WHERE tt.外装資材記号 LIKE '%SP%'
                            AND tt.ｺﾝﾄﾛｰﾙNO = t.ｺﾝﾄﾛｰﾙNO
                            AND tt.ケースNO1 = t.ケースNO1
                            AND tt.包装ロットNO = t.包装ロットNO
                      )
                )
                UPDATE cte
                SET パネルケース数 =  " & _panel_case & "
                WHERE rn = 1;"


        'スカシケース数
        sql = "WITH cte AS (
                    SELECT t.*,
                           ROW_NUMBER() OVER (PARTITION BY t.ｺﾝﾄﾛｰﾙNO, t.ケースNO1, t.包装ロットNO
                                              ORDER BY t.id) AS rn
                    FROM T_CCC_Lot t
                    WHERE t.見積No = " & _target_mitsumori_no & "
                      AND EXISTS (
                          SELECT 1
                          FROM T_CCC_Lot tt
                          WHERE tt.外装資材記号 LIKE '%SP%' OR tt.外装資材記号 LIKE '%RC%' OR tt.外装資材記号 LIKE '%CY%'
                            AND tt.ｺﾝﾄﾛｰﾙNO = t.ｺﾝﾄﾛｰﾙNO
                            AND tt.ケースNO1 = t.ケースNO1
                            AND tt.包装ロットNO = t.包装ロットNO
                      )
                )
                UPDATE cte
                SET スカシケース数 =  " & _sukashi_case & "
                WHERE rn = 1;"


        '外装用段ボールパット使用数
        sql = sql & " UPDATE t
                        SET t.外装用段ボールパット使用数 = 
                            ISNULL(
                                (CASE WHEN g12.内装資材コード IS NOT NULL THEN t.必要数12 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g13.内装資材コード IS NOT NULL THEN t.必要数13 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g14.内装資材コード IS NOT NULL THEN t.必要数14 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g15.内装資材コード IS NOT NULL THEN t.必要数15 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g16.内装資材コード IS NOT NULL THEN t.必要数16 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g17.内装資材コード IS NOT NULL THEN t.必要数17 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g18.内装資材コード IS NOT NULL THEN t.必要数18 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g19.内装資材コード IS NOT NULL THEN t.必要数19 * " & gaisou_danboru & " ELSE 0 END) +
                                (CASE WHEN g20.内装資材コード IS NOT NULL THEN t.必要数20 * " & gaisou_danboru & " ELSE 0 END)
                            , 0)
                        FROM T_CCC_Lot t
                        LEFT JOIN M_Gaisou_Danboru g12 ON t.副資材12 = g12.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g13 ON t.副資材13 = g13.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g14 ON t.副資材14 = g14.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g15 ON t.副資材15 = g15.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g16 ON t.副資材16 = g16.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g17 ON t.副資材17 = g17.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g18 ON t.副資材18 = g18.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g19 ON t.副資材19 = g19.内装資材コード
                        LEFT JOIN M_Gaisou_Danboru g20 ON t.副資材20 = g20.内装資材コード
                        WHERE t.見積No = " & _target_mitsumori_no & ";"

        '外装用箱型ポリ袋
        sql = sql & " UPDATE t
                        SET t.外装用箱型ポリ袋 = 
                            ISNULL(
                                (CASE WHEN g12.内装資材コード IS NOT NULL THEN t.必要数12 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g13.内装資材コード IS NOT NULL THEN t.必要数13 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g14.内装資材コード IS NOT NULL THEN t.必要数14 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g15.内装資材コード IS NOT NULL THEN t.必要数15 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g16.内装資材コード IS NOT NULL THEN t.必要数16 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g17.内装資材コード IS NOT NULL THEN t.必要数17 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g18.内装資材コード IS NOT NULL THEN t.必要数18 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g19.内装資材コード IS NOT NULL THEN t.必要数19 * " & gaisou_pori & " ELSE 0 END) +
                                (CASE WHEN g20.内装資材コード IS NOT NULL THEN t.必要数20 * " & gaisou_pori & " ELSE 0 END)
                            , 0)
                        FROM T_CCC_Lot t
                        LEFT JOIN M_Gaisou_Box g12 ON t.副資材12 = g12.内装資材コード
                        LEFT JOIN M_Gaisou_Box g13 ON t.副資材13 = g13.内装資材コード
                        LEFT JOIN M_Gaisou_Box g14 ON t.副資材14 = g14.内装資材コード
                        LEFT JOIN M_Gaisou_Box g15 ON t.副資材15 = g15.内装資材コード
                        LEFT JOIN M_Gaisou_Box g16 ON t.副資材16 = g16.内装資材コード
                        LEFT JOIN M_Gaisou_Box g17 ON t.副資材17 = g17.内装資材コード
                        LEFT JOIN M_Gaisou_Box g18 ON t.副資材18 = g18.内装資材コード
                        LEFT JOIN M_Gaisou_Box g19 ON t.副資材19 = g19.内装資材コード
                        LEFT JOIN M_Gaisou_Box g20 ON t.副資材20 = g20.内装資材コード
                        WHERE t.見積No = " & _target_mitsumori_no & ";"

        '外装用ボルト使用数
        sql = sql & " UPDATE t
                        SET t.外装用ボルト使用数 = 
                            ISNULL(
                                (CASE WHEN g12.個装資材コード IS NOT NULL THEN t.必要数12 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g13.個装資材コード IS NOT NULL THEN t.必要数13 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g14.個装資材コード IS NOT NULL THEN t.必要数14 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g15.個装資材コード IS NOT NULL THEN t.必要数15 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g16.個装資材コード IS NOT NULL THEN t.必要数16 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g17.個装資材コード IS NOT NULL THEN t.必要数17 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g18.個装資材コード IS NOT NULL THEN t.必要数18 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g19.個装資材コード IS NOT NULL THEN t.必要数19 * " & gaisou_bolt & " ELSE 0 END) +
                                (CASE WHEN g20.個装資材コード IS NOT NULL THEN t.必要数20 * " & gaisou_bolt & " ELSE 0 END)
                            , 0)
                        FROM T_CCC_Lot t
                        LEFT JOIN M_Bolt g12 ON t.副資材12 = g12.個装資材コード
                        LEFT JOIN M_Bolt g13 ON t.副資材13 = g13.個装資材コード
                        LEFT JOIN M_Bolt g14 ON t.副資材14 = g14.個装資材コード
                        LEFT JOIN M_Bolt g15 ON t.副資材15 = g15.個装資材コード
                        LEFT JOIN M_Bolt g16 ON t.副資材16 = g16.個装資材コード
                        LEFT JOIN M_Bolt g17 ON t.副資材17 = g17.個装資材コード
                        LEFT JOIN M_Bolt g18 ON t.副資材18 = g18.個装資材コード
                        LEFT JOIN M_Bolt g19 ON t.副資材19 = g19.個装資材コード
                        LEFT JOIN M_Bolt g20 ON t.副資材20 = g20.個装資材コード
                        WHERE t.見積No = " & _target_mitsumori_no & ";"


        '外装用副資材使用数
        sql = sql & " UPDATE t
                        SET t.外装用副資材使用数 = 
                            ISNULL(
                                (CASE WHEN g12.内装資材コード IS NULL 
                                           AND b12.内装資材コード IS NULL
                                           AND bo12.個装資材コード IS NULL
                                           AND t.副資材12 NOT LIKE '%TA%' THEN t.必要数12 *  " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g13.内装資材コード IS NULL 
                                           AND b13.内装資材コード IS NULL
                                           AND bo13.個装資材コード IS NULL
                                           AND t.副資材13 NOT LIKE '%TA%' THEN t.必要数13 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g14.内装資材コード IS NULL 
                                           AND b14.内装資材コード IS NULL
                                           AND bo14.個装資材コード IS NULL
                                           AND t.副資材14 NOT LIKE '%TA%' THEN t.必要数14 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g15.内装資材コード IS NULL 
                                           AND b15.内装資材コード IS NULL
                                           AND bo15.個装資材コード IS NULL
                                           AND t.副資材15 NOT LIKE '%TA%' THEN t.必要数15 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g16.内装資材コード IS NULL 
                                           AND b16.内装資材コード IS NULL
                                           AND bo16.個装資材コード IS NULL
                                           AND t.副資材16 NOT LIKE '%TA%' THEN t.必要数16 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g17.内装資材コード IS NULL 
                                           AND b17.内装資材コード IS NULL
                                           AND bo17.個装資材コード IS NULL
                                           AND t.副資材17 NOT LIKE '%TA%' THEN t.必要数17 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g18.内装資材コード IS NULL 
                                           AND b18.内装資材コード IS NULL
                                           AND bo18.個装資材コード IS NULL
                                           AND t.副資材18 NOT LIKE '%TA%' THEN t.必要数18 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g19.内装資材コード IS NULL 
                                           AND b19.内装資材コード IS NULL
                                           AND bo19.個装資材コード IS NULL
                                           AND t.副資材19 NOT LIKE '%TA%' THEN t.必要数19 * " & _gaisou_fukushizai & " ELSE 0 END) +
                                (CASE WHEN g20.内装資材コード IS NULL 
                                           AND b20.内装資材コード IS NULL
                                           AND bo20.個装資材コード IS NULL
                                           AND t.副資材20 NOT LIKE '%TA%' THEN t.必要数20 * " & _gaisou_fukushizai & " ELSE 0 END)
                            , 0)
                        FROM T_CCC_Lot t
                        LEFT JOIN M_Gaisou_Danboru g12 ON t.副資材12 = g12.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b12 ON t.副資材12 = b12.内装資材コード
                        LEFT JOIN M_Bolt           bo12 ON t.副資材12 = bo12.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g13 ON t.副資材13 = g13.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b13 ON t.副資材13 = b13.内装資材コード
                        LEFT JOIN M_Bolt           bo13 ON t.副資材13 = bo13.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g14 ON t.副資材14 = g14.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b14 ON t.副資材14 = b14.内装資材コード
                        LEFT JOIN M_Bolt           bo14 ON t.副資材14 = bo14.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g15 ON t.副資材15 = g15.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b15 ON t.副資材15 = b15.内装資材コード
                        LEFT JOIN M_Bolt           bo15 ON t.副資材15 = bo15.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g16 ON t.副資材16 = g16.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b16 ON t.副資材16 = b16.内装資材コード
                        LEFT JOIN M_Bolt           bo16 ON t.副資材16 = bo16.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g17 ON t.副資材17 = g17.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b17 ON t.副資材17 = b17.内装資材コード
                        LEFT JOIN M_Bolt           bo17 ON t.副資材17 = bo17.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g18 ON t.副資材18 = g18.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b18 ON t.副資材18 = b18.内装資材コード
                        LEFT JOIN M_Bolt           bo18 ON t.副資材18 = bo18.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g19 ON t.副資材19 = g19.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b19 ON t.副資材19 = b19.内装資材コード
                        LEFT JOIN M_Bolt           bo19 ON t.副資材19 = bo19.個装資材コード

                        LEFT JOIN M_Gaisou_Danboru g20 ON t.副資材20 = g20.内装資材コード
                        LEFT JOIN M_Gaisou_Box    b20 ON t.副資材20 = b20.内装資材コード
                        LEFT JOIN M_Bolt           bo20 ON t.副資材20 = bo20.個装資材コード
                        WHERE t.見積No = " & _target_mitsumori_no & ";"


        '外直の防錆回数
        sql = sql & " UPDATE t
                        SET t.外直の防錆回数 = 
                            (CASE 
                                WHEN t.副資材2 LIKE '%BA008%' OR t.副資材2 LIKE '%BA009%' OR
                                     t.副資材3 LIKE '%BA008%' OR t.副資材3 LIKE '%BA009%' OR
                                     t.副資材4 LIKE '%BA008%' OR t.副資材4 LIKE '%BA009%' OR
                                     t.副資材5 LIKE '%BA008%' OR t.副資材5 LIKE '%BA009%' OR
                                     t.副資材6 LIKE '%BA008%' OR t.副資材6 LIKE '%BA009%' OR
                                     t.副資材7 LIKE '%BA008%' OR t.副資材7 LIKE '%BA009%' OR
                                     t.副資材8 LIKE '%BA008%' OR t.副資材8 LIKE '%BA009%' OR
                                     t.副資材9 LIKE '%BA008%' OR t.副資材9 LIKE '%BA009%' OR
                                     t.副資材10 LIKE '%BA008%' OR t.副資材10 LIKE '%BA009%' OR
                                     t.副資材11 LIKE '%BA008%' OR t.副資材11 LIKE '%BA009%' OR
                                     t.副資材12 LIKE '%BA008%' OR t.副資材12 LIKE '%BA009%' OR
                                     t.副資材13 LIKE '%BA008%' OR t.副資材13 LIKE '%BA009%' OR
                                     t.副資材14 LIKE '%BA008%' OR t.副資材14 LIKE '%BA009%' OR
                                     t.副資材15 LIKE '%BA008%' OR t.副資材15 LIKE '%BA009%' OR
                                     t.副資材16 LIKE '%BA008%' OR t.副資材16 LIKE '%BA009%' OR
                                     t.副資材17 LIKE '%BA008%' OR t.副資材17 LIKE '%BA009%' OR
                                     t.副資材18 LIKE '%BA008%' OR t.副資材18 LIKE '%BA009%' OR
                                     t.副資材19 LIKE '%BA008%' OR t.副資材19 LIKE '%BA009%' OR
                                     t.副資材20 LIKE '%BA008%' OR t.副資材20 LIKE '%BA009%'
                                THEN
                                    ISNULL(NULLIF(CAST(t.部品収容数 AS INT),0),1) *
                                    ISNULL(NULLIF(CAST(t.個装入り数 AS INT),0),1) *
                                    ISNULL(NULLIF(CAST(t.内装入り数 AS INT),0),1) *
                                    1.0/2 * CAST(" & _gaichoku_bousabi & " AS INT)
                                ELSE 0
                            END)
                        FROM T_CCC_Lot t
                        WHERE t.見積No = " & _target_mitsumori_no & ";"

        '外装ケース数
        sql = sql & " ;WITH cte AS (
                            SELECT 
                                *,
                                ROW_NUMBER() OVER (
                                    PARTITION BY ｺﾝﾄﾛｰﾙNO, ケースNO1, 包装ロットNO
                                    ORDER BY ｺﾝﾄﾛｰﾙNO, ケースNO1, 包装ロットNO
                                ) AS rn
                            FROM T_CCC_Lot
                            WHERE 見積No = " & _target_mitsumori_no & "
                        )
                        UPDATE cte
                        SET 外装ケース数 = " & _gaichoku_case & "
                        WHERE rn = 1;"










        '内装資材費
        sql = sql & " UPDATE t
                        SET t.内装資材費 =
                            CASE
                                -- 内装が存在する場合のみ計算
                                WHEN HK_naisou.DIST IS NOT NULL
                                     AND NS.内装資材コード IS NOT NULL
                                THEN 
                                    (
                                        ISNULL(TK1.単価, 0) * t.内装入り数
                                    )
                                    +
                                    (
                                        (ISNULL(TK2.単価, 0) * ISNULL(t.必要数2, 0)) +
                                        (ISNULL(TK3.単価, 0) * ISNULL(t.必要数3, 0)) +
                                        (ISNULL(TK4.単価, 0) * ISNULL(t.必要数4, 0)) +
                                        (ISNULL(TK5.単価, 0) * ISNULL(t.必要数5, 0)) +
                                        (ISNULL(TK6.単価, 0) * ISNULL(t.必要数6, 0)) +
                                        (ISNULL(TK7.単価, 0) * ISNULL(t.必要数7, 0)) +
                                        (ISNULL(TK8.単価, 0) * ISNULL(t.必要数8, 0)) +
                                        (ISNULL(TK9.単価, 0) * ISNULL(t.必要数9, 0)) +
                                        (ISNULL(TK10.単価, 0) * ISNULL(t.必要数10, 0))
                                    ) * t.内装入り数
                                ELSE 0
                            END
                        FROM T_CCC_Lot t

                        LEFT JOIN M_Naisou_Shizai NS
                        ON t.内装資材記号 = NS.内装資材コード

                        LEFT JOIN M_Housou_Kbn HK_kosou
                        ON t.代表DIST = HK_kosou.DIST
                        AND HK_kosou.個装内装区分 = '個装'

                        LEFT JOIN M_Housou_Kbn HK_naisou
                        ON t.代表DIST = HK_naisou.DIST
                        AND HK_naisou.個装内装区分 = '内装'

                        LEFT JOIN M_Tanka TK1
                        ON t.内装資材記号 = TK1.資材コード

                        LEFT JOIN M_Tanka TK2  ON t.副資材2  = TK2.資材コード
                        LEFT JOIN M_Tanka TK3  ON t.副資材3  = TK3.資材コード
                        LEFT JOIN M_Tanka TK4  ON t.副資材4  = TK4.資材コード
                        LEFT JOIN M_Tanka TK5  ON t.副資材5  = TK5.資材コード
                        LEFT JOIN M_Tanka TK6  ON t.副資材6  = TK6.資材コード
                        LEFT JOIN M_Tanka TK7  ON t.副資材7  = TK7.資材コード
                        LEFT JOIN M_Tanka TK8  ON t.副資材8  = TK8.資材コード
                        LEFT JOIN M_Tanka TK9  ON t.副資材9  = TK9.資材コード
                        LEFT JOIN M_Tanka TK10 ON t.副資材10 = TK10.資材コード

                        WHERE t.見積No = " & _target_mitsumori_no & "
                          AND (
                                (HK_kosou.DIST IS NOT NULL  -- 個装あり
                                 AND HK_naisou.DIST IS NOT NULL  -- 内装あり
                                 AND ISNULL(t.包装ライン_外装,'') NOT LIKE '%M%')
                                OR HK_naisou.DIST IS NOT NULL  -- 内装のみもしくは両方
                              );"






        '外装資材費
        sql = sql & " UPDATE t
                        SET t.外装資材費 = 
                            ISNULL(
                                (CASE WHEN g11.資材コード IS NOT NULL THEN t.必要数11 * g11.単価 ELSE 0 END) +
                                (CASE WHEN g12.資材コード IS NOT NULL THEN t.必要数12 * g12.単価 ELSE 0 END) +
                                (CASE WHEN g13.資材コード IS NOT NULL THEN t.必要数13 * g13.単価 ELSE 0 END) +
                                (CASE WHEN g14.資材コード IS NOT NULL THEN t.必要数14 * g14.単価 ELSE 0 END) +
                                (CASE WHEN g15.資材コード IS NOT NULL THEN t.必要数15 * g15.単価 ELSE 0 END) +
                                (CASE WHEN g16.資材コード IS NOT NULL THEN t.必要数16 * g16.単価 ELSE 0 END) +
                                (CASE WHEN g17.資材コード IS NOT NULL THEN t.必要数17 * g17.単価 ELSE 0 END) +
                                (CASE WHEN g18.資材コード IS NOT NULL THEN t.必要数18 * g18.単価 ELSE 0 END) +
                                (CASE WHEN g19.資材コード IS NOT NULL THEN t.必要数19 * g19.単価 ELSE 0 END) +
                                (CASE WHEN g20.資材コード IS NOT NULL THEN t.必要数20 * g20.単価 ELSE 0 END)
                            , 0)
                        FROM T_CCC_Lot t
                        LEFT JOIN M_Tanka g11 ON t.副資材11 = g11.資材コード
                        LEFT JOIN M_Tanka g12 ON t.副資材12 = g12.資材コード
                        LEFT JOIN M_Tanka g13 ON t.副資材13 = g13.資材コード
                        LEFT JOIN M_Tanka g14 ON t.副資材14 = g14.資材コード
                        LEFT JOIN M_Tanka g15 ON t.副資材15 = g15.資材コード
                        LEFT JOIN M_Tanka g16 ON t.副資材16 = g16.資材コード
                        LEFT JOIN M_Tanka g17 ON t.副資材17 = g17.資材コード
                        LEFT JOIN M_Tanka g18 ON t.副資材18 = g18.資材コード
                        LEFT JOIN M_Tanka g19 ON t.副資材19 = g19.資材コード
                        LEFT JOIN M_Tanka g20 ON t.副資材20 = g20.資材コード
                        WHERE t.見積No = " & _target_mitsumori_no & ";"

        '個装作業
        sql = sql & " UPDATE T_CCC_Lot
                        SET 個装作業 = ISNULL(防錆回数, 0) + ISNULL(個装数, 0)
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        '内装作業
        sql = sql & " UPDATE T_CCC_Lot
                        SET 内装作業 = ISNULL(単品部品総数, 0) + ISNULL(部品点数, 0) + ISNULL(内装資材数, 0) + ISNULL(カートン数, 0) + ISNULL(リターナブル容器数, 0)
                                    + ISNULL(ENG発泡材数, 0) + ISNULL(積み付け回数, 0)
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        '外装作業
        sql = sql & " UPDATE T_CCC_Lot
                        SET 外装作業 = ISNULL(パネルケース数, 0) + ISNULL(スカシケース数, 0) + ISNULL(外装用段ボールパット使用数, 0) + ISNULL(外装用箱型ポリ袋, 0) 
                                    + ISNULL(外装用ボルト使用数, 0) + ISNULL(外装用副資材使用数, 0) + ISNULL(外直部品総数, 0) + ISNULL(外直の防錆回数, 0) + ISNULL(外装ケース数, 0)
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        '作業計
        sql = sql & " UPDATE T_CCC_Lot
                        SET 作業計 = ISNULL(個装作業, 0) + ISNULL(内装作業, 0) + ISNULL(外装作業, 0)
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        '個_内装資材
        sql = sql & " UPDATE T_CCC_Lot
                        SET 個_内装資材 = ISNULL(個装資材費, 0) + ISNULL(内装資材費, 0)
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        '外装資材
        sql = sql & " UPDATE T_CCC_Lot
                        SET 外装資材 = ISNULL(外装資材費, 0) 
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        '資材計
        sql = sql & " UPDATE T_CCC_Lot
                        SET 資材計 = ISNULL(個_内装資材, 0)  + ISNULL(外装資材, 0)
                        WHERE 見積No = " & _target_mitsumori_no & ";"

        Return sql

    End Function

    Function MakeSQL6(_target_mitsumori_no As String) As String

        ' SQL文
        Dim sql As String = ""

        '年度
        sql = " UPDATE K
                    SET K.年度 = C.年度2
                    FROM T_KOW46 K
                    INNER JOIN T_CCC_Lot C
                        ON K.MUDULE        = C.ｺﾝﾄﾛｰﾙNO   
                        AND K.本C_No       = C.ケースNO1     
                        AND CAST(CAST(K.内装手順 AS INT) AS VARCHAR(40))     = C.モジュール手順SEQ     
	                    AND C.見積No = " & _target_mitsumori_no & "
                    WHERE K.見積No = " & _target_mitsumori_no & ";"

        'モデル
        sql = sql & " UPDATE K
                    SET K.モデル = C.モデル2
                    FROM T_KOW46 K
                    INNER JOIN T_CCC_Lot C
                        ON K.MUDULE        = C.ｺﾝﾄﾛｰﾙNO   
                        AND K.本C_No       = C.ケースNO1     
                        AND CAST(CAST(K.内装手順 AS INT) AS VARCHAR(40))     = C.モジュール手順SEQ     
	                    AND C.見積No = " & _target_mitsumori_no & "
                    WHERE K.見積No = " & _target_mitsumori_no & ";"

        'タイプ
        sql = sql & " UPDATE K
                    SET K.タイプ = C.タイプ1
                    FROM T_KOW46 K
                    INNER JOIN T_CCC_Lot C
                        ON K.MUDULE        = C.ｺﾝﾄﾛｰﾙNO   
                        AND K.本C_No       = C.ケースNO1     
                        AND CAST(CAST(K.内装手順 AS INT) AS VARCHAR(40))     = C.モジュール手順SEQ     
	                    AND C.見積No = " & _target_mitsumori_no & "
                    WHERE K.見積No = " & _target_mitsumori_no & ";"

        'オプション
        sql = sql & " UPDATE K
                    SET K.オプション = C.オプション1
                    FROM T_KOW46 K
                    INNER JOIN T_CCC_Lot C
                        ON K.MUDULE        = C.ｺﾝﾄﾛｰﾙNO   
                        AND K.本C_No       = C.ケースNO1     
                        AND CAST(CAST(K.内装手順 AS INT) AS VARCHAR(40))     = C.モジュール手順SEQ     
	                    AND C.見積No = " & _target_mitsumori_no & "
                    WHERE K.見積No = " & _target_mitsumori_no & ";"

        '資材単価表示
        sql = sql & " UPDATE K
                    SET K.資材単価表示 = T.単価
                    FROM T_KOW46 K
                    INNER JOIN M_Tanka T
                        ON K.資材規格        = T.資材コード   
	                    AND K.見積No = " & _target_mitsumori_no & "
                    WHERE K.見積No = " & _target_mitsumori_no & ";"

        '資材費
        sql = sql & " UPDATE K
                    SET K.資材費 =
                        ISNULL(NULLIF(TRY_CAST(K.資材単価表示 AS DECIMAL(16,2)), 0), 0)
                      * ISNULL(NULLIF(TRY_CAST(K.使用数 AS DECIMAL(16,0)), 0), 0)
                    FROM T_KOW46 K
                    WHERE K.見積No = " & _target_mitsumori_no & ";"






        'ケース当たりの外装資材費
        sql = sql & " UPDATE K
                    SET K.ケース当たりの外装資材費 = K.資材費
                    FROM T_KOW46 K
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM T_CCC_Lot C
                        WHERE K.年度        = C.年度2
                          AND K.モデル      = C.モデル2
                          AND K.タイプ      = C.タイプ1
                          AND K.MUDULE      = C.ｺﾝﾄﾛｰﾙNO
                          AND CAST(CAST(K.内装手順 AS INT) AS VARCHAR(40))    = C.モジュール手順SEQ   
	                      AND C.見積No = " & _target_mitsumori_no & ")
                    AND K.見積No = " & _target_mitsumori_no & ";"

        '内装入数_カートン数
        sql = sql & " UPDATE K
                    SET K.内装入数_カートン数 = C.内装入り数
                    FROM T_KOW46 K
                    INNER JOIN T_CCC_Lot C
                        ON K.年度        = C.年度2   
                        AND K.モデル       = C.モデル2     
                        AND K.タイプ     = C.タイプ1     
                        AND K.MUDULE     = C.ｺﾝﾄﾛｰﾙNO   
                        AND CAST(CAST(K.内装手順 AS INT) AS VARCHAR(40))     = C.モジュール手順SEQ     
	                    AND C.見積No = " & _target_mitsumori_no & "
                    WHERE K.見積No = " & _target_mitsumori_no & ";"

        'ケース内必要資材数
        sql = sql & " UPDATE K
                    SET K.ケース内必要資材数 =
                        ISNULL(NULLIF(TRY_CAST(K.内装入数_カートン数 AS DECIMAL(16,2)), 0), 0)
                      * ISNULL(NULLIF(TRY_CAST(K.使用数 AS DECIMAL(16,0)), 0), 0)
                    FROM T_KOW46 K
                    WHERE K.見積No = " & _target_mitsumori_no & ";"


        Return sql

    End Function

#End Region

#Region "CSV作成処理"

    '保存先選択ダイアログ
    Function MakeOutPath() As String
        MakeOutPath = ""
        Try
            'SaveFileDialogクラスのインスタンスを作成
            Dim sfd As New SaveFileDialog()
            'はじめのファイル名を指定する
            'はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            'はじめに表示されるフォルダを指定する
            '指定しない（空の文字列）の時は、現在のディレクトリが表示される
            'sfd.InitialDirectory = "C:\"
            '[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
            '[ファイルの種類]ではじめに選択されるものを指定する
            '2番目の「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 1
            'タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください"
            'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = True
            '既に存在するファイル名を指定したとき警告する
            'デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = True
            '存在しないパスが指定されたとき警告を表示する
            'デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = True
            'ダイアログを表示する
            If sfd.ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき、選択されたファイル名をリターン
                Return sfd.FileName
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    'DTをCSVデータに変換
    Public Sub ConvertDataTableToCsv(
dt As DataTable, csvPath As String, writeHeader As Boolean)
        'CSVファイルに書き込むときに使うEncoding
        Dim enc As System.Text.Encoding =
            System.Text.Encoding.GetEncoding("Shift_JIS")
        '書き込むファイルを開く
        Dim sr As New System.IO.StreamWriter(csvPath, False, enc)
        Dim colCount As Integer = dt.Columns.Count
        Dim lastColIndex As Integer = colCount - 1
        Dim i As Integer
        'ヘッダを書き込む
        If writeHeader Then
            For i = 0 To colCount - 1
                'ヘッダの取得
                Dim field As String = dt.Columns(i).Caption
                '"で囲む
                field = EncloseDoubleQuotesIfNeed(field)
                'フィールドを書き込む
                sr.Write(field)
                'カンマを書き込む
                If lastColIndex > i Then
                    sr.Write(","c)
                End If
            Next
            '改行する
            sr.Write(vbCrLf)
        End If
        'レコードを書き込む
        Dim row As DataRow
        For Each row In dt.Rows
            For i = 0 To colCount - 1
                'フィールドの取得
                Dim field As String = row(i).ToString()
                '"で囲む
                field = EncloseDoubleQuotesIfNeed(field)
                'フィールドを書き込む
                sr.Write(field)
                'カンマを書き込む
                If lastColIndex > i Then
                    sr.Write(","c)
                End If
            Next
            '改行する
            sr.Write(vbCrLf)
        Next
        '閉じる
        sr.Close()
    End Sub

    Private Function EncloseDoubleQuotesIfNeed(field As String) As String
        If NeedEncloseDoubleQuotes(field) Then
            Return EncloseDoubleQuotes(field)
        End If
        Return field
    End Function

    Private Function NeedEncloseDoubleQuotes(field As String) As Boolean
        Return field.IndexOf(""""c) > -1 OrElse
            field.IndexOf(","c) > -1 OrElse
            field.IndexOf(ControlChars.Cr) > -1 OrElse
            field.IndexOf(ControlChars.Lf) > -1 OrElse
            field.StartsWith(" ") OrElse
            field.StartsWith(vbTab) OrElse
            field.EndsWith(" ") OrElse
            field.EndsWith(vbTab)
    End Function

    Private Function EncloseDoubleQuotes(field As String) As String
        If field.IndexOf(""""c) > -1 Then
            '"を""とする
            field = field.Replace("""", """""")
        End If
        Return """" & field & """"
    End Function

#End Region


    '-----------------------------------------------------------
    ' 単価計算関数
    '-----------------------------------------------------------
    Public Function CalcOrderPrice(info As OrderInfo, priceDict As Dictionary(Of String, Decimal)) As Decimal
        Dim total As Decimal = 0D

        For i As Integer = 0 To 15
            Dim code = info.資材コード(i)
            Dim qty = info.数量(i)

            If Not String.IsNullOrEmpty(code) AndAlso qty > 0 Then
                If priceDict.ContainsKey(code) Then
                    total += priceDict(code) * qty
                End If
            End If
        Next

        Return total
    End Function

    ' ---- ヘルパー関数（Null 安全に値を取り出す） ----
    Private Function SafeGetString(row As DataRow, colName As String) As String
        If row.Table.Columns.Contains(colName) = False Then Return String.Empty
        If IsDBNull(row(colName)) Then Return String.Empty
        Return row(colName).ToString().Trim()
    End Function

    Public Function SafeGetInt(dr As DataRow, columnName As String) As Integer
        Try
            If dr Is Nothing OrElse dr.IsNull(columnName) Then
                Return 0
            End If

            Dim value As Object = dr(columnName)

            ' 空文字の場合も 0
            If value Is Nothing OrElse String.IsNullOrWhiteSpace(value.ToString()) Then
                Return 0
            End If

            ' 数値に変換
            Dim result As Integer
            If Integer.TryParse(value.ToString(), result) Then
                Return result
            Else
                Return 0
            End If

        Catch ex As Exception
            ' 例外が出た場合も 0
            Return 0
        End Try
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

    Public Class OrderInfo
        Public Property DIST As String
        Public Property No As String
        Public Property 変更フラグ As String
        Public Property GR As String
        Public Property Basic_Part_No As String
        Public Property Export_Name As String
        Public Property Order_Lot As String
        Public Property LOTカートン数 As String
        Public Property 個装入数 As String
        Public Property OS As String
        Public Property 内装適用 As String
        Public Property L As String
        Public Property W As String
        Public Property H As String
        Public Property 防錆 As String
        Public Property 個装適用袋 As String
        Public Property 袋必要数 As String
        Public Property 資材コード As String()
        Public Property 数量 As Integer()
        Public Property 単品重量 As Decimal
        Public Property 内装重量 As Decimal
        Public Property 取込年月 As String
        Public Property 見積No As Integer
    End Class

    Public Class KowInfo
        Public Property 包装ロットNo As String           ' [包装ロットNo]
        Public Property MUDULE As String                 ' MUDULE
        Public Property 本C_No As String                ' [本C_No]
        Public Property 内装手順 As String               ' [内装手順]
        Public Property 手順識別 As String              ' [手順識別]
        Public Property 資材規格 As String              ' [資材規格]
        Public Property 使用数 As String                ' [使用数]
        Public Property 主資材 As String                ' [主資材]
        Public Property その他1 As String               ' [その他1]
        Public Property その他2 As String               ' [その他2]
        Public Property 年度 As String                  ' [年度]
        Public Property モデル As String                 ' [モデル]
        Public Property タイプ As String                 ' [タイプ]
        Public Property オプション As String            ' [オプション]
        Public Property 資材単価表示 As String           ' [資材単価表示]
        Public Property 資材費 As String                 ' [資材費]
        Public Property ケース当たりの内装資材費 As String ' [ケース当たりの内装資材費]
        Public Property ケース当たりの外装資材費 As String ' [ケース当たりの外装資材費]
        Public Property 内装入数_カートン数 As String     ' [内装入数_カートン数]
        Public Property ケース内必要資材数 As String       ' [ケース内必要資材数]
        Public Property 取込年月 As String               ' [取込年月]
        Public Property 見積No As Integer               ' [見積No]
    End Class

    Public Class CCCInfo
        Public Property 年度2 As String
        Public Property モデル2 As String
        Public Property タイプ1 As String
        Public Property ｺﾝﾄﾛｰﾙNO As String
        Public Property モジュール手順SEQ As String
        Public Property 個装入り数 As String
        Public Property 内装入り数 As String
        Public Property 部品収容数 As String
        Public Property オプション1 As String

    End Class

End Class




