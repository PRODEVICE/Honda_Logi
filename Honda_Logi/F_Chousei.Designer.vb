<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Chousei
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Target = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GV_Chousei = New System.Windows.Forms.DataGridView()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Touroku = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DS_T = New Honda_Logi.DS_T()
        Me.DTTCCCLotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TA_T_CCC_Lot = New Honda_Logi.DS_TTableAdapters.TA_T_CCC_Lot()
        Me.ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.モデフNODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ケースNO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.代表DISTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.部品群DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.包装ロットNODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.包装ロット連番DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.年度2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.モデル2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.タイプ1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.オプション1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.群DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.包装数量DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装ラインDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装ラインDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.包装ライン外装DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.基本部番DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装資材記号DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装手順SEQDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.部品収容数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装資材記号DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装手順SEQDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装入り数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装資材記号DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.モジュール手順SEQDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装入り数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材6DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数6DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材7DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数7DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材8DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数8DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材9DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数9DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材10DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数10DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材11DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数11DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材13DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数13DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材14DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数14DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材15DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数15DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材16DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数16DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材17DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数17DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材18DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数18DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材19DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数19DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.副資材20DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.必要数20DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.基本部番ハイフン付DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.単品部品総数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.部品点数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.防錆回数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装資材数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.カートン数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.リターナブル容器数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENG発泡材数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.積み付け回数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.パネルケース数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.スカシケース数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装用段ボールパット使用数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装用箱型ポリ袋DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装用ボルト使用数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装用副資材使用数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外直部品総数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外直の防錆回数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装ケース数DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.部品点数集計DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装資材費DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装資材費DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装資材費DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個装作業DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内装作業DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装作業DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.作業計DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.個内装資材DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.外装資材DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.資材計DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.見積NoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Txt_DIST = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GV_Chousei, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DS_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTTCCCLotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(230, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "対象データ"
        '
        'Cmb_Target
        '
        Me.Cmb_Target.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb_Target.FormattingEnabled = True
        Me.Cmb_Target.Location = New System.Drawing.Point(315, 29)
        Me.Cmb_Target.Name = "Cmb_Target"
        Me.Cmb_Target.Size = New System.Drawing.Size(515, 24)
        Me.Cmb_Target.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Cmb_Target)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 83)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GV_Chousei)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1264, 231)
        Me.Panel2.TabIndex = 5
        '
        'GV_Chousei
        '
        Me.GV_Chousei.AllowUserToAddRows = False
        Me.GV_Chousei.AllowUserToDeleteRows = False
        Me.GV_Chousei.AutoGenerateColumns = False
        Me.GV_Chousei.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV_Chousei.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn, Me.モデフNODataGridViewTextBoxColumn, Me.ケースNO1DataGridViewTextBoxColumn, Me.代表DISTDataGridViewTextBoxColumn, Me.部品群DataGridViewTextBoxColumn, Me.包装ロットNODataGridViewTextBoxColumn, Me.包装ロット連番DataGridViewTextBoxColumn, Me.年度2DataGridViewTextBoxColumn, Me.モデル2DataGridViewTextBoxColumn, Me.タイプ1DataGridViewTextBoxColumn, Me.オプション1DataGridViewTextBoxColumn, Me.群DataGridViewTextBoxColumn, Me.包装数量DataGridViewTextBoxColumn, Me.個装ラインDataGridViewTextBoxColumn, Me.内装ラインDataGridViewTextBoxColumn, Me.包装ライン外装DataGridViewTextBoxColumn, Me.基本部番DataGridViewTextBoxColumn, Me.個装資材記号DataGridViewTextBoxColumn, Me.個装手順SEQDataGridViewTextBoxColumn, Me.部品収容数DataGridViewTextBoxColumn, Me.内装資材記号DataGridViewTextBoxColumn, Me.内装手順SEQDataGridViewTextBoxColumn, Me.個装入り数DataGridViewTextBoxColumn, Me.外装資材記号DataGridViewTextBoxColumn, Me.モジュール手順SEQDataGridViewTextBoxColumn, Me.内装入り数DataGridViewTextBoxColumn, Me.副資材1DataGridViewTextBoxColumn, Me.必要数1DataGridViewTextBoxColumn, Me.副資材2DataGridViewTextBoxColumn, Me.必要数2DataGridViewTextBoxColumn, Me.副資材3DataGridViewTextBoxColumn, Me.必要数3DataGridViewTextBoxColumn, Me.副資材4DataGridViewTextBoxColumn, Me.必要数4DataGridViewTextBoxColumn, Me.副資材5DataGridViewTextBoxColumn, Me.必要数5DataGridViewTextBoxColumn, Me.副資材6DataGridViewTextBoxColumn, Me.必要数6DataGridViewTextBoxColumn, Me.副資材7DataGridViewTextBoxColumn, Me.必要数7DataGridViewTextBoxColumn, Me.副資材8DataGridViewTextBoxColumn, Me.必要数8DataGridViewTextBoxColumn, Me.副資材9DataGridViewTextBoxColumn, Me.必要数9DataGridViewTextBoxColumn, Me.副資材10DataGridViewTextBoxColumn, Me.必要数10DataGridViewTextBoxColumn, Me.副資材11DataGridViewTextBoxColumn, Me.必要数11DataGridViewTextBoxColumn, Me.副資材12DataGridViewTextBoxColumn, Me.必要数12DataGridViewTextBoxColumn, Me.副資材13DataGridViewTextBoxColumn, Me.必要数13DataGridViewTextBoxColumn, Me.副資材14DataGridViewTextBoxColumn, Me.必要数14DataGridViewTextBoxColumn, Me.副資材15DataGridViewTextBoxColumn, Me.必要数15DataGridViewTextBoxColumn, Me.副資材16DataGridViewTextBoxColumn, Me.必要数16DataGridViewTextBoxColumn, Me.副資材17DataGridViewTextBoxColumn, Me.必要数17DataGridViewTextBoxColumn, Me.副資材18DataGridViewTextBoxColumn, Me.必要数18DataGridViewTextBoxColumn, Me.副資材19DataGridViewTextBoxColumn, Me.必要数19DataGridViewTextBoxColumn, Me.副資材20DataGridViewTextBoxColumn, Me.必要数20DataGridViewTextBoxColumn, Me.基本部番ハイフン付DataGridViewTextBoxColumn, Me.単品部品総数DataGridViewTextBoxColumn, Me.部品点数DataGridViewTextBoxColumn, Me.防錆回数DataGridViewTextBoxColumn, Me.個装数DataGridViewTextBoxColumn, Me.内装資材数DataGridViewTextBoxColumn, Me.カートン数DataGridViewTextBoxColumn, Me.リターナブル容器数DataGridViewTextBoxColumn, Me.ENG発泡材数DataGridViewTextBoxColumn, Me.積み付け回数DataGridViewTextBoxColumn, Me.パネルケース数DataGridViewTextBoxColumn, Me.スカシケース数DataGridViewTextBoxColumn, Me.外装用段ボールパット使用数DataGridViewTextBoxColumn, Me.外装用箱型ポリ袋DataGridViewTextBoxColumn, Me.外装用ボルト使用数DataGridViewTextBoxColumn, Me.外装用副資材使用数DataGridViewTextBoxColumn, Me.外直部品総数DataGridViewTextBoxColumn, Me.外直の防錆回数DataGridViewTextBoxColumn, Me.外装ケース数DataGridViewTextBoxColumn, Me.部品点数集計DataGridViewTextBoxColumn, Me.個装資材費DataGridViewTextBoxColumn, Me.内装資材費DataGridViewTextBoxColumn, Me.外装資材費DataGridViewTextBoxColumn, Me.個装作業DataGridViewTextBoxColumn, Me.内装作業DataGridViewTextBoxColumn, Me.外装作業DataGridViewTextBoxColumn, Me.作業計DataGridViewTextBoxColumn, Me.個内装資材DataGridViewTextBoxColumn, Me.外装資材DataGridViewTextBoxColumn, Me.資材計DataGridViewTextBoxColumn, Me.見積NoDataGridViewTextBoxColumn})
        Me.GV_Chousei.DataSource = Me.DTTCCCLotBindingSource
        Me.GV_Chousei.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Chousei.Location = New System.Drawing.Point(0, 0)
        Me.GV_Chousei.Name = "GV_Chousei"
        Me.GV_Chousei.ReadOnly = True
        Me.GV_Chousei.RowTemplate.Height = 21
        Me.GV_Chousei.Size = New System.Drawing.Size(1264, 231)
        Me.GV_Chousei.TabIndex = 0
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(1128, 220)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(124, 65)
        Me.Btn_Delete.TabIndex = 5
        Me.Btn_Delete.Text = "削　除"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Touroku
        '
        Me.Btn_Touroku.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Touroku.Location = New System.Drawing.Point(971, 220)
        Me.Btn_Touroku.Name = "Btn_Touroku"
        Me.Btn_Touroku.Size = New System.Drawing.Size(124, 65)
        Me.Btn_Touroku.TabIndex = 4
        Me.Btn_Touroku.Text = "登　録"
        Me.Btn_Touroku.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TextBox26)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.TextBox27)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.TextBox28)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.TextBox29)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.TextBox30)
        Me.Panel3.Controls.Add(Me.Label33)
        Me.Panel3.Controls.Add(Me.TextBox31)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.TextBox32)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Controls.Add(Me.TextBox11)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.TextBox12)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.TextBox13)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.TextBox14)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.TextBox15)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.TextBox16)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.TextBox17)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.TextBox18)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.TextBox19)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.TextBox20)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.TextBox21)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.TextBox9)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.TextBox10)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.TextBox6)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TextBox7)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TextBox8)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.TextBox4)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.TextBox5)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Txt_DIST)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Btn_Touroku)
        Me.Panel3.Controls.Add(Me.Btn_Delete)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 314)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1264, 305)
        Me.Panel3.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(3, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "1Lotデータ"
        '
        'DS_T
        '
        Me.DS_T.DataSetName = "DS_T"
        Me.DS_T.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DTTCCCLotBindingSource
        '
        Me.DTTCCCLotBindingSource.DataMember = "DT_T_CCC_Lot"
        Me.DTTCCCLotBindingSource.DataSource = Me.DS_T
        '
        'TA_T_CCC_Lot
        '
        Me.TA_T_CCC_Lot.ClearBeforeFill = True
        '
        'ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn
        '
        Me.ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn.DataPropertyName = "ｺﾝﾄﾛｰﾙNO"
        Me.ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn.HeaderText = "ｺﾝﾄﾛｰﾙNO"
        Me.ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn.Name = "ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn"
        '
        'モデフNODataGridViewTextBoxColumn
        '
        Me.モデフNODataGridViewTextBoxColumn.DataPropertyName = "モデフNO"
        Me.モデフNODataGridViewTextBoxColumn.HeaderText = "モデフNO"
        Me.モデフNODataGridViewTextBoxColumn.Name = "モデフNODataGridViewTextBoxColumn"
        '
        'ケースNO1DataGridViewTextBoxColumn
        '
        Me.ケースNO1DataGridViewTextBoxColumn.DataPropertyName = "ケースNO1"
        Me.ケースNO1DataGridViewTextBoxColumn.HeaderText = "ケースNO1"
        Me.ケースNO1DataGridViewTextBoxColumn.Name = "ケースNO1DataGridViewTextBoxColumn"
        '
        '代表DISTDataGridViewTextBoxColumn
        '
        Me.代表DISTDataGridViewTextBoxColumn.DataPropertyName = "代表DIST"
        Me.代表DISTDataGridViewTextBoxColumn.HeaderText = "代表DIST"
        Me.代表DISTDataGridViewTextBoxColumn.Name = "代表DISTDataGridViewTextBoxColumn"
        '
        '部品群DataGridViewTextBoxColumn
        '
        Me.部品群DataGridViewTextBoxColumn.DataPropertyName = "部品群"
        Me.部品群DataGridViewTextBoxColumn.HeaderText = "部品群"
        Me.部品群DataGridViewTextBoxColumn.Name = "部品群DataGridViewTextBoxColumn"
        '
        '包装ロットNODataGridViewTextBoxColumn
        '
        Me.包装ロットNODataGridViewTextBoxColumn.DataPropertyName = "包装ロットNO"
        Me.包装ロットNODataGridViewTextBoxColumn.HeaderText = "包装ロットNO"
        Me.包装ロットNODataGridViewTextBoxColumn.Name = "包装ロットNODataGridViewTextBoxColumn"
        '
        '包装ロット連番DataGridViewTextBoxColumn
        '
        Me.包装ロット連番DataGridViewTextBoxColumn.DataPropertyName = "包装ロット連番"
        Me.包装ロット連番DataGridViewTextBoxColumn.HeaderText = "包装ロット連番"
        Me.包装ロット連番DataGridViewTextBoxColumn.Name = "包装ロット連番DataGridViewTextBoxColumn"
        '
        '年度2DataGridViewTextBoxColumn
        '
        Me.年度2DataGridViewTextBoxColumn.DataPropertyName = "年度2"
        Me.年度2DataGridViewTextBoxColumn.HeaderText = "年度2"
        Me.年度2DataGridViewTextBoxColumn.Name = "年度2DataGridViewTextBoxColumn"
        '
        'モデル2DataGridViewTextBoxColumn
        '
        Me.モデル2DataGridViewTextBoxColumn.DataPropertyName = "モデル2"
        Me.モデル2DataGridViewTextBoxColumn.HeaderText = "モデル2"
        Me.モデル2DataGridViewTextBoxColumn.Name = "モデル2DataGridViewTextBoxColumn"
        '
        'タイプ1DataGridViewTextBoxColumn
        '
        Me.タイプ1DataGridViewTextBoxColumn.DataPropertyName = "タイプ1"
        Me.タイプ1DataGridViewTextBoxColumn.HeaderText = "タイプ1"
        Me.タイプ1DataGridViewTextBoxColumn.Name = "タイプ1DataGridViewTextBoxColumn"
        '
        'オプション1DataGridViewTextBoxColumn
        '
        Me.オプション1DataGridViewTextBoxColumn.DataPropertyName = "オプション1"
        Me.オプション1DataGridViewTextBoxColumn.HeaderText = "オプション1"
        Me.オプション1DataGridViewTextBoxColumn.Name = "オプション1DataGridViewTextBoxColumn"
        '
        '群DataGridViewTextBoxColumn
        '
        Me.群DataGridViewTextBoxColumn.DataPropertyName = "群"
        Me.群DataGridViewTextBoxColumn.HeaderText = "群"
        Me.群DataGridViewTextBoxColumn.Name = "群DataGridViewTextBoxColumn"
        '
        '包装数量DataGridViewTextBoxColumn
        '
        Me.包装数量DataGridViewTextBoxColumn.DataPropertyName = "包装数量"
        Me.包装数量DataGridViewTextBoxColumn.HeaderText = "包装数量"
        Me.包装数量DataGridViewTextBoxColumn.Name = "包装数量DataGridViewTextBoxColumn"
        '
        '個装ラインDataGridViewTextBoxColumn
        '
        Me.個装ラインDataGridViewTextBoxColumn.DataPropertyName = "個装ライン"
        Me.個装ラインDataGridViewTextBoxColumn.HeaderText = "個装ライン"
        Me.個装ラインDataGridViewTextBoxColumn.Name = "個装ラインDataGridViewTextBoxColumn"
        '
        '内装ラインDataGridViewTextBoxColumn
        '
        Me.内装ラインDataGridViewTextBoxColumn.DataPropertyName = "内装ライン"
        Me.内装ラインDataGridViewTextBoxColumn.HeaderText = "内装ライン"
        Me.内装ラインDataGridViewTextBoxColumn.Name = "内装ラインDataGridViewTextBoxColumn"
        '
        '包装ライン外装DataGridViewTextBoxColumn
        '
        Me.包装ライン外装DataGridViewTextBoxColumn.DataPropertyName = "包装ライン_外装"
        Me.包装ライン外装DataGridViewTextBoxColumn.HeaderText = "包装ライン_外装"
        Me.包装ライン外装DataGridViewTextBoxColumn.Name = "包装ライン外装DataGridViewTextBoxColumn"
        '
        '基本部番DataGridViewTextBoxColumn
        '
        Me.基本部番DataGridViewTextBoxColumn.DataPropertyName = "基本部番"
        Me.基本部番DataGridViewTextBoxColumn.HeaderText = "基本部番"
        Me.基本部番DataGridViewTextBoxColumn.Name = "基本部番DataGridViewTextBoxColumn"
        '
        '個装資材記号DataGridViewTextBoxColumn
        '
        Me.個装資材記号DataGridViewTextBoxColumn.DataPropertyName = "個装資材記号"
        Me.個装資材記号DataGridViewTextBoxColumn.HeaderText = "個装資材記号"
        Me.個装資材記号DataGridViewTextBoxColumn.Name = "個装資材記号DataGridViewTextBoxColumn"
        '
        '個装手順SEQDataGridViewTextBoxColumn
        '
        Me.個装手順SEQDataGridViewTextBoxColumn.DataPropertyName = "個装手順SEQ"
        Me.個装手順SEQDataGridViewTextBoxColumn.HeaderText = "個装手順SEQ"
        Me.個装手順SEQDataGridViewTextBoxColumn.Name = "個装手順SEQDataGridViewTextBoxColumn"
        '
        '部品収容数DataGridViewTextBoxColumn
        '
        Me.部品収容数DataGridViewTextBoxColumn.DataPropertyName = "部品収容数"
        Me.部品収容数DataGridViewTextBoxColumn.HeaderText = "部品収容数"
        Me.部品収容数DataGridViewTextBoxColumn.Name = "部品収容数DataGridViewTextBoxColumn"
        '
        '内装資材記号DataGridViewTextBoxColumn
        '
        Me.内装資材記号DataGridViewTextBoxColumn.DataPropertyName = "内装資材記号"
        Me.内装資材記号DataGridViewTextBoxColumn.HeaderText = "内装資材記号"
        Me.内装資材記号DataGridViewTextBoxColumn.Name = "内装資材記号DataGridViewTextBoxColumn"
        '
        '内装手順SEQDataGridViewTextBoxColumn
        '
        Me.内装手順SEQDataGridViewTextBoxColumn.DataPropertyName = "内装手順SEQ"
        Me.内装手順SEQDataGridViewTextBoxColumn.HeaderText = "内装手順SEQ"
        Me.内装手順SEQDataGridViewTextBoxColumn.Name = "内装手順SEQDataGridViewTextBoxColumn"
        '
        '個装入り数DataGridViewTextBoxColumn
        '
        Me.個装入り数DataGridViewTextBoxColumn.DataPropertyName = "個装入り数"
        Me.個装入り数DataGridViewTextBoxColumn.HeaderText = "個装入り数"
        Me.個装入り数DataGridViewTextBoxColumn.Name = "個装入り数DataGridViewTextBoxColumn"
        '
        '外装資材記号DataGridViewTextBoxColumn
        '
        Me.外装資材記号DataGridViewTextBoxColumn.DataPropertyName = "外装資材記号"
        Me.外装資材記号DataGridViewTextBoxColumn.HeaderText = "外装資材記号"
        Me.外装資材記号DataGridViewTextBoxColumn.Name = "外装資材記号DataGridViewTextBoxColumn"
        '
        'モジュール手順SEQDataGridViewTextBoxColumn
        '
        Me.モジュール手順SEQDataGridViewTextBoxColumn.DataPropertyName = "モジュール手順SEQ"
        Me.モジュール手順SEQDataGridViewTextBoxColumn.HeaderText = "モジュール手順SEQ"
        Me.モジュール手順SEQDataGridViewTextBoxColumn.Name = "モジュール手順SEQDataGridViewTextBoxColumn"
        '
        '内装入り数DataGridViewTextBoxColumn
        '
        Me.内装入り数DataGridViewTextBoxColumn.DataPropertyName = "内装入り数"
        Me.内装入り数DataGridViewTextBoxColumn.HeaderText = "内装入り数"
        Me.内装入り数DataGridViewTextBoxColumn.Name = "内装入り数DataGridViewTextBoxColumn"
        '
        '副資材1DataGridViewTextBoxColumn
        '
        Me.副資材1DataGridViewTextBoxColumn.DataPropertyName = "副資材1"
        Me.副資材1DataGridViewTextBoxColumn.HeaderText = "副資材1"
        Me.副資材1DataGridViewTextBoxColumn.Name = "副資材1DataGridViewTextBoxColumn"
        '
        '必要数1DataGridViewTextBoxColumn
        '
        Me.必要数1DataGridViewTextBoxColumn.DataPropertyName = "必要数1"
        Me.必要数1DataGridViewTextBoxColumn.HeaderText = "必要数1"
        Me.必要数1DataGridViewTextBoxColumn.Name = "必要数1DataGridViewTextBoxColumn"
        '
        '副資材2DataGridViewTextBoxColumn
        '
        Me.副資材2DataGridViewTextBoxColumn.DataPropertyName = "副資材2"
        Me.副資材2DataGridViewTextBoxColumn.HeaderText = "副資材2"
        Me.副資材2DataGridViewTextBoxColumn.Name = "副資材2DataGridViewTextBoxColumn"
        '
        '必要数2DataGridViewTextBoxColumn
        '
        Me.必要数2DataGridViewTextBoxColumn.DataPropertyName = "必要数2"
        Me.必要数2DataGridViewTextBoxColumn.HeaderText = "必要数2"
        Me.必要数2DataGridViewTextBoxColumn.Name = "必要数2DataGridViewTextBoxColumn"
        '
        '副資材3DataGridViewTextBoxColumn
        '
        Me.副資材3DataGridViewTextBoxColumn.DataPropertyName = "副資材3"
        Me.副資材3DataGridViewTextBoxColumn.HeaderText = "副資材3"
        Me.副資材3DataGridViewTextBoxColumn.Name = "副資材3DataGridViewTextBoxColumn"
        '
        '必要数3DataGridViewTextBoxColumn
        '
        Me.必要数3DataGridViewTextBoxColumn.DataPropertyName = "必要数3"
        Me.必要数3DataGridViewTextBoxColumn.HeaderText = "必要数3"
        Me.必要数3DataGridViewTextBoxColumn.Name = "必要数3DataGridViewTextBoxColumn"
        '
        '副資材4DataGridViewTextBoxColumn
        '
        Me.副資材4DataGridViewTextBoxColumn.DataPropertyName = "副資材4"
        Me.副資材4DataGridViewTextBoxColumn.HeaderText = "副資材4"
        Me.副資材4DataGridViewTextBoxColumn.Name = "副資材4DataGridViewTextBoxColumn"
        '
        '必要数4DataGridViewTextBoxColumn
        '
        Me.必要数4DataGridViewTextBoxColumn.DataPropertyName = "必要数4"
        Me.必要数4DataGridViewTextBoxColumn.HeaderText = "必要数4"
        Me.必要数4DataGridViewTextBoxColumn.Name = "必要数4DataGridViewTextBoxColumn"
        '
        '副資材5DataGridViewTextBoxColumn
        '
        Me.副資材5DataGridViewTextBoxColumn.DataPropertyName = "副資材5"
        Me.副資材5DataGridViewTextBoxColumn.HeaderText = "副資材5"
        Me.副資材5DataGridViewTextBoxColumn.Name = "副資材5DataGridViewTextBoxColumn"
        '
        '必要数5DataGridViewTextBoxColumn
        '
        Me.必要数5DataGridViewTextBoxColumn.DataPropertyName = "必要数5"
        Me.必要数5DataGridViewTextBoxColumn.HeaderText = "必要数5"
        Me.必要数5DataGridViewTextBoxColumn.Name = "必要数5DataGridViewTextBoxColumn"
        '
        '副資材6DataGridViewTextBoxColumn
        '
        Me.副資材6DataGridViewTextBoxColumn.DataPropertyName = "副資材6"
        Me.副資材6DataGridViewTextBoxColumn.HeaderText = "副資材6"
        Me.副資材6DataGridViewTextBoxColumn.Name = "副資材6DataGridViewTextBoxColumn"
        '
        '必要数6DataGridViewTextBoxColumn
        '
        Me.必要数6DataGridViewTextBoxColumn.DataPropertyName = "必要数6"
        Me.必要数6DataGridViewTextBoxColumn.HeaderText = "必要数6"
        Me.必要数6DataGridViewTextBoxColumn.Name = "必要数6DataGridViewTextBoxColumn"
        '
        '副資材7DataGridViewTextBoxColumn
        '
        Me.副資材7DataGridViewTextBoxColumn.DataPropertyName = "副資材7"
        Me.副資材7DataGridViewTextBoxColumn.HeaderText = "副資材7"
        Me.副資材7DataGridViewTextBoxColumn.Name = "副資材7DataGridViewTextBoxColumn"
        '
        '必要数7DataGridViewTextBoxColumn
        '
        Me.必要数7DataGridViewTextBoxColumn.DataPropertyName = "必要数7"
        Me.必要数7DataGridViewTextBoxColumn.HeaderText = "必要数7"
        Me.必要数7DataGridViewTextBoxColumn.Name = "必要数7DataGridViewTextBoxColumn"
        '
        '副資材8DataGridViewTextBoxColumn
        '
        Me.副資材8DataGridViewTextBoxColumn.DataPropertyName = "副資材8"
        Me.副資材8DataGridViewTextBoxColumn.HeaderText = "副資材8"
        Me.副資材8DataGridViewTextBoxColumn.Name = "副資材8DataGridViewTextBoxColumn"
        '
        '必要数8DataGridViewTextBoxColumn
        '
        Me.必要数8DataGridViewTextBoxColumn.DataPropertyName = "必要数8"
        Me.必要数8DataGridViewTextBoxColumn.HeaderText = "必要数8"
        Me.必要数8DataGridViewTextBoxColumn.Name = "必要数8DataGridViewTextBoxColumn"
        '
        '副資材9DataGridViewTextBoxColumn
        '
        Me.副資材9DataGridViewTextBoxColumn.DataPropertyName = "副資材9"
        Me.副資材9DataGridViewTextBoxColumn.HeaderText = "副資材9"
        Me.副資材9DataGridViewTextBoxColumn.Name = "副資材9DataGridViewTextBoxColumn"
        '
        '必要数9DataGridViewTextBoxColumn
        '
        Me.必要数9DataGridViewTextBoxColumn.DataPropertyName = "必要数9"
        Me.必要数9DataGridViewTextBoxColumn.HeaderText = "必要数9"
        Me.必要数9DataGridViewTextBoxColumn.Name = "必要数9DataGridViewTextBoxColumn"
        '
        '副資材10DataGridViewTextBoxColumn
        '
        Me.副資材10DataGridViewTextBoxColumn.DataPropertyName = "副資材10"
        Me.副資材10DataGridViewTextBoxColumn.HeaderText = "副資材10"
        Me.副資材10DataGridViewTextBoxColumn.Name = "副資材10DataGridViewTextBoxColumn"
        '
        '必要数10DataGridViewTextBoxColumn
        '
        Me.必要数10DataGridViewTextBoxColumn.DataPropertyName = "必要数10"
        Me.必要数10DataGridViewTextBoxColumn.HeaderText = "必要数10"
        Me.必要数10DataGridViewTextBoxColumn.Name = "必要数10DataGridViewTextBoxColumn"
        '
        '副資材11DataGridViewTextBoxColumn
        '
        Me.副資材11DataGridViewTextBoxColumn.DataPropertyName = "副資材11"
        Me.副資材11DataGridViewTextBoxColumn.HeaderText = "副資材11"
        Me.副資材11DataGridViewTextBoxColumn.Name = "副資材11DataGridViewTextBoxColumn"
        '
        '必要数11DataGridViewTextBoxColumn
        '
        Me.必要数11DataGridViewTextBoxColumn.DataPropertyName = "必要数11"
        Me.必要数11DataGridViewTextBoxColumn.HeaderText = "必要数11"
        Me.必要数11DataGridViewTextBoxColumn.Name = "必要数11DataGridViewTextBoxColumn"
        '
        '副資材12DataGridViewTextBoxColumn
        '
        Me.副資材12DataGridViewTextBoxColumn.DataPropertyName = "副資材12"
        Me.副資材12DataGridViewTextBoxColumn.HeaderText = "副資材12"
        Me.副資材12DataGridViewTextBoxColumn.Name = "副資材12DataGridViewTextBoxColumn"
        '
        '必要数12DataGridViewTextBoxColumn
        '
        Me.必要数12DataGridViewTextBoxColumn.DataPropertyName = "必要数12"
        Me.必要数12DataGridViewTextBoxColumn.HeaderText = "必要数12"
        Me.必要数12DataGridViewTextBoxColumn.Name = "必要数12DataGridViewTextBoxColumn"
        '
        '副資材13DataGridViewTextBoxColumn
        '
        Me.副資材13DataGridViewTextBoxColumn.DataPropertyName = "副資材13"
        Me.副資材13DataGridViewTextBoxColumn.HeaderText = "副資材13"
        Me.副資材13DataGridViewTextBoxColumn.Name = "副資材13DataGridViewTextBoxColumn"
        '
        '必要数13DataGridViewTextBoxColumn
        '
        Me.必要数13DataGridViewTextBoxColumn.DataPropertyName = "必要数13"
        Me.必要数13DataGridViewTextBoxColumn.HeaderText = "必要数13"
        Me.必要数13DataGridViewTextBoxColumn.Name = "必要数13DataGridViewTextBoxColumn"
        '
        '副資材14DataGridViewTextBoxColumn
        '
        Me.副資材14DataGridViewTextBoxColumn.DataPropertyName = "副資材14"
        Me.副資材14DataGridViewTextBoxColumn.HeaderText = "副資材14"
        Me.副資材14DataGridViewTextBoxColumn.Name = "副資材14DataGridViewTextBoxColumn"
        '
        '必要数14DataGridViewTextBoxColumn
        '
        Me.必要数14DataGridViewTextBoxColumn.DataPropertyName = "必要数14"
        Me.必要数14DataGridViewTextBoxColumn.HeaderText = "必要数14"
        Me.必要数14DataGridViewTextBoxColumn.Name = "必要数14DataGridViewTextBoxColumn"
        '
        '副資材15DataGridViewTextBoxColumn
        '
        Me.副資材15DataGridViewTextBoxColumn.DataPropertyName = "副資材15"
        Me.副資材15DataGridViewTextBoxColumn.HeaderText = "副資材15"
        Me.副資材15DataGridViewTextBoxColumn.Name = "副資材15DataGridViewTextBoxColumn"
        '
        '必要数15DataGridViewTextBoxColumn
        '
        Me.必要数15DataGridViewTextBoxColumn.DataPropertyName = "必要数15"
        Me.必要数15DataGridViewTextBoxColumn.HeaderText = "必要数15"
        Me.必要数15DataGridViewTextBoxColumn.Name = "必要数15DataGridViewTextBoxColumn"
        '
        '副資材16DataGridViewTextBoxColumn
        '
        Me.副資材16DataGridViewTextBoxColumn.DataPropertyName = "副資材16"
        Me.副資材16DataGridViewTextBoxColumn.HeaderText = "副資材16"
        Me.副資材16DataGridViewTextBoxColumn.Name = "副資材16DataGridViewTextBoxColumn"
        '
        '必要数16DataGridViewTextBoxColumn
        '
        Me.必要数16DataGridViewTextBoxColumn.DataPropertyName = "必要数16"
        Me.必要数16DataGridViewTextBoxColumn.HeaderText = "必要数16"
        Me.必要数16DataGridViewTextBoxColumn.Name = "必要数16DataGridViewTextBoxColumn"
        '
        '副資材17DataGridViewTextBoxColumn
        '
        Me.副資材17DataGridViewTextBoxColumn.DataPropertyName = "副資材17"
        Me.副資材17DataGridViewTextBoxColumn.HeaderText = "副資材17"
        Me.副資材17DataGridViewTextBoxColumn.Name = "副資材17DataGridViewTextBoxColumn"
        '
        '必要数17DataGridViewTextBoxColumn
        '
        Me.必要数17DataGridViewTextBoxColumn.DataPropertyName = "必要数17"
        Me.必要数17DataGridViewTextBoxColumn.HeaderText = "必要数17"
        Me.必要数17DataGridViewTextBoxColumn.Name = "必要数17DataGridViewTextBoxColumn"
        '
        '副資材18DataGridViewTextBoxColumn
        '
        Me.副資材18DataGridViewTextBoxColumn.DataPropertyName = "副資材18"
        Me.副資材18DataGridViewTextBoxColumn.HeaderText = "副資材18"
        Me.副資材18DataGridViewTextBoxColumn.Name = "副資材18DataGridViewTextBoxColumn"
        '
        '必要数18DataGridViewTextBoxColumn
        '
        Me.必要数18DataGridViewTextBoxColumn.DataPropertyName = "必要数18"
        Me.必要数18DataGridViewTextBoxColumn.HeaderText = "必要数18"
        Me.必要数18DataGridViewTextBoxColumn.Name = "必要数18DataGridViewTextBoxColumn"
        '
        '副資材19DataGridViewTextBoxColumn
        '
        Me.副資材19DataGridViewTextBoxColumn.DataPropertyName = "副資材19"
        Me.副資材19DataGridViewTextBoxColumn.HeaderText = "副資材19"
        Me.副資材19DataGridViewTextBoxColumn.Name = "副資材19DataGridViewTextBoxColumn"
        '
        '必要数19DataGridViewTextBoxColumn
        '
        Me.必要数19DataGridViewTextBoxColumn.DataPropertyName = "必要数19"
        Me.必要数19DataGridViewTextBoxColumn.HeaderText = "必要数19"
        Me.必要数19DataGridViewTextBoxColumn.Name = "必要数19DataGridViewTextBoxColumn"
        '
        '副資材20DataGridViewTextBoxColumn
        '
        Me.副資材20DataGridViewTextBoxColumn.DataPropertyName = "副資材20"
        Me.副資材20DataGridViewTextBoxColumn.HeaderText = "副資材20"
        Me.副資材20DataGridViewTextBoxColumn.Name = "副資材20DataGridViewTextBoxColumn"
        '
        '必要数20DataGridViewTextBoxColumn
        '
        Me.必要数20DataGridViewTextBoxColumn.DataPropertyName = "必要数20"
        Me.必要数20DataGridViewTextBoxColumn.HeaderText = "必要数20"
        Me.必要数20DataGridViewTextBoxColumn.Name = "必要数20DataGridViewTextBoxColumn"
        '
        '基本部番ハイフン付DataGridViewTextBoxColumn
        '
        Me.基本部番ハイフン付DataGridViewTextBoxColumn.DataPropertyName = "基本部番ハイフン付"
        Me.基本部番ハイフン付DataGridViewTextBoxColumn.HeaderText = "基本部番ハイフン付"
        Me.基本部番ハイフン付DataGridViewTextBoxColumn.Name = "基本部番ハイフン付DataGridViewTextBoxColumn"
        '
        '単品部品総数DataGridViewTextBoxColumn
        '
        Me.単品部品総数DataGridViewTextBoxColumn.DataPropertyName = "単品部品総数"
        Me.単品部品総数DataGridViewTextBoxColumn.HeaderText = "単品部品総数"
        Me.単品部品総数DataGridViewTextBoxColumn.Name = "単品部品総数DataGridViewTextBoxColumn"
        '
        '部品点数DataGridViewTextBoxColumn
        '
        Me.部品点数DataGridViewTextBoxColumn.DataPropertyName = "部品点数"
        Me.部品点数DataGridViewTextBoxColumn.HeaderText = "部品点数"
        Me.部品点数DataGridViewTextBoxColumn.Name = "部品点数DataGridViewTextBoxColumn"
        '
        '防錆回数DataGridViewTextBoxColumn
        '
        Me.防錆回数DataGridViewTextBoxColumn.DataPropertyName = "防錆回数"
        Me.防錆回数DataGridViewTextBoxColumn.HeaderText = "防錆回数"
        Me.防錆回数DataGridViewTextBoxColumn.Name = "防錆回数DataGridViewTextBoxColumn"
        '
        '個装数DataGridViewTextBoxColumn
        '
        Me.個装数DataGridViewTextBoxColumn.DataPropertyName = "個装数"
        Me.個装数DataGridViewTextBoxColumn.HeaderText = "個装数"
        Me.個装数DataGridViewTextBoxColumn.Name = "個装数DataGridViewTextBoxColumn"
        '
        '内装資材数DataGridViewTextBoxColumn
        '
        Me.内装資材数DataGridViewTextBoxColumn.DataPropertyName = "内装資材数"
        Me.内装資材数DataGridViewTextBoxColumn.HeaderText = "内装資材数"
        Me.内装資材数DataGridViewTextBoxColumn.Name = "内装資材数DataGridViewTextBoxColumn"
        '
        'カートン数DataGridViewTextBoxColumn
        '
        Me.カートン数DataGridViewTextBoxColumn.DataPropertyName = "カートン数"
        Me.カートン数DataGridViewTextBoxColumn.HeaderText = "カートン数"
        Me.カートン数DataGridViewTextBoxColumn.Name = "カートン数DataGridViewTextBoxColumn"
        '
        'リターナブル容器数DataGridViewTextBoxColumn
        '
        Me.リターナブル容器数DataGridViewTextBoxColumn.DataPropertyName = "リターナブル容器数"
        Me.リターナブル容器数DataGridViewTextBoxColumn.HeaderText = "リターナブル容器数"
        Me.リターナブル容器数DataGridViewTextBoxColumn.Name = "リターナブル容器数DataGridViewTextBoxColumn"
        '
        'ENG発泡材数DataGridViewTextBoxColumn
        '
        Me.ENG発泡材数DataGridViewTextBoxColumn.DataPropertyName = "ENG発泡材数"
        Me.ENG発泡材数DataGridViewTextBoxColumn.HeaderText = "ENG発泡材数"
        Me.ENG発泡材数DataGridViewTextBoxColumn.Name = "ENG発泡材数DataGridViewTextBoxColumn"
        '
        '積み付け回数DataGridViewTextBoxColumn
        '
        Me.積み付け回数DataGridViewTextBoxColumn.DataPropertyName = "積み付け回数"
        Me.積み付け回数DataGridViewTextBoxColumn.HeaderText = "積み付け回数"
        Me.積み付け回数DataGridViewTextBoxColumn.Name = "積み付け回数DataGridViewTextBoxColumn"
        '
        'パネルケース数DataGridViewTextBoxColumn
        '
        Me.パネルケース数DataGridViewTextBoxColumn.DataPropertyName = "パネルケース数"
        Me.パネルケース数DataGridViewTextBoxColumn.HeaderText = "パネルケース数"
        Me.パネルケース数DataGridViewTextBoxColumn.Name = "パネルケース数DataGridViewTextBoxColumn"
        '
        'スカシケース数DataGridViewTextBoxColumn
        '
        Me.スカシケース数DataGridViewTextBoxColumn.DataPropertyName = "スカシケース数"
        Me.スカシケース数DataGridViewTextBoxColumn.HeaderText = "スカシケース数"
        Me.スカシケース数DataGridViewTextBoxColumn.Name = "スカシケース数DataGridViewTextBoxColumn"
        '
        '外装用段ボールパット使用数DataGridViewTextBoxColumn
        '
        Me.外装用段ボールパット使用数DataGridViewTextBoxColumn.DataPropertyName = "外装用段ボールパット使用数"
        Me.外装用段ボールパット使用数DataGridViewTextBoxColumn.HeaderText = "外装用段ボールパット使用数"
        Me.外装用段ボールパット使用数DataGridViewTextBoxColumn.Name = "外装用段ボールパット使用数DataGridViewTextBoxColumn"
        '
        '外装用箱型ポリ袋DataGridViewTextBoxColumn
        '
        Me.外装用箱型ポリ袋DataGridViewTextBoxColumn.DataPropertyName = "外装用箱型ポリ袋"
        Me.外装用箱型ポリ袋DataGridViewTextBoxColumn.HeaderText = "外装用箱型ポリ袋"
        Me.外装用箱型ポリ袋DataGridViewTextBoxColumn.Name = "外装用箱型ポリ袋DataGridViewTextBoxColumn"
        '
        '外装用ボルト使用数DataGridViewTextBoxColumn
        '
        Me.外装用ボルト使用数DataGridViewTextBoxColumn.DataPropertyName = "外装用ボルト使用数"
        Me.外装用ボルト使用数DataGridViewTextBoxColumn.HeaderText = "外装用ボルト使用数"
        Me.外装用ボルト使用数DataGridViewTextBoxColumn.Name = "外装用ボルト使用数DataGridViewTextBoxColumn"
        '
        '外装用副資材使用数DataGridViewTextBoxColumn
        '
        Me.外装用副資材使用数DataGridViewTextBoxColumn.DataPropertyName = "外装用副資材使用数"
        Me.外装用副資材使用数DataGridViewTextBoxColumn.HeaderText = "外装用副資材使用数"
        Me.外装用副資材使用数DataGridViewTextBoxColumn.Name = "外装用副資材使用数DataGridViewTextBoxColumn"
        '
        '外直部品総数DataGridViewTextBoxColumn
        '
        Me.外直部品総数DataGridViewTextBoxColumn.DataPropertyName = "外直部品総数"
        Me.外直部品総数DataGridViewTextBoxColumn.HeaderText = "外直部品総数"
        Me.外直部品総数DataGridViewTextBoxColumn.Name = "外直部品総数DataGridViewTextBoxColumn"
        '
        '外直の防錆回数DataGridViewTextBoxColumn
        '
        Me.外直の防錆回数DataGridViewTextBoxColumn.DataPropertyName = "外直の防錆回数"
        Me.外直の防錆回数DataGridViewTextBoxColumn.HeaderText = "外直の防錆回数"
        Me.外直の防錆回数DataGridViewTextBoxColumn.Name = "外直の防錆回数DataGridViewTextBoxColumn"
        '
        '外装ケース数DataGridViewTextBoxColumn
        '
        Me.外装ケース数DataGridViewTextBoxColumn.DataPropertyName = "外装ケース数"
        Me.外装ケース数DataGridViewTextBoxColumn.HeaderText = "外装ケース数"
        Me.外装ケース数DataGridViewTextBoxColumn.Name = "外装ケース数DataGridViewTextBoxColumn"
        '
        '部品点数集計DataGridViewTextBoxColumn
        '
        Me.部品点数集計DataGridViewTextBoxColumn.DataPropertyName = "部品点数_集計"
        Me.部品点数集計DataGridViewTextBoxColumn.HeaderText = "部品点数_集計"
        Me.部品点数集計DataGridViewTextBoxColumn.Name = "部品点数集計DataGridViewTextBoxColumn"
        '
        '個装資材費DataGridViewTextBoxColumn
        '
        Me.個装資材費DataGridViewTextBoxColumn.DataPropertyName = "個装資材費"
        Me.個装資材費DataGridViewTextBoxColumn.HeaderText = "個装資材費"
        Me.個装資材費DataGridViewTextBoxColumn.Name = "個装資材費DataGridViewTextBoxColumn"
        '
        '内装資材費DataGridViewTextBoxColumn
        '
        Me.内装資材費DataGridViewTextBoxColumn.DataPropertyName = "内装資材費"
        Me.内装資材費DataGridViewTextBoxColumn.HeaderText = "内装資材費"
        Me.内装資材費DataGridViewTextBoxColumn.Name = "内装資材費DataGridViewTextBoxColumn"
        '
        '外装資材費DataGridViewTextBoxColumn
        '
        Me.外装資材費DataGridViewTextBoxColumn.DataPropertyName = "外装資材費"
        Me.外装資材費DataGridViewTextBoxColumn.HeaderText = "外装資材費"
        Me.外装資材費DataGridViewTextBoxColumn.Name = "外装資材費DataGridViewTextBoxColumn"
        '
        '個装作業DataGridViewTextBoxColumn
        '
        Me.個装作業DataGridViewTextBoxColumn.DataPropertyName = "個装作業"
        Me.個装作業DataGridViewTextBoxColumn.HeaderText = "個装作業"
        Me.個装作業DataGridViewTextBoxColumn.Name = "個装作業DataGridViewTextBoxColumn"
        '
        '内装作業DataGridViewTextBoxColumn
        '
        Me.内装作業DataGridViewTextBoxColumn.DataPropertyName = "内装作業"
        Me.内装作業DataGridViewTextBoxColumn.HeaderText = "内装作業"
        Me.内装作業DataGridViewTextBoxColumn.Name = "内装作業DataGridViewTextBoxColumn"
        '
        '外装作業DataGridViewTextBoxColumn
        '
        Me.外装作業DataGridViewTextBoxColumn.DataPropertyName = "外装作業"
        Me.外装作業DataGridViewTextBoxColumn.HeaderText = "外装作業"
        Me.外装作業DataGridViewTextBoxColumn.Name = "外装作業DataGridViewTextBoxColumn"
        '
        '作業計DataGridViewTextBoxColumn
        '
        Me.作業計DataGridViewTextBoxColumn.DataPropertyName = "作業計"
        Me.作業計DataGridViewTextBoxColumn.HeaderText = "作業計"
        Me.作業計DataGridViewTextBoxColumn.Name = "作業計DataGridViewTextBoxColumn"
        '
        '個内装資材DataGridViewTextBoxColumn
        '
        Me.個内装資材DataGridViewTextBoxColumn.DataPropertyName = "個_内装資材"
        Me.個内装資材DataGridViewTextBoxColumn.HeaderText = "個_内装資材"
        Me.個内装資材DataGridViewTextBoxColumn.Name = "個内装資材DataGridViewTextBoxColumn"
        '
        '外装資材DataGridViewTextBoxColumn
        '
        Me.外装資材DataGridViewTextBoxColumn.DataPropertyName = "外装資材"
        Me.外装資材DataGridViewTextBoxColumn.HeaderText = "外装資材"
        Me.外装資材DataGridViewTextBoxColumn.Name = "外装資材DataGridViewTextBoxColumn"
        '
        '資材計DataGridViewTextBoxColumn
        '
        Me.資材計DataGridViewTextBoxColumn.DataPropertyName = "資材計"
        Me.資材計DataGridViewTextBoxColumn.HeaderText = "資材計"
        Me.資材計DataGridViewTextBoxColumn.Name = "資材計DataGridViewTextBoxColumn"
        '
        '見積NoDataGridViewTextBoxColumn
        '
        Me.見積NoDataGridViewTextBoxColumn.DataPropertyName = "見積No"
        Me.見積NoDataGridViewTextBoxColumn.HeaderText = "見積No"
        Me.見積NoDataGridViewTextBoxColumn.Name = "見積NoDataGridViewTextBoxColumn"
        '
        'Txt_DIST
        '
        Me.Txt_DIST.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt_DIST.Location = New System.Drawing.Point(30, 44)
        Me.Txt_DIST.Name = "Txt_DIST"
        Me.Txt_DIST.Size = New System.Drawing.Size(101, 23)
        Me.Txt_DIST.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "単品部品総数"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(134, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "部品点数"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(137, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(101, 23)
        Me.TextBox1.TabIndex = 15
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(244, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(101, 23)
        Me.TextBox2.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(241, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "防錆回数"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(565, 44)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(101, 23)
        Me.TextBox3.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(562, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "カートン数"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(458, 44)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(101, 23)
        Me.TextBox4.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(455, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "内装資材数"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(351, 44)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(101, 23)
        Me.TextBox5.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(348, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "個装数"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(888, 44)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(101, 23)
        Me.TextBox6.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(885, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "積み付け回数"
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(781, 44)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(101, 23)
        Me.TextBox7.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(778, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 16)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "ENG発泡材数"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(674, 44)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(101, 23)
        Me.TextBox8.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(671, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 16)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "リターナブル容器数"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(1102, 44)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(101, 23)
        Me.TextBox9.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(1099, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 16)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "スカシケース数"
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(995, 44)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(101, 23)
        Me.TextBox10.TabIndex = 31
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(992, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 16)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "パネルケース数"
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(351, 172)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(101, 23)
        Me.TextBox11.TabIndex = 55
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(348, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "外装資材費"
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(244, 172)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(101, 23)
        Me.TextBox12.TabIndex = 53
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(241, 153)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "内装資材費"
        '
        'TextBox13
        '
        Me.TextBox13.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(137, 172)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(101, 23)
        Me.TextBox13.TabIndex = 51
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(134, 153)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "個装資材費"
        '
        'TextBox14
        '
        Me.TextBox14.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(30, 172)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(101, 23)
        Me.TextBox14.TabIndex = 49
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(27, 153)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 16)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "部品点数_集計"
        '
        'TextBox15
        '
        Me.TextBox15.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(901, 106)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(101, 23)
        Me.TextBox15.TabIndex = 46
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(898, 87)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 16)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "外装ケース数"
        '
        'TextBox16
        '
        Me.TextBox16.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox16.Location = New System.Drawing.Point(781, 106)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(101, 23)
        Me.TextBox16.TabIndex = 45
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(778, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(117, 16)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "外直の防錆回数"
        '
        'TextBox17
        '
        Me.TextBox17.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox17.Location = New System.Drawing.Point(674, 106)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(101, 23)
        Me.TextBox17.TabIndex = 43
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(671, 87)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "外直部品総数"
        '
        'TextBox18
        '
        Me.TextBox18.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox18.Location = New System.Drawing.Point(523, 106)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(101, 23)
        Me.TextBox18.TabIndex = 40
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(520, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(152, 16)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "外装用副資材使用数"
        '
        'TextBox19
        '
        Me.TextBox19.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox19.Location = New System.Drawing.Point(376, 106)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(101, 23)
        Me.TextBox19.TabIndex = 39
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(373, 87)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(141, 16)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "外装用ボルト使用数"
        '
        'TextBox20
        '
        Me.TextBox20.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox20.Location = New System.Drawing.Point(244, 106)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(101, 23)
        Me.TextBox20.TabIndex = 37
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(241, 87)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(126, 16)
        Me.Label23.TabIndex = 36
        Me.Label23.Text = "外装用箱型ポリ袋"
        '
        'TextBox21
        '
        Me.TextBox21.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox21.Location = New System.Drawing.Point(30, 106)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(101, 23)
        Me.TextBox21.TabIndex = 34
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(30, 87)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(192, 16)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "外装用段ボールパット使用数"
        '
        'TextBox26
        '
        Me.TextBox26.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox26.Location = New System.Drawing.Point(1102, 172)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(101, 23)
        Me.TextBox26.TabIndex = 68
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(1099, 153)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 16)
        Me.Label29.TabIndex = 69
        Me.Label29.Text = "資材計"
        '
        'TextBox27
        '
        Me.TextBox27.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox27.Location = New System.Drawing.Point(993, 172)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(101, 23)
        Me.TextBox27.TabIndex = 67
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(990, 153)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(72, 16)
        Me.Label30.TabIndex = 66
        Me.Label30.Text = "外装資材"
        '
        'TextBox28
        '
        Me.TextBox28.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox28.Location = New System.Drawing.Point(886, 172)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(101, 23)
        Me.TextBox28.TabIndex = 65
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(883, 153)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(93, 16)
        Me.Label31.TabIndex = 64
        Me.Label31.Text = "個_内装資材"
        '
        'TextBox29
        '
        Me.TextBox29.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox29.Location = New System.Drawing.Point(779, 172)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(101, 23)
        Me.TextBox29.TabIndex = 62
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.Location = New System.Drawing.Point(776, 153)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(56, 16)
        Me.Label32.TabIndex = 63
        Me.Label32.Text = "作業計"
        '
        'TextBox30
        '
        Me.TextBox30.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox30.Location = New System.Drawing.Point(672, 172)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(101, 23)
        Me.TextBox30.TabIndex = 61
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.Location = New System.Drawing.Point(669, 153)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 16)
        Me.Label33.TabIndex = 60
        Me.Label33.Text = "外装作業"
        '
        'TextBox31
        '
        Me.TextBox31.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox31.Location = New System.Drawing.Point(565, 172)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New System.Drawing.Size(101, 23)
        Me.TextBox31.TabIndex = 59
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.Location = New System.Drawing.Point(562, 153)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 16)
        Me.Label34.TabIndex = 58
        Me.Label34.Text = "内装作業"
        '
        'TextBox32
        '
        Me.TextBox32.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox32.Location = New System.Drawing.Point(458, 172)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New System.Drawing.Size(101, 23)
        Me.TextBox32.TabIndex = 56
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.Location = New System.Drawing.Point(455, 153)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(72, 16)
        Me.Label35.TabIndex = 57
        Me.Label35.Text = "個装作業"
        '
        'F_Chousei
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 619)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "F_Chousei"
        Me.Text = "調整工数登録"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GV_Chousei, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DS_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTTCCCLotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Target As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GV_Chousei As DataGridView
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Touroku As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DS_T As DS_T
    Friend WithEvents DTTCCCLotBindingSource As BindingSource
    Friend WithEvents TA_T_CCC_Lot As DS_TTableAdapters.TA_T_CCC_Lot
    Friend WithEvents ｺﾝﾄﾛｰﾙNODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents モデフNODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ケースNO1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 代表DISTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 部品群DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 包装ロットNODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 包装ロット連番DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 年度2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents モデル2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents タイプ1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents オプション1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 群DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 包装数量DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装ラインDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装ラインDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 包装ライン外装DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 基本部番DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装資材記号DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装手順SEQDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 部品収容数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装資材記号DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装手順SEQDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装入り数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装資材記号DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents モジュール手順SEQDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装入り数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材4DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数4DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材5DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数5DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材6DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数6DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材7DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数7DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材8DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数8DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材9DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数9DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材10DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数10DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材11DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数11DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材12DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数12DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材13DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数13DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材14DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数14DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材15DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数15DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材16DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数16DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材17DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数17DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材18DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数18DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材19DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数19DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 副資材20DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 必要数20DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 基本部番ハイフン付DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 単品部品総数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 部品点数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 防錆回数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装資材数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents カートン数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents リターナブル容器数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ENG発泡材数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 積み付け回数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents パネルケース数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents スカシケース数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装用段ボールパット使用数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装用箱型ポリ袋DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装用ボルト使用数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装用副資材使用数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外直部品総数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外直の防錆回数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装ケース数DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 部品点数集計DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装資材費DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装資材費DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装資材費DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個装作業DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 内装作業DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装作業DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 作業計DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 個内装資材DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 外装資材DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 資材計DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents 見積NoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TextBox26 As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TextBox29 As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents TextBox30 As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_DIST As TextBox
    Friend WithEvents Label2 As Label
End Class
