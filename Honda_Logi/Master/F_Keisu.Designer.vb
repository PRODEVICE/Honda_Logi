<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Keisu
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
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Txt_S_Kishu = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt_S_Type = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GV_Master = New System.Windows.Forms.DataGridView()
        Me.選択 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.機種 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.タイプ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.係数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.削除 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DTMKeisuBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt_Keisu = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Type = New System.Windows.Forms.TextBox()
        Me.Txt_Kishu = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Clear = New System.Windows.Forms.Button()
        Me.Txt_id = New System.Windows.Forms.TextBox()
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.TA_M_Keisu = New Honda_Logi.DS_MTableAdapters.TA_M_Keisu()
        Me.Btn_Import = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMKeisuBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(574, 14)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Search.TabIndex = 13
        Me.Btn_Search.Text = "検　索"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Txt_S_Kishu
        '
        Me.Txt_S_Kishu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Kishu.Location = New System.Drawing.Point(95, 24)
        Me.Txt_S_Kishu.Name = "Txt_S_Kishu"
        Me.Txt_S_Kishu.Size = New System.Drawing.Size(109, 23)
        Me.Txt_S_Kishu.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(283, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "タイプ"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Btn_Import)
        Me.Panel3.Controls.Add(Me.Txt_S_Type)
        Me.Panel3.Controls.Add(Me.Btn_Search)
        Me.Panel3.Controls.Add(Me.Txt_S_Kishu)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(800, 77)
        Me.Panel3.TabIndex = 15
        '
        'Txt_S_Type
        '
        Me.Txt_S_Type.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Type.Location = New System.Drawing.Point(349, 24)
        Me.Txt_S_Type.Name = "Txt_S_Type"
        Me.Txt_S_Type.Size = New System.Drawing.Size(109, 23)
        Me.Txt_S_Type.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "機種"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GV_Master)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 77)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 295)
        Me.Panel1.TabIndex = 13
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
        Me.GV_Master.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選択, Me.id, Me.機種, Me.タイプ, Me.係数, Me.削除})
        Me.GV_Master.DataSource = Me.DTMKeisuBindingSource
        Me.GV_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Master.Location = New System.Drawing.Point(0, 0)
        Me.GV_Master.Name = "GV_Master"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GV_Master.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GV_Master.RowTemplate.Height = 31
        Me.GV_Master.Size = New System.Drawing.Size(800, 295)
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
        '機種
        '
        Me.機種.DataPropertyName = "機種"
        Me.機種.HeaderText = "機種"
        Me.機種.Name = "機種"
        '
        'タイプ
        '
        Me.タイプ.DataPropertyName = "タイプ"
        Me.タイプ.HeaderText = "タイプ"
        Me.タイプ.Name = "タイプ"
        '
        '係数
        '
        Me.係数.DataPropertyName = "係数"
        Me.係数.HeaderText = "係数"
        Me.係数.Name = "係数"
        '
        '削除
        '
        Me.削除.HeaderText = "削除"
        Me.削除.Name = "削除"
        Me.削除.Text = "削除"
        Me.削除.UseColumnTextForLinkValue = True
        '
        'DTMKeisuBindingSource
        '
        Me.DTMKeisuBindingSource.DataMember = "DT_M_Keisu"
        Me.DTMKeisuBindingSource.DataSource = Me.DS_M
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Txt_Keisu)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Txt_Type)
        Me.Panel2.Controls.Add(Me.Txt_Kishu)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Btn_Clear)
        Me.Panel2.Controls.Add(Me.Txt_id)
        Me.Panel2.Controls.Add(Me.Btn_Touroku)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 372)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 78)
        Me.Panel2.TabIndex = 14
        '
        'Txt_Keisu
        '
        Me.Txt_Keisu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Keisu.Location = New System.Drawing.Point(490, 27)
        Me.Txt_Keisu.Name = "Txt_Keisu"
        Me.Txt_Keisu.Size = New System.Drawing.Size(109, 23)
        Me.Txt_Keisu.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(424, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "係数"
        '
        'Txt_Type
        '
        Me.Txt_Type.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Type.Location = New System.Drawing.Point(290, 27)
        Me.Txt_Type.Name = "Txt_Type"
        Me.Txt_Type.Size = New System.Drawing.Size(109, 23)
        Me.Txt_Type.TabIndex = 19
        '
        'Txt_Kishu
        '
        Me.Txt_Kishu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Kishu.Location = New System.Drawing.Point(95, 27)
        Me.Txt_Kishu.Name = "Txt_Kishu"
        Me.Txt_Kishu.Size = New System.Drawing.Size(109, 23)
        Me.Txt_Kishu.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(224, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "タイプ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "機種"
        '
        'Btn_Clear
        '
        Me.Btn_Clear.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Clear.Location = New System.Drawing.Point(718, 30)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Clear.TabIndex = 10
        Me.Btn_Clear.Text = "クリア"
        Me.Btn_Clear.UseVisualStyleBackColor = True
        '
        'Txt_id
        '
        Me.Txt_id.Location = New System.Drawing.Point(349, 56)
        Me.Txt_id.Name = "Txt_id"
        Me.Txt_id.Size = New System.Drawing.Size(50, 19)
        Me.Txt_id.TabIndex = 9
        Me.Txt_id.Visible = False
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(616, 30)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Touroku.TabIndex = 0
        Me.Btn_Touroku.Text = "登　録"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'TA_M_Keisu
        '
        Me.TA_M_Keisu.ClearBeforeFill = True
        '
        'Btn_Import
        '
        Me.Btn_Import.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Import.Location = New System.Drawing.Point(684, 14)
        Me.Btn_Import.Name = "Btn_Import"
        Me.Btn_Import.Size = New System.Drawing.Size(104, 40)
        Me.Btn_Import.TabIndex = 29
        Me.Btn_Import.Text = "CSV取込"
        Me.Btn_Import.UseVisualStyleBackColor = True
        '
        'F_Keisu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "F_Keisu"
        Me.Text = "機種係数マスタ"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMKeisuBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Search As Button
    Friend WithEvents Txt_S_Kishu As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GV_Master As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents Txt_id As TextBox
    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Txt_S_Type As TextBox
    Friend WithEvents Txt_Type As TextBox
    Friend WithEvents Txt_Kishu As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMKeisuBindingSource As BindingSource
    Friend WithEvents TA_M_Keisu As DS_MTableAdapters.TA_M_Keisu
    Friend WithEvents Txt_Keisu As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents 選択 As DataGridViewLinkColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents 機種 As DataGridViewTextBoxColumn
    Friend WithEvents タイプ As DataGridViewTextBoxColumn
    Friend WithEvents 係数 As DataGridViewTextBoxColumn
    Friend WithEvents 削除 As DataGridViewLinkColumn
    Friend WithEvents Btn_Import As Button
End Class
