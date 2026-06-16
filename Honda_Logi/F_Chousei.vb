Public Class F_Chousei

    Dim fnc As New Function_Class

    Private _mode As Integer

    ' コンストラクタを追加
    Public Sub New(mode As Integer)
        InitializeComponent()
        _mode = mode
    End Sub

    'ページロード
    Private Sub F_Chousei_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: このコード行はデータを 'DS_T.DT_T_CCC_Lot' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TA_T_CCC_Lot.Fill(Me.DS_T.DT_T_CCC_Lot)

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

    '登録ボタンクリック時








    '削除ボタンクリック時


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

            Dim dt_1lot As New DS_T.DT_T_CCC_LotDataTable
            Dim ta_1lot As New DS_TTableAdapters.TA_T_CCC_Lot

            ta_1lot.Q_CCC_Lot取得(dt_1lot, Cmb_Target.SelectedValue)

            GV_Chousei.DataSource = Nothing
            GV_Chousei.DataSource = dt_1lot

        Catch ex As Exception
            fnc.ERR_LOG(ex.Message, "F_Chousei_Cmb_Target_SelectedIndexChanged")
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class