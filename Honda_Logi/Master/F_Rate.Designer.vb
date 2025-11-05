<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Rate
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
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.Txt_Rate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(155, 118)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Touroku.TabIndex = 4
        Me.Btn_Touroku.Text = "更　新"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'Txt_Rate
        '
        Me.Txt_Rate.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_Rate.Location = New System.Drawing.Point(138, 56)
        Me.Txt_Rate.Name = "Txt_Rate"
        Me.Txt_Rate.Size = New System.Drawing.Size(173, 23)
        Me.Txt_Rate.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "賃率"
        '
        'F_Rate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 219)
        Me.Controls.Add(Me.Btn_Touroku)
        Me.Controls.Add(Me.Txt_Rate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "F_Rate"
        Me.Text = "賃率"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Txt_Rate As TextBox
    Friend WithEvents Label1 As Label
End Class
