<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserProfile
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
        Dim TreeNode241 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Database Connection")
        Dim TreeNode242 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mailer Setup")
        Dim TreeNode243 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Login")
        Dim TreeNode244 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Password")
        Dim TreeNode245 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User", New System.Windows.Forms.TreeNode() {TreeNode243, TreeNode244})
        Dim TreeNode246 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("System", New System.Windows.Forms.TreeNode() {TreeNode241, TreeNode242, TreeNode245})
        Dim TreeNode247 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Profile")
        Dim TreeNode248 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Departments")
        Dim TreeNode249 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Section / Division")
        Dim TreeNode250 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Company", New System.Windows.Forms.TreeNode() {TreeNode247, TreeNode248, TreeNode249})
        Dim TreeNode251 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Profiles")
        Dim TreeNode252 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Groups")
        Dim TreeNode253 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User", New System.Windows.Forms.TreeNode() {TreeNode251, TreeNode252})
        Dim TreeNode254 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Client Accounts")
        Dim TreeNode255 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Accounts", New System.Windows.Forms.TreeNode() {TreeNode250, TreeNode253, TreeNode254})
        Dim TreeNode256 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Defaults")
        Dim TreeNode257 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Types")
        Dim TreeNode258 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Status")
        Dim TreeNode259 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MR", New System.Windows.Forms.TreeNode() {TreeNode256, TreeNode257, TreeNode258})
        Dim TreeNode260 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Defaults")
        Dim TreeNode261 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Types")
        Dim TreeNode262 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Status")
        Dim TreeNode263 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Line-up", New System.Windows.Forms.TreeNode() {TreeNode260, TreeNode261, TreeNode262})
        Dim TreeNode264 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Defaults")
        Dim TreeNode265 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Types")
        Dim TreeNode266 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Status")
        Dim TreeNode267 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contract", New System.Windows.Forms.TreeNode() {TreeNode264, TreeNode265, TreeNode266})
        Dim TreeNode268 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Defaults")
        Dim TreeNode269 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Status")
        Dim TreeNode270 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Type")
        Dim TreeNode271 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Group")
        Dim TreeNode272 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Skill Information")
        Dim TreeNode273 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Skills", New System.Windows.Forms.TreeNode() {TreeNode270, TreeNode271, TreeNode272})
        Dim TreeNode274 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Candidate", New System.Windows.Forms.TreeNode() {TreeNode268, TreeNode269, TreeNode273})
        Dim TreeNode275 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintenance", New System.Windows.Forms.TreeNode() {TreeNode259, TreeNode263, TreeNode267, TreeNode274})
        Dim TreeNode276 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Manpower")
        Dim TreeNode277 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Candidate Line-up")
        Dim TreeNode278 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contract")
        Dim TreeNode279 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Requests", New System.Windows.Forms.TreeNode() {TreeNode276, TreeNode277, TreeNode278})
        Dim TreeNode280 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recruitment", New System.Windows.Forms.TreeNode() {TreeNode275, TreeNode279})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserProfile))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpUserInfo = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCLogPwd = New System.Windows.Forms.TextBox()
        Me.lblUserRefId = New System.Windows.Forms.Label()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkPwdExpires = New System.Windows.Forms.CheckBox()
        Me.chkChangePwd = New System.Windows.Forms.CheckBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLogPwd = New System.Windows.Forms.TextBox()
        Me.cboUserGroup = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLoginId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tpUserAccess = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.trvModules = New System.Windows.Forms.TreeView()
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
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpUserInfo.SuspendLayout()
        Me.tpUserAccess.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tsOps.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 517)
        Me.Panel1.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpUserInfo)
        Me.TabControl1.Controls.Add(Me.tpUserAccess)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(793, 515)
        Me.TabControl1.TabIndex = 0
        '
        'tpUserInfo
        '
        Me.tpUserInfo.AutoScroll = True
        Me.tpUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpUserInfo.Controls.Add(Me.Label11)
        Me.tpUserInfo.Controls.Add(Me.CheckBox7)
        Me.tpUserInfo.Controls.Add(Me.Label31)
        Me.tpUserInfo.Controls.Add(Me.txtCLogPwd)
        Me.tpUserInfo.Controls.Add(Me.lblUserRefId)
        Me.tpUserInfo.Controls.Add(Me.cboDept)
        Me.tpUserInfo.Controls.Add(Me.Label30)
        Me.tpUserInfo.Controls.Add(Me.txtEmail)
        Me.tpUserInfo.Controls.Add(Me.Label9)
        Me.tpUserInfo.Controls.Add(Me.chkPwdExpires)
        Me.tpUserInfo.Controls.Add(Me.chkChangePwd)
        Me.tpUserInfo.Controls.Add(Me.txtLName)
        Me.tpUserInfo.Controls.Add(Me.txtMName)
        Me.tpUserInfo.Controls.Add(Me.txtFName)
        Me.tpUserInfo.Controls.Add(Me.Label8)
        Me.tpUserInfo.Controls.Add(Me.Label7)
        Me.tpUserInfo.Controls.Add(Me.Label6)
        Me.tpUserInfo.Controls.Add(Me.Label5)
        Me.tpUserInfo.Controls.Add(Me.txtLogPwd)
        Me.tpUserInfo.Controls.Add(Me.cboUserGroup)
        Me.tpUserInfo.Controls.Add(Me.Label4)
        Me.tpUserInfo.Controls.Add(Me.txtLoginId)
        Me.tpUserInfo.Controls.Add(Me.Label3)
        Me.tpUserInfo.Controls.Add(Me.Label2)
        Me.tpUserInfo.Controls.Add(Me.Label1)
        Me.tpUserInfo.Controls.Add(Me.Label15)
        Me.tpUserInfo.Location = New System.Drawing.Point(4, 24)
        Me.tpUserInfo.Name = "tpUserInfo"
        Me.tpUserInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUserInfo.Size = New System.Drawing.Size(785, 487)
        Me.tpUserInfo.TabIndex = 0
        Me.tpUserInfo.Text = "User Information"
        Me.tpUserInfo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(533, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 15)
        Me.Label11.TabIndex = 66
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Enabled = False
        Me.CheckBox7.Location = New System.Drawing.Point(149, 217)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(76, 19)
        Me.CheckBox7.TabIndex = 65
        Me.CheckBox7.Text = "Activated"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(29, 117)
        Me.Label31.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(107, 15)
        Me.Label31.TabIndex = 64
        Me.Label31.Text = "Confirm Password"
        '
        'txtCLogPwd
        '
        Me.txtCLogPwd.Location = New System.Drawing.Point(149, 114)
        Me.txtCLogPwd.Name = "txtCLogPwd"
        Me.txtCLogPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(111)
        Me.txtCLogPwd.Size = New System.Drawing.Size(325, 23)
        Me.txtCLogPwd.TabIndex = 63
        '
        'lblUserRefId
        '
        Me.lblUserRefId.AutoSize = True
        Me.lblUserRefId.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserRefId.Location = New System.Drawing.Point(146, 43)
        Me.lblUserRefId.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblUserRefId.Name = "lblUserRefId"
        Me.lblUserRefId.Size = New System.Drawing.Size(18, 18)
        Me.lblUserRefId.TabIndex = 62
        Me.lblUserRefId.Text = "[]"
        '
        'cboDept
        '
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(149, 371)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(325, 23)
        Me.cboDept.TabIndex = 61
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(29, 374)
        Me.Label30.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(71, 15)
        Me.Label30.TabIndex = 60
        Me.Label30.Text = "Department"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(149, 138)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(325, 23)
        Me.txtEmail.TabIndex = 59
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 141)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "E-Mail  Address"
        '
        'chkPwdExpires
        '
        Me.chkPwdExpires.AutoSize = True
        Me.chkPwdExpires.Location = New System.Drawing.Point(149, 192)
        Me.chkPwdExpires.Name = "chkPwdExpires"
        Me.chkPwdExpires.Size = New System.Drawing.Size(123, 19)
        Me.chkPwdExpires.TabIndex = 57
        Me.chkPwdExpires.Text = "Password expires"
        Me.chkPwdExpires.UseVisualStyleBackColor = True
        '
        'chkChangePwd
        '
        Me.chkChangePwd.AutoSize = True
        Me.chkChangePwd.Location = New System.Drawing.Point(149, 167)
        Me.chkChangePwd.Name = "chkChangePwd"
        Me.chkChangePwd.Size = New System.Drawing.Size(210, 19)
        Me.chkChangePwd.TabIndex = 56
        Me.chkChangePwd.Text = "Change password on initial logon"
        Me.chkChangePwd.UseVisualStyleBackColor = True
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(149, 347)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(325, 23)
        Me.txtLName.TabIndex = 55
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(149, 323)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(325, 23)
        Me.txtMName.TabIndex = 54
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(149, 299)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(325, 23)
        Me.txtFName.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 350)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 15)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Last Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 326)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Middle Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 302)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "First Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 264)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 15)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "User Information"
        '
        'txtLogPwd
        '
        Me.txtLogPwd.Location = New System.Drawing.Point(149, 90)
        Me.txtLogPwd.Name = "txtLogPwd"
        Me.txtLogPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(111)
        Me.txtLogPwd.Size = New System.Drawing.Size(325, 23)
        Me.txtLogPwd.TabIndex = 48
        '
        'cboUserGroup
        '
        Me.cboUserGroup.FormattingEnabled = True
        Me.cboUserGroup.Location = New System.Drawing.Point(149, 395)
        Me.cboUserGroup.Name = "cboUserGroup"
        Me.cboUserGroup.Size = New System.Drawing.Size(325, 23)
        Me.cboUserGroup.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Password"
        '
        'txtLoginId
        '
        Me.txtLoginId.Location = New System.Drawing.Point(149, 66)
        Me.txtLoginId.Name = "txtLoginId"
        Me.txtLoginId.Size = New System.Drawing.Size(325, 23)
        Me.txtLoginId.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 398)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "User Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Login Id"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "User Reference #"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 13)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 15)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Login Information"
        '
        'tpUserAccess
        '
        Me.tpUserAccess.AutoScroll = True
        Me.tpUserAccess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpUserAccess.Controls.Add(Me.Panel2)
        Me.tpUserAccess.Controls.Add(Me.trvModules)
        Me.tpUserAccess.Location = New System.Drawing.Point(4, 24)
        Me.tpUserAccess.Name = "tpUserAccess"
        Me.tpUserAccess.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUserAccess.Size = New System.Drawing.Size(785, 487)
        Me.tpUserAccess.TabIndex = 1
        Me.tpUserAccess.Text = "User Access"
        Me.tpUserAccess.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CheckBox6)
        Me.Panel2.Controls.Add(Me.CheckBox5)
        Me.Panel2.Controls.Add(Me.CheckBox4)
        Me.Panel2.Controls.Add(Me.CheckBox3)
        Me.Panel2.Controls.Add(Me.CheckBox2)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(328, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(452, 479)
        Me.Panel2.TabIndex = 2
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(34, 162)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(155, 19)
        Me.CheckBox6.TabIndex = 47
        Me.CheckBox6.Text = "Approve / Deny Request"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(34, 137)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(53, 19)
        Me.CheckBox5.TabIndex = 46
        Me.CheckBox5.Text = "Print"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(34, 112)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(100, 19)
        Me.CheckBox4.TabIndex = 45
        Me.CheckBox4.Text = "View / Search"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(34, 87)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(60, 19)
        Me.CheckBox3.TabIndex = 44
        Me.CheckBox3.Text = "Delete"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(34, 62)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(94, 19)
        Me.CheckBox2.TabIndex = 43
        Me.CheckBox2.Text = "Modify Data"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(34, 37)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(92, 19)
        Me.CheckBox1.TabIndex = 42
        Me.CheckBox1.Text = "Create Entry"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 9)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 15)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Access Type"
        '
        'trvModules
        '
        Me.trvModules.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvModules.Location = New System.Drawing.Point(3, 3)
        Me.trvModules.Name = "trvModules"
        TreeNode241.Name = "Node10"
        TreeNode241.Text = "Database Connection"
        TreeNode242.Name = "Node11"
        TreeNode242.Text = "Mailer Setup"
        TreeNode243.Name = "Node7"
        TreeNode243.Text = "Login"
        TreeNode244.Name = "Node8"
        TreeNode244.Text = "Change Password"
        TreeNode245.Name = "Node9"
        TreeNode245.Text = "User"
        TreeNode246.Name = "Node1"
        TreeNode246.Text = "System"
        TreeNode247.Name = "Node16"
        TreeNode247.Text = "Profile"
        TreeNode248.Name = "Node17"
        TreeNode248.Text = "Departments"
        TreeNode249.Name = "Node18"
        TreeNode249.Text = "Section / Division"
        TreeNode250.Name = "Node14"
        TreeNode250.Text = "Company"
        TreeNode251.Name = "Node15"
        TreeNode251.Text = "Profiles"
        TreeNode252.Name = "Node20"
        TreeNode252.Text = "Groups"
        TreeNode253.Name = "Node12"
        TreeNode253.Text = "User"
        TreeNode254.Name = "Node39"
        TreeNode254.Text = "Client Accounts"
        TreeNode255.Name = "Node13"
        TreeNode255.Text = "Accounts"
        TreeNode256.Name = "Node24"
        TreeNode256.Text = "Defaults"
        TreeNode257.Name = "Node21"
        TreeNode257.Text = "Types"
        TreeNode258.Name = "Node22"
        TreeNode258.Text = "Status"
        TreeNode259.Name = "Node19"
        TreeNode259.Text = "MR"
        TreeNode260.Name = "Node25"
        TreeNode260.Text = "Defaults"
        TreeNode261.Name = "Node26"
        TreeNode261.Text = "Types"
        TreeNode262.Name = "Node27"
        TreeNode262.Text = "Status"
        TreeNode263.Name = "Node23"
        TreeNode263.Text = "Line-up"
        TreeNode264.Name = "Node29"
        TreeNode264.Text = "Defaults"
        TreeNode265.Name = "Node30"
        TreeNode265.Text = "Types"
        TreeNode266.Name = "Node31"
        TreeNode266.Text = "Status"
        TreeNode267.Name = "Node28"
        TreeNode267.Text = "Contract"
        TreeNode268.Name = "Node33"
        TreeNode268.Text = "Defaults"
        TreeNode269.Name = "Node34"
        TreeNode269.Text = "Status"
        TreeNode270.Name = "Node35"
        TreeNode270.Text = "Type"
        TreeNode271.Name = "Node37"
        TreeNode271.Text = "Group"
        TreeNode272.Name = "Node38"
        TreeNode272.Text = "Skill Information"
        TreeNode273.Name = "Node36"
        TreeNode273.Text = "Skills"
        TreeNode274.Name = "Node32"
        TreeNode274.Text = "Candidate"
        TreeNode275.Name = "Node2"
        TreeNode275.Text = "Maintenance"
        TreeNode276.Name = "Node4"
        TreeNode276.Text = "Manpower"
        TreeNode277.Name = "Node5"
        TreeNode277.Text = "Candidate Line-up"
        TreeNode278.Name = "Node6"
        TreeNode278.Text = "Contract"
        TreeNode279.Name = "Node3"
        TreeNode279.Text = "Requests"
        TreeNode280.Name = "Node0"
        TreeNode280.Text = "Recruitment"
        Me.trvModules.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode246, TreeNode255, TreeNode280})
        Me.trvModules.Size = New System.Drawing.Size(325, 479)
        Me.trvModules.TabIndex = 1
        '
        'tsOps
        '
        Me.tsOps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbClose, Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.tsbSave, Me.tsbCancel, Me.tsbSeparator, Me.tsbSearch, Me.tsbPrint})
        Me.tsOps.Location = New System.Drawing.Point(0, 0)
        Me.tsOps.Name = "tsOps"
        Me.tsOps.Size = New System.Drawing.Size(795, 39)
        Me.tsOps.TabIndex = 3
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
        'frmUserProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 556)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tsOps)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserProfile"
        Me.Text = "User Profile"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpUserInfo.ResumeLayout(False)
        Me.tpUserInfo.PerformLayout()
        Me.tpUserAccess.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tsOps.ResumeLayout(False)
        Me.tsOps.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpUserInfo As System.Windows.Forms.TabPage
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkPwdExpires As System.Windows.Forms.CheckBox
    Friend WithEvents chkChangePwd As System.Windows.Forms.CheckBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLogPwd As System.Windows.Forms.TextBox
    Friend WithEvents cboUserGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLoginId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tpUserAccess As System.Windows.Forms.TabPage
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblUserRefId As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCLogPwd As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents trvModules As System.Windows.Forms.TreeView
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
