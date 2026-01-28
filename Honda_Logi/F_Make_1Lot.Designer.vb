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
        Me.SuspendLayout()
        '
        'Btn_Change
        '
        Me.Btn_Change.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Change.Location = New System.Drawing.Point(139, 118)
        Me.Btn_Change.Name = "Btn_Change"
        Me.Btn_Change.Size = New System.Drawing.Size(124, 65)
        Me.Btn_Change.TabIndex = 32
        Me.Btn_Change.Text = "変　換"
        Me.Btn_Change.UseVisualStyleBackColor = True
        '
        'Btn_Output
        '
        Me.Btn_Output.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output.Location = New System.Drawing.Point(359, 118)
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
        'F_Make_1Lot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 296)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Btn_Output)
        Me.Controls.Add(Me.Btn_Change)
        Me.Name = "F_Make_1Lot"
        Me.Text = "データ変換"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Change As Button
    Friend WithEvents Btn_Output As Button
    Friend WithEvents Lbl_Messege As Label
End Class
