<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Shizai
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Txt_Suryou = New System.Windows.Forms.TextBox()
        Me.Lbl_Suryou = New System.Windows.Forms.Label()
        Me.Btn_Clear = New System.Windows.Forms.Button()
        Me.Txt_id = New System.Windows.Forms.TextBox()
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.Txt_Shizai_CD = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GV_Master = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cmb_Shurui = New System.Windows.Forms.ComboBox()
        Me.DTMKubunBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Txt_S_Shizai_CD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TA_M_Kubun = New Honda_Logi.DS_MTableAdapters.TA_M_Kubun()
        Me.Btn_Import = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DTMKubunBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Suryou
        '
        Me.Txt_Suryou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Suryou.Location = New System.Drawing.Point(394, 20)
        Me.Txt_Suryou.Name = "Txt_Suryou"
        Me.Txt_Suryou.Size = New System.Drawing.Size(70, 23)
        Me.Txt_Suryou.TabIndex = 12
        '
        'Lbl_Suryou
        '
        Me.Lbl_Suryou.AutoSize = True
        Me.Lbl_Suryou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_Suryou.Location = New System.Drawing.Point(348, 23)
        Me.Lbl_Suryou.Name = "Lbl_Suryou"
        Me.Lbl_Suryou.Size = New System.Drawing.Size(40, 16)
        Me.Lbl_Suryou.TabIndex = 11
        Me.Lbl_Suryou.Text = "数量"
        '
        'Btn_Clear
        '
        Me.Btn_Clear.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Clear.Location = New System.Drawing.Point(665, 23)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Clear.TabIndex = 10
        Me.Btn_Clear.Text = "クリア"
        Me.Btn_Clear.UseVisualStyleBackColor = True
        '
        'Txt_id
        '
        Me.Txt_id.Location = New System.Drawing.Point(394, 55)
        Me.Txt_id.Name = "Txt_id"
        Me.Txt_id.Size = New System.Drawing.Size(50, 19)
        Me.Txt_id.TabIndex = 9
        Me.Txt_id.Visible = False
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(563, 23)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Touroku.TabIndex = 0
        Me.Btn_Touroku.Text = "登　録"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'Txt_Shizai_CD
        '
        Me.Txt_Shizai_CD.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Shizai_CD.Location = New System.Drawing.Point(109, 20)
        Me.Txt_Shizai_CD.Name = "Txt_Shizai_CD"
        Me.Txt_Shizai_CD.Size = New System.Drawing.Size(173, 23)
        Me.Txt_Shizai_CD.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GV_Master)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 403)
        Me.Panel1.TabIndex = 9
        '
        'GV_Master
        '
        Me.GV_Master.AllowUserToAddRows = False
        Me.GV_Master.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GV_Master.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GV_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Master.Location = New System.Drawing.Point(0, 0)
        Me.GV_Master.Name = "GV_Master"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GV_Master.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GV_Master.RowTemplate.Height = 31
        Me.GV_Master.Size = New System.Drawing.Size(803, 403)
        Me.GV_Master.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "資材コード"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Txt_Suryou)
        Me.Panel2.Controls.Add(Me.Lbl_Suryou)
        Me.Panel2.Controls.Add(Me.Btn_Clear)
        Me.Panel2.Controls.Add(Me.Txt_id)
        Me.Panel2.Controls.Add(Me.Btn_Touroku)
        Me.Panel2.Controls.Add(Me.Txt_Shizai_CD)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 497)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(803, 88)
        Me.Panel2.TabIndex = 10
        '
        'Cmb_Shurui
        '
        Me.Cmb_Shurui.DataSource = Me.DTMKubunBindingSource
        Me.Cmb_Shurui.DisplayMember = "区分詳細名"
        Me.Cmb_Shurui.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Shurui.FormattingEnabled = True
        Me.Cmb_Shurui.Location = New System.Drawing.Point(109, 33)
        Me.Cmb_Shurui.Name = "Cmb_Shurui"
        Me.Cmb_Shurui.Size = New System.Drawing.Size(175, 24)
        Me.Cmb_Shurui.TabIndex = 11
        Me.Cmb_Shurui.ValueMember = "区分CD"
        '
        'DTMKubunBindingSource
        '
        Me.DTMKubunBindingSource.DataMember = "DT_M_Kubun"
        Me.DTMKubunBindingSource.DataSource = Me.DS_M
        Me.DTMKubunBindingSource.Filter = "区分id = 2 and 区分CD <= 5"
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Btn_Import)
        Me.Panel3.Controls.Add(Me.Btn_Search)
        Me.Panel3.Controls.Add(Me.Txt_S_Shizai_CD)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Cmb_Shurui)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(803, 94)
        Me.Panel3.TabIndex = 12
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(598, 23)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Search.TabIndex = 13
        Me.Btn_Search.Text = "検　索"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Txt_S_Shizai_CD
        '
        Me.Txt_S_Shizai_CD.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Shizai_CD.Location = New System.Drawing.Point(404, 33)
        Me.Txt_S_Shizai_CD.Name = "Txt_S_Shizai_CD"
        Me.Txt_S_Shizai_CD.Size = New System.Drawing.Size(173, 23)
        Me.Txt_S_Shizai_CD.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "資材コード"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "マスタ種類"
        '
        'TA_M_Kubun
        '
        Me.TA_M_Kubun.ClearBeforeFill = True
        '
        'Btn_Import
        '
        Me.Btn_Import.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Import.Location = New System.Drawing.Point(687, 23)
        Me.Btn_Import.Name = "Btn_Import"
        Me.Btn_Import.Size = New System.Drawing.Size(104, 40)
        Me.Btn_Import.TabIndex = 29
        Me.Btn_Import.Text = "CSV取込"
        Me.Btn_Import.UseVisualStyleBackColor = True
        '
        'F_Shizai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 585)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "F_Shizai"
        Me.Text = "資材マスタ"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DTMKubunBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Suryou As TextBox
    Friend WithEvents Lbl_Suryou As Label
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents Txt_id As TextBox
    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Txt_Shizai_CD As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GV_Master As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Cmb_Shurui As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMKubunBindingSource As BindingSource
    Friend WithEvents TA_M_Kubun As DS_MTableAdapters.TA_M_Kubun
    Friend WithEvents Btn_Search As Button
    Friend WithEvents Txt_S_Shizai_CD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Import As Button
End Class
