<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Print_Sub_Mitsumori
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
        Me.Btn_Output3 = New System.Windows.Forms.Button()
        Me.Btn_Output4 = New System.Windows.Forms.Button()
        Me.Btn_Output2 = New System.Windows.Forms.Button()
        Me.Btn_Output1 = New System.Windows.Forms.Button()
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
        Me.Label1.Location = New System.Drawing.Point(150, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "係数の付与"
        '
        'Chk_Keisu_Flg
        '
        Me.Chk_Keisu_Flg.AutoSize = True
        Me.Chk_Keisu_Flg.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Chk_Keisu_Flg.Location = New System.Drawing.Point(268, 29)
        Me.Chk_Keisu_Flg.Name = "Chk_Keisu_Flg"
        Me.Chk_Keisu_Flg.Size = New System.Drawing.Size(89, 20)
        Me.Chk_Keisu_Flg.TabIndex = 0
        Me.Chk_Keisu_Flg.Text = "付与する"
        Me.Chk_Keisu_Flg.UseVisualStyleBackColor = True
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
        Me.Panel5.Controls.Add(Me.Btn_Output3)
        Me.Panel5.Controls.Add(Me.Btn_Output4)
        Me.Panel5.Controls.Add(Me.Chk_Keisu_Flg)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Btn_Output2)
        Me.Panel5.Controls.Add(Me.Btn_Output1)
        Me.Panel5.Location = New System.Drawing.Point(71, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(600, 225)
        Me.Panel5.TabIndex = 65
        '
        'Btn_Output3
        '
        Me.Btn_Output3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output3.Location = New System.Drawing.Point(314, 64)
        Me.Btn_Output3.Name = "Btn_Output3"
        Me.Btn_Output3.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output3.TabIndex = 3
        Me.Btn_Output3.Text = "部単内装"
        Me.Btn_Output3.UseVisualStyleBackColor = True
        '
        'Btn_Output4
        '
        Me.Btn_Output4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output4.Location = New System.Drawing.Point(314, 123)
        Me.Btn_Output4.Name = "Btn_Output4"
        Me.Btn_Output4.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output4.TabIndex = 4
        Me.Btn_Output4.Text = "部単外装"
        Me.Btn_Output4.UseVisualStyleBackColor = True
        '
        'Btn_Output2
        '
        Me.Btn_Output2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output2.Location = New System.Drawing.Point(16, 123)
        Me.Btn_Output2.Name = "Btn_Output2"
        Me.Btn_Output2.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output2.TabIndex = 2
        Me.Btn_Output2.Text = "汎用機種"
        Me.Btn_Output2.UseVisualStyleBackColor = True
        '
        'Btn_Output1
        '
        Me.Btn_Output1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output1.Location = New System.Drawing.Point(16, 64)
        Me.Btn_Output1.Name = "Btn_Output1"
        Me.Btn_Output1.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output1.TabIndex = 1
        Me.Btn_Output1.Text = "2R/ATV"
        Me.Btn_Output1.UseVisualStyleBackColor = True
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
        'F_Print_Sub_Mitsumori
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 311)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "F_Print_Sub_Mitsumori"
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
    Friend WithEvents Btn_Output3 As Button
    Friend WithEvents Btn_Output4 As Button
    Friend WithEvents Btn_Output2 As Button
    Friend WithEvents Btn_Output1 As Button
    Friend WithEvents Label6 As Label
End Class
