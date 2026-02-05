Imports System.Configuration
Imports System.IO

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
            fnc.ERR_LOG(ex.Message, "F_Shizai_Load")
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

                Dim qty As Integer
                If Not Integer.TryParse(suryou, qty) Then
                    MessageBox.Show("数量は整数で入力してください。")
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
            fnc.ERR_LOG(ex.Message, "F_Shizai_Btn_Touroku_Click")
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

    'CSV取込ボタンクリック時
    Private Sub Btn_Import_Click(sender As Object, e As EventArgs) Handles Btn_Import.Click

        Try

            Dim dt_From As DataTable
            Dim ta
            Dim target_file As String = ""

            ' DataRow を作成
            Dim dr As DataRow

            '個装マスタ
            If Cmb_Shurui.SelectedValue = "1" Then

                dt_From = New DS_M.DT_M_Kosou_ShizaiDataTable
                ta = New DS_MTableAdapters.TA_M_Kosou_Shizai
                dr = dt_From.NewRow

            ElseIf Cmb_Shurui.SelectedValue = "2" Then '内装マスタ

                dt_From = New DS_M.DT_M_Naisou_ShizaiDataTable
                ta = New DS_MTableAdapters.TA_M_Naisou_Shizai
                dr = dt_From.NewRow

            ElseIf Cmb_Shurui.SelectedValue = "3" Then 'ボルトマスタ

                dt_From = New DS_M.DT_M_BoltDataTable
                ta = New DS_MTableAdapters.TA_M_Bolt
                dr = dt_From.NewRow

            ElseIf Cmb_Shurui.SelectedValue = "4" Then 'ダンボール

                dt_From = New DS_M.DT_M_Gaisou_DanboruDataTable
                ta = New DS_MTableAdapters.TA_M_Gaisou_Danboru
                dr = dt_From.NewRow

            ElseIf Cmb_Shurui.SelectedValue = "5" Then '箱

                dt_From = New DS_M.DT_M_Gaisou_BoxDataTable
                ta = New DS_MTableAdapters.TA_M_Gaisou_Box
                dr = dt_From.NewRow

            End If

            '取込ファイル選択ダイアログ
            Using ofd As New OpenFileDialog()

                'ダイアログのタイトル
                ofd.Title = "ファイルを指定してください"

                '初期フォルダ（テキストボックスにパスがある場合はそこを開く）
                ofd.InitialDirectory = "C:\"

                '選択できるファイルの種類（必要に応じて調整）
                ofd.Filter = "すべてのファイル (*.*)|*.*"

                '複数選択を許可する場合
                ofd.Multiselect = False

                'OKが押されたらファイルパスをテキストボックスに表示
                If ofd.ShowDialog(Me) = DialogResult.OK Then
                    target_file = ofd.FileName
                End If

            End Using

            If target_file = "" Then
                Exit Sub
            End If


            'CSVの取込
            dt_From = Import_CSV(target_file, dt_From)

            'トランザクションの始まり
            Using scope As New System.Transactions.TransactionScope()

                '全件削除
                ta.Q_全件削除()

                '新規インサート
                ta.Update(dt_From)

                'コミット処理
                scope.Complete()

                'トランザクション終了
                scope.Dispose()

            End Using

            MessageBox.Show("取込完了しました。")

            'GV更新
            Chenge_Master(Cmb_Shurui.SelectedValue)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Btn_Import_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'CSV出力ボタンクリック
    Private Sub Btn_Output_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click

        Try

            '待機状態
            Cursor.Current = Cursors.WaitCursor


            Dim dt_csv As New DataTable

            If Cmb_Shurui.SelectedValue = "1" Then

                Dim dt As New DS_M.DT_M_Kosou_ShizaiDataTable
                Dim ta As New DS_MTableAdapters.TA_M_Kosou_Shizai
                ta.Fill(dt)

                dt_csv = dt

            ElseIf Cmb_Shurui.SelectedValue = "2" Then '内装マスタ
                Dim dt As New DS_M.DT_M_Naisou_ShizaiDataTable
                Dim ta As New DS_MTableAdapters.TA_M_Naisou_Shizai
                ta.Fill(dt)

                dt_csv = dt
            ElseIf Cmb_Shurui.SelectedValue = "3" Then 'ボルトマスタ
                Dim dt As New DS_M.DT_M_BoltDataTable
                Dim ta As New DS_MTableAdapters.TA_M_Bolt
                ta.Fill(dt)

                dt_csv = dt
            ElseIf Cmb_Shurui.SelectedValue = "4" Then 'ダンボール
                Dim dt As New DS_M.DT_M_Gaisou_DanboruDataTable
                Dim ta As New DS_MTableAdapters.TA_M_Gaisou_Danboru
                ta.Fill(dt)

                dt_csv = dt
            ElseIf Cmb_Shurui.SelectedValue = "5" Then '箱
                Dim dt As New DS_M.DT_M_Gaisou_BoxDataTable
                Dim ta As New DS_MTableAdapters.TA_M_Gaisou_Box
                ta.Fill(dt)

                dt_csv = dt
            End If


            Dim out_path As String = MakeOutPath()

            If out_path = "" Then
                Exit Sub
            End If

            ConvertDataTableToCsv(dt_csv, out_path, True)

            MessageBox.Show("ファイルの出力が完了しました。", "ファイル出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Shizai_Btn_Output_Click")
            MessageBox.Show(ex.Message)

        Finally
            '元に戻す
            Cursor.Current = Cursors.Default
        End Try

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


    'CSVファイル取り込み処理
    Function Import_CSV(_file_path As String, dt As DataTable) As DataTable

        Try

            Using sr As New StreamReader(_file_path, System.Text.Encoding.Default) ' Shift-JIS等も自動判別されやすい
                Dim isFirstLine As Boolean = True

                While Not sr.EndOfStream
                    Dim line As String = sr.ReadLine()

                    ' CSV の1行をパース（ダブルクォート対応）
                    Dim fields As String() = ParseCsvLine(line)

                    ' 最初の行はヘッダー
                    If isFirstLine Then

                        isFirstLine = False

                    Else
                        Dim dr As DataRow = dt.NewRow()


                        'CSV の各フィールドを id 以外の列に順にセット
                        For i As Integer = 0 To fields.Length - 1
                            dr(i + 1) = fields(i) ' ← +1 で id をスキップ
                        Next

                        dt.Rows.Add(dr)

                    End If

                End While

            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ParseCsvLine(line As String) As String()
        Dim result As New List(Of String)()
        Dim current As String = ""
        Dim inQuotes As Boolean = False

        For i As Integer = 0 To line.Length - 1
            Dim c As Char = line(i)

            If c = """"c Then
                ' ダブルクォートの開始/終了
                inQuotes = Not inQuotes
            ElseIf c = ","c AndAlso Not inQuotes Then
                ' カンマ区切り（クォート外のみ）
                result.Add(current)
                current = ""
            Else
                current &= c
            End If
        Next

        result.Add(current)
        Return result.ToArray()
    End Function


#Region "CSV作成処理"

    '保存先選択ダイアログ
    Function MakeOutPath() As String
        MakeOutPath = ""
        Try
            'SaveFileDialogクラスのインスタンスを作成
            Dim sfd As New SaveFileDialog()
            'はじめのファイル名を指定する
            'はじめに「ファイル名」で表示される文字列を指定する


            '個装マスタ
            If Cmb_Shurui.SelectedValue = "1" Then
                sfd.FileName = "個装主資材マスタ" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            ElseIf Cmb_Shurui.SelectedValue = "2" Then '内装マスタ
                sfd.FileName = "内装主資材マスタ" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            ElseIf Cmb_Shurui.SelectedValue = "3" Then 'ボルトマスタ
                sfd.FileName = "ボルト資材マスタ" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            ElseIf Cmb_Shurui.SelectedValue = "4" Then 'ダンボール
                sfd.FileName = "ダンボールパット資材マスタ" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            ElseIf Cmb_Shurui.SelectedValue = "5" Then '箱
                sfd.FileName = "箱ポリ" & Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            End If

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
            For i = 1 To colCount - 1
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
            For i = 1 To colCount - 1
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

End Class