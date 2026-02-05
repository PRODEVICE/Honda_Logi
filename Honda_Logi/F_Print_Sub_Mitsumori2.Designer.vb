<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Print_Sub_Mitsumori2
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chk_Keisu_Flg = New System.Windows.Forms.CheckBox()
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Target = New System.Windows.Forms.ComboBox()
        Me.Btn_Output = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(154, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "係数の付与"
        Me.Label1.Visible = False
        '
        'Chk_Keisu_Flg
        '
        Me.Chk_Keisu_Flg.AutoSize = True
        Me.Chk_Keisu_Flg.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Chk_Keisu_Flg.Location = New System.Drawing.Point(272, 67)
        Me.Chk_Keisu_Flg.Name = "Chk_Keisu_Flg"
        Me.Chk_Keisu_Flg.Size = New System.Drawing.Size(89, 20)
        Me.Chk_Keisu_Flg.TabIndex = 1
        Me.Chk_Keisu_Flg.Text = "付与する"
        Me.Chk_Keisu_Flg.UseVisualStyleBackColor = True
        Me.Chk_Keisu_Flg.Visible = False
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(327, 9)
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
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Cmb_Target)
        Me.Panel5.Controls.Add(Me.Chk_Keisu_Flg)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Btn_Output)
        Me.Panel5.Location = New System.Drawing.Point(71, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(600, 225)
        Me.Panel5.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(154, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "対象データ"
        '
        'Cmb_Target
        '
        Me.Cmb_Target.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Target.FormattingEnabled = True
        Me.Cmb_Target.Location = New System.Drawing.Point(239, 24)
        Me.Cmb_Target.Name = "Cmb_Target"
        Me.Cmb_Target.Size = New System.Drawing.Size(203, 24)
        Me.Cmb_Target.TabIndex = 0
        '
        'Btn_Output
        '
        Me.Btn_Output.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output.Location = New System.Drawing.Point(176, 122)
        Me.Btn_Output.Name = "Btn_Output"
        Me.Btn_Output.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output.TabIndex = 2
        Me.Btn_Output.Text = "機種"
        Me.Btn_Output.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.BlueViolet
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(71, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 18)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "帳票出力"
        '
        'F_Print_Sub_Mitsumori2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 311)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "F_Print_Sub_Mitsumori2"
        Me.Text = "見積印刷"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Chk_Keisu_Flg As CheckBox
    Friend WithEvents Lbl_Messege As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Btn_Output As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Target As ComboBox
End Class
