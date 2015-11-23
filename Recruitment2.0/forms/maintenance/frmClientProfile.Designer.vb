<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientProfile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientProfile))
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.tabInfo = New System.Windows.Forms.TabControl()
        Me.tpAccountInfo = New System.Windows.Forms.TabPage()
        Me.cboAcctType = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblRefNo = New System.Windows.Forms.Label()
        Me.cboHandledBy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWebURL = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFaxNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPhoneNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAcctName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpContactInfo = New System.Windows.Forms.TabPage()
        Me.dgvContact = New System.Windows.Forms.DataGridView()
        Me.colSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlCInfo = New System.Windows.Forms.Panel()
        Me.tsContactOps = New System.Windows.Forms.ToolStrip()
        Me.tsbCCancel = New System.Windows.Forms.ToolStripButton()
        Me.txbCSave = New System.Windows.Forms.ToolStripButton()
        Me.txtCOthers = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCMobile = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCPhone = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCDesignation = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tsOps = New System.Windows.Forms.ToolStrip()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.tsbSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.pnlInfo.SuspendLayout()
        Me.tabInfo.SuspendLayout()
        Me.tpAccountInfo.SuspendLayout()
        Me.tpContactInfo.SuspendLayout()
        CType(Me.dgvContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCInfo.SuspendLayout()
        Me.tsContactOps.SuspendLayout()
        Me.tsOps.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.AutoScroll = True
        Me.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfo.Controls.Add(Me.tabInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfo.Enabled = False
        Me.pnlInfo.Location = New System.Drawing.Point(0, 39)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(710, 497)
        Me.pnlInfo.TabIndex = 10
        '
        'tabInfo
        '
        Me.tabInfo.Controls.Add(Me.tpAccountInfo)
        Me.tabInfo.Controls.Add(Me.tpContactInfo)
        Me.tabInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabInfo.Location = New System.Drawing.Point(0, 0)
        Me.tabInfo.Name = "tabInfo"
        Me.tabInfo.SelectedIndex = 0
        Me.tabInfo.Size = New System.Drawing.Size(708, 495)
        Me.tabInfo.TabIndex = 2
        '
        'tpAccountInfo
        '
        Me.tpAccountInfo.AutoScroll = True
        Me.tpAccountInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpAccountInfo.Controls.Add(Me.cboAcctType)
        Me.tpAccountInfo.Controls.Add(Me.Label18)
        Me.tpAccountInfo.Controls.Add(Me.lblRefNo)
        Me.tpAccountInfo.Controls.Add(Me.cboHandledBy)
        Me.tpAccountInfo.Controls.Add(Me.Label2)
        Me.tpAccountInfo.Controls.Add(Me.txtWebURL)
        Me.tpAccountInfo.Controls.Add(Me.Label9)
        Me.tpAccountInfo.Controls.Add(Me.txtFaxNo)
        Me.tpAccountInfo.Controls.Add(Me.Label8)
        Me.tpAccountInfo.Controls.Add(Me.txtPhoneNo)
        Me.tpAccountInfo.Controls.Add(Me.Label7)
        Me.tpAccountInfo.Controls.Add(Me.txtAddr)
        Me.tpAccountInfo.Controls.Add(Me.Label6)
        Me.tpAccountInfo.Controls.Add(Me.Label4)
        Me.tpAccountInfo.Controls.Add(Me.txtAcctName)
        Me.tpAccountInfo.Controls.Add(Me.Label3)
        Me.tpAccountInfo.Location = New System.Drawing.Point(4, 24)
        Me.tpAccountInfo.Name = "tpAccountInfo"
        Me.tpAccountInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAccountInfo.Size = New System.Drawing.Size(700, 467)
        Me.tpAccountInfo.TabIndex = 0
        Me.tpAccountInfo.Text = "Account Information"
        Me.tpAccountInfo.UseVisualStyleBackColor = True
        '
        'cboAcctType
        '
        Me.cboAcctType.FormattingEnabled = True
        Me.cboAcctType.Location = New System.Drawing.Point(143, 34)
        Me.cboAcctType.Name = "cboAcctType"
        Me.cboAcctType.Size = New System.Drawing.Size(383, 23)
        Me.cboAcctType.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 15)
        Me.Label18.TabIndex = 91
        Me.Label18.Text = "Account Type"
        '
        'lblRefNo
        '
        Me.lblRefNo.AutoSize = True
        Me.lblRefNo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefNo.Location = New System.Drawing.Point(140, 14)
        Me.lblRefNo.Name = "lblRefNo"
        Me.lblRefNo.Size = New System.Drawing.Size(15, 15)
        Me.lblRefNo.TabIndex = 73
        Me.lblRefNo.Text = "[]"
        '
        'cboHandledBy
        '
        Me.cboHandledBy.FormattingEnabled = True
        Me.cboHandledBy.Location = New System.Drawing.Point(143, 178)
        Me.cboHandledBy.Name = "cboHandledBy"
        Me.cboHandledBy.Size = New System.Drawing.Size(383, 23)
        Me.cboHandledBy.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Handled By"
        '
        'txtWebURL
        '
        Me.txtWebURL.Location = New System.Drawing.Point(143, 154)
        Me.txtWebURL.Name = "txtWebURL"
        Me.txtWebURL.Size = New System.Drawing.Size(383, 23)
        Me.txtWebURL.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 15)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Website"
        '
        'txtFaxNo
        '
        Me.txtFaxNo.Location = New System.Drawing.Point(143, 130)
        Me.txtFaxNo.Name = "txtFaxNo"
        Me.txtFaxNo.Size = New System.Drawing.Size(186, 23)
        Me.txtFaxNo.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Fax No."
        '
        'txtPhoneNo
        '
        Me.txtPhoneNo.Location = New System.Drawing.Point(143, 106)
        Me.txtPhoneNo.Name = "txtPhoneNo"
        Me.txtPhoneNo.Size = New System.Drawing.Size(186, 23)
        Me.txtPhoneNo.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 15)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Phone No."
        '
        'txtAddr
        '
        Me.txtAddr.Location = New System.Drawing.Point(143, 82)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(383, 23)
        Me.txtAddr.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Account Reference #"
        '
        'txtAcctName
        '
        Me.txtAcctName.Location = New System.Drawing.Point(143, 58)
        Me.txtAcctName.Name = "txtAcctName"
        Me.txtAcctName.Size = New System.Drawing.Size(383, 23)
        Me.txtAcctName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Account Name"
        '
        'tpContactInfo
        '
        Me.tpContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpContactInfo.Controls.Add(Me.dgvContact)
        Me.tpContactInfo.Controls.Add(Me.pnlCInfo)
        Me.tpContactInfo.Location = New System.Drawing.Point(4, 24)
        Me.tpContactInfo.Name = "tpContactInfo"
        Me.tpContactInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpContactInfo.Size = New System.Drawing.Size(700, 467)
        Me.tpContactInfo.TabIndex = 1
        Me.tpContactInfo.Text = "Contact Information"
        Me.tpContactInfo.UseVisualStyleBackColor = True
        '
        'dgvContact
        '
        Me.dgvContact.AllowUserToAddRows = False
        Me.dgvContact.AllowUserToDeleteRows = False
        Me.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContact.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colRemove})
        Me.dgvContact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContact.Location = New System.Drawing.Point(3, 279)
        Me.dgvContact.Name = "dgvContact"
        Me.dgvContact.ReadOnly = True
        Me.dgvContact.Size = New System.Drawing.Size(692, 183)
        Me.dgvContact.TabIndex = 1
        '
        'colSelect
        '
        Me.colSelect.Frozen = True
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.ReadOnly = True
        Me.colSelect.Text = "Edit"
        Me.colSelect.UseColumnTextForButtonValue = True
        Me.colSelect.Width = 70
        '
        'colRemove
        '
        Me.colRemove.Frozen = True
        Me.colRemove.HeaderText = ""
        Me.colRemove.Name = "colRemove"
        Me.colRemove.ReadOnly = True
        Me.colRemove.Text = "Remove"
        Me.colRemove.UseColumnTextForButtonValue = True
        Me.colRemove.Width = 70
        '
        'pnlCInfo
        '
        Me.pnlCInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCInfo.Controls.Add(Me.tsContactOps)
        Me.pnlCInfo.Controls.Add(Me.txtCOthers)
        Me.pnlCInfo.Controls.Add(Me.Label17)
        Me.pnlCInfo.Controls.Add(Me.txtCMobile)
        Me.pnlCInfo.Controls.Add(Me.Label16)
        Me.pnlCInfo.Controls.Add(Me.txtCPhone)
        Me.pnlCInfo.Controls.Add(Me.Label14)
        Me.pnlCInfo.Controls.Add(Me.txtCEmail)
        Me.pnlCInfo.Controls.Add(Me.Label13)
        Me.pnlCInfo.Controls.Add(Me.txtCDesignation)
        Me.pnlCInfo.Controls.Add(Me.Label12)
        Me.pnlCInfo.Controls.Add(Me.Label11)
        Me.pnlCInfo.Controls.Add(Me.txtCName)
        Me.pnlCInfo.Controls.Add(Me.Label10)
        Me.pnlCInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCInfo.Location = New System.Drawing.Point(3, 3)
        Me.pnlCInfo.Name = "pnlCInfo"
        Me.pnlCInfo.Size = New System.Drawing.Size(692, 276)
        Me.pnlCInfo.TabIndex = 0
        '
        'tsContactOps
        '
        Me.tsContactOps.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsContactOps.Enabled = False
        Me.tsContactOps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCCancel, Me.txbCSave})
        Me.tsContactOps.Location = New System.Drawing.Point(0, 235)
        Me.tsContactOps.Name = "tsContactOps"
        Me.tsContactOps.Size = New System.Drawing.Size(690, 39)
        Me.tsContactOps.TabIndex = 114
        Me.tsContactOps.Text = "ToolStrip1"
        '
        'tsbCCancel
        '
        Me.tsbCCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbCCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCCancel.Image = CType(resources.GetObject("tsbCCancel.Image"), System.Drawing.Image)
        Me.tsbCCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbCCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCCancel.Name = "tsbCCancel"
        Me.tsbCCancel.Size = New System.Drawing.Size(36, 36)
        Me.tsbCCancel.Text = "ToolStripButton1"
        Me.tsbCCancel.ToolTipText = "Cancel"
        '
        'txbCSave
        '
        Me.txbCSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txbCSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.txbCSave.Image = CType(resources.GetObject("txbCSave.Image"), System.Drawing.Image)
        Me.txbCSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.txbCSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.txbCSave.Name = "txbCSave"
        Me.txbCSave.Size = New System.Drawing.Size(36, 36)
        Me.txbCSave.Text = "ToolStripButton2"
        Me.txbCSave.ToolTipText = "Save Contact"
        '
        'txtCOthers
        '
        Me.txtCOthers.Location = New System.Drawing.Point(115, 123)
        Me.txtCOthers.Multiline = True
        Me.txtCOthers.Name = "txtCOthers"
        Me.txtCOthers.Size = New System.Drawing.Size(383, 94)
        Me.txtCOthers.TabIndex = 113
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 126)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 15)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "Others"
        '
        'txtCMobile
        '
        Me.txtCMobile.Location = New System.Drawing.Point(115, 99)
        Me.txtCMobile.Name = "txtCMobile"
        Me.txtCMobile.Size = New System.Drawing.Size(383, 23)
        Me.txtCMobile.TabIndex = 111
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 15)
        Me.Label16.TabIndex = 110
        Me.Label16.Text = "Mobile No."
        '
        'txtCPhone
        '
        Me.txtCPhone.Location = New System.Drawing.Point(115, 75)
        Me.txtCPhone.Name = "txtCPhone"
        Me.txtCPhone.Size = New System.Drawing.Size(383, 23)
        Me.txtCPhone.TabIndex = 109
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 15)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "Phone No."
        '
        'txtCEmail
        '
        Me.txtCEmail.Location = New System.Drawing.Point(115, 51)
        Me.txtCEmail.Name = "txtCEmail"
        Me.txtCEmail.Size = New System.Drawing.Size(383, 23)
        Me.txtCEmail.TabIndex = 107
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 15)
        Me.Label13.TabIndex = 106
        Me.Label13.Text = "E-mail Address"
        '
        'txtCDesignation
        '
        Me.txtCDesignation.Location = New System.Drawing.Point(115, 27)
        Me.txtCDesignation.Name = "txtCDesignation"
        Me.txtCDesignation.Size = New System.Drawing.Size(383, 23)
        Me.txtCDesignation.TabIndex = 105
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 15)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Designation"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 15)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "[]"
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(115, 3)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.Size = New System.Drawing.Size(383, 23)
        Me.txtCName.TabIndex = 102
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 15)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "Contact Name"
        '
        'tsOps
        '
        Me.tsOps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbClose, Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.tsbSave, Me.tsbCancel, Me.tsbSeparator, Me.tsbSearch, Me.tsbPrint})
        Me.tsOps.Location = New System.Drawing.Point(0, 0)
        Me.tsOps.Name = "tsOps"
        Me.tsOps.Size = New System.Drawing.Size(710, 39)
        Me.tsOps.TabIndex = 9
        '
        'tsbClose
        '
        Me.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbClose.Image = CType(resources.GetObject("tsbClose.Image"), System.Drawing.Image)
        Me.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(36, 36)
        Me.tsbClose.Text = "ToolStripButton1"
        Me.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbClose.ToolTipText = "Close"
        Me.tsbClose.Visible = False
        '
        'tsbAdd
        '
        Me.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAdd.Image = CType(resources.GetObject("tsbAdd.Image"), System.Drawing.Image)
        Me.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(36, 36)
        Me.tsbAdd.Text = "ToolStripButton5"
        Me.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbAdd.ToolTipText = "New"
        '
        'tsbEdit
        '
        Me.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEdit.Image = CType(resources.GetObject("tsbEdit.Image"), System.Drawing.Image)
        Me.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(36, 36)
        Me.tsbEdit.Text = "ToolStripButton4"
        Me.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbEdit.ToolTipText = "Edit"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(36, 36)
        Me.tsbDelete.Text = "ToolStripButton3"
        Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbDelete.ToolTipText = "Delete"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(36, 36)
        Me.tsbSave.Text = "ToolStripButton2"
        Me.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSave.ToolTipText = "Save"
        Me.tsbSave.Visible = False
        '
        'tsbCancel
        '
        Me.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCancel.Image = CType(resources.GetObject("tsbCancel.Image"), System.Drawing.Image)
        Me.tsbCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancel.Name = "tsbCancel"
        Me.tsbCancel.Size = New System.Drawing.Size(36, 36)
        Me.tsbCancel.Text = "ToolStripButton7"
        Me.tsbCancel.ToolTipText = "Cancel"
        Me.tsbCancel.Visible = False
        '
        'tsbSeparator
        '
        Me.tsbSeparator.Name = "tsbSeparator"
        Me.tsbSeparator.Size = New System.Drawing.Size(6, 39)
        '
        'tsbSearch
        '
        Me.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSearch.Image = CType(resources.GetObject("tsbSearch.Image"), System.Drawing.Image)
        Me.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearch.Name = "tsbSearch"
        Me.tsbSearch.Size = New System.Drawing.Size(36, 36)
        Me.tsbSearch.Text = "ToolStripButton6"
        Me.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSearch.ToolTipText = "Search"
        '
        'tsbPrint
        '
        Me.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrint.Image = CType(resources.GetObject("tsbPrint.Image"), System.Drawing.Image)
        Me.tsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(36, 36)
        Me.tsbPrint.Text = "ToolStripButton8"
        Me.tsbPrint.ToolTipText = "Print"
        '
        'frmClientProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 536)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.tsOps)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientProfile"
        Me.Text = "Client Accounts"
        Me.pnlInfo.ResumeLayout(False)
        Me.tabInfo.ResumeLayout(False)
        Me.tpAccountInfo.ResumeLayout(False)
        Me.tpAccountInfo.PerformLayout()
        Me.tpContactInfo.ResumeLayout(False)
        CType(Me.dgvContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCInfo.ResumeLayout(False)
        Me.pnlCInfo.PerformLayout()
        Me.tsContactOps.ResumeLayout(False)
        Me.tsContactOps.PerformLayout()
        Me.tsOps.ResumeLayout(False)
        Me.tsOps.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents tsOps As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabInfo As System.Windows.Forms.TabControl
    Friend WithEvents tpAccountInfo As System.Windows.Forms.TabPage
    Friend WithEvents lblRefNo As System.Windows.Forms.Label
    Friend WithEvents cboHandledBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWebURL As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAcctName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpContactInfo As System.Windows.Forms.TabPage
    Friend WithEvents dgvContact As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCInfo As System.Windows.Forms.Panel
    Friend WithEvents tsContactOps As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents txbCSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCOthers As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCDesignation As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboAcctType As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colRemove As System.Windows.Forms.DataGridViewButtonColumn
End Class
