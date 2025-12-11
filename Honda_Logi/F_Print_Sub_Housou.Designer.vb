<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Print_Sub_Housou
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Btn_Print = New System.Windows.Forms.Button()
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        Me.GV_Search = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.コピー = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DIST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.年度 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.モデル = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.タイプ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.包装ロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GV_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Print
        '
        Me.Btn_Print.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Print.Location = New System.Drawing.Point(323, 17)
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Print.TabIndex = 62
        Me.Btn_Print.Text = "印　刷"
        Me.Btn_Print.UseVisualStyleBackColor = True
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(318, 23)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 63
        Me.Lbl_Messege.Text = "出力中"
        Me.Lbl_Messege.Visible = False
        '
        'GV_Search
        '
        Me.GV_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.コピー, Me.DIST, Me.年度, Me.モデル, Me.タイプ, Me.OP, Me.包装ロットNo})
        Me.GV_Search.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Search.Location = New System.Drawing.Point(0, 0)
        Me.GV_Search.Name = "GV_Search"
        Me.GV_Search.RowTemplate.Height = 21
        Me.GV_Search.Size = New System.Drawing.Size(714, 267)
        Me.GV_Search.TabIndex = 88
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Lbl_Messege)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 69)
        Me.Panel1.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 18)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "出力条件"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GV_Search)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(714, 267)
        Me.Panel2.TabIndex = 90
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Btn_Print)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 336)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(714, 69)
        Me.Panel3.TabIndex = 90
        '
        'コピー
        '
        Me.コピー.HeaderText = "コピー"
        Me.コピー.Name = "コピー"
        Me.コピー.Text = "コピー"
        Me.コピー.UseColumnTextForLinkValue = True
        '
        'DIST
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DIST.DefaultCellStyle = DataGridViewCellStyle1
        Me.DIST.HeaderText = "DIST"
        Me.DIST.Name = "DIST"
        '
        '年度
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.年度.DefaultCellStyle = DataGridViewCellStyle2
        Me.年度.HeaderText = "年度"
        Me.年度.Name = "年度"
        '
        'モデル
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.モデル.DefaultCellStyle = DataGridViewCellStyle3
        Me.モデル.HeaderText = "モデル"
        Me.モデル.Name = "モデル"
        '
        'タイプ
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.タイプ.DefaultCellStyle = DataGridViewCellStyle4
        Me.タイプ.HeaderText = "タイプ"
        Me.タイプ.Name = "タイプ"
        '
        'OP
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.OP.DefaultCellStyle = DataGridViewCellStyle5
        Me.OP.HeaderText = "OP"
        Me.OP.Name = "OP"
        '
        '包装ロットNo
        '
        Me.包装ロットNo.HeaderText = "包装ロットNo"
        Me.包装ロットNo.Name = "包装ロットNo"
        '
        'F_Print_Sub_Housou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 405)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "F_Print_Sub_Housou"
        Me.Text = "包装印刷"
        CType(Me.GV_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Print As Button
    Friend WithEvents Lbl_Messege As Label
    Friend WithEvents GV_Search As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents コピー As DataGridViewLinkColumn
    Friend WithEvents DIST As DataGridViewTextBoxColumn
    Friend WithEvents 年度 As DataGridViewTextBoxColumn
    Friend WithEvents モデル As DataGridViewTextBoxColumn
    Friend WithEvents タイプ As DataGridViewTextBoxColumn
    Friend WithEvents OP As DataGridViewTextBoxColumn
    Friend WithEvents 包装ロットNo As DataGridViewTextBoxColumn
End Class
