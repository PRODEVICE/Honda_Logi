Imports System.Configuration
Imports System.Data.SqlClient

Public Class F_Make_1Lot

    Dim fnc As New Function_Class

    '**********************************************************************************
    'ボタンクリック時
    '**********************************************************************************

    '変換ボタンクリック時
    Private Sub Btn_Change_Click(sender As Object, e As EventArgs) Handles Btn_Change.Click

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString


            '①workテーブルにグループバイしたデータをインサート

            'SQL生成
            Dim sql As String = MakeSQL()
            Dim del_sql As String = "Delete From T_CCC_Work"
            Dim del_sql2 As String = "Delete From T_CCC_Lot"
            Dim sql2 As String = MakeSQL2()

            ' SQL実行
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' トランザクション開始
                Dim transaction As SqlTransaction = conn.BeginTransaction()


                Try

                    '① DELETE実行
                    Using cmdDel As New SqlCommand(del_sql, conn, transaction)
                        cmdDel.ExecuteNonQuery()
                    End Using

                    Using cmdDel As New SqlCommand(del_sql2, conn, transaction)
                        cmdDel.ExecuteNonQuery()
                    End Using

                    '② INSERT実行
                    Using cmdIns As New SqlCommand(sql, conn, transaction)
                        Dim rowsAffected As Integer = cmdIns.ExecuteNonQuery()
                    End Using

                    '③ 必要情報を関連テーブルから収集して本番テーブルへインサート
                    Using cmdIns2 As New SqlCommand(sql2, conn, transaction)
                        Dim rowsAffected As Integer = cmdIns2.ExecuteNonQuery()
                    End Using

                    '③ インサートしたデータをループして更新処理

                    ' コミット
                    transaction.Commit()

                Catch ex As Exception
                    ' エラー時はロールバック
                    transaction.Rollback()
                End Try



            End Using




        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Make_1Lot_Btn_Change_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '出力ボタンクリック時
    Private Sub Btn_Output_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click

        Try

            Dim dt As New DS_T.DT_T_CCC_LotDataTable
            Dim ta As New DS_TTableAdapters.TA_T_CCC_Lot

            ta.Fill(dt)

            Dim out_path As String = MakeOutPath()
            ConvertDataTableToCsv(dt, out_path, True)

            MessageBox.Show("ファイルの出力が完了しました。", "ファイル出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Make_1Lot_Btn_Output_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '**********************************************************************************
    '関数
    '**********************************************************************************

    Function MakeSQL() As String

        ' SQL文（INSERT文）
        Dim sql As String = "
;WITH Ranked AS (
    SELECT *,
        ROW_NUMBER() OVER (
            PARTITION BY ｺﾝﾄﾛｰﾙNO, ケースNO1, 代表DIST, 年度2, モデル2, タイプ1, オプション1, 群
            ORDER BY 包装ロットNO ASC
        ) AS RN
    FROM [dbo].[T_CCC]
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
    取込年月
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
    取込年月
FROM Ranked
WHERE RN = 1;

"

        Return sql

    End Function

    Function MakeSQL2() As String

        ' SQL文（INSERT文）
        Dim sql As String = "


INSERT INTO [dbo].[T_CCC_Lot] (

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
Main.取込年月
		
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
		,Second3.秒数  AS 防錆回数
		
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
		 ,CASE WHEN Main.外装資材記号  LIKE '%SP%' THEN Second10.秒数 ELSE 0 END AS パネルケース数
		 
		 --スカシケース数
		 ,CASE WHEN Main.外装資材記号  LIKE '%SC%' OR Main.外装資材記号 LIKE '%RC%' OR Main.外装資材記号 LIKE '%CY%'  THEN Second11.秒数 ELSE 0 END AS スカシケース数

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

		LEFT JOIN M_Buhin_Order_List OrderList1
		ON Main.代表DIST = OrderList1.DIST
		AND Main.基本部番 = OrderList1.Basic_Part_No
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

		LEFT JOIN M_Buhin_Order_List OrderList2
		ON Main.代表DIST = OrderList2.DIST
		AND Main.基本部番 = OrderList2.Basic_Part_No

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
		LEFT JOIN M_Second Second19 ON Second19.作業区分 = 19;
"

        Return sql

    End Function




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

End Class