<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Tanka
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
        Me.Txt_Maker = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Tanka = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Shizai_NM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Clear = New System.Windows.Forms.Button()
        Me.Txt_id = New System.Windows.Forms.TextBox()
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.Txt_Shizai_CD = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GV_Master = New System.Windows.Forms.DataGridView()
        Me.選択 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.単価 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.メーカーコード = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.削除 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DTMTankaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TA_M_Tanka = New Honda_Logi.DS_MTableAdapters.TA_M_Tanka()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMTankaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Maker
        '
        Me.Txt_Maker.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Maker.Location = New System.Drawing.Point(401, 73)
        Me.Txt_Maker.Name = "Txt_Maker"
        Me.Txt_Maker.Size = New System.Drawing.Size(108, 23)
        Me.Txt_Maker.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(331, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "メーカー"
        '
        'Txt_Tanka
        '
        Me.Txt_Tanka.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Tanka.Location = New System.Drawing.Point(115, 73)
        Me.Txt_Tanka.Name = "Txt_Tanka"
        Me.Txt_Tanka.Size = New System.Drawing.Size(123, 23)
        Me.Txt_Tanka.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "単価"
        '
        'Txt_Shizai_NM
        '
        Me.Txt_Shizai_NM.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Shizai_NM.Location = New System.Drawing.Point(401, 22)
        Me.Txt_Shizai_NM.Name = "Txt_Shizai_NM"
        Me.Txt_Shizai_NM.Size = New System.Drawing.Size(360, 23)
        Me.Txt_Shizai_NM.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(331, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "資材名"
        '
        'Btn_Clear
        '
        Me.Btn_Clear.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Clear.Location = New System.Drawing.Point(788, 63)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Clear.TabIndex = 10
        Me.Btn_Clear.Text = "クリア"
        Me.Btn_Clear.UseVisualStyleBackColor = True
        '
        'Txt_id
        '
        Me.Txt_id.Location = New System.Drawing.Point(916, 22)
        Me.Txt_id.Name = "Txt_id"
        Me.Txt_id.Size = New System.Drawing.Size(50, 19)
        Me.Txt_id.TabIndex = 9
        Me.Txt_id.Visible = False
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(686, 63)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Touroku.TabIndex = 0
        Me.Btn_Touroku.Text = "登　録"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'Txt_Shizai_CD
        '
        Me.Txt_Shizai_CD.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Shizai_CD.Location = New System.Drawing.Point(115, 22)
        Me.Txt_Shizai_CD.Name = "Txt_Shizai_CD"
        Me.Txt_Shizai_CD.Size = New System.Drawing.Size(173, 23)
        Me.Txt_Shizai_CD.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "資材コード"
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
        Me.GV_Master.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選択, Me.id, Me.資材コード, Me.資材名, Me.単価, Me.メーカーコード, Me.削除})
        Me.GV_Master.DataSource = Me.DTMTankaBindingSource
        Me.GV_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Master.Location = New System.Drawing.Point(0, 0)
        Me.GV_Master.Name = "GV_Master"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GV_Master.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GV_Master.RowTemplate.Height = 31
        Me.GV_Master.Size = New System.Drawing.Size(1231, 498)
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
        '資材コード
        '
        Me.資材コード.DataPropertyName = "資材コード"
        Me.資材コード.HeaderText = "資材コード"
        Me.資材コード.Name = "資材コード"
        '
        '資材名
        '
        Me.資材名.DataPropertyName = "資材名"
        Me.資材名.HeaderText = "資材名"
        Me.資材名.Name = "資材名"
        '
        '単価
        '
        Me.単価.DataPropertyName = "単価"
        Me.単価.HeaderText = "単価"
        Me.単価.Name = "単価"
        '
        'メーカーコード
        '
        Me.メーカーコード.DataPropertyName = "メーカーコード"
        Me.メーカーコード.HeaderText = "メーカーコード"
        Me.メーカーコード.Name = "メーカーコード"
        '
        '削除
        '
        Me.削除.HeaderText = "削除"
        Me.削除.Name = "削除"
        Me.削除.Text = "削除"
        Me.削除.UseColumnTextForLinkValue = True
        '
        'DTMTankaBindingSource
        '
        Me.DTMTankaBindingSource.DataMember = "DT_M_Tanka"
        Me.DTMTankaBindingSource.DataSource = Me.DS_M
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
        Me.Panel1.Size = New System.Drawing.Size(1231, 498)
        Me.Panel1.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Txt_Maker)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Txt_Tanka)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Txt_Shizai_NM)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Btn_Clear)
        Me.Panel2.Controls.Add(Me.Txt_id)
        Me.Panel2.Controls.Add(Me.Btn_Touroku)
        Me.Panel2.Controls.Add(Me.Txt_Shizai_CD)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 498)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1231, 115)
        Me.Panel2.TabIndex = 16
        '
        'TA_M_Tanka
        '
        Me.TA_M_Tanka.ClearBeforeFill = True
        '
        'F_Tanka
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 613)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "F_Tanka"
        Me.Text = "単価マスタ"
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMTankaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Maker As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Tanka As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Shizai_NM As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents Txt_id As TextBox
    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Txt_Shizai_CD As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GV_Master As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMTankaBindingSource As BindingSource
    Friend WithEvents TA_M_Tanka As DS_MTableAdapters.TA_M_Tanka
    Friend WithEvents 選択 As DataGridViewLinkColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード As DataGridViewTextBoxColumn
    Friend WithEvents 資材名 As DataGridViewTextBoxColumn
    Friend WithEvents 単価 As DataGridViewTextBoxColumn
    Friend WithEvents メーカーコード As DataGridViewTextBoxColumn
    Friend WithEvents 削除 As DataGridViewLinkColumn
End Class
