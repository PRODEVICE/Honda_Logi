<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Second
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt_id = New System.Windows.Forms.TextBox()
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.Txt_Byousu = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GV_Master = New System.Windows.Forms.DataGridView()
        Me.選択 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.作業区分 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.作業単位 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.秒数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTMSecondBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TA_M_Second = New Honda_Logi.DS_MTableAdapters.TA_M_Second()
        Me.Panel2.SuspendLayout()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMSecondBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Txt_id)
        Me.Panel2.Controls.Add(Me.Btn_Touroku)
        Me.Panel2.Controls.Add(Me.Txt_Byousu)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 670)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(686, 72)
        Me.Panel2.TabIndex = 20
        '
        'Txt_id
        '
        Me.Txt_id.Location = New System.Drawing.Point(397, 22)
        Me.Txt_id.Name = "Txt_id"
        Me.Txt_id.Size = New System.Drawing.Size(50, 19)
        Me.Txt_id.TabIndex = 9
        Me.Txt_id.Visible = False
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(289, 12)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Touroku.TabIndex = 1
        Me.Btn_Touroku.Text = "更　新"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'Txt_Byousu
        '
        Me.Txt_Byousu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Byousu.Location = New System.Drawing.Point(115, 22)
        Me.Txt_Byousu.Name = "Txt_Byousu"
        Me.Txt_Byousu.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Byousu.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "秒数"
        '
        'GV_Master
        '
        Me.GV_Master.AllowUserToAddRows = False
        Me.GV_Master.AllowUserToDeleteRows = False
        Me.GV_Master.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GV_Master.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GV_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV_Master.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選択, Me.id, Me.作業区分, Me.作業単位, Me.秒数})
        Me.GV_Master.DataSource = Me.DTMSecondBindingSource
        Me.GV_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Master.Location = New System.Drawing.Point(0, 0)
        Me.GV_Master.Name = "GV_Master"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GV_Master.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GV_Master.RowTemplate.Height = 31
        Me.GV_Master.Size = New System.Drawing.Size(686, 670)
        Me.GV_Master.TabIndex = 1
        Me.GV_Master.TabStop = False
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
        '作業区分
        '
        Me.作業区分.DataPropertyName = "作業区分"
        Me.作業区分.HeaderText = "作業区分"
        Me.作業区分.Name = "作業区分"
        Me.作業区分.Visible = False
        '
        '作業単位
        '
        Me.作業単位.DataPropertyName = "作業単位"
        Me.作業単位.HeaderText = "工程"
        Me.作業単位.Name = "作業単位"
        '
        '秒数
        '
        Me.秒数.DataPropertyName = "秒数"
        Me.秒数.HeaderText = "秒数"
        Me.秒数.Name = "秒数"
        '
        'DTMSecondBindingSource
        '
        Me.DTMSecondBindingSource.DataMember = "DT_M_Second"
        Me.DTMSecondBindingSource.DataSource = Me.DS_M
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GV_Master)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(686, 670)
        Me.Panel1.TabIndex = 19
        '
        'TA_M_Second
        '
        Me.TA_M_Second.ClearBeforeFill = True
        '
        'F_Second
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 742)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "F_Second"
        Me.Text = "秒数"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMSecondBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Txt_id As TextBox
    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Txt_Byousu As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GV_Master As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMSecondBindingSource As BindingSource
    Friend WithEvents TA_M_Second As DS_MTableAdapters.TA_M_Second
    Friend WithEvents 選択 As DataGridViewLinkColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents 作業区分 As DataGridViewTextBoxColumn
    Friend WithEvents 作業単位 As DataGridViewTextBoxColumn
    Friend WithEvents 秒数 As DataGridViewTextBoxColumn
End Class
