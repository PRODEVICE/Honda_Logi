<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Receive
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
        Me.components = New System.ComponentModel.Container()
        Me.DTMKubunBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.Btn_Sanshou = New System.Windows.Forms.Button()
        Me.Txt_File_Path = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Receive = New System.Windows.Forms.Button()
        Me.TA_M_Kubun = New Honda_Logi.DS_MTableAdapters.TA_M_Kubun()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dtp_Nengetu = New System.Windows.Forms.DateTimePicker()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Lbl_Messege = New System.Windows.Forms.Label()
        CType(Me.DTMKubunBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTMKubunBindingSource
        '
        Me.DTMKubunBindingSource.DataMember = "DT_M_Kubun"
        Me.DTMKubunBindingSource.DataSource = Me.DS_M
        Me.DTMKubunBindingSource.Filter = "区分id = 1"
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Btn_Sanshou
        '
        Me.Btn_Sanshou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Sanshou.Location = New System.Drawing.Point(697, 212)
        Me.Btn_Sanshou.Name = "Btn_Sanshou"
        Me.Btn_Sanshou.Size = New System.Drawing.Size(75, 38)
        Me.Btn_Sanshou.TabIndex = 2
        Me.Btn_Sanshou.Text = "参照"
        Me.Btn_Sanshou.UseVisualStyleBackColor = True
        '
        'Txt_File_Path
        '
        Me.Txt_File_Path.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_File_Path.Location = New System.Drawing.Point(62, 183)
        Me.Txt_File_Path.Name = "Txt_File_Path"
        Me.Txt_File_Path.Size = New System.Drawing.Size(710, 23)
        Me.Txt_File_Path.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(62, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 18)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "取込ファイルパス"
        '
        'Btn_Receive
        '
        Me.Btn_Receive.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Receive.Location = New System.Drawing.Point(349, 225)
        Me.Btn_Receive.Name = "Btn_Receive"
        Me.Btn_Receive.Size = New System.Drawing.Size(124, 65)
        Me.Btn_Receive.TabIndex = 3
        Me.Btn_Receive.Text = "取　込"
        Me.Btn_Receive.UseVisualStyleBackColor = True
        '
        'TA_M_Kubun
        '
        Me.TA_M_Kubun.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(62, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 18)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "取込年月"
        '
        'Dtp_Nengetu
        '
        Me.Dtp_Nengetu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Dtp_Nengetu.Location = New System.Drawing.Point(62, 83)
        Me.Dtp_Nengetu.Name = "Dtp_Nengetu"
        Me.Dtp_Nengetu.Size = New System.Drawing.Size(200, 23)
        Me.Dtp_Nengetu.TabIndex = 0
        '
        'Lbl_Messege
        '
        Me.Lbl_Messege.AutoSize = True
        Me.Lbl_Messege.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Messege.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Messege.Location = New System.Drawing.Point(363, 25)
        Me.Lbl_Messege.Name = "Lbl_Messege"
        Me.Lbl_Messege.Size = New System.Drawing.Size(96, 27)
        Me.Lbl_Messege.TabIndex = 65
        Me.Lbl_Messege.Text = "取込中"
        Me.Lbl_Messege.Visible = False
        '
        'F_Receive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 346)
        Me.Controls.Add(Me.Lbl_Messege)
        Me.Controls.Add(Me.Dtp_Nengetu)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Btn_Receive)
        Me.Controls.Add(Me.Btn_Sanshou)
        Me.Controls.Add(Me.Txt_File_Path)
        Me.Controls.Add(Me.Label1)
        Me.Name = "F_Receive"
        Me.Text = "データ取込"
        CType(Me.DTMKubunBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Sanshou As Button
    Friend WithEvents Txt_File_Path As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Receive As Button
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMKubunBindingSource As BindingSource
    Friend WithEvents TA_M_Kubun As DS_MTableAdapters.TA_M_Kubun
    Friend WithEvents Label3 As Label
    Friend WithEvents Dtp_Nengetu As DateTimePicker
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Lbl_Messege As Label
End Class
