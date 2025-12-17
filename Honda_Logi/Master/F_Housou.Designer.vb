<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Housou
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GV_Master = New System.Windows.Forms.DataGridView()
        Me.選択 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ライン = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装内装区分 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.区分 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.定量_不定量 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.削除 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DTMHousouKbnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_DIST = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Clear = New System.Windows.Forms.Button()
        Me.Txt_id = New System.Windows.Forms.TextBox()
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cmb_Teiryou = New System.Windows.Forms.ComboBox()
        Me.BS_Teiryou = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Cmb_Kubun = New System.Windows.Forms.ComboBox()
        Me.BS_Kubun = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Cmb_Line = New System.Windows.Forms.ComboBox()
        Me.BS_Line = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cmb_Housou_Kbn = New System.Windows.Forms.ComboBox()
        Me.BS_KosouNaisou = New System.Windows.Forms.BindingSource(Me.components)
        Me.BS_S_KosouNaisou = New System.Windows.Forms.BindingSource(Me.components)
        Me.TA_M_Housou_Kbn = New Honda_Logi.DS_MTableAdapters.TA_M_Housou_Kbn()
        Me.TA_M_Kubun = New Honda_Logi.DS_MTableAdapters.TA_M_Kubun()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cmb_S_Teiryou = New System.Windows.Forms.ComboBox()
        Me.BS_S_Teiryou = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cmb_S_Kubun = New System.Windows.Forms.ComboBox()
        Me.BS_S_Kubun = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_S_Housou_Kbn = New System.Windows.Forms.ComboBox()
        Me.Btn_Import = New System.Windows.Forms.Button()
        Me.Txt_S_Line = New System.Windows.Forms.TextBox()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_S_DIST = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMHousouKbnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.BS_Teiryou, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_Kubun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_Line, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_KosouNaisou, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_S_KosouNaisou, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.BS_S_Teiryou, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_S_Kubun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GV_Master)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 123)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(934, 358)
        Me.Panel1.TabIndex = 17
        '
        'GV_Master
        '
        Me.GV_Master.AllowUserToAddRows = False
        Me.GV_Master.AllowUserToDeleteRows = False
        Me.GV_Master.AutoGenerateColumns = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GV_Master.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GV_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV_Master.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選択, Me.id, Me.ライン, Me.DIST, Me.個装内装区分, Me.区分, Me.定量_不定量, Me.削除})
        Me.GV_Master.DataSource = Me.DTMHousouKbnBindingSource
        Me.GV_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Master.Location = New System.Drawing.Point(0, 0)
        Me.GV_Master.Name = "GV_Master"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GV_Master.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GV_Master.RowTemplate.Height = 31
        Me.GV_Master.Size = New System.Drawing.Size(934, 358)
        Me.GV_Master.TabIndex = 1
        '
        '選択
        '
        Me.選択.HeaderText = "選択"
        Me.選択.Name = "選択"
        Me.選択.Text = "選択"
        Me.選択.UseColumnTextForLinkValue = True
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'ライン
        '
        Me.ライン.DataPropertyName = "ライン"
        Me.ライン.HeaderText = "ライン"
        Me.ライン.Name = "ライン"
        '
        'DIST
        '
        Me.DIST.DataPropertyName = "DIST"
        Me.DIST.HeaderText = "DIST"
        Me.DIST.Name = "DIST"
        '
        '個装内装区分
        '
        Me.個装内装区分.DataPropertyName = "個装内装区分"
        Me.個装内装区分.HeaderText = "個装/内装"
        Me.個装内装区分.Name = "個装内装区分"
        '
        '区分
        '
        Me.区分.DataPropertyName = "区分"
        Me.区分.HeaderText = "区分"
        Me.区分.Name = "区分"
        '
        '定量_不定量
        '
        Me.定量_不定量.DataPropertyName = "定量_不定量"
        Me.定量_不定量.HeaderText = "定量_不定量"
        Me.定量_不定量.Name = "定量_不定量"
        '
        '削除
        '
        Me.削除.HeaderText = "削除"
        Me.削除.Name = "削除"
        Me.削除.Text = "削除"
        Me.削除.UseColumnTextForLinkValue = True
        '
        'DTMHousouKbnBindingSource
        '
        Me.DTMHousouKbnBindingSource.DataMember = "DT_M_Housou_Kbn"
        Me.DTMHousouKbnBindingSource.DataSource = Me.DS_M
        Me.DTMHousouKbnBindingSource.Filter = ""
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(521, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "個装/内装"
        '
        'Txt_DIST
        '
        Me.Txt_DIST.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_DIST.Location = New System.Drawing.Point(299, 21)
        Me.Txt_DIST.Name = "Txt_DIST"
        Me.Txt_DIST.Size = New System.Drawing.Size(173, 23)
        Me.Txt_DIST.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(252, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "DIST"
        '
        'Btn_Clear
        '
        Me.Btn_Clear.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Clear.Location = New System.Drawing.Point(842, 63)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Clear.TabIndex = 10
        Me.Btn_Clear.Text = "クリア"
        Me.Btn_Clear.UseVisualStyleBackColor = True
        '
        'Txt_id
        '
        Me.Txt_id.Location = New System.Drawing.Point(677, 92)
        Me.Txt_id.Name = "Txt_id"
        Me.Txt_id.Size = New System.Drawing.Size(50, 19)
        Me.Txt_id.TabIndex = 9
        Me.Txt_id.Visible = False
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(740, 63)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Touroku.TabIndex = 0
        Me.Btn_Touroku.Text = "登　録"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ライン"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Cmb_Teiryou)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Cmb_Kubun)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Cmb_Line)
        Me.Panel2.Controls.Add(Me.Cmb_Housou_Kbn)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Txt_DIST)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Btn_Clear)
        Me.Panel2.Controls.Add(Me.Txt_id)
        Me.Panel2.Controls.Add(Me.Btn_Touroku)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 481)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(934, 123)
        Me.Panel2.TabIndex = 18
        '
        'Cmb_Teiryou
        '
        Me.Cmb_Teiryou.DataSource = Me.BS_Teiryou
        Me.Cmb_Teiryou.DisplayMember = "区分詳細名"
        Me.Cmb_Teiryou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Teiryou.FormattingEnabled = True
        Me.Cmb_Teiryou.Location = New System.Drawing.Point(351, 73)
        Me.Cmb_Teiryou.Name = "Cmb_Teiryou"
        Me.Cmb_Teiryou.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_Teiryou.TabIndex = 37
        Me.Cmb_Teiryou.ValueMember = "区分詳細名"
        '
        'BS_Teiryou
        '
        Me.BS_Teiryou.DataMember = "DT_M_Kubun"
        Me.BS_Teiryou.DataSource = Me.DS_M
        Me.BS_Teiryou.Filter = "区分id= 8 and 区分CD <> 0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(252, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "定量/不定量"
        '
        'Cmb_Kubun
        '
        Me.Cmb_Kubun.DataSource = Me.BS_Kubun
        Me.Cmb_Kubun.DisplayMember = "区分詳細名"
        Me.Cmb_Kubun.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Kubun.FormattingEnabled = True
        Me.Cmb_Kubun.Location = New System.Drawing.Point(82, 73)
        Me.Cmb_Kubun.Name = "Cmb_Kubun"
        Me.Cmb_Kubun.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_Kubun.TabIndex = 35
        Me.Cmb_Kubun.ValueMember = "区分詳細名"
        '
        'BS_Kubun
        '
        Me.BS_Kubun.DataMember = "DT_M_Kubun"
        Me.BS_Kubun.DataSource = Me.DS_M
        Me.BS_Kubun.Filter = "区分id = 7 and 区分CD <> 0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(36, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "区分"
        '
        'Cmb_Line
        '
        Me.Cmb_Line.DataSource = Me.BS_Line
        Me.Cmb_Line.DisplayMember = "区分詳細名"
        Me.Cmb_Line.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Line.FormattingEnabled = True
        Me.Cmb_Line.Location = New System.Drawing.Point(82, 21)
        Me.Cmb_Line.Name = "Cmb_Line"
        Me.Cmb_Line.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_Line.TabIndex = 16
        Me.Cmb_Line.ValueMember = "区分詳細名"
        '
        'BS_Line
        '
        Me.BS_Line.DataMember = "DT_M_Kubun"
        Me.BS_Line.DataSource = Me.DS_M
        Me.BS_Line.Filter = "区分id = 3"
        '
        'Cmb_Housou_Kbn
        '
        Me.Cmb_Housou_Kbn.DataSource = Me.BS_KosouNaisou
        Me.Cmb_Housou_Kbn.DisplayMember = "区分詳細名"
        Me.Cmb_Housou_Kbn.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Housou_Kbn.FormattingEnabled = True
        Me.Cmb_Housou_Kbn.Location = New System.Drawing.Point(607, 21)
        Me.Cmb_Housou_Kbn.Name = "Cmb_Housou_Kbn"
        Me.Cmb_Housou_Kbn.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_Housou_Kbn.TabIndex = 15
        Me.Cmb_Housou_Kbn.ValueMember = "区分詳細名"
        '
        'BS_KosouNaisou
        '
        Me.BS_KosouNaisou.DataMember = "DT_M_Kubun"
        Me.BS_KosouNaisou.DataSource = Me.DS_M
        Me.BS_KosouNaisou.Filter = "区分id = 4 and 区分CD <> 0"
        '
        'BS_S_KosouNaisou
        '
        Me.BS_S_KosouNaisou.DataMember = "DT_M_Kubun"
        Me.BS_S_KosouNaisou.DataSource = Me.DS_M
        Me.BS_S_KosouNaisou.Filter = "区分id = 4"
        '
        'TA_M_Housou_Kbn
        '
        Me.TA_M_Housou_Kbn.ClearBeforeFill = True
        '
        'TA_M_Kubun
        '
        Me.TA_M_Kubun.ClearBeforeFill = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Cmb_S_Teiryou)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Cmb_S_Kubun)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Cmb_S_Housou_Kbn)
        Me.Panel3.Controls.Add(Me.Btn_Import)
        Me.Panel3.Controls.Add(Me.Txt_S_Line)
        Me.Panel3.Controls.Add(Me.Btn_Search)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Txt_S_DIST)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(934, 123)
        Me.Panel3.TabIndex = 19
        '
        'Cmb_S_Teiryou
        '
        Me.Cmb_S_Teiryou.DataSource = Me.BS_S_Teiryou
        Me.Cmb_S_Teiryou.DisplayMember = "区分詳細名"
        Me.Cmb_S_Teiryou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_S_Teiryou.FormattingEnabled = True
        Me.Cmb_S_Teiryou.Location = New System.Drawing.Point(351, 83)
        Me.Cmb_S_Teiryou.Name = "Cmb_S_Teiryou"
        Me.Cmb_S_Teiryou.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_S_Teiryou.TabIndex = 33
        Me.Cmb_S_Teiryou.ValueMember = "区分詳細名"
        '
        'BS_S_Teiryou
        '
        Me.BS_S_Teiryou.DataMember = "DT_M_Kubun"
        Me.BS_S_Teiryou.DataSource = Me.DS_M
        Me.BS_S_Teiryou.Filter = "区分id= 8"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(252, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "定量/不定量"
        '
        'Cmb_S_Kubun
        '
        Me.Cmb_S_Kubun.DataSource = Me.BS_S_Kubun
        Me.Cmb_S_Kubun.DisplayMember = "区分詳細名"
        Me.Cmb_S_Kubun.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_S_Kubun.FormattingEnabled = True
        Me.Cmb_S_Kubun.Location = New System.Drawing.Point(82, 83)
        Me.Cmb_S_Kubun.Name = "Cmb_S_Kubun"
        Me.Cmb_S_Kubun.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_S_Kubun.TabIndex = 31
        Me.Cmb_S_Kubun.ValueMember = "区分詳細名"
        '
        'BS_S_Kubun
        '
        Me.BS_S_Kubun.DataMember = "DT_M_Kubun"
        Me.BS_S_Kubun.DataSource = Me.DS_M
        Me.BS_S_Kubun.Filter = "区分id = 7"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(33, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "区分"
        '
        'Cmb_S_Housou_Kbn
        '
        Me.Cmb_S_Housou_Kbn.DataSource = Me.BS_S_KosouNaisou
        Me.Cmb_S_Housou_Kbn.DisplayMember = "区分詳細名"
        Me.Cmb_S_Housou_Kbn.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_S_Housou_Kbn.FormattingEnabled = True
        Me.Cmb_S_Housou_Kbn.Location = New System.Drawing.Point(607, 22)
        Me.Cmb_S_Housou_Kbn.Name = "Cmb_S_Housou_Kbn"
        Me.Cmb_S_Housou_Kbn.Size = New System.Drawing.Size(121, 24)
        Me.Cmb_S_Housou_Kbn.TabIndex = 29
        Me.Cmb_S_Housou_Kbn.ValueMember = "区分詳細名"
        '
        'Btn_Import
        '
        Me.Btn_Import.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Import.Location = New System.Drawing.Point(808, 73)
        Me.Btn_Import.Name = "Btn_Import"
        Me.Btn_Import.Size = New System.Drawing.Size(104, 40)
        Me.Btn_Import.TabIndex = 28
        Me.Btn_Import.Text = "CSV取込"
        Me.Btn_Import.UseVisualStyleBackColor = True
        '
        'Txt_S_Line
        '
        Me.Txt_S_Line.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Line.Location = New System.Drawing.Point(82, 22)
        Me.Txt_S_Line.Name = "Txt_S_Line"
        Me.Txt_S_Line.Size = New System.Drawing.Size(121, 23)
        Me.Txt_S_Line.TabIndex = 26
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(710, 73)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Search.TabIndex = 25
        Me.Btn_Search.Text = "検　索"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(521, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "個装/内装"
        '
        'Txt_S_DIST
        '
        Me.Txt_S_DIST.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_DIST.Location = New System.Drawing.Point(299, 22)
        Me.Txt_S_DIST.Name = "Txt_S_DIST"
        Me.Txt_S_DIST.Size = New System.Drawing.Size(173, 23)
        Me.Txt_S_DIST.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(252, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "DIST"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "ライン"
        '
        'F_Housou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 604)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "F_Housou"
        Me.Text = "個装内装登録早見表"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMHousouKbnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.BS_Teiryou, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_Kubun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_Line, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_KosouNaisou, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_S_KosouNaisou, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.BS_S_Teiryou, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_S_Kubun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GV_Master As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_DIST As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents Txt_id As TextBox
    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMHousouKbnBindingSource As BindingSource
    Friend WithEvents TA_M_Housou_Kbn As DS_MTableAdapters.TA_M_Housou_Kbn
    Friend WithEvents Cmb_Line As ComboBox
    Friend WithEvents Cmb_Housou_Kbn As ComboBox
    Friend WithEvents BS_Line As BindingSource
    Friend WithEvents TA_M_Kubun As DS_MTableAdapters.TA_M_Kubun
    Friend WithEvents BS_S_KosouNaisou As BindingSource
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_S_DIST As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Btn_Search As Button
    Friend WithEvents Txt_S_Line As TextBox
    Friend WithEvents Btn_Import As Button
    Friend WithEvents Cmb_S_Teiryou As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Cmb_S_Kubun As ComboBox
    Friend WithEvents BS_S_Kubun As BindingSource
    Friend WithEvents Label7 As Label
    Friend WithEvents Cmb_S_Housou_Kbn As ComboBox
    Friend WithEvents BS_KosouNaisou As BindingSource
    Friend WithEvents 選択 As DataGridViewLinkColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents ライン As DataGridViewTextBoxColumn
    Friend WithEvents DIST As DataGridViewTextBoxColumn
    Friend WithEvents 個装内装区分 As DataGridViewTextBoxColumn
    Friend WithEvents 区分 As DataGridViewTextBoxColumn
    Friend WithEvents 定量_不定量 As DataGridViewTextBoxColumn
    Friend WithEvents 削除 As DataGridViewLinkColumn
    Friend WithEvents Cmb_Teiryou As ComboBox
    Friend WithEvents BS_Teiryou As BindingSource
    Friend WithEvents Label9 As Label
    Friend WithEvents Cmb_Kubun As ComboBox
    Friend WithEvents BS_Kubun As BindingSource
    Friend WithEvents Label10 As Label
    Friend WithEvents BS_S_Teiryou As BindingSource
End Class
