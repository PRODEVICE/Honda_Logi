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
        Me.components = New System.ComponentModel.Container()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Target = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chk_Keisu_Flg = New System.Windows.Forms.CheckBox()
        Me.Btn_Print = New System.Windows.Forms.Button()
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        Me.DS_M = New Honda_Logi.DS_M()
        Me.DTMKubunBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TA_M_Kubun = New Honda_Logi.DS_MTableAdapters.TA_M_Kubun()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMKubunBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(114, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 18)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "出力対象"
        '
        'Cmb_Target
        '
        Me.Cmb_Target.DataSource = Me.DTMKubunBindingSource
        Me.Cmb_Target.DisplayMember = "区分詳細名"
        Me.Cmb_Target.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Target.FormattingEnabled = True
        Me.Cmb_Target.Location = New System.Drawing.Point(199, 61)
        Me.Cmb_Target.Name = "Cmb_Target"
        Me.Cmb_Target.Size = New System.Drawing.Size(203, 24)
        Me.Cmb_Target.TabIndex = 58
        Me.Cmb_Target.ValueMember = "区分CD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(114, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "係数の付与"
        '
        'Chk_Keisu_Flg
        '
        Me.Chk_Keisu_Flg.AutoSize = True
        Me.Chk_Keisu_Flg.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Chk_Keisu_Flg.Location = New System.Drawing.Point(241, 119)
        Me.Chk_Keisu_Flg.Name = "Chk_Keisu_Flg"
        Me.Chk_Keisu_Flg.Size = New System.Drawing.Size(89, 20)
        Me.Chk_Keisu_Flg.TabIndex = 61
        Me.Chk_Keisu_Flg.Text = "付与する"
        Me.Chk_Keisu_Flg.UseVisualStyleBackColor = True
        '
        'Btn_Print
        '
        Me.Btn_Print.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Print.Location = New System.Drawing.Point(241, 162)
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Print.TabIndex = 62
        Me.Btn_Print.Text = "印　刷"
        Me.Btn_Print.UseVisualStyleBackColor = True
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(236, 19)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 63
        Me.Lbl_Messege.Text = "出力中"
        Me.Lbl_Messege.Visible = False
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DTMKubunBindingSource
        '
        Me.DTMKubunBindingSource.DataMember = "DT_M_Kubun"
        Me.DTMKubunBindingSource.DataSource = Me.DS_M
        Me.DTMKubunBindingSource.Filter = "区分id = 6"
        '
        'TA_M_Kubun
        '
        Me.TA_M_Kubun.ClearBeforeFill = True
        '
        'F_Print_Sub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 244)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Btn_Print)
        Me.Controls.Add(Me.Chk_Keisu_Flg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_Target)
        Me.Name = "F_Print_Sub"
        Me.Text = "見積印刷"
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMKubunBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Target As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Chk_Keisu_Flg As CheckBox
    Friend WithEvents Btn_Print As Button
    Friend WithEvents Lbl_Messege As Label
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMKubunBindingSource As BindingSource
    Friend WithEvents TA_M_Kubun As DS_MTableAdapters.TA_M_Kubun
End Class
