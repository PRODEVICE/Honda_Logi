<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Make_1Lot
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
        Me.Btn_Change = New System.Windows.Forms.Button()
        Me.Btn_Output = New System.Windows.Forms.Button()
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        Me.Pnl_Maker = New System.Windows.Forms.Panel()
        Me.Rdb_6519 = New System.Windows.Forms.RadioButton()
        Me.Rdb_all = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Maker.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Change
        '
        Me.Btn_Change.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Change.Location = New System.Drawing.Point(138, 160)
        Me.Btn_Change.Name = "Btn_Change"
        Me.Btn_Change.Size = New System.Drawing.Size(124, 65)
        Me.Btn_Change.TabIndex = 32
        Me.Btn_Change.Text = "変　換"
        Me.Btn_Change.UseVisualStyleBackColor = True
        '
        'Btn_Output
        '
        Me.Btn_Output.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output.Location = New System.Drawing.Point(358, 160)
        Me.Btn_Output.Name = "Btn_Output"
        Me.Btn_Output.Size = New System.Drawing.Size(124, 65)
        Me.Btn_Output.TabIndex = 35
        Me.Btn_Output.Text = "出　力"
        Me.Btn_Output.UseVisualStyleBackColor = True
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(258, 24)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 64
        Me.Lbl_Messege.Text = "出力中"
        Me.Lbl_Messege.Visible = False
        '
        'Pnl_Maker
        '
        Me.Pnl_Maker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Maker.Controls.Add(Me.Rdb_6519)
        Me.Pnl_Maker.Controls.Add(Me.Rdb_all)
        Me.Pnl_Maker.Controls.Add(Me.Label1)
        Me.Pnl_Maker.Location = New System.Drawing.Point(91, 67)
        Me.Pnl_Maker.Name = "Pnl_Maker"
        Me.Pnl_Maker.Size = New System.Drawing.Size(444, 53)
        Me.Pnl_Maker.TabIndex = 65
        '
        'Rdb_6519
        '
        Me.Rdb_6519.AutoSize = True
        Me.Rdb_6519.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Rdb_6519.Location = New System.Drawing.Point(289, 10)
        Me.Rdb_6519.Name = "Rdb_6519"
        Me.Rdb_6519.Size = New System.Drawing.Size(132, 31)
        Me.Rdb_6519.TabIndex = 2
        Me.Rdb_6519.TabStop = True
        Me.Rdb_6519.Text = "6519のみ"
        Me.Rdb_6519.UseVisualStyleBackColor = True
        '
        'Rdb_all
        '
        Me.Rdb_all.AutoSize = True
        Me.Rdb_all.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Rdb_all.Location = New System.Drawing.Point(185, 10)
        Me.Rdb_all.Name = "Rdb_all"
        Me.Rdb_all.Size = New System.Drawing.Size(78, 31)
        Me.Rdb_all.TabIndex = 1
        Me.Rdb_all.TabStop = True
        Me.Rdb_all.Text = "全て"
        Me.Rdb_all.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "メーカーコード"
        '
        'F_Make_1Lot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 296)
        Me.Controls.Add(Me.Pnl_Maker)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Btn_Output)
        Me.Controls.Add(Me.Btn_Change)
        Me.Name = "F_Make_1Lot"
        Me.Text = "データ変換"
        Me.Pnl_Maker.ResumeLayout(False)
        Me.Pnl_Maker.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Change As Button
    Friend WithEvents Btn_Output As Button
    Friend WithEvents Lbl_Messege As Label
    Friend WithEvents Pnl_Maker As Panel
    Friend WithEvents Rdb_6519 As RadioButton
    Friend WithEvents Rdb_all As RadioButton
    Friend WithEvents Label1 As Label
End Class
