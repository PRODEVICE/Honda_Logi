Imports System.Configuration

Public Class F_User

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'DS_M.DT_M_Kubun' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Kubun.Fill(Me.DS_M.DT_M_Kubun)

        'TODO: このコード行はデータを 'DS_M.DT_M_User' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_User.Fill(Me.DS_M.DT_M_User)

        'ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
        GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_user As New DS_MTableAdapters.TA_M_User
            Dim hankaku_suji As New System.Text.RegularExpressions.Regex(“^[0-9.]+$”)

            Dim tantou_cd As String = Txt_Tantou_CD.Text.Trim
            Dim tantou_nm As String = Txt_Tantou_NM.Text.Trim
            Dim password As String = Txt_Password.Text.Trim
            Dim kengen As String = Cmb_Kengen.SelectedValue
            Dim id As String = Txt_id.Text.Trim

            '入力チェック
            If tantou_cd = "" Then

                MessageBox.Show("担当者コードを入力してください")
                Exit Sub

            End If

            Dim chk_count As String = ""

            '新規モード
            If Btn_Touroku.Text = "登　録" Then

                '存在チェック
                chk_count = ta_user.Q_存在チェック(tantou_cd)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの担当者コードです。")
                    Exit Sub
                End If

                '登録処理
                ta_user.Q_ユーザー登録(tantou_cd, tantou_nm, kengen, password)

            Else '更新モード

                '存在チェック
                chk_count = ta_user.Q_更新存在チェック(tantou_cd, id)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの担当者コードです。")
                    Exit Sub
                End If

                ta_user.Q_ユーザー更新(tantou_cd, tantou_nm, kengen, password, id)

            End If

            'GV更新
            Me.TA_M_User.Fill(Me.DS_M.DT_M_User)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_User_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '検索ボタンクリック時
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
            Me.DS_M.DT_M_User.Clear()
            DataAdapter.Fill(Me.DS_M.DT_M_User)
            GV_Master.DataSource = Me.DS_M.DT_M_User

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

            '入力項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_User_Btn_Search_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'クリアボタンクリック時
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        clear()
    End Sub

    '******************************************************************************
    'GVイベント
    '******************************************************************************

    'リンクボタンがクリックされたら
    Private Sub GV_Master_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Master.CellContentClick

        Try

            Dim ta_user As New DS_MTableAdapters.TA_M_User

            'ヘッダークリックは無視
            If e.RowIndex < 0 Then
                Return
            End If

            Dim grid As DataGridView = CType(sender, DataGridView)

            '対象ID取得
            Dim target_id As String = grid.Rows(e.RowIndex).Cells("ID").Value.ToString()

            '選択ボタン
            If grid.Columns(e.ColumnIndex).Name = "選択" Then

                Txt_id.Text = target_id

                Txt_Tantou_CD.Text = grid.Rows(e.RowIndex).Cells("User_id").Value.ToString()
                Txt_Tantou_NM.Text = grid.Rows(e.RowIndex).Cells("User_NM").Value.ToString()
                Cmb_Kengen.SelectedValue = grid.Rows(e.RowIndex).Cells("Kengen").Value.ToString()
                Txt_Password.Text = grid.Rows(e.RowIndex).Cells("Password").Value.ToString()

                Btn_Touroku.Text = "更　新"

            End If

            '削除ボタン
            If grid.Columns(e.ColumnIndex).Name = "削除" Then

                If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'データソースから削除
                    grid.Rows.RemoveAt(e.RowIndex)

                    'DBからも削除
                    ta_user.Q_ユーザー削除(target_id)

                    MessageBox.Show("削除完了しました。")

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_User_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    '関数
    '******************************************************************************

    '画面項目クリア処理
    Sub clear()

        Txt_id.Text = ""
        Txt_Tantou_CD.Text = ""
        Txt_Tantou_NM.Text = ""
        Txt_Password.Text = ""
        Cmb_Kengen.SelectedIndex = 0

        Btn_Touroku.Text = "登　録"
    End Sub

    Function MakeSQL_Search() As String

        Try

            Dim tantou_cd As String = Txt_S_Tantou_CD.Text.Trim
            Dim tantou_nm As String = Txt_S_Tantou_NM.Text.Trim
            Dim kengen As String = Cmb_S_Kengen.SelectedValue

            Dim Retstr As String = Nothing
            Dim strtemp As String = Nothing

            'Where区作成区作成

            '担当者コード
            If (tantou_cd.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "User_id like '%" & tantou_cd & "%'"
                Else
                    strtemp = strtemp & " AND User_id like '%" & tantou_cd & "%'"
                End If
            End If

            '担当者名
            If (tantou_nm.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "User_NM like '%" & tantou_nm & "%'"
                Else
                    strtemp = strtemp & " AND User_NM like '%" & tantou_nm & "%'"
                End If
            End If

            '権限
            If (kengen.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "Kengen like '%" & kengen & "%'"
                Else
                    strtemp = strtemp & " AND Kengen like '%" & kengen & "%'"
                End If
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM M_User "
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

End Class