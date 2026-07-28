Imports System.Configuration

Public Class F_Chousei

    Dim fnc As New Function_Class

    Private _mode As Integer
    Private _selected_ccc_lot_id As Integer = 0

    ' コンストラクタを追加
    Public Sub New(mode As Integer)
        InitializeComponent()
        _mode = mode
    End Sub

    'ページロード
    Private Sub F_Chousei_Load(sender As Object, e As EventArgs) Handles Me.Load

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
            fnc.ERR_LOG(ex.Message, "F_Chousei_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'ボタンクリック時
    '******************************************************************************

    '検索ボタンクリック時
    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click

        Try

            If Cmb_Target.SelectedValue Is Nothing OrElse Cmb_Target.SelectedValue Is DBNull.Value Then
                MessageBox.Show("対象データを選択してください。")
                Exit Sub
            End If

            Dim dt_1lot As New DS_T.DT_T_CCC_LotDataTable
            dt_1lot.Columns.Add("変更フラグ")

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            Using conn As New SqlClient.SqlConnection(connectionString)

                Using cmd As New SqlClient.SqlCommand(MakeSQL_Chousei_Search(), conn)

                    cmd.Parameters.AddWithValue("@見積No", Cmb_Target.SelectedValue)
                    cmd.Parameters.AddWithValue("@代表DIST", Txt_DIST.Text.Trim)
                    cmd.Parameters.AddWithValue("@年度2", Txt_Nendo.Text.Trim)
                    cmd.Parameters.AddWithValue("@モデル2", Txt_Model.Text.Trim)
                    cmd.Parameters.AddWithValue("@タイプ1", Txt_Type.Text.Trim)
                    cmd.Parameters.AddWithValue("@オプション1", Txt_Option.Text.Trim)
                    cmd.Parameters.AddWithValue("@ｺﾝﾄﾛｰﾙNO", Txt_Module.Text.Trim)
                    cmd.Parameters.AddWithValue("@ケースNO1", Txt_Case_No.Text.Trim)
                    cmd.Parameters.AddWithValue("@モジュール手順SEQ", Txt_Module_SEQ.Text.Trim)

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(dt_1lot)

                End Using

            End Using

            GV_Chousei.DataSource = Nothing
            GV_Chousei.DataSource = dt_1lot

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Chousei_Btn_Search_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            If _selected_ccc_lot_id = 0 Then
                MessageBox.Show("編集する行をグリッドから選択してください。")
                Exit Sub
            End If

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            Using conn As New SqlClient.SqlConnection(connectionString)

                conn.Open()

                Using cmd As New SqlClient.SqlCommand(MakeSQL_Chousei_Update(), conn)

                    cmd.Parameters.AddWithValue("@id", _selected_ccc_lot_id)
                    AddDecimalParam(cmd, "@単品部品総数", Txt_Tanpin_Buhin_Sousu.Text)
                    AddDecimalParam(cmd, "@部品点数", Txt_Buhin_Tensu.Text)
                    AddDecimalParam(cmd, "@防錆回数", Txt_Bousabi_Kaisu.Text)
                    AddDecimalParam(cmd, "@個装数", Txt_Kosousu.Text)
                    AddDecimalParam(cmd, "@内装資材数", Txt_Naisou_Shizaisu.Text)
                    AddDecimalParam(cmd, "@カートン数", Txt_Cartonsu.Text)
                    AddDecimalParam(cmd, "@リターナブル容器数", Txt_Returnable.Text)
                    AddDecimalParam(cmd, "@ENG発泡材数", Txt_ENG.Text)
                    AddDecimalParam(cmd, "@積み付け回数", Txt_Tsumituke_Kaisu.Text)
                    AddDecimalParam(cmd, "@パネルケース数", Txt_Panel_Casesu.Text)
                    AddDecimalParam(cmd, "@スカシケース数", Txt_Sukashi_Casesu.Text)
                    AddDecimalParam(cmd, "@外装用段ボールパット使用数", Txt_Gaisouo_Danborusu.Text)
                    AddDecimalParam(cmd, "@外装用箱型ポリ袋", Txt_Gaisou_Poribukuro.Text)
                    AddDecimalParam(cmd, "@外装用ボルト使用数", Txt_Gaisou_Boltsu.Text)
                    AddDecimalParam(cmd, "@外装用副資材使用数", Txt_Gaisou_Fukushizai.Text)
                    AddDecimalParam(cmd, "@外直部品総数", Txt_Gaichoku_Buhinsu.Text)
                    AddDecimalParam(cmd, "@外直の防錆回数", Txt_Gaichoku_Bousabi.Text)
                    AddDecimalParam(cmd, "@外装ケース数", Txt_Gaisou_Case.Text)
                    AddDecimalParam(cmd, "@部品点数_集計", Txt_Buhin_Tensu_Sum.Text)
                    AddDecimalParam(cmd, "@個装資材費", Txt_Kosou_Shizaihi.Text)
                    AddDecimalParam(cmd, "@内装資材費", Txt_Naisou_Shizaihi.Text)
                    AddDecimalParam(cmd, "@外装資材費", Txt_Gaisou_Shizaihi.Text)
                    AddDecimalParam(cmd, "@個装作業", Txt_Kosou_Sagyou.Text)
                    AddDecimalParam(cmd, "@内装作業", Txt_Naisou_Sagyou.Text)
                    AddDecimalParam(cmd, "@外装作業", Txt_Gaisou_Sagyou.Text)
                    AddDecimalParam(cmd, "@作業計", Txt_Sagyou_Total.Text)
                    AddDecimalParam(cmd, "@個_内装資材", Txt_Ko_Naisou_Shizai.Text)
                    AddDecimalParam(cmd, "@外装資材", Txt_Gaisou_Shizai.Text)
                    AddDecimalParam(cmd, "@資材計", Txt_Shizai_Total.Text)

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show("更新しました。")

            '再検索して最新の値を表示
            Btn_Search_Click(Nothing, Nothing)

            '入力欄をクリア
            Clear_Henshu()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Chousei_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    'クリアボタンクリック時
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click

        Clear_Henshu()

    End Sub

    '全て戻すボタンクリック時（対象見積No分をまとめてT_CCC_Lot_Saveの原本値に戻す）
    Private Sub Btn_All_Return_Click(sender As Object, e As EventArgs) Handles Btn_All_Return.Click

        Try

            If Cmb_Target.SelectedValue Is Nothing OrElse Cmb_Target.SelectedValue Is DBNull.Value Then
                MessageBox.Show("対象データを選択してください。")
                Exit Sub
            End If

            If MessageBox.Show("対象見積No分のすべての行を変換直後の値に戻しますか？", "確認", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            End If

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            Dim rowsAffected As Integer = 0

            Using conn As New SqlClient.SqlConnection(connectionString)

                conn.Open()

                Using cmd As New SqlClient.SqlCommand(MakeSQL_Chousei_Restore_All(), conn)
                    cmd.Parameters.AddWithValue("@見積No", Cmb_Target.SelectedValue)
                    rowsAffected = cmd.ExecuteNonQuery()
                End Using

            End Using

            MessageBox.Show(rowsAffected.ToString() & "件を元に戻しました。")

            Btn_Search_Click(Nothing, Nothing)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Chousei_Btn_All_Return_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'GVイベント
    '******************************************************************************

    '描画される行だけ都度判定して背景色を変更（大量行でも検索直後の全件走査を避けるため）
    Private Sub GV_Chousei_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles GV_Chousei.RowPrePaint

        Dim rowView As DataRowView = TryCast(GV_Chousei.Rows(e.RowIndex).DataBoundItem, DataRowView)

        If rowView IsNot Nothing AndAlso CInt(rowView("変更フラグ")) = 1 Then
            GV_Chousei.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightPink
        Else
            GV_Chousei.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End If

    End Sub

    'GVの選択リンクボタンクリックで編集エリアに値を表示
    Private Sub GV_Chousei_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Chousei.CellContentClick

        Try

            'ヘッダークリックは無視
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            Dim grid As DataGridView = CType(sender, DataGridView)

            If grid.Columns(e.ColumnIndex).Name = "選択" Then

                Dim row As DataRowView = CType(grid.Rows(e.RowIndex).DataBoundItem, DataRowView)

                _selected_ccc_lot_id = CInt(row("id"))

                Txt_Tanpin_Buhin_Sousu.Text = row("単品部品総数").ToString()
                Txt_Buhin_Tensu.Text = row("部品点数").ToString()
                Txt_Bousabi_Kaisu.Text = row("防錆回数").ToString()
                Txt_Kosousu.Text = row("個装数").ToString()
                Txt_Naisou_Shizaisu.Text = row("内装資材数").ToString()
                Txt_Cartonsu.Text = row("カートン数").ToString()
                Txt_Returnable.Text = row("リターナブル容器数").ToString()
                Txt_ENG.Text = row("ENG発泡材数").ToString()
                Txt_Tsumituke_Kaisu.Text = row("積み付け回数").ToString()
                Txt_Panel_Casesu.Text = row("パネルケース数").ToString()
                Txt_Sukashi_Casesu.Text = row("スカシケース数").ToString()
                Txt_Gaisouo_Danborusu.Text = row("外装用段ボールパット使用数").ToString()
                Txt_Gaisou_Poribukuro.Text = row("外装用箱型ポリ袋").ToString()
                Txt_Gaisou_Boltsu.Text = row("外装用ボルト使用数").ToString()
                Txt_Gaisou_Fukushizai.Text = row("外装用副資材使用数").ToString()
                Txt_Gaichoku_Buhinsu.Text = row("外直部品総数").ToString()
                Txt_Gaichoku_Bousabi.Text = row("外直の防錆回数").ToString()
                Txt_Gaisou_Case.Text = row("外装ケース数").ToString()
                Txt_Buhin_Tensu_Sum.Text = row("部品点数_集計").ToString()
                Txt_Kosou_Shizaihi.Text = row("個装資材費").ToString()
                Txt_Naisou_Shizaihi.Text = row("内装資材費").ToString()
                Txt_Gaisou_Shizaihi.Text = row("外装資材費").ToString()
                Txt_Kosou_Sagyou.Text = row("個装作業").ToString()
                Txt_Naisou_Sagyou.Text = row("内装作業").ToString()
                Txt_Gaisou_Sagyou.Text = row("外装作業").ToString()
                Txt_Sagyou_Total.Text = row("作業計").ToString()
                Txt_Ko_Naisou_Shizai.Text = row("個_内装資材").ToString()
                Txt_Gaisou_Shizai.Text = row("外装資材").ToString()
                Txt_Shizai_Total.Text = row("資材計").ToString()

                '原本（T_CCC_Lot_Save）と値が異なる項目のテキストボックス背景色を変更
                Dim saveRow As DataRow = Get_CCC_Lot_Save(_selected_ccc_lot_id)
                Set_Henshu_BackColor(row, saveRow)

            End If

            '元に戻すボタン（1行分をT_CCC_Lot_Saveの原本値に戻す）
            If grid.Columns(e.ColumnIndex).Name = "元に戻す" Then

                Dim row As DataRowView = CType(grid.Rows(e.RowIndex).DataBoundItem, DataRowView)
                Dim target_id As Integer = CInt(row("id"))

                If MessageBox.Show("この行を変換直後の値に戻しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

                    Dim rowsAffected As Integer = 0

                    Using conn As New SqlClient.SqlConnection(connectionString)

                        conn.Open()

                        Using cmd As New SqlClient.SqlCommand(MakeSQL_Chousei_Restore(), conn)
                            cmd.Parameters.AddWithValue("@id", target_id)
                            rowsAffected = cmd.ExecuteNonQuery()
                        End Using

                    End Using

                    If rowsAffected = 0 Then
                        MessageBox.Show("元データ（T_CCC_Lot_Save）が見つかりませんでした。")
                    Else
                        MessageBox.Show("元に戻しました。")
                    End If

                    Btn_Search_Click(Nothing, Nothing)

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Chousei_GV_Chousei_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'その他コントロールイベント
    '******************************************************************************

    'ターゲット見積Noが変わったら
    Private Sub Cmb_Target_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Target.SelectedIndexChanged

        Try

            If Cmb_Target.SelectedValue Is Nothing Then
                Exit Sub
            ElseIf Cmb_Target.SelectedValue Is DBNull.Value Then
                Exit Sub
            ElseIf TypeOf Cmb_Target.SelectedValue Is DataRowView Then
                Exit Sub
            End If

            Btn_Search_Click(Nothing, Nothing)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Chousei_Cmb_Target_SelectedIndexChanged")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    '関数
    '******************************************************************************

    '1行分の復元用SQL作成
    Function MakeSQL_Chousei_Restore() As String

        Return "UPDATE C
                SET C.単品部品総数 = S.単品部品総数,
                    C.部品点数 = S.部品点数,
                    C.防錆回数 = S.防錆回数,
                    C.個装数 = S.個装数,
                    C.内装資材数 = S.内装資材数,
                    C.カートン数 = S.カートン数,
                    C.リターナブル容器数 = S.リターナブル容器数,
                    C.ENG発泡材数 = S.ENG発泡材数,
                    C.積み付け回数 = S.積み付け回数,
                    C.パネルケース数 = S.パネルケース数,
                    C.スカシケース数 = S.スカシケース数,
                    C.外装用段ボールパット使用数 = S.外装用段ボールパット使用数,
                    C.外装用箱型ポリ袋 = S.外装用箱型ポリ袋,
                    C.外装用ボルト使用数 = S.外装用ボルト使用数,
                    C.外装用副資材使用数 = S.外装用副資材使用数,
                    C.外直部品総数 = S.外直部品総数,
                    C.外直の防錆回数 = S.外直の防錆回数,
                    C.外装ケース数 = S.外装ケース数,
                    C.部品点数_集計 = S.部品点数_集計,
                    C.個装資材費 = S.個装資材費,
                    C.内装資材費 = S.内装資材費,
                    C.外装資材費 = S.外装資材費,
                    C.個装作業 = S.個装作業,
                    C.内装作業 = S.内装作業,
                    C.外装作業 = S.外装作業,
                    C.作業計 = S.作業計,
                    C.個_内装資材 = S.個_内装資材,
                    C.外装資材 = S.外装資材,
                    C.資材計 = S.資材計
                FROM T_CCC_Lot C
                INNER JOIN T_CCC_Lot_Save S ON S.CCC_Lot_id = C.id
                WHERE C.id = @id"

    End Function

    '対象見積No全行分の復元用SQL作成
    Function MakeSQL_Chousei_Restore_All() As String

        Return "UPDATE C
                SET C.単品部品総数 = S.単品部品総数,
                    C.部品点数 = S.部品点数,
                    C.防錆回数 = S.防錆回数,
                    C.個装数 = S.個装数,
                    C.内装資材数 = S.内装資材数,
                    C.カートン数 = S.カートン数,
                    C.リターナブル容器数 = S.リターナブル容器数,
                    C.ENG発泡材数 = S.ENG発泡材数,
                    C.積み付け回数 = S.積み付け回数,
                    C.パネルケース数 = S.パネルケース数,
                    C.スカシケース数 = S.スカシケース数,
                    C.外装用段ボールパット使用数 = S.外装用段ボールパット使用数,
                    C.外装用箱型ポリ袋 = S.外装用箱型ポリ袋,
                    C.外装用ボルト使用数 = S.外装用ボルト使用数,
                    C.外装用副資材使用数 = S.外装用副資材使用数,
                    C.外直部品総数 = S.外直部品総数,
                    C.外直の防錆回数 = S.外直の防錆回数,
                    C.外装ケース数 = S.外装ケース数,
                    C.部品点数_集計 = S.部品点数_集計,
                    C.個装資材費 = S.個装資材費,
                    C.内装資材費 = S.内装資材費,
                    C.外装資材費 = S.外装資材費,
                    C.個装作業 = S.個装作業,
                    C.内装作業 = S.内装作業,
                    C.外装作業 = S.外装作業,
                    C.作業計 = S.作業計,
                    C.個_内装資材 = S.個_内装資材,
                    C.外装資材 = S.外装資材,
                    C.資材計 = S.資材計
                FROM T_CCC_Lot C
                INNER JOIN T_CCC_Lot_Save S ON S.CCC_Lot_id = C.id
                WHERE C.見積No = @見積No"

    End Function

    '検索条件SQL作成（検索条件が空欄の項目は絞り込み対象外）
    '「変更フラグ」＝T_CCC_Lot_Save（変換直後の原本）と値が異なる行なら1、原本がない・差異なしなら0
    Function MakeSQL_Chousei_Search() As String

        Return "SELECT C.*,
                       CASE WHEN S.CCC_Lot_id IS NULL THEN 0
                            WHEN EXISTS (
                                SELECT C.単品部品総数, C.部品点数, C.防錆回数, C.個装数, C.内装資材数, C.カートン数,
                                       C.リターナブル容器数, C.ENG発泡材数, C.積み付け回数, C.パネルケース数, C.スカシケース数,
                                       C.外装用段ボールパット使用数, C.外装用箱型ポリ袋, C.外装用ボルト使用数, C.外装用副資材使用数,
                                       C.外直部品総数, C.外直の防錆回数, C.外装ケース数, C.部品点数_集計, C.個装資材費, C.内装資材費,
                                       C.外装資材費, C.個装作業, C.内装作業, C.外装作業, C.作業計, C.個_内装資材, C.外装資材, C.資材計
                                EXCEPT
                                SELECT S.単品部品総数, S.部品点数, S.防錆回数, S.個装数, S.内装資材数, S.カートン数,
                                       S.リターナブル容器数, S.ENG発泡材数, S.積み付け回数, S.パネルケース数, S.スカシケース数,
                                       S.外装用段ボールパット使用数, S.外装用箱型ポリ袋, S.外装用ボルト使用数, S.外装用副資材使用数,
                                       S.外直部品総数, S.外直の防錆回数, S.外装ケース数, S.部品点数_集計, S.個装資材費, S.内装資材費,
                                       S.外装資材費, S.個装作業, S.内装作業, S.外装作業, S.作業計, S.個_内装資材, S.外装資材, S.資材計
                            ) THEN 1 ELSE 0 END AS 変更フラグ
                FROM T_CCC_Lot C
                LEFT JOIN T_CCC_Lot_Save S ON S.CCC_Lot_id = C.id
                WHERE C.見積No = @見積No
                  AND (C.代表DIST LIKE '%' + @代表DIST + '%' OR @代表DIST = '')
                  AND (C.年度2 LIKE '%' + @年度2 + '%' OR @年度2 = '')
                  AND (C.モデル2 LIKE '%' + @モデル2 + '%' OR @モデル2 = '')
                  AND (C.タイプ1 LIKE '%' + @タイプ1 + '%' OR @タイプ1 = '')
                  AND (C.オプション1 LIKE '%' + @オプション1 + '%' OR @オプション1 = '')
                  AND (C.ｺﾝﾄﾛｰﾙNO LIKE '%' + @ｺﾝﾄﾛｰﾙNO + '%' OR @ｺﾝﾄﾛｰﾙNO = '')
                  AND (C.ケースNO1 LIKE '%' + @ケースNO1 + '%' OR @ケースNO1 = '')
                  AND (C.モジュール手順SEQ LIKE '%' + @モジュール手順SEQ + '%' OR @モジュール手順SEQ = '')
                ORDER BY C.id"

    End Function

    '更新用SQL作成
    Function MakeSQL_Chousei_Update() As String

        Return "UPDATE T_CCC_Lot
                SET 単品部品総数 = @単品部品総数,
                    部品点数 = @部品点数,
                    防錆回数 = @防錆回数,
                    個装数 = @個装数,
                    内装資材数 = @内装資材数,
                    カートン数 = @カートン数,
                    リターナブル容器数 = @リターナブル容器数,
                    ENG発泡材数 = @ENG発泡材数,
                    積み付け回数 = @積み付け回数,
                    パネルケース数 = @パネルケース数,
                    スカシケース数 = @スカシケース数,
                    外装用段ボールパット使用数 = @外装用段ボールパット使用数,
                    外装用箱型ポリ袋 = @外装用箱型ポリ袋,
                    外装用ボルト使用数 = @外装用ボルト使用数,
                    外装用副資材使用数 = @外装用副資材使用数,
                    外直部品総数 = @外直部品総数,
                    外直の防錆回数 = @外直の防錆回数,
                    外装ケース数 = @外装ケース数,
                    部品点数_集計 = @部品点数_集計,
                    個装資材費 = @個装資材費,
                    内装資材費 = @内装資材費,
                    外装資材費 = @外装資材費,
                    個装作業 = @個装作業,
                    内装作業 = @内装作業,
                    外装作業 = @外装作業,
                    作業計 = @作業計,
                    個_内装資材 = @個_内装資材,
                    外装資材 = @外装資材,
                    資材計 = @資材計
                WHERE id = @id"

    End Function

    '数値項目パラメータ追加（未入力・数値以外はNULLとして登録）
    Sub AddDecimalParam(cmd As SqlClient.SqlCommand, paramName As String, text As String)

        Dim value As Decimal

        If Decimal.TryParse(text, value) Then
            cmd.Parameters.AddWithValue(paramName, value)
        Else
            cmd.Parameters.AddWithValue(paramName, DBNull.Value)
        End If

    End Sub


    '編集エリアの項目名とテキストボックスの対応表
    Function Get_Henshu_Field_Map() As List(Of Tuple(Of String, TextBox))

        Return New List(Of Tuple(Of String, TextBox)) From {
            Tuple.Create("単品部品総数", Txt_Tanpin_Buhin_Sousu),
            Tuple.Create("部品点数", Txt_Buhin_Tensu),
            Tuple.Create("防錆回数", Txt_Bousabi_Kaisu),
            Tuple.Create("個装数", Txt_Kosousu),
            Tuple.Create("内装資材数", Txt_Naisou_Shizaisu),
            Tuple.Create("カートン数", Txt_Cartonsu),
            Tuple.Create("リターナブル容器数", Txt_Returnable),
            Tuple.Create("ENG発泡材数", Txt_ENG),
            Tuple.Create("積み付け回数", Txt_Tsumituke_Kaisu),
            Tuple.Create("パネルケース数", Txt_Panel_Casesu),
            Tuple.Create("スカシケース数", Txt_Sukashi_Casesu),
            Tuple.Create("外装用段ボールパット使用数", Txt_Gaisouo_Danborusu),
            Tuple.Create("外装用箱型ポリ袋", Txt_Gaisou_Poribukuro),
            Tuple.Create("外装用ボルト使用数", Txt_Gaisou_Boltsu),
            Tuple.Create("外装用副資材使用数", Txt_Gaisou_Fukushizai),
            Tuple.Create("外直部品総数", Txt_Gaichoku_Buhinsu),
            Tuple.Create("外直の防錆回数", Txt_Gaichoku_Bousabi),
            Tuple.Create("外装ケース数", Txt_Gaisou_Case),
            Tuple.Create("部品点数_集計", Txt_Buhin_Tensu_Sum),
            Tuple.Create("個装資材費", Txt_Kosou_Shizaihi),
            Tuple.Create("内装資材費", Txt_Naisou_Shizaihi),
            Tuple.Create("外装資材費", Txt_Gaisou_Shizaihi),
            Tuple.Create("個装作業", Txt_Kosou_Sagyou),
            Tuple.Create("内装作業", Txt_Naisou_Sagyou),
            Tuple.Create("外装作業", Txt_Gaisou_Sagyou),
            Tuple.Create("作業計", Txt_Sagyou_Total),
            Tuple.Create("個_内装資材", Txt_Ko_Naisou_Shizai),
            Tuple.Create("外装資材", Txt_Gaisou_Shizai),
            Tuple.Create("資材計", Txt_Shizai_Total)
        }

    End Function

    '選択行の値と原本（T_CCC_Lot_Save）を比較し、差異があるテキストボックスの背景色を変更（原本がない場合は変更なし扱い）
    Sub Set_Henshu_BackColor(row As DataRowView, saveRow As DataRow)

        Dim hasOriginal As Boolean = (saveRow IsNot Nothing)

        For Each field In Get_Henshu_Field_Map()

            Dim isChanged As Boolean = hasOriginal AndAlso Not IsSameValue(row(field.Item1), saveRow(field.Item1))

            field.Item2.BackColor = If(isChanged, Color.LightPink, SystemColors.Window)

        Next

    End Sub

    '選択行に対応するT_CCC_Lot_Saveの原本値を取得（存在しなければNothing）
    Function Get_CCC_Lot_Save(id As Integer) As DataRow

        Dim dt As New DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

        Using conn As New SqlClient.SqlConnection(connectionString)

            Using cmd As New SqlClient.SqlCommand(MakeSQL_Chousei_Save_Select(), conn)

                cmd.Parameters.AddWithValue("@id", id)

                Dim da As New SqlClient.SqlDataAdapter(cmd)
                da.Fill(dt)

            End Using

        End Using

        If dt.Rows.Count = 0 Then
            Return Nothing
        Else
            Return dt.Rows(0)
        End If

    End Function

    '選択行の原本値取得用SQL作成
    Function MakeSQL_Chousei_Save_Select() As String

        Return "SELECT 単品部品総数, 部品点数, 防錆回数, 個装数, 内装資材数, カートン数,
                       リターナブル容器数, ENG発泡材数, 積み付け回数, パネルケース数, スカシケース数,
                       外装用段ボールパット使用数, 外装用箱型ポリ袋, 外装用ボルト使用数, 外装用副資材使用数,
                       外直部品総数, 外直の防錆回数, 外装ケース数, 部品点数_集計, 個装資材費, 内装資材費,
                       外装資材費, 個装作業, 内装作業, 外装作業, 作業計, 個_内装資材, 外装資材, 資材計
                FROM T_CCC_Lot_Save
                WHERE CCC_Lot_id = @id"

    End Function

    '現在値と原本値が同じかどうか判定（NULL同士は同じとみなす）
    Function IsSameValue(current As Object, original As Object) As Boolean

        Dim currentIsNull As Boolean = (current Is DBNull.Value)
        Dim originalIsNull As Boolean = (original Is DBNull.Value)

        If currentIsNull AndAlso originalIsNull Then
            Return True
        ElseIf currentIsNull OrElse originalIsNull Then
            Return False
        Else
            Return CDec(current) = CDec(original)
        End If

    End Function

    '******************************************************************************
    '編集エリア自動計算（ReadOnly項目を関連テキストボックスの変更に応じて再計算）
    '計算式はF_Make_1Lot.vbのT_CCC_Lot更新SQLと同一のものを使用
    '******************************************************************************

    'テキストの数値をDecimalとして取得（未入力・数値以外は0扱い）
    Function GetDecimalOrZero(txt As TextBox) As Decimal

        Dim value As Decimal

        If Decimal.TryParse(txt.Text, value) Then
            Return value
        Else
            Return 0
        End If

    End Function

    '個装作業＝防錆回数＋個装数
    Private Sub Recalc_Kosou_Sagyou(sender As Object, e As EventArgs) Handles Txt_Bousabi_Kaisu.TextChanged, Txt_Kosousu.TextChanged

        Txt_Kosou_Sagyou.Text = (GetDecimalOrZero(Txt_Bousabi_Kaisu) + GetDecimalOrZero(Txt_Kosousu)).ToString()

    End Sub

    '内装作業＝単品部品総数＋部品点数＋内装資材数＋カートン数＋リターナブル容器数＋ENG発泡材数＋積み付け回数
    Private Sub Recalc_Naisou_Sagyou(sender As Object, e As EventArgs) Handles Txt_Tanpin_Buhin_Sousu.TextChanged, Txt_Buhin_Tensu.TextChanged, _
        Txt_Naisou_Shizaisu.TextChanged, Txt_Cartonsu.TextChanged, Txt_Returnable.TextChanged, Txt_ENG.TextChanged, Txt_Tsumituke_Kaisu.TextChanged

        Txt_Naisou_Sagyou.Text = (GetDecimalOrZero(Txt_Tanpin_Buhin_Sousu) + GetDecimalOrZero(Txt_Buhin_Tensu) + GetDecimalOrZero(Txt_Naisou_Shizaisu) + _
            GetDecimalOrZero(Txt_Cartonsu) + GetDecimalOrZero(Txt_Returnable) + GetDecimalOrZero(Txt_ENG) + GetDecimalOrZero(Txt_Tsumituke_Kaisu)).ToString()

    End Sub

    '外装作業＝パネルケース数＋スカシケース数＋外装用段ボールパット使用数＋外装用箱型ポリ袋＋外装用ボルト使用数＋外装用副資材使用数＋外直部品総数＋外直の防錆回数＋外装ケース数
    Private Sub Recalc_Gaisou_Sagyou(sender As Object, e As EventArgs) Handles Txt_Panel_Casesu.TextChanged, Txt_Sukashi_Casesu.TextChanged, _
        Txt_Gaisouo_Danborusu.TextChanged, Txt_Gaisou_Poribukuro.TextChanged, Txt_Gaisou_Boltsu.TextChanged, Txt_Gaisou_Fukushizai.TextChanged, _
        Txt_Gaichoku_Buhinsu.TextChanged, Txt_Gaichoku_Bousabi.TextChanged, Txt_Gaisou_Case.TextChanged

        Txt_Gaisou_Sagyou.Text = (GetDecimalOrZero(Txt_Panel_Casesu) + GetDecimalOrZero(Txt_Sukashi_Casesu) + GetDecimalOrZero(Txt_Gaisouo_Danborusu) + _
            GetDecimalOrZero(Txt_Gaisou_Poribukuro) + GetDecimalOrZero(Txt_Gaisou_Boltsu) + GetDecimalOrZero(Txt_Gaisou_Fukushizai) + _
            GetDecimalOrZero(Txt_Gaichoku_Buhinsu) + GetDecimalOrZero(Txt_Gaichoku_Bousabi) + GetDecimalOrZero(Txt_Gaisou_Case)).ToString()

    End Sub

    '作業計＝個装作業＋内装作業＋外装作業
    Private Sub Recalc_Sagyou_Total(sender As Object, e As EventArgs) Handles Txt_Kosou_Sagyou.TextChanged, Txt_Naisou_Sagyou.TextChanged, Txt_Gaisou_Sagyou.TextChanged

        Txt_Sagyou_Total.Text = (GetDecimalOrZero(Txt_Kosou_Sagyou) + GetDecimalOrZero(Txt_Naisou_Sagyou) + GetDecimalOrZero(Txt_Gaisou_Sagyou)).ToString()

    End Sub

    '個_内装資材＝個装資材費＋内装資材費
    Private Sub Recalc_Ko_Naisou_Shizai(sender As Object, e As EventArgs) Handles Txt_Kosou_Shizaihi.TextChanged, Txt_Naisou_Shizaihi.TextChanged

        Txt_Ko_Naisou_Shizai.Text = (GetDecimalOrZero(Txt_Kosou_Shizaihi) + GetDecimalOrZero(Txt_Naisou_Shizaihi)).ToString()

    End Sub

    '外装資材＝外装資材費
    Private Sub Recalc_Gaisou_Shizai(sender As Object, e As EventArgs) Handles Txt_Gaisou_Shizaihi.TextChanged

        Txt_Gaisou_Shizai.Text = GetDecimalOrZero(Txt_Gaisou_Shizaihi).ToString()

    End Sub

    '資材計＝個_内装資材＋外装資材
    Private Sub Recalc_Shizai_Total(sender As Object, e As EventArgs) Handles Txt_Ko_Naisou_Shizai.TextChanged, Txt_Gaisou_Shizai.TextChanged

        Txt_Shizai_Total.Text = (GetDecimalOrZero(Txt_Ko_Naisou_Shizai) + GetDecimalOrZero(Txt_Gaisou_Shizai)).ToString()

    End Sub

    '編集エリアの入力欄をクリア
    Sub Clear_Henshu()

        _selected_ccc_lot_id = 0

        For Each field In Get_Henshu_Field_Map()
            field.Item2.BackColor = SystemColors.Window
        Next

        Txt_Tanpin_Buhin_Sousu.Text = ""
        Txt_Buhin_Tensu.Text = ""
        Txt_Bousabi_Kaisu.Text = ""
        Txt_Kosousu.Text = ""
        Txt_Naisou_Shizaisu.Text = ""
        Txt_Cartonsu.Text = ""
        Txt_Returnable.Text = ""
        Txt_ENG.Text = ""
        Txt_Tsumituke_Kaisu.Text = ""
        Txt_Panel_Casesu.Text = ""
        Txt_Sukashi_Casesu.Text = ""
        Txt_Gaisouo_Danborusu.Text = ""
        Txt_Gaisou_Poribukuro.Text = ""
        Txt_Gaisou_Boltsu.Text = ""
        Txt_Gaisou_Fukushizai.Text = ""
        Txt_Gaichoku_Buhinsu.Text = ""
        Txt_Gaichoku_Bousabi.Text = ""
        Txt_Gaisou_Case.Text = ""
        Txt_Buhin_Tensu_Sum.Text = ""
        Txt_Kosou_Shizaihi.Text = ""
        Txt_Naisou_Shizaihi.Text = ""
        Txt_Gaisou_Shizaihi.Text = ""
        Txt_Kosou_Sagyou.Text = ""
        Txt_Naisou_Sagyou.Text = ""
        Txt_Gaisou_Sagyou.Text = ""
        Txt_Sagyou_Total.Text = ""
        Txt_Ko_Naisou_Shizai.Text = ""
        Txt_Gaisou_Shizai.Text = ""
        Txt_Shizai_Total.Text = ""

    End Sub

End Class