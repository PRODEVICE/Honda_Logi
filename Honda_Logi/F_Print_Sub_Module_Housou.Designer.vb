<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Print_Sub_Module_Housou
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
        Me.Txt_Kishu = New System.Windows.Forms.TextBox()
        Me.Txt_Year = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Btn_Print = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_DIST = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Module = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Modefu = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Month = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Nendo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Type = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(345, 9)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 63
        Me.Lbl_Messege.Text = "出力中"
        Me.Lbl_Messege.Visible = False
        '
        'Txt_Kishu
        '
        Me.Txt_Kishu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Kishu.Location = New System.Drawing.Point(350, 139)
        Me.Txt_Kishu.Name = "Txt_Kishu"
        Me.Txt_Kishu.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Kishu.TabIndex = 5
        '
        'Txt_Year
        '
        Me.Txt_Year.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Year.Location = New System.Drawing.Point(102, 79)
        Me.Txt_Year.Name = "Txt_Year"
        Me.Txt_Year.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Year.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.BlueViolet
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(41, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 18)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "出力条件"
        '
        'Btn_Print
        '
        Me.Btn_Print.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Print.Location = New System.Drawing.Point(350, 273)
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Print.TabIndex = 9
        Me.Btn_Print.Text = "印　刷"
        Me.Btn_Print.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(286, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "機種"
        '
        'Txt_DIST
        '
        Me.Txt_DIST.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_DIST.Location = New System.Drawing.Point(591, 82)
        Me.Txt_DIST.Name = "Txt_DIST"
        Me.Txt_DIST.Size = New System.Drawing.Size(121, 23)
        Me.Txt_DIST.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(525, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "DIST"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "年"
        '
        'Txt_Module
        '
        Me.Txt_Module.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Module.Location = New System.Drawing.Point(102, 201)
        Me.Txt_Module.Name = "Txt_Module"
        Me.Txt_Module.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Module.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "モジュール"
        '
        'Txt_Modefu
        '
        Me.Txt_Modefu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Modefu.Location = New System.Drawing.Point(350, 201)
        Me.Txt_Modefu.Name = "Txt_Modefu"
        Me.Txt_Modefu.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Modefu.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(282, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "モデフ"
        '
        'Txt_Month
        '
        Me.Txt_Month.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Month.Location = New System.Drawing.Point(350, 82)
        Me.Txt_Month.Name = "Txt_Month"
        Me.Txt_Month.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Month.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(302, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "月"
        '
        'Txt_Nendo
        '
        Me.Txt_Nendo.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Nendo.Location = New System.Drawing.Point(102, 139)
        Me.Txt_Nendo.Name = "Txt_Nendo"
        Me.Txt_Nendo.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Nendo.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(38, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "年度"
        '
        'Txt_Type
        '
        Me.Txt_Type.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Type.Location = New System.Drawing.Point(591, 139)
        Me.Txt_Type.Name = "Txt_Type"
        Me.Txt_Type.Size = New System.Drawing.Size(121, 23)
        Me.Txt_Type.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(523, 142)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 16)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "タイプ"
        '
        'F_Print_Sub_Module_Housou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 335)
        Me.Controls.Add(Me.Txt_Type)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txt_Nendo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txt_Month)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Txt_Modefu)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Module)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Kishu)
        Me.Controls.Add(Me.Txt_Year)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Btn_Print)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_DIST)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Name = "F_Print_Sub_Module_Housou"
        Me.Text = "機種摘要モジュール印刷"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Messege As Label
    Friend WithEvents Txt_Kishu As TextBox
    Friend WithEvents Txt_Year As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Btn_Print As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_DIST As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Module As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Modefu As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Month As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_Nendo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Type As TextBox
    Friend WithEvents Label9 As Label
End Class
