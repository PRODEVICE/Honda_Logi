<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Main
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
        Me.Btn_Master = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lbl_Data = New System.Windows.Forms.Label()
        Me.Pnl_Data = New System.Windows.Forms.Panel()
        Me.Btn_Receive = New System.Windows.Forms.Button()
        Me.Btn_Change = New System.Windows.Forms.Button()
        Me.Pnl_Master = New System.Windows.Forms.Panel()
        Me.Lbl_Master = New System.Windows.Forms.Label()
        Me.Pnl_Output = New System.Windows.Forms.Panel()
        Me.Btn_Output = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Data.SuspendLayout()
        Me.Pnl_Master.SuspendLayout()
        Me.Pnl_Output.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Master
        '
        Me.Btn_Master.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Master.Location = New System.Drawing.Point(11, 15)
        Me.Btn_Master.Name = "Btn_Master"
        Me.Btn_Master.Size = New System.Drawing.Size(162, 46)
        Me.Btn_Master.TabIndex = 0
        Me.Btn_Master.Text = "マスタ編集"
        Me.Btn_Master.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("HGｺﾞｼｯｸE", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(208, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(254, 36)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Honda_Logi"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Data
        '
        Me.Lbl_Data.AutoSize = True
        Me.Lbl_Data.BackColor = System.Drawing.Color.DodgerBlue
        Me.Lbl_Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Data.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_Data.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Lbl_Data.Location = New System.Drawing.Point(86, 74)
        Me.Lbl_Data.Name = "Lbl_Data"
        Me.Lbl_Data.Size = New System.Drawing.Size(50, 18)
        Me.Lbl_Data.TabIndex = 43
        Me.Lbl_Data.Text = "データ"
        '
        'Pnl_Data
        '
        Me.Pnl_Data.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Pnl_Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Data.Controls.Add(Me.Btn_Receive)
        Me.Pnl_Data.Controls.Add(Me.Btn_Change)
        Me.Pnl_Data.Location = New System.Drawing.Point(86, 94)
        Me.Pnl_Data.Name = "Pnl_Data"
        Me.Pnl_Data.Size = New System.Drawing.Size(189, 207)
        Me.Pnl_Data.TabIndex = 38
        '
        'Btn_Receive
        '
        Me.Btn_Receive.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Receive.Location = New System.Drawing.Point(11, 26)
        Me.Btn_Receive.Name = "Btn_Receive"
        Me.Btn_Receive.Size = New System.Drawing.Size(162, 53)
        Me.Btn_Receive.TabIndex = 1
        Me.Btn_Receive.Text = "データ取込"
        Me.Btn_Receive.UseVisualStyleBackColor = True
        '
        'Btn_Change
        '
        Me.Btn_Change.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Change.Location = New System.Drawing.Point(11, 106)
        Me.Btn_Change.Name = "Btn_Change"
        Me.Btn_Change.Size = New System.Drawing.Size(162, 53)
        Me.Btn_Change.TabIndex = 0
        Me.Btn_Change.Text = "データ変換"
        Me.Btn_Change.UseVisualStyleBackColor = True
        '
        'Pnl_Master
        '
        Me.Pnl_Master.BackColor = System.Drawing.Color.Thistle
        Me.Pnl_Master.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Master.Controls.Add(Me.Btn_Master)
        Me.Pnl_Master.Location = New System.Drawing.Point(406, 105)
        Me.Pnl_Master.Name = "Pnl_Master"
        Me.Pnl_Master.Size = New System.Drawing.Size(189, 79)
        Me.Pnl_Master.TabIndex = 57
        '
        'Lbl_Master
        '
        Me.Lbl_Master.AutoSize = True
        Me.Lbl_Master.BackColor = System.Drawing.Color.BlueViolet
        Me.Lbl_Master.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Master.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_Master.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Lbl_Master.Location = New System.Drawing.Point(406, 85)
        Me.Lbl_Master.Name = "Lbl_Master"
        Me.Lbl_Master.Size = New System.Drawing.Size(82, 18)
        Me.Lbl_Master.TabIndex = 56
        Me.Lbl_Master.Text = "マスタ編集"
        '
        'Pnl_Output
        '
        Me.Pnl_Output.BackColor = System.Drawing.Color.Thistle
        Me.Pnl_Output.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Output.Controls.Add(Me.Btn_Output)
        Me.Pnl_Output.Location = New System.Drawing.Point(406, 222)
        Me.Pnl_Output.Name = "Pnl_Output"
        Me.Pnl_Output.Size = New System.Drawing.Size(189, 79)
        Me.Pnl_Output.TabIndex = 59
        '
        'Btn_Output
        '
        Me.Btn_Output.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Output.Location = New System.Drawing.Point(11, 13)
        Me.Btn_Output.Name = "Btn_Output"
        Me.Btn_Output.Size = New System.Drawing.Size(162, 46)
        Me.Btn_Output.TabIndex = 2
        Me.Btn_Output.Text = "データ出力"
        Me.Btn_Output.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.BlueViolet
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(419, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "データ出力"
        '
        'F_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 368)
        Me.Controls.Add(Me.Pnl_Output)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pnl_Master)
        Me.Controls.Add(Me.Lbl_Master)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lbl_Data)
        Me.Controls.Add(Me.Pnl_Data)
        Me.Name = "F_Main"
        Me.Text = "メインメニュー"
        Me.Pnl_Data.ResumeLayout(False)
        Me.Pnl_Master.ResumeLayout(False)
        Me.Pnl_Output.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Master As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Lbl_Data As Label
    Friend WithEvents Pnl_Data As Panel
    Friend WithEvents Btn_Receive As Button
    Friend WithEvents Btn_Change As Button
    Friend WithEvents Pnl_Master As Panel
    Friend WithEvents Lbl_Master As Label
    Friend WithEvents Pnl_Output As Panel
    Friend WithEvents Btn_Output As Button
    Friend WithEvents Label1 As Label
End Class
