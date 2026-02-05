<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Print_Main
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Btn_Output11 = New System.Windows.Forms.Button()
        Me.Btn_Output8 = New System.Windows.Forms.Button()
        Me.Btn_Output12 = New System.Windows.Forms.Button()
        Me.Btn_Output5 = New System.Windows.Forms.Button()
        Me.Btn_Output9 = New System.Windows.Forms.Button()
        Me.Btn_Output6 = New System.Windows.Forms.Button()
        Me.Btn_Output10 = New System.Windows.Forms.Button()
        Me.Btn_Output7 = New System.Windows.Forms.Button()
        Me.Btn_Output2 = New System.Windows.Forms.Button()
        Me.Btn_Output1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_Target = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Thistle
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.Btn_Output11)
        Me.Panel5.Controls.Add(Me.Btn_Output8)
        Me.Panel5.Controls.Add(Me.Btn_Output12)
        Me.Panel5.Controls.Add(Me.Btn_Output5)
        Me.Panel5.Controls.Add(Me.Btn_Output9)
        Me.Panel5.Controls.Add(Me.Btn_Output6)
        Me.Panel5.Controls.Add(Me.Btn_Output10)
        Me.Panel5.Controls.Add(Me.Btn_Output7)
        Me.Panel5.Controls.Add(Me.Btn_Output2)
        Me.Panel5.Controls.Add(Me.Btn_Output1)
        Me.Panel5.Location = New System.Drawing.Point(68, 111)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(600, 320)
        Me.Panel5.TabIndex = 55
        '
        'Btn_Output11
        '
        Me.Btn_Output11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output11.Location = New System.Drawing.Point(304, 189)
        Me.Btn_Output11.Name = "Btn_Output11"
        Me.Btn_Output11.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output11.TabIndex = 10
        Me.Btn_Output11.Text = "請求明細"
        Me.Btn_Output11.UseVisualStyleBackColor = True
        '
        'Btn_Output8
        '
        Me.Btn_Output8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output8.Location = New System.Drawing.Point(304, 12)
        Me.Btn_Output8.Name = "Btn_Output8"
        Me.Btn_Output8.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output8.TabIndex = 7
        Me.Btn_Output8.Text = "包装仕様一覧"
        Me.Btn_Output8.UseVisualStyleBackColor = True
        '
        'Btn_Output12
        '
        Me.Btn_Output12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output12.Location = New System.Drawing.Point(304, 248)
        Me.Btn_Output12.Name = "Btn_Output12"
        Me.Btn_Output12.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output12.TabIndex = 11
        Me.Btn_Output12.Text = "モジュール別包装費明細"
        Me.Btn_Output12.UseVisualStyleBackColor = True
        '
        'Btn_Output5
        '
        Me.Btn_Output5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output5.Location = New System.Drawing.Point(18, 130)
        Me.Btn_Output5.Name = "Btn_Output5"
        Me.Btn_Output5.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output5.TabIndex = 4
        Me.Btn_Output5.Text = "部品単位包装費一覧(内装)"
        Me.Btn_Output5.UseVisualStyleBackColor = True
        '
        'Btn_Output9
        '
        Me.Btn_Output9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output9.Location = New System.Drawing.Point(304, 71)
        Me.Btn_Output9.Name = "Btn_Output9"
        Me.Btn_Output9.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output9.TabIndex = 8
        Me.Btn_Output9.Text = "包装資材明細(定量、不定量共通)"
        Me.Btn_Output9.UseVisualStyleBackColor = True
        '
        'Btn_Output6
        '
        Me.Btn_Output6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output6.Location = New System.Drawing.Point(18, 189)
        Me.Btn_Output6.Name = "Btn_Output6"
        Me.Btn_Output6.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output6.TabIndex = 5
        Me.Btn_Output6.Text = "部品単位包装費一覧(外装)"
        Me.Btn_Output6.UseVisualStyleBackColor = True
        '
        'Btn_Output10
        '
        Me.Btn_Output10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output10.Location = New System.Drawing.Point(304, 130)
        Me.Btn_Output10.Name = "Btn_Output10"
        Me.Btn_Output10.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output10.TabIndex = 9
        Me.Btn_Output10.Text = "KIT60(最終加工)"
        Me.Btn_Output10.UseVisualStyleBackColor = True
        '
        'Btn_Output7
        '
        Me.Btn_Output7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output7.Location = New System.Drawing.Point(18, 248)
        Me.Btn_Output7.Name = "Btn_Output7"
        Me.Btn_Output7.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output7.TabIndex = 6
        Me.Btn_Output7.Text = "包装費変動表"
        Me.Btn_Output7.UseVisualStyleBackColor = True
        '
        'Btn_Output2
        '
        Me.Btn_Output2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output2.Location = New System.Drawing.Point(18, 71)
        Me.Btn_Output2.Name = "Btn_Output2"
        Me.Btn_Output2.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output2.TabIndex = 3
        Me.Btn_Output2.Text = "見積書"
        Me.Btn_Output2.UseVisualStyleBackColor = True
        '
        'Btn_Output1
        '
        Me.Btn_Output1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output1.Location = New System.Drawing.Point(18, 12)
        Me.Btn_Output1.Name = "Btn_Output1"
        Me.Btn_Output1.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Output1.TabIndex = 2
        Me.Btn_Output1.Text = "機種摘要モジュール一覧"
        Me.Btn_Output1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.BlueViolet
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(68, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 18)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "帳票出力"
        '
        'Cmb_Target
        '
        Me.Cmb_Target.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Target.FormattingEnabled = True
        Me.Cmb_Target.Location = New System.Drawing.Point(274, 66)
        Me.Cmb_Target.Name = "Cmb_Target"
        Me.Cmb_Target.Size = New System.Drawing.Size(203, 24)
        Me.Cmb_Target.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(189, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "対象データ"
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(313, 19)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 64
        Me.Lbl_Messege.Text = "出力中"
        Me.Lbl_Messege.Visible = False
        '
        'F_Print_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 482)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_Target)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "F_Print_Main"
        Me.Text = "Excel出力"
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents Btn_Output11 As Button
    Friend WithEvents Btn_Output8 As Button
    Friend WithEvents Btn_Output12 As Button
    Friend WithEvents Btn_Output5 As Button
    Friend WithEvents Btn_Output9 As Button
    Friend WithEvents Btn_Output6 As Button
    Friend WithEvents Btn_Output10 As Button
    Friend WithEvents Btn_Output7 As Button
    Friend WithEvents Btn_Output2 As Button
    Friend WithEvents Btn_Output1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmb_Target As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Lbl_Messege As Label
End Class
