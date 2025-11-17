Imports System.Configuration

Public Class F_Shizai

    Dim fnc As New Function_Class


    'ページロード時
    Private Sub F_Shizai_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'TODO: このコード行はデータを 'DS_M.DT_M_Kubun' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            Me.TA_M_Kubun.Fill(Me.DS_M.DT_M_Kubun)

            '初回は個装資材マスタを呼び出す
            Chenge_Master("1")

            '数量項目は非表示
            Lbl_Suryou.Visible = False
            Txt_Suryou.Visible = False

            'ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Master_Load")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_kosou As New DS_MTableAdapters.TA_M_Kosou_Shizai
            Dim ta_naisou As New DS_MTableAdapters.TA_M_Naisou_Shizai
            Dim ta_bolt As New DS_MTableAdapters.TA_M_Bolt
            Dim ta_danboru As New DS_MTableAdapters.TA_M_Gaisou_Danboru
            Dim ta_box As New DS_MTableAdapters.TA_M_Gaisou_Box

            Dim shizai_cd As String = Txt_Shizai_CD.Text.Trim
            Dim suryou As String = Txt_Suryou.Text.Trim
            Dim id As String = Txt_id.Text.Trim

            '入力チェック
            If Cmb_Shurui.SelectedValue = "2" Then '内装資材マスタなら

                If shizai_cd = "" Or suryou = "" Then
                    MessageBox.Show("資材コード、数量を入力してください")
                    Exit Sub
                End If

            Else 'その他資材マスタ

                If shizai_cd = "" Then
                    MessageBox.Show("資材コードを入力してください")
                    Exit Sub
                End If

            End If

            Dim chk_count As String = ""

            '新規モード
            If Btn_Touroku.Text = "登　録" Then


                If Cmb_Shurui.SelectedValue = "1" Then

                    '存在チェック
                    chk_count = ta_kosou.Q_存在チェック(shizai_cd)

                    If chk_count <> 0 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    '登録処理
                    ta_kosou.Q_個装資材登録(shizai_cd)


                ElseIf Cmb_Shurui.SelectedValue = "2" Then

                    '存在チェック
                    chk_count = ta_naisou.Q_存在チェック(shizai_cd)

                    If chk_count <> 0 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    '登録処理
                    ta_naisou.Q_内装資材登録(shizai_cd, suryou)


                ElseIf Cmb_Shurui.SelectedValue = "3" Then

                    '存在チェック
                    chk_count = ta_bolt.Q_存在チェック(shizai_cd)

                    If chk_count <> 0 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    '登録処理
                    ta_bolt.Q_ボルト登録(shizai_cd)


                ElseIf Cmb_Shurui.SelectedValue = "4" Then

                    '存在チェック
                    chk_count = ta_danboru.Q_存在チェック(shizai_cd)

                    If chk_count <> 0 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    '登録処理
                    ta_danboru.Q_ダンボール登録(shizai_cd)

                ElseIf Cmb_Shurui.SelectedValue = "5" Then

                    '存在チェック
                    chk_count = ta_box.Q_存在チェック(shizai_cd)

                    If chk_count <> 0 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    '登録処理
                    ta_box.Q_箱登録(shizai_cd)

                End If

            Else '更新モード

                If Cmb_Shurui.SelectedValue = "1" Then

                    '存在チェック
                    chk_count = ta_kosou.Q_存在チェック(shizai_cd)

                    If chk_count >= 1 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    ta_kosou.Q_個装資材更新(shizai_cd, id)

                ElseIf Cmb_Shurui.SelectedValue = "2" Then

                    '存在チェック
                    chk_count = ta_naisou.Q_存在チェック(shizai_cd)

                    If chk_count >= 1 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    ta_naisou.Q_内装資材更新(shizai_cd, suryou, id)

                ElseIf Cmb_Shurui.SelectedValue = "3" Then

                    '存在チェック
                    chk_count = ta_bolt.Q_存在チェック(shizai_cd)

                    If chk_count >= 1 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    ta_bolt.Q_ボルト更新(shizai_cd, id)

                ElseIf Cmb_Shurui.SelectedValue = "4" Then

                    '存在チェック
                    chk_count = ta_danboru.Q_存在チェック(shizai_cd)

                    If chk_count >= 1 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    ta_danboru.Q_ダンボール更新(shizai_cd, id)

                ElseIf Cmb_Shurui.SelectedValue = "5" Then

                    '存在チェック
                    chk_count = ta_box.Q_存在チェック(shizai_cd)

                    If chk_count >= 1 Then
                        MessageBox.Show("既に登録済みの資材コードです。")
                        Exit Sub
                    End If

                    ta_box.Q_箱更新(shizai_cd, id)

                End If

            End If

            'GV更新
            Chenge_Master(Cmb_Shurui.SelectedValue)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Master_Btn_Touroku_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '検索ボタンクリック時
    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click

        Try

            Dim dt_kosou As New DS_M.DT_M_Kosou_ShizaiDataTable
            Dim dt_naisou As New DS_M.DT_M_Naisou_ShizaiDataTable
            Dim dt_bolt As New DS_M.DT_M_BoltDataTable
            Dim dt_danboru As New DS_M.DT_M_Gaisou_DanboruDataTable
            Dim dt_box As New DS_M.DT_M_Gaisou_BoxDataTable

            Dim master_kbn As String = Cmb_Shurui.SelectedValue
            Dim shizai_cd As String = Txt_S_Shizai_CD.Text.Trim

            If shizai_cd.Length = 0 Then

                Chenge_Master(master_kbn)

            Else

                'コンフィグのコネクトストリング取得
                Dim con As New SqlClient.SqlConnection
                con.ConnectionString = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

                'SQL作成
                Dim CommandString As String

                CommandString = MakeSQL_Search(master_kbn, shizai_cd)

                'GVをクリア
                GV_Master.DataSource = Nothing


                'テーブルアダプター作成
                Dim DataAdapter As New SqlClient.SqlDataAdapter(CommandString, con)

                If master_kbn = "1" Then

                    'SQLを実行
                    DataAdapter.Fill(dt_kosou)
                    GV_Master.DataSource = dt_kosou

                ElseIf master_kbn = "2" Then

                    'SQLを実行
                    DataAdapter.Fill(dt_naisou)
                    GV_Master.DataSource = dt_naisou

                ElseIf master_kbn = "3" Then

                    'SQLを実行
                    DataAdapter.Fill(dt_bolt)
                    GV_Master.DataSource = dt_bolt

                ElseIf master_kbn = "4" Then

                    'SQLを実行
                    DataAdapter.Fill(dt_danboru)
                    GV_Master.DataSource = dt_danboru

                ElseIf master_kbn = "5" Then

                    'SQLを実行
                    DataAdapter.Fill(dt_box)
                    GV_Master.DataSource = dt_box

                End If

                ' ID列を非表示に
                If GV_Master.Columns.Contains("ID") Then
                    GV_Master.Columns("ID").Visible = False
                End If

                ' 既存のボタン列を削除（逆順で安全に）
                For i As Integer = GV_Master.Columns.Count - 1 To 0 Step -1
                    If GV_Master.Columns(i).Name = "選択" Or GV_Master.Columns(i).Name = "削除" Then
                        GV_Master.Columns.RemoveAt(i)
                    End If
                Next

                ' 選択ボタン列（最初の列）
                Dim selectCol As New DataGridViewLinkColumn()
                selectCol.Name = "選択"
                selectCol.HeaderText = "選択"
                selectCol.Text = "選択"
                selectCol.UseColumnTextForLinkValue = True
                selectCol.Width = 60
                selectCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                selectCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                GV_Master.Columns.Insert(0, selectCol)   ' 最初の列に追加

                ' 削除ボタン列（最後の列）
                Dim deleteCol As New DataGridViewLinkColumn()
                deleteCol.Name = "削除"
                deleteCol.HeaderText = "削除"
                deleteCol.Text = "削除"
                deleteCol.UseColumnTextForLinkValue = True
                deleteCol.Width = 60
                deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                deleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                GV_Master.Columns.Add(deleteCol)   ' 最後の列に追加

                ' 列幅を自動調整
                GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                GV_Master.AutoResizeColumns()

            End If

            '入力項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Master_Btn_Search_Click")
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

            Dim ta_kosou As New DS_MTableAdapters.TA_M_Kosou_Shizai
            Dim ta_naisou As New DS_MTableAdapters.TA_M_Naisou_Shizai
            Dim ta_bolt As New DS_MTableAdapters.TA_M_Bolt
            Dim ta_danboru As New DS_MTableAdapters.TA_M_Gaisou_Danboru
            Dim ta_box As New DS_MTableAdapters.TA_M_Gaisou_Box

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

                '内装資材だけ数量がある
                If Cmb_Shurui.SelectedValue = "1" Then

                    Txt_Shizai_CD.Text = grid.Rows(e.RowIndex).Cells("個装資材コード").Value.ToString()
                    Txt_Suryou.Text = ""

                ElseIf Cmb_Shurui.SelectedValue = "2" Then

                    Txt_Shizai_CD.Text = grid.Rows(e.RowIndex).Cells("内装資材コード").Value.ToString()
                    Txt_Suryou.Text = grid.Rows(e.RowIndex).Cells("数量").Value.ToString()

                ElseIf Cmb_Shurui.SelectedValue = "3" Then

                    Txt_Shizai_CD.Text = grid.Rows(e.RowIndex).Cells("個装資材コード").Value.ToString()
                    Txt_Suryou.Text = ""

                ElseIf Cmb_Shurui.SelectedValue = "4" Then

                    Txt_Shizai_CD.Text = grid.Rows(e.RowIndex).Cells("内装資材コード").Value.ToString()
                    Txt_Suryou.Text = ""

                ElseIf Cmb_Shurui.SelectedValue = "5" Then

                    Txt_Shizai_CD.Text = grid.Rows(e.RowIndex).Cells("内装資材コード").Value.ToString()
                    Txt_Suryou.Text = ""

                End If

                Btn_Touroku.Text = "更　新"

            End If

            '削除ボタン
            If grid.Columns(e.ColumnIndex).Name = "削除" Then

                If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'データソースから削除
                    grid.Rows.RemoveAt(e.RowIndex)

                    'DBからも削除
                    If Cmb_Shurui.SelectedValue = "1" Then

                        ta_kosou.Q_個装資材削除(target_id)

                    ElseIf Cmb_Shurui.SelectedValue = "2" Then

                        ta_naisou.Q_内装資材削除(target_id)

                    ElseIf Cmb_Shurui.SelectedValue = "3" Then

                        ta_bolt.Q_ボルト削除(target_id)

                    ElseIf Cmb_Shurui.SelectedValue = "4" Then

                        ta_danboru.Q_ダンボール削除(target_id)

                    ElseIf Cmb_Shurui.SelectedValue = "5" Then

                        ta_box.Q_箱削除(target_id)

                    End If

                    MessageBox.Show("削除完了しました。")

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Master_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '******************************************************************************
    'その他コントロールイベント
    '******************************************************************************

    'マスタの種類が変更されたら
    Private Sub Cmb_Shurui_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Shurui.SelectedIndexChanged

        Try

            'GVのデータソースを切り替える
            'Chenge_Master(Cmb_Shurui.SelectedValue)
            Btn_Search_Click(Nothing, Nothing)


            'コントロールの表示制御
            If Cmb_Shurui.SelectedValue = "2" Then

                Lbl_Suryou.Visible = True
                Txt_Suryou.Visible = True

            Else

                Lbl_Suryou.Visible = False
                Txt_Suryou.Visible = False

            End If

            '画面項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Master_Cmb_Shurui_SelectedIndexChanged")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '******************************************************************************
    '関数
    '******************************************************************************

    'GVのデータソース切り替え処理
    Sub Chenge_Master(master_kbn As String)

        Try

            Dim dt_kosou As New DS_M.DT_M_Kosou_ShizaiDataTable
            Dim dt_naisou As New DS_M.DT_M_Naisou_ShizaiDataTable
            Dim dt_bolt As New DS_M.DT_M_BoltDataTable
            Dim dt_danboru As New DS_M.DT_M_Gaisou_DanboruDataTable
            Dim dt_box As New DS_M.DT_M_Gaisou_BoxDataTable

            'コンフィグのコネクトストリング取得
            Dim con As New SqlClient.SqlConnection
            con.ConnectionString = ConfigurationManager.ConnectionStrings("Honda_Logi.My.MySettings.Honda_LogiConnectionString").ConnectionString

            'SQL作成
            Dim CommandString As String

            CommandString = MakeSQL(master_kbn)

            'GVをクリア
            GV_Master.DataSource = Nothing


            'テーブルアダプター作成
            Dim DataAdapter As New SqlClient.SqlDataAdapter(CommandString, con)

            If master_kbn = "1" Then

                'SQLを実行
                DataAdapter.Fill(dt_kosou)
                GV_Master.DataSource = dt_kosou

            ElseIf master_kbn = "2" Then

                'SQLを実行
                DataAdapter.Fill(dt_naisou)
                GV_Master.DataSource = dt_naisou

            ElseIf master_kbn = "3" Then

                'SQLを実行
                DataAdapter.Fill(dt_bolt)
                GV_Master.DataSource = dt_bolt

            ElseIf master_kbn = "4" Then

                'SQLを実行
                DataAdapter.Fill(dt_danboru)
                GV_Master.DataSource = dt_danboru

            ElseIf master_kbn = "5" Then

                'SQLを実行
                DataAdapter.Fill(dt_box)
                GV_Master.DataSource = dt_box

            End If

            ' ID列を非表示に
            If GV_Master.Columns.Contains("ID") Then
                GV_Master.Columns("ID").Visible = False
            End If

            ' 既存のボタン列を削除（逆順で安全に）
            For i As Integer = GV_Master.Columns.Count - 1 To 0 Step -1
                If GV_Master.Columns(i).Name = "選択" Or GV_Master.Columns(i).Name = "削除" Then
                    GV_Master.Columns.RemoveAt(i)
                End If
            Next

            ' 選択ボタン列（最初の列）
            Dim selectCol As New DataGridViewLinkColumn()
            selectCol.Name = "選択"
            selectCol.HeaderText = "選択"
            selectCol.Text = "選択"
            selectCol.UseColumnTextForLinkValue = True
            selectCol.Width = 60
            selectCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            selectCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            GV_Master.Columns.Insert(0, selectCol)   ' 最初の列に追加

            ' 削除ボタン列（最後の列）
            Dim deleteCol As New DataGridViewLinkColumn()
            deleteCol.Name = "削除"
            deleteCol.HeaderText = "削除"
            deleteCol.Text = "削除"
            deleteCol.UseColumnTextForLinkValue = True
            deleteCol.Width = 60
            deleteCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            deleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            GV_Master.Columns.Add(deleteCol)   ' 最後の列に追加

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    'SQL作成処理
    Function MakeSQL(_shurui) As String

        Try

            Dim strtemp As String = Nothing
            Dim Retstr As String = Nothing
            Dim From As String

            'From区作成
            If _shurui = "1" Then
                From = "M_Kosou_Shizai"
            ElseIf _shurui = "2" Then
                From = "M_Naisou_Shizai"
            ElseIf _shurui = "3" Then
                From = "M_Bolt"
            ElseIf _shurui = "4" Then
                From = "M_Gaisou_Danboru"
            ElseIf _shurui = "5" Then
                From = "M_Gaisou_Box"
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM " & From
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Function MakeSQL_Search(_shurui, _shizai_cd) As String

        Try

            Dim strtemp As String = Nothing
            Dim Retstr As String = Nothing
            Dim From As String

            'FromWhere区作成
            If _shurui = "1" Then
                From = "M_Kosou_Shizai WHERE 個装資材コード like '%" & _shizai_cd & "%'"
            ElseIf _shurui = "2" Then
                From = "M_Naisou_Shizai WHERE 内装資材コード like '%" & _shizai_cd & "%'"
            ElseIf _shurui = "3" Then
                From = "M_Bolt WHERE 個装資材コード like '%" & _shizai_cd & "%'"
            ElseIf _shurui = "4" Then
                From = "M_Gaisou_Danboru WHERE 内装資材コード like '%" & _shizai_cd & "%'"
            ElseIf _shurui = "5" Then
                From = "M_Gaisou_Box WHERE 内装資材コード like '%" & _shizai_cd & "%'"
            End If


            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM " & From
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Sub clear()

        Txt_Shizai_CD.Text = ""
        Txt_Suryou.Text = ""
        Txt_id.Text = ""

        Btn_Touroku.Text = "登　録"

    End Sub


End Class