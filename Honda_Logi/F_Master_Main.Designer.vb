<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Master_Main
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
        Me.Btn_M_Keisu = New System.Windows.Forms.Button()
        Me.Btn_M_Tanka = New System.Windows.Forms.Button()
        Me.Btn_M_Order = New System.Windows.Forms.Button()
        Me.Btn_M_Hayami = New System.Windows.Forms.Button()
        Me.Btn_M_Mitsumori = New System.Windows.Forms.Button()
        Me.Btn_M_Kousu = New System.Windows.Forms.Button()
        Me.Btn_M_Tinritsu = New System.Windows.Forms.Button()
        Me.Btn_M_Shizai = New System.Windows.Forms.Button()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Thistle
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.Btn_M_Keisu)
        Me.Panel5.Controls.Add(Me.Btn_M_Tanka)
        Me.Panel5.Controls.Add(Me.Btn_M_Order)
        Me.Panel5.Controls.Add(Me.Btn_M_Hayami)
        Me.Panel5.Controls.Add(Me.Btn_M_Mitsumori)
        Me.Panel5.Controls.Add(Me.Btn_M_Kousu)
        Me.Panel5.Controls.Add(Me.Btn_M_Tinritsu)
        Me.Panel5.Controls.Add(Me.Btn_M_Shizai)
        Me.Panel5.Location = New System.Drawing.Point(65, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(600, 261)
        Me.Panel5.TabIndex = 58
        '
        'Btn_M_Keisu
        '
        Me.Btn_M_Keisu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Keisu.Location = New System.Drawing.Point(304, 130)
        Me.Btn_M_Keisu.Name = "Btn_M_Keisu"
        Me.Btn_M_Keisu.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Keisu.TabIndex = 15
        Me.Btn_M_Keisu.Text = "機種係数マスタ"
        Me.Btn_M_Keisu.UseVisualStyleBackColor = True
        '
        'Btn_M_Tanka
        '
        Me.Btn_M_Tanka.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Tanka.Location = New System.Drawing.Point(18, 189)
        Me.Btn_M_Tanka.Name = "Btn_M_Tanka"
        Me.Btn_M_Tanka.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Tanka.TabIndex = 13
        Me.Btn_M_Tanka.Text = "資材単価マスタ"
        Me.Btn_M_Tanka.UseVisualStyleBackColor = True
        '
        'Btn_M_Order
        '
        Me.Btn_M_Order.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Order.Location = New System.Drawing.Point(304, 189)
        Me.Btn_M_Order.Name = "Btn_M_Order"
        Me.Btn_M_Order.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Order.TabIndex = 11
        Me.Btn_M_Order.Text = "部品単位オーダーリスト"
        Me.Btn_M_Order.UseVisualStyleBackColor = True
        '
        'Btn_M_Hayami
        '
        Me.Btn_M_Hayami.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Hayami.Location = New System.Drawing.Point(304, 12)
        Me.Btn_M_Hayami.Name = "Btn_M_Hayami"
        Me.Btn_M_Hayami.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Hayami.TabIndex = 10
        Me.Btn_M_Hayami.Text = "個装/内装登録早見表"
        Me.Btn_M_Hayami.UseVisualStyleBackColor = True
        '
        'Btn_M_Mitsumori
        '
        Me.Btn_M_Mitsumori.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Mitsumori.Location = New System.Drawing.Point(18, 71)
        Me.Btn_M_Mitsumori.Name = "Btn_M_Mitsumori"
        Me.Btn_M_Mitsumori.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Mitsumori.TabIndex = 14
        Me.Btn_M_Mitsumori.Text = "見積コードマスタ"
        Me.Btn_M_Mitsumori.UseVisualStyleBackColor = True
        '
        'Btn_M_Kousu
        '
        Me.Btn_M_Kousu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Kousu.Location = New System.Drawing.Point(304, 71)
        Me.Btn_M_Kousu.Name = "Btn_M_Kousu"
        Me.Btn_M_Kousu.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Kousu.TabIndex = 9
        Me.Btn_M_Kousu.Text = "工数マスタ"
        Me.Btn_M_Kousu.UseVisualStyleBackColor = True
        '
        'Btn_M_Tinritsu
        '
        Me.Btn_M_Tinritsu.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Tinritsu.Location = New System.Drawing.Point(18, 130)
        Me.Btn_M_Tinritsu.Name = "Btn_M_Tinritsu"
        Me.Btn_M_Tinritsu.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Tinritsu.TabIndex = 11
        Me.Btn_M_Tinritsu.Text = "賃率マスタ"
        Me.Btn_M_Tinritsu.UseVisualStyleBackColor = True
        '
        'Btn_M_Shizai
        '
        Me.Btn_M_Shizai.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_M_Shizai.Location = New System.Drawing.Point(18, 12)
        Me.Btn_M_Shizai.Name = "Btn_M_Shizai"
        Me.Btn_M_Shizai.Size = New System.Drawing.Size(266, 53)
        Me.Btn_M_Shizai.TabIndex = 2
        Me.Btn_M_Shizai.Text = "資材マスタ"
        Me.Btn_M_Shizai.UseVisualStyleBackColor = True
        '
        'F_Master_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 360)
        Me.Controls.Add(Me.Panel5)
        Me.Name = "F_Master_Main"
        Me.Text = "F_Master_Main"
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents Btn_M_Keisu As Button
    Friend WithEvents Btn_M_Tanka As Button
    Friend WithEvents Btn_M_Order As Button
    Friend WithEvents Btn_M_Hayami As Button
    Friend WithEvents Btn_M_Mitsumori As Button
    Friend WithEvents Btn_M_Kousu As Button
    Friend WithEvents Btn_M_Tinritsu As Button
    Friend WithEvents Btn_M_Shizai As Button
End Class
