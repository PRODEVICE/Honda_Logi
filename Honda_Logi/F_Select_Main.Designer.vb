<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Select_Main
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Btn_Tokushu = New System.Windows.Forms.Button()
        Me.Btn_Normal = New System.Windows.Forms.Button()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Thistle
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.Btn_Tokushu)
        Me.Panel5.Controls.Add(Me.Btn_Normal)
        Me.Panel5.Location = New System.Drawing.Point(62, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(332, 205)
        Me.Panel5.TabIndex = 65
        '
        'Btn_Tokushu
        '
        Me.Btn_Tokushu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Tokushu.Location = New System.Drawing.Point(29, 113)
        Me.Btn_Tokushu.Name = "Btn_Tokushu"
        Me.Btn_Tokushu.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Tokushu.TabIndex = 5
        Me.Btn_Tokushu.Text = "新見積システム" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "見積依頼用"
        Me.Btn_Tokushu.UseVisualStyleBackColor = True
        '
        'Btn_Normal
        '
        Me.Btn_Normal.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Normal.Location = New System.Drawing.Point(29, 28)
        Me.Btn_Normal.Name = "Btn_Normal"
        Me.Btn_Normal.Size = New System.Drawing.Size(266, 53)
        Me.Btn_Normal.TabIndex = 3
        Me.Btn_Normal.Text = "新見積システム"
        Me.Btn_Normal.UseVisualStyleBackColor = True
        '
        'F_Select_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 313)
        Me.Controls.Add(Me.Panel5)
        Me.Name = "F_Select_Main"
        Me.Text = "メニュー選択"
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Btn_Tokushu As Button
    Friend WithEvents Btn_Normal As Button
End Class
