Imports System.Configuration

Public Class F_Buhin_Order_List

    'ページロード時
    Private Sub F_Buhin_Order_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'DS_M.DT_M_Buhin_Order_List' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Buhin_Order_List.Fill(Me.DS_M.DT_M_Buhin_Order_List)

    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click

        Try

            'コンフィグのコネクトストリング取得
            Dim con As New SqlClient.SqlConnection
            con.ConnectionString = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            'SQL作成
            Dim CommandString As String

            CommandString = MakeSQL_Search()

            'GVをクリア
            GV_Master.DataSource = Nothing

            'テーブルアダプター作成
            Dim DataAdapter As New SqlClient.SqlDataAdapter(CommandString, con)

            'SQLを実行
            Me.DS_M.DT_M_Mitsumori.Clear()
            DataAdapter.Fill(Me.DS_M.DT_M_Mitsumori)
            GV_Master.DataSource = Me.DS_M.DT_M_Mitsumori

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

        Catch ex As Exception

        End Try

    End Sub

    Function MakeSQL_Search() As String

        Try

            Dim DIST As String = Txt_S_DIST.Text.Trim
            Dim basic_no As String = Txt_S_Basic_No.Text.Trim
            Dim export_nm As String = Txt_S_Export_NM.Text.Trim
            Dim order_lot As String = Txt_S_Order_Lot.Text.Trim
            Dim OS As String = Txt_S_OS.Text.Trim
            Dim carton As String = Txt_S_Carton.Text.Trim


            Dim Retstr As String = Nothing
            Dim strtemp As String = Nothing

            'Where区作成

            'DIST
            If (DIST.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "DIST like '%" & DIST & "%'"
                Else
                    strtemp = strtemp & " AND DIST like '%" & DIST & "%'"
                End If
            End If

            'Basic_Part_No
            If (basic_no.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "Basic_Part_No like '%" & basic_no & "%'"
                Else
                    strtemp = strtemp & " AND Basic_Part_No like '%" & basic_no & "%'"
                End If
            End If

            'Export_Name
            If (export_nm.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "Export_Name like '%" & export_nm & "%'"
                Else
                    strtemp = strtemp & " AND Export_Name like '%" & export_nm & "%'"
                End If
            End If

            'Order_Lot
            If (order_lot.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "Order_Lot like '%" & order_lot & "%'"
                Else
                    strtemp = strtemp & " AND Order_Lot like '%" & order_lot & "%'"
                End If
            End If

            'OS
            If (OS.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "OS like '%" & OS & "%'"
                Else
                    strtemp = strtemp & " AND OS like '%" & OS & "%'"
                End If
            End If

            '内装適用
            If (carton.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "内装適用 like '%" & carton & "%'"
                Else
                    strtemp = strtemp & " AND 内装適用 like '%" & carton & "%'"
                End If
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM M_Buhin_Order_List "
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

End Class