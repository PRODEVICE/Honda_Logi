Imports System.Configuration

Public Class F_Mitsumori

    Dim fnc As New Function_Class

    'ページロード時
    Private Sub F_Mitsumori_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: このコード行はデータを 'DS_M.DT_M_Mitsumori' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_M_Mitsumori.Fill(Me.DS_M.DT_M_Mitsumori)

        'ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
        GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    '******************************************************************************
    'ボタンクリックイベント
    '******************************************************************************

    '登録ボタンクリック時
    Private Sub Btn_Touroku_Click(sender As Object, e As EventArgs) Handles Btn_Touroku.Click

        Try

            Dim ta_mitsumori As New DS_MTableAdapters.TA_M_Mitsumori

            Dim mitsumori_cd As String = Txt_Mitsumori_CD.Text.Trim
            Dim shimuke As String = Txt_Shimuke.Text.Trim
            Dim kishu As String = Txt_Kishu.Text.Trim
            Dim type As String = Txt_Type.Text.Trim
            Dim op As String = Txt_OP.Text.Trim
            Dim id As String = Txt_id.Text.Trim

            '入力チェック
            If mitsumori_cd = "" Or shimuke = "" Or kishu = "" Or type = "" Or op = "" Then

                MessageBox.Show("全項目入力してください")
                Exit Sub

            End If

            Dim chk_count As String = ""

            '新規モード
            If Btn_Touroku.Text = "登　録" Then

                '存在チェック
                chk_count = ta_mitsumori.Q_存在チェック(mitsumori_cd)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの見積コードです。")
                    Exit Sub
                End If

                '存在チェック2
                chk_count = ta_mitsumori.Q_存在チェック2(shimuke, kishu, type, op)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの内容です。")
                    Exit Sub
                End If

                '登録処理
                ta_mitsumori.Q_見積登録(mitsumori_cd, shimuke, kishu, type, op)

            Else '更新モード

                '存在チェック
                chk_count = ta_mitsumori.Q_更新存在チェック(mitsumori_cd, id)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの見積コードです。")
                    Exit Sub
                End If

                '存在チェック2
                chk_count = ta_mitsumori.Q_更新存在チェック2(shimuke, kishu, type, op, id)

                If chk_count <> 0 Then
                    MessageBox.Show("既に登録済みの内容です。")
                    Exit Sub
                End If

                ta_mitsumori.Q_見積更新(mitsumori_cd, shimuke, kishu, type, op, id)

            End If

            'GV更新
            Me.TA_M_Mitsumori.Fill(Me.DS_M.DT_M_Mitsumori)

            'クリア
            clear()

            MessageBox.Show("完了しました。")

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Mitsumori_Btn_Touroku_Click")
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
            Me.DS_M.DT_M_Mitsumori.Clear()
            DataAdapter.Fill(Me.DS_M.DT_M_Mitsumori)
            GV_Master.DataSource = Me.DS_M.DT_M_Mitsumori

            ' 列幅を自動調整
            GV_Master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            GV_Master.AutoResizeColumns()

            '入力項目もクリア
            clear()

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Mitsumori_Master_Btn_Search_Click")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '全件削除ボタンクリック時
    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click

        Try

            If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Dim ta_mitsumori As New DS_MTableAdapters.TA_M_Mitsumori

                'DBからも削除
                ta_mitsumori.Q_見積全件削除()

                MessageBox.Show("削除完了しました。")

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Mitsumori_Master_Btn_Delete_Click")
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

            Dim ta_mitsumori As New DS_MTableAdapters.TA_M_Mitsumori

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

                Txt_Mitsumori_CD.Text = grid.Rows(e.RowIndex).Cells("見積コード").Value.ToString()
                Txt_Shimuke.Text = grid.Rows(e.RowIndex).Cells("仕向").Value.ToString()
                Txt_Kishu.Text = grid.Rows(e.RowIndex).Cells("機種").Value.ToString()
                Txt_Type.Text = grid.Rows(e.RowIndex).Cells("タイプ").Value.ToString()
                Txt_OP.Text = grid.Rows(e.RowIndex).Cells("OP").Value.ToString()

                Btn_Touroku.Text = "更　新"

            End If

            '削除ボタン
            If grid.Columns(e.ColumnIndex).Name = "削除" Then

                If MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'データソースから削除
                    grid.Rows.RemoveAt(e.RowIndex)

                    'DBからも削除
                    ta_mitsumori.Q_見積削除(target_id)

                    MessageBox.Show("削除完了しました。")

                End If

            End If

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Mitsumori_GV_Master_CellContentClick")
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '******************************************************************************
    '関数
    '******************************************************************************

    '画面項目クリア処理
    Sub clear()

        Txt_id.Text = ""
        Txt_Kishu.Text = ""
        Txt_Mitsumori_CD.Text = ""
        Txt_OP.Text = ""
        Txt_Shimuke.Text = ""
        Txt_Type.Text = ""

        Btn_Touroku.Text = "登　録"
    End Sub

    Function MakeSQL_Search() As String

        Try
            Dim mitsumori_cd As String = Txt_S_Mitsumori_CD.Text.Trim
            Dim shimuke As String = Txt_S_Shimuke.Text.Trim
            Dim kishu As String = Txt_S_Kishu.Text.Trim
            Dim type As String = Txt_S_Type.Text.Trim
            Dim op As String = Txt_S_OP.Text.Trim

            Dim Retstr As String = Nothing
            Dim strtemp As String = Nothing

            'Where区作成区作成

            '見積コード
            If (mitsumori_cd.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "見積コード like '%" & mitsumori_cd & "%'"
                Else
                    strtemp = strtemp & " AND 見積コード like '%" & mitsumori_cd & "%'"
                End If
            End If

            '仕向
            If (shimuke.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "仕向 like '%" & shimuke & "%'"
                Else
                    strtemp = strtemp & " AND 仕向 like '%" & shimuke & "%'"
                End If
            End If

            '機種
            If (kishu.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "機種 like '%" & kishu & "%'"
                Else
                    strtemp = strtemp & " AND 機種 like '%" & kishu & "%'"
                End If
            End If

            'タイプ
            If (type.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "タイプ like '%" & type & "%'"
                Else
                    strtemp = strtemp & " AND タイプ like '%" & type & "%'"
                End If
            End If

            'OP
            If (op.Length > 0) Then
                If strtemp = Nothing Then
                    strtemp = "OP like '%" & op & "%'"
                Else
                    strtemp = strtemp & " AND OP like '%" & op & "%'"
                End If
            End If

            'Where句の完成
            If strtemp <> Nothing Then
                strtemp = " WHERE " & strtemp
            End If

            '最終的なSQL文の作成
            Retstr = "SELECT  *
                        FROM M_Mitsumori "
            Retstr = Retstr & strtemp       'Where句

            Return Retstr

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function


End Class