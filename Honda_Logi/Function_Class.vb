Imports System.Data.SqlClient

Public Class Function_Class



    '***********************************************************************************
    'エラーログ作成
    '***********************************************************************************
    '引数
    '1:エラーメッセージ
    '2:発生個所
    '3:発生日時

    Public Sub ERR_LOG(ByVal _err_msg As String, ByVal _err_place As String)
        Try
            Dim date_now As DateTime = System.DateTime.Now
            Dim ta As New DS_TTableAdapters.TA_T_ERR_LOG

            'エラーログ出力
            ta.Q_エラーログ登録(_err_place, _err_msg, date_now)

        Catch ex As Exception
            Throw New Exception("エラーログ登録時にエラーが発生しました。")
        End Try
    End Sub

    Public Sub Master_Change_Start(_new_mitsumori_no As String, _mitsumori_no As String, conn As SqlConnection, tran As SqlTransaction)

        Try

            '最新を過去マスタに保存
            Dim master_bk_delete_sql As String = MakeSQL_BK_Delete(_new_mitsumori_no)
            Dim master_bk_insert_sql As String = MakeSQL_BK_Insert(_new_mitsumori_no)

            '該当見積Noのデータはデリート
            Using cmd_master_del As New SqlCommand(master_bk_delete_sql, conn, tran)
                Dim rowsAffected As Integer = cmd_master_del.ExecuteNonQuery()
            End Using

            'インサート処理
            Using cmd_master_insert As New SqlCommand(master_bk_insert_sql, conn, tran)
                Dim rowsAffected As Integer = cmd_master_insert.ExecuteNonQuery()
            End Using

            '過去のマスタを呼び出す
            Dim master_delete_sql As String = MakeSQL_Delete()
            Dim master_insert_sql As String = MakeSQL_Insert(_mitsumori_no)

            '該当見積Noのデータはデリート
            Using cmd_master_del As New SqlCommand(master_delete_sql, conn, tran)
                Dim rowsAffected As Integer = cmd_master_del.ExecuteNonQuery()
            End Using

            'インサート処理
            Using cmd_master_insert As New SqlCommand(master_insert_sql, conn, tran)
                Dim rowsAffected As Integer = cmd_master_insert.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception()
        End Try

    End Sub

    Public Sub Master_Change_END(_new_mitsumori_no As String, conn As SqlConnection, tran As SqlTransaction)

        Try

            Dim master_delete_sql As String = MakeSQL_Delete()
            Dim master_insert_sql As String = MakeSQL_Insert(_new_mitsumori_no)

            '該当見積Noのデータはデリート
            Using cmd_master_del As New SqlCommand(master_delete_sql, conn, tran)
                Dim rowsAffected As Integer = cmd_master_del.ExecuteNonQuery()
            End Using

            'BKからインサート処理
            Using cmd_master_insert As New SqlCommand(master_insert_sql, conn, tran)
                Dim rowsAffected As Integer = cmd_master_insert.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception()
        End Try

    End Sub

    Function MakeSQL_BK_Delete(_target_mitsumori_no As String) As String

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
        sql = sql & " DELETE FROM M_Keisu_BK WHERE 見積No = '" & _target_mitsumori_no & "';"

        Return sql

    End Function

    Function MakeSQL_BK_Insert(_target_mitsumori_no As String) As String

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
        sql = sql & " INSERT INTO M_Tanka_BK (資材コード,資材名,単価,メーカーコード, 単重,M3,見積No) SELECT 資材コード,資材名,単価,メーカーコード, 単重,M3, " & _target_mitsumori_no & " FROM M_Tanka;"
        sql = sql & " INSERT INTO M_Keisu_BK (仕向,機種,群,係数, 見積No) SELECT 仕向,機種,群,係数, " & _target_mitsumori_no & " FROM M_Keisu;"

        Return sql

    End Function

    Function MakeSQL_Delete() As String

        ' SQL文
        Dim sql As String = ""

        sql = "DELETE FROM M_Bolt;"
        sql = sql & " DELETE FROM M_Bolt;"
        sql = sql & " DELETE FROM M_Gaisou_Box;"
        sql = sql & " DELETE FROM M_Gaisou_Danboru;"
        sql = sql & " DELETE FROM M_Housou_Kbn;"
        sql = sql & " DELETE FROM M_Kosou_Shizai;"
        sql = sql & " DELETE FROM M_Mitsumori;"
        sql = sql & " DELETE FROM M_Naisou_Shizai;"
        sql = sql & " DELETE FROM M_Rate;"
        sql = sql & " DELETE FROM M_Second;"
        sql = sql & " DELETE FROM M_Tanka;"
        sql = sql & " DELETE FROM M_Keisu;"

        Return sql

    End Function

    Function MakeSQL_Insert(_target_mitsumori_no As String) As String

        ' SQL文
        Dim sql As String = ""

        sql = "INSERT INTO M_Bolt (個装資材コード) SELECT 個装資材コード FROM M_Bolt_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Gaisou_Box (内装資材コード) SELECT 内装資材コード FROM M_Gaisou_Box_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Gaisou_Danboru (内装資材コード) SELECT 内装資材コード FROM M_Gaisou_Danboru_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Housou_Kbn (ライン,DIST,個装内装区分,区分,定量_不定量) SELECT ライン,DIST,個装内装区分,区分,定量_不定量 FROM M_Housou_Kbn_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Kosou_Shizai (個装資材コード) SELECT 個装資材コード FROM M_Kosou_Shizai_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Mitsumori (見積コード,仕向,機種,タイプ,OP) SELECT 見積コード,仕向,機種,タイプ,OP FROM M_Mitsumori_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Naisou_Shizai (内装資材コード,数量) SELECT 内装資材コード,数量 FROM M_Naisou_Shizai_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Rate (賃率) SELECT 賃率 FROM M_Rate_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Second (作業区分,作業単位,秒数) SELECT 作業区分,作業単位,秒数 FROM M_Second_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Tanka (資材コード,資材名,単価,メーカーコード, 単重,M3) SELECT 資材コード,資材名,単価,メーカーコード, 単重,M3 FROM M_Tanka_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        sql = sql & " INSERT INTO M_Keisu (仕向,機種,群,係数) SELECT 仕向,機種,群,係数 FROM M_Keisu_BK WHERE 見積No = " & _target_mitsumori_no & ";"
        Return sql

    End Function

End Class
