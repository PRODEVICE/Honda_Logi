<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Print_Sub_Module
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
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Btn_Output3 = New System.Windows.Forms.Button()
        Me.Btn_Output2 = New System.Windows.Forms.Button()
        Me.Btn_Output1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(196, 9)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 63
        Me.Lbl_Messege.Text = "出力中"
        Me.Lbl_Messege.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Thistle
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.Btn_Output3)
        Me.Panel5.Controls.Add(Me.Btn_Output2)
        Me.Panel5.Controls.Add(Me.Btn_Output1)
        Me.Panel5.Location = New System.Drawing.Point(62, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(394, 240)
        Me.Panel5.TabIndex = 65
        '
        'Btn_Output3
        '
        Me.Btn_Output3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output3.Location = New System.Drawing.Point(58, 148)
        Me.Btn_Output3.Name = "Btn_Output3"
        Me.Btn_Output3.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output3.TabIndex = 5
        Me.Btn_Output3.Text = "不定量のみ"
        Me.Btn_Output3.UseVisualStyleBackColor = True
        '
        'Btn_Output2
        '
        Me.Btn_Output2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output2.Location = New System.Drawing.Point(58, 89)
        Me.Btn_Output2.Name = "Btn_Output2"
        Me.Btn_Output2.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output2.TabIndex = 4
        Me.Btn_Output2.Text = "定量のみ"
        Me.Btn_Output2.UseVisualStyleBackColor = True
        '
        'Btn_Output1
        '
        Me.Btn_Output1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output1.Location = New System.Drawing.Point(58, 30)
        Me.Btn_Output1.Name = "Btn_Output1"
        Me.Btn_Output1.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output1.TabIndex = 3
        Me.Btn_Output1.Text = "定量/不定量"
        Me.Btn_Output1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.BlueViolet
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(62, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 18)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "帳票出力"
        '
        'F_Print_Sub_Module
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 313)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "F_Print_Sub_Module"
        Me.Text = "機種摘要モジュール印刷"
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Messege As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Btn_Output3 As Button
    Friend WithEvents Btn_Output2 As Button
    Friend WithEvents Btn_Output1 As Button
    Friend WithEvents Label6 As Label
End Class
