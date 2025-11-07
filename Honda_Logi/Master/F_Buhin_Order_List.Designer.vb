<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Buhin_Order_List
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GV_Master = New System.Windows.Forms.DataGridView()
        Me.DTMBuhinOrderListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_M = New Honda_Logi.DS_M()
        Me.TA_M_Buhin_Order_List = New Honda_Logi.DS_MTableAdapters.TA_M_Buhin_Order_List()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt_S_Export_NM = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_S_DIST = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Txt_S_Basic_No = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.変更フラグ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Basic_Part_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Export_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_Lot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LOTカートン数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装入数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装適用 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.L = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.W = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.H = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.防錆 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装適用袋 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.袋必要数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材コード20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数量20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.単品重量 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装重量 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Txt_S_Order_Lot = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_S_OS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_S_Carton = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMBuhinOrderListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GV_Master)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 134)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1357, 547)
        Me.Panel1.TabIndex = 17
        '
        'GV_Master
        '
        Me.GV_Master.AllowUserToAddRows = False
        Me.GV_Master.AllowUserToDeleteRows = False
        Me.GV_Master.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GV_Master.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GV_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV_Master.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.DIST, Me.No, Me.変更フラグ, Me.GR, Me.Basic_Part_No, Me.Export_Name, Me.Order_Lot, Me.LOTカートン数, Me.個装入数, Me.OS, Me.内装適用, Me.L, Me.W, Me.H, Me.防錆, Me.個装適用袋, Me.袋必要数, Me.資材コード1, Me.数量1, Me.資材コード2, Me.数量2, Me.資材コード3, Me.数量3, Me.資材コード4, Me.数量4, Me.資材コード5, Me.数量5, Me.資材コード6, Me.数量6, Me.資材コード7, Me.数量7, Me.資材コード8, Me.数量8, Me.資材コード9, Me.数量9, Me.資材コード10, Me.数量10, Me.資材コード11, Me.数量11, Me.資材コード12, Me.数量12, Me.資材コード13, Me.数量13, Me.資材コード14, Me.数量14, Me.資材コード15, Me.数量15, Me.資材コード16, Me.数量16, Me.資材コード17, Me.数量17, Me.資材コード18, Me.数量18, Me.資材コード19, Me.数量19, Me.資材コード20, Me.数量20, Me.単品重量, Me.内装重量})
        Me.GV_Master.DataSource = Me.DTMBuhinOrderListBindingSource
        Me.GV_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Master.Location = New System.Drawing.Point(0, 0)
        Me.GV_Master.Name = "GV_Master"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GV_Master.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GV_Master.RowTemplate.Height = 31
        Me.GV_Master.Size = New System.Drawing.Size(1357, 547)
        Me.GV_Master.TabIndex = 1
        '
        'DTMBuhinOrderListBindingSource
        '
        Me.DTMBuhinOrderListBindingSource.DataMember = "DT_M_Buhin_Order_List"
        Me.DTMBuhinOrderListBindingSource.DataSource = Me.DS_M
        '
        'DS_M
        '
        Me.DS_M.DataSetName = "DS_M"
        Me.DS_M.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TA_M_Buhin_Order_List
        '
        Me.TA_M_Buhin_Order_List.ClearBeforeFill = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Txt_S_Carton)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Txt_S_OS)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Txt_S_Order_Lot)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Txt_S_Export_NM)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Txt_S_DIST)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Btn_Search)
        Me.Panel3.Controls.Add(Me.Txt_S_Basic_No)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1357, 134)
        Me.Panel3.TabIndex = 19
        '
        'Txt_S_Export_NM
        '
        Me.Txt_S_Export_NM.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Export_NM.Location = New System.Drawing.Point(783, 24)
        Me.Txt_S_Export_NM.Name = "Txt_S_Export_NM"
        Me.Txt_S_Export_NM.Size = New System.Drawing.Size(220, 23)
        Me.Txt_S_Export_NM.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(654, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 16)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "EXPORT NAME"
        '
        'Txt_S_DIST
        '
        Me.Txt_S_DIST.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_DIST.Location = New System.Drawing.Point(93, 24)
        Me.Txt_S_DIST.Name = "Txt_S_DIST"
        Me.Txt_S_DIST.Size = New System.Drawing.Size(145, 23)
        Me.Txt_S_DIST.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "DIST"
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(1014, 62)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Search.TabIndex = 19
        Me.Btn_Search.Text = "検　索"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Txt_S_Basic_No
        '
        Me.Txt_S_Basic_No.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Basic_No.Location = New System.Drawing.Point(400, 24)
        Me.Txt_S_Basic_No.Name = "Txt_S_Basic_No"
        Me.Txt_S_Basic_No.Size = New System.Drawing.Size(220, 23)
        Me.Txt_S_Basic_No.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(271, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "BASIC PART NO"
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'DIST
        '
        Me.DIST.DataPropertyName = "DIST"
        Me.DIST.HeaderText = "DIST"
        Me.DIST.Name = "DIST"
        '
        'No
        '
        Me.No.DataPropertyName = "No"
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        '
        '変更フラグ
        '
        Me.変更フラグ.DataPropertyName = "変更フラグ"
        Me.変更フラグ.HeaderText = "変更フラグ"
        Me.変更フラグ.Name = "変更フラグ"
        '
        'GR
        '
        Me.GR.DataPropertyName = "GR"
        Me.GR.HeaderText = "GR"
        Me.GR.Name = "GR"
        '
        'Basic_Part_No
        '
        Me.Basic_Part_No.DataPropertyName = "Basic_Part_No"
        Me.Basic_Part_No.HeaderText = "Basic_Part_No"
        Me.Basic_Part_No.Name = "Basic_Part_No"
        '
        'Export_Name
        '
        Me.Export_Name.DataPropertyName = "Export_Name"
        Me.Export_Name.HeaderText = "Export_Name"
        Me.Export_Name.Name = "Export_Name"
        '
        'Order_Lot
        '
        Me.Order_Lot.DataPropertyName = "Order_Lot"
        Me.Order_Lot.HeaderText = "Order_Lot"
        Me.Order_Lot.Name = "Order_Lot"
        '
        'LOTカートン数
        '
        Me.LOTカートン数.DataPropertyName = "LOTカートン数"
        Me.LOTカートン数.HeaderText = "LOTカートン数"
        Me.LOTカートン数.Name = "LOTカートン数"
        '
        '個装入数
        '
        Me.個装入数.DataPropertyName = "個装入数"
        Me.個装入数.HeaderText = "個装入数"
        Me.個装入数.Name = "個装入数"
        '
        'OS
        '
        Me.OS.DataPropertyName = "OS"
        Me.OS.HeaderText = "OS"
        Me.OS.Name = "OS"
        '
        '内装適用
        '
        Me.内装適用.DataPropertyName = "内装適用"
        Me.内装適用.HeaderText = "内装適用"
        Me.内装適用.Name = "内装適用"
        '
        'L
        '
        Me.L.DataPropertyName = "L"
        Me.L.HeaderText = "L"
        Me.L.Name = "L"
        '
        'W
        '
        Me.W.DataPropertyName = "W"
        Me.W.HeaderText = "W"
        Me.W.Name = "W"
        '
        'H
        '
        Me.H.DataPropertyName = "H"
        Me.H.HeaderText = "H"
        Me.H.Name = "H"
        '
        '防錆
        '
        Me.防錆.DataPropertyName = "防錆"
        Me.防錆.HeaderText = "防錆"
        Me.防錆.Name = "防錆"
        '
        '個装適用袋
        '
        Me.個装適用袋.DataPropertyName = "個装適用袋"
        Me.個装適用袋.HeaderText = "個装適用袋"
        Me.個装適用袋.Name = "個装適用袋"
        '
        '袋必要数
        '
        Me.袋必要数.DataPropertyName = "袋必要数"
        Me.袋必要数.HeaderText = "袋必要数"
        Me.袋必要数.Name = "袋必要数"
        '
        '資材コード1
        '
        Me.資材コード1.DataPropertyName = "資材コード1"
        Me.資材コード1.HeaderText = "資材コード1"
        Me.資材コード1.Name = "資材コード1"
        '
        '数量1
        '
        Me.数量1.DataPropertyName = "数量1"
        Me.数量1.HeaderText = "数量1"
        Me.数量1.Name = "数量1"
        '
        '資材コード2
        '
        Me.資材コード2.DataPropertyName = "資材コード2"
        Me.資材コード2.HeaderText = "資材コード2"
        Me.資材コード2.Name = "資材コード2"
        '
        '数量2
        '
        Me.数量2.DataPropertyName = "数量2"
        Me.数量2.HeaderText = "数量2"
        Me.数量2.Name = "数量2"
        '
        '資材コード3
        '
        Me.資材コード3.DataPropertyName = "資材コード3"
        Me.資材コード3.HeaderText = "資材コード3"
        Me.資材コード3.Name = "資材コード3"
        '
        '数量3
        '
        Me.数量3.DataPropertyName = "数量3"
        Me.数量3.HeaderText = "数量3"
        Me.数量3.Name = "数量3"
        '
        '資材コード4
        '
        Me.資材コード4.DataPropertyName = "資材コード4"
        Me.資材コード4.HeaderText = "資材コード4"
        Me.資材コード4.Name = "資材コード4"
        '
        '数量4
        '
        Me.数量4.DataPropertyName = "数量4"
        Me.数量4.HeaderText = "数量4"
        Me.数量4.Name = "数量4"
        '
        '資材コード5
        '
        Me.資材コード5.DataPropertyName = "資材コード5"
        Me.資材コード5.HeaderText = "資材コード5"
        Me.資材コード5.Name = "資材コード5"
        '
        '数量5
        '
        Me.数量5.DataPropertyName = "数量5"
        Me.数量5.HeaderText = "数量5"
        Me.数量5.Name = "数量5"
        '
        '資材コード6
        '
        Me.資材コード6.DataPropertyName = "資材コード6"
        Me.資材コード6.HeaderText = "資材コード6"
        Me.資材コード6.Name = "資材コード6"
        '
        '数量6
        '
        Me.数量6.DataPropertyName = "数量6"
        Me.数量6.HeaderText = "数量6"
        Me.数量6.Name = "数量6"
        '
        '資材コード7
        '
        Me.資材コード7.DataPropertyName = "資材コード7"
        Me.資材コード7.HeaderText = "資材コード7"
        Me.資材コード7.Name = "資材コード7"
        '
        '数量7
        '
        Me.数量7.DataPropertyName = "数量7"
        Me.数量7.HeaderText = "数量7"
        Me.数量7.Name = "数量7"
        '
        '資材コード8
        '
        Me.資材コード8.DataPropertyName = "資材コード8"
        Me.資材コード8.HeaderText = "資材コード8"
        Me.資材コード8.Name = "資材コード8"
        '
        '数量8
        '
        Me.数量8.DataPropertyName = "数量8"
        Me.数量8.HeaderText = "数量8"
        Me.数量8.Name = "数量8"
        '
        '資材コード9
        '
        Me.資材コード9.DataPropertyName = "資材コード9"
        Me.資材コード9.HeaderText = "資材コード9"
        Me.資材コード9.Name = "資材コード9"
        '
        '数量9
        '
        Me.数量9.DataPropertyName = "数量9"
        Me.数量9.HeaderText = "数量9"
        Me.数量9.Name = "数量9"
        '
        '資材コード10
        '
        Me.資材コード10.DataPropertyName = "資材コード10"
        Me.資材コード10.HeaderText = "資材コード10"
        Me.資材コード10.Name = "資材コード10"
        '
        '数量10
        '
        Me.数量10.DataPropertyName = "数量10"
        Me.数量10.HeaderText = "数量10"
        Me.数量10.Name = "数量10"
        '
        '資材コード11
        '
        Me.資材コード11.DataPropertyName = "資材コード11"
        Me.資材コード11.HeaderText = "資材コード11"
        Me.資材コード11.Name = "資材コード11"
        '
        '数量11
        '
        Me.数量11.DataPropertyName = "数量11"
        Me.数量11.HeaderText = "数量11"
        Me.数量11.Name = "数量11"
        '
        '資材コード12
        '
        Me.資材コード12.DataPropertyName = "資材コード12"
        Me.資材コード12.HeaderText = "資材コード12"
        Me.資材コード12.Name = "資材コード12"
        '
        '数量12
        '
        Me.数量12.DataPropertyName = "数量12"
        Me.数量12.HeaderText = "数量12"
        Me.数量12.Name = "数量12"
        '
        '資材コード13
        '
        Me.資材コード13.DataPropertyName = "資材コード13"
        Me.資材コード13.HeaderText = "資材コード13"
        Me.資材コード13.Name = "資材コード13"
        '
        '数量13
        '
        Me.数量13.DataPropertyName = "数量13"
        Me.数量13.HeaderText = "数量13"
        Me.数量13.Name = "数量13"
        '
        '資材コード14
        '
        Me.資材コード14.DataPropertyName = "資材コード14"
        Me.資材コード14.HeaderText = "資材コード14"
        Me.資材コード14.Name = "資材コード14"
        '
        '数量14
        '
        Me.数量14.DataPropertyName = "数量14"
        Me.数量14.HeaderText = "数量14"
        Me.数量14.Name = "数量14"
        '
        '資材コード15
        '
        Me.資材コード15.DataPropertyName = "資材コード15"
        Me.資材コード15.HeaderText = "資材コード15"
        Me.資材コード15.Name = "資材コード15"
        '
        '数量15
        '
        Me.数量15.DataPropertyName = "数量15"
        Me.数量15.HeaderText = "数量15"
        Me.数量15.Name = "数量15"
        '
        '資材コード16
        '
        Me.資材コード16.DataPropertyName = "資材コード16"
        Me.資材コード16.HeaderText = "資材コード16"
        Me.資材コード16.Name = "資材コード16"
        '
        '数量16
        '
        Me.数量16.DataPropertyName = "数量16"
        Me.数量16.HeaderText = "数量16"
        Me.数量16.Name = "数量16"
        '
        '資材コード17
        '
        Me.資材コード17.DataPropertyName = "資材コード17"
        Me.資材コード17.HeaderText = "資材コード17"
        Me.資材コード17.Name = "資材コード17"
        '
        '数量17
        '
        Me.数量17.DataPropertyName = "数量17"
        Me.数量17.HeaderText = "数量17"
        Me.数量17.Name = "数量17"
        '
        '資材コード18
        '
        Me.資材コード18.DataPropertyName = "資材コード18"
        Me.資材コード18.HeaderText = "資材コード18"
        Me.資材コード18.Name = "資材コード18"
        '
        '数量18
        '
        Me.数量18.DataPropertyName = "数量18"
        Me.数量18.HeaderText = "数量18"
        Me.数量18.Name = "数量18"
        '
        '資材コード19
        '
        Me.資材コード19.DataPropertyName = "資材コード19"
        Me.資材コード19.HeaderText = "資材コード19"
        Me.資材コード19.Name = "資材コード19"
        '
        '数量19
        '
        Me.数量19.DataPropertyName = "数量19"
        Me.数量19.HeaderText = "数量19"
        Me.数量19.Name = "数量19"
        '
        '資材コード20
        '
        Me.資材コード20.DataPropertyName = "資材コード20"
        Me.資材コード20.HeaderText = "資材コード20"
        Me.資材コード20.Name = "資材コード20"
        '
        '数量20
        '
        Me.数量20.DataPropertyName = "数量20"
        Me.数量20.HeaderText = "数量20"
        Me.数量20.Name = "数量20"
        '
        '単品重量
        '
        Me.単品重量.DataPropertyName = "単品重量"
        Me.単品重量.HeaderText = "単品重量"
        Me.単品重量.Name = "単品重量"
        '
        '内装重量
        '
        Me.内装重量.DataPropertyName = "内装重量"
        Me.内装重量.HeaderText = "内装重量"
        Me.内装重量.Name = "内装重量"
        '
        'Txt_S_Order_Lot
        '
        Me.Txt_S_Order_Lot.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Order_Lot.Location = New System.Drawing.Point(144, 76)
        Me.Txt_S_Order_Lot.Name = "Txt_S_Order_Lot"
        Me.Txt_S_Order_Lot.Size = New System.Drawing.Size(145, 23)
        Me.Txt_S_Order_Lot.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "ORDER_LOT"
        '
        'Txt_S_OS
        '
        Me.Txt_S_OS.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_OS.Location = New System.Drawing.Point(400, 76)
        Me.Txt_S_OS.Name = "Txt_S_OS"
        Me.Txt_S_OS.Size = New System.Drawing.Size(145, 23)
        Me.Txt_S_OS.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(365, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "OS"
        '
        'Txt_S_Carton
        '
        Me.Txt_S_Carton.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_S_Carton.Location = New System.Drawing.Point(783, 72)
        Me.Txt_S_Carton.Name = "Txt_S_Carton"
        Me.Txt_S_Carton.Size = New System.Drawing.Size(145, 23)
        Me.Txt_S_Carton.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(654, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "内装適用カートン"
        '
        'F_Buhin_Order_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1357, 681)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "F_Buhin_Order_List"
        Me.Text = "F_Buhin_Order_List"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GV_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMBuhinOrderListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GV_Master As DataGridView
    Friend WithEvents DS_M As DS_M
    Friend WithEvents DTMBuhinOrderListBindingSource As BindingSource
    Friend WithEvents TA_M_Buhin_Order_List As DS_MTableAdapters.TA_M_Buhin_Order_List
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Txt_S_Export_NM As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_S_DIST As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Btn_Search As Button
    Friend WithEvents Txt_S_Basic_No As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents DIST As DataGridViewTextBoxColumn
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents 変更フラグ As DataGridViewTextBoxColumn
    Friend WithEvents GR As DataGridViewTextBoxColumn
    Friend WithEvents Basic_Part_No As DataGridViewTextBoxColumn
    Friend WithEvents Export_Name As DataGridViewTextBoxColumn
    Friend WithEvents Order_Lot As DataGridViewTextBoxColumn
    Friend WithEvents LOTカートン数 As DataGridViewTextBoxColumn
    Friend WithEvents 個装入数 As DataGridViewTextBoxColumn
    Friend WithEvents OS As DataGridViewTextBoxColumn
    Friend WithEvents 内装適用 As DataGridViewTextBoxColumn
    Friend WithEvents L As DataGridViewTextBoxColumn
    Friend WithEvents W As DataGridViewTextBoxColumn
    Friend WithEvents H As DataGridViewTextBoxColumn
    Friend WithEvents 防錆 As DataGridViewTextBoxColumn
    Friend WithEvents 個装適用袋 As DataGridViewTextBoxColumn
    Friend WithEvents 袋必要数 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード1 As DataGridViewTextBoxColumn
    Friend WithEvents 数量1 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード2 As DataGridViewTextBoxColumn
    Friend WithEvents 数量2 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード3 As DataGridViewTextBoxColumn
    Friend WithEvents 数量3 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード4 As DataGridViewTextBoxColumn
    Friend WithEvents 数量4 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード5 As DataGridViewTextBoxColumn
    Friend WithEvents 数量5 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード6 As DataGridViewTextBoxColumn
    Friend WithEvents 数量6 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード7 As DataGridViewTextBoxColumn
    Friend WithEvents 数量7 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード8 As DataGridViewTextBoxColumn
    Friend WithEvents 数量8 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード9 As DataGridViewTextBoxColumn
    Friend WithEvents 数量9 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード10 As DataGridViewTextBoxColumn
    Friend WithEvents 数量10 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード11 As DataGridViewTextBoxColumn
    Friend WithEvents 数量11 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード12 As DataGridViewTextBoxColumn
    Friend WithEvents 数量12 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード13 As DataGridViewTextBoxColumn
    Friend WithEvents 数量13 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード14 As DataGridViewTextBoxColumn
    Friend WithEvents 数量14 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード15 As DataGridViewTextBoxColumn
    Friend WithEvents 数量15 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード16 As DataGridViewTextBoxColumn
    Friend WithEvents 数量16 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード17 As DataGridViewTextBoxColumn
    Friend WithEvents 数量17 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード18 As DataGridViewTextBoxColumn
    Friend WithEvents 数量18 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード19 As DataGridViewTextBoxColumn
    Friend WithEvents 数量19 As DataGridViewTextBoxColumn
    Friend WithEvents 資材コード20 As DataGridViewTextBoxColumn
    Friend WithEvents 数量20 As DataGridViewTextBoxColumn
    Friend WithEvents 単品重量 As DataGridViewTextBoxColumn
    Friend WithEvents 内装重量 As DataGridViewTextBoxColumn
    Friend WithEvents Txt_S_Carton As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_S_OS As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_S_Order_Lot As TextBox
    Friend WithEvents Label1 As Label
End Class
