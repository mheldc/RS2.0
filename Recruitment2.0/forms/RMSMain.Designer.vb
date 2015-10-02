<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RMSMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RMSMain))
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.tsFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplicantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkillCategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkillGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkillLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutAndCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SharedFoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RolesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProvinceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZipCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuditLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EventLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RecruitmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewCandidatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsHelpS1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsActivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFile, Me.tsSetup, Me.tsReports, Me.tsHelp})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(903, 24)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'tsFile
        '
        Me.tsFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripSeparator1, Me.LoginToolStripMenuItem, Me.LogoutToolStripMenuItem, Me.LogoutAndCloseToolStripMenuItem})
        Me.tsFile.Name = "tsFile"
        Me.tsFile.Size = New System.Drawing.Size(37, 20)
        Me.tsFile.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicantToolStripMenuItem, Me.ClientToolStripMenuItem, Me.SkillCategoryToolStripMenuItem, Me.SkillGroupToolStripMenuItem, Me.SkillLevelToolStripMenuItem, Me.SkillToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'ApplicantToolStripMenuItem
        '
        Me.ApplicantToolStripMenuItem.Name = "ApplicantToolStripMenuItem"
        Me.ApplicantToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ApplicantToolStripMenuItem.Text = "Applicant"
        '
        'ClientToolStripMenuItem
        '
        Me.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem"
        Me.ClientToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ClientToolStripMenuItem.Text = "Client"
        '
        'SkillCategoryToolStripMenuItem
        '
        Me.SkillCategoryToolStripMenuItem.Name = "SkillCategoryToolStripMenuItem"
        Me.SkillCategoryToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SkillCategoryToolStripMenuItem.Text = "Skill Category"
        '
        'SkillGroupToolStripMenuItem
        '
        Me.SkillGroupToolStripMenuItem.Name = "SkillGroupToolStripMenuItem"
        Me.SkillGroupToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SkillGroupToolStripMenuItem.Text = "Skill Group"
        '
        'SkillLevelToolStripMenuItem
        '
        Me.SkillLevelToolStripMenuItem.Name = "SkillLevelToolStripMenuItem"
        Me.SkillLevelToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SkillLevelToolStripMenuItem.Text = "Skill Level"
        '
        'SkillToolStripMenuItem
        '
        Me.SkillToolStripMenuItem.Name = "SkillToolStripMenuItem"
        Me.SkillToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SkillToolStripMenuItem.Text = "Skill"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(164, 6)
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'LogoutAndCloseToolStripMenuItem
        '
        Me.LogoutAndCloseToolStripMenuItem.Name = "LogoutAndCloseToolStripMenuItem"
        Me.LogoutAndCloseToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LogoutAndCloseToolStripMenuItem.Text = "Logout and Close"
        '
        'tsSetup
        '
        Me.tsSetup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemToolStripMenuItem1, Me.SystemAccountsToolStripMenuItem, Me.CountriesToolStripMenuItem})
        Me.tsSetup.Name = "tsSetup"
        Me.tsSetup.Size = New System.Drawing.Size(49, 20)
        Me.tsSetup.Text = "&Setup"
        '
        'SystemToolStripMenuItem1
        '
        Me.SystemToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerToolStripMenuItem, Me.SharedFoldersToolStripMenuItem})
        Me.SystemToolStripMenuItem1.Name = "SystemToolStripMenuItem1"
        Me.SystemToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.SystemToolStripMenuItem1.Text = "System"
        '
        'ServerToolStripMenuItem
        '
        Me.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem"
        Me.ServerToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ServerToolStripMenuItem.Text = "Server "
        '
        'SharedFoldersToolStripMenuItem
        '
        Me.SharedFoldersToolStripMenuItem.Name = "SharedFoldersToolStripMenuItem"
        Me.SharedFoldersToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SharedFoldersToolStripMenuItem.Text = "Shared Folders"
        '
        'SystemAccountsToolStripMenuItem
        '
        Me.SystemAccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GroupsToolStripMenuItem, Me.AccountsToolStripMenuItem, Me.RolesToolStripMenuItem})
        Me.SystemAccountsToolStripMenuItem.Name = "SystemAccountsToolStripMenuItem"
        Me.SystemAccountsToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SystemAccountsToolStripMenuItem.Text = "User"
        '
        'GroupsToolStripMenuItem
        '
        Me.GroupsToolStripMenuItem.Name = "GroupsToolStripMenuItem"
        Me.GroupsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.GroupsToolStripMenuItem.Text = "Groups"
        '
        'AccountsToolStripMenuItem
        '
        Me.AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        Me.AccountsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AccountsToolStripMenuItem.Text = "Accounts"
        '
        'RolesToolStripMenuItem
        '
        Me.RolesToolStripMenuItem.Name = "RolesToolStripMenuItem"
        Me.RolesToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.RolesToolStripMenuItem.Text = "Roles"
        '
        'CountriesToolStripMenuItem
        '
        Me.CountriesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CountryToolStripMenuItem, Me.ProvinceToolStripMenuItem, Me.CityToolStripMenuItem, Me.TownToolStripMenuItem, Me.ZipCodeToolStripMenuItem})
        Me.CountriesToolStripMenuItem.Name = "CountriesToolStripMenuItem"
        Me.CountriesToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.CountriesToolStripMenuItem.Text = "Location"
        '
        'CountryToolStripMenuItem
        '
        Me.CountryToolStripMenuItem.Name = "CountryToolStripMenuItem"
        Me.CountryToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CountryToolStripMenuItem.Text = "Country"
        '
        'ProvinceToolStripMenuItem
        '
        Me.ProvinceToolStripMenuItem.Name = "ProvinceToolStripMenuItem"
        Me.ProvinceToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ProvinceToolStripMenuItem.Text = "Province / State"
        '
        'CityToolStripMenuItem
        '
        Me.CityToolStripMenuItem.Name = "CityToolStripMenuItem"
        Me.CityToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CityToolStripMenuItem.Text = "City"
        '
        'TownToolStripMenuItem
        '
        Me.TownToolStripMenuItem.Name = "TownToolStripMenuItem"
        Me.TownToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.TownToolStripMenuItem.Text = "Town"
        '
        'ZipCodeToolStripMenuItem
        '
        Me.ZipCodeToolStripMenuItem.Name = "ZipCodeToolStripMenuItem"
        Me.ZipCodeToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ZipCodeToolStripMenuItem.Text = "Zip Code"
        '
        'tsReports
        '
        Me.tsReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemToolStripMenuItem, Me.ToolStripMenuItem1, Me.RecruitmentToolStripMenuItem})
        Me.tsReports.Name = "tsReports"
        Me.tsReports.Size = New System.Drawing.Size(59, 20)
        Me.tsReports.Text = "&Reports"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AuditLogsToolStripMenuItem, Me.EventLogsToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SystemToolStripMenuItem.Text = "&System"
        '
        'AuditLogsToolStripMenuItem
        '
        Me.AuditLogsToolStripMenuItem.Name = "AuditLogsToolStripMenuItem"
        Me.AuditLogsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.AuditLogsToolStripMenuItem.Text = "Audit Logs"
        '
        'EventLogsToolStripMenuItem
        '
        Me.EventLogsToolStripMenuItem.Name = "EventLogsToolStripMenuItem"
        Me.EventLogsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.EventLogsToolStripMenuItem.Text = "Event Logs"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 6)
        '
        'RecruitmentToolStripMenuItem
        '
        Me.RecruitmentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewCandidatesToolStripMenuItem})
        Me.RecruitmentToolStripMenuItem.Name = "RecruitmentToolStripMenuItem"
        Me.RecruitmentToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.RecruitmentToolStripMenuItem.Text = "Recruitment"
        '
        'NewCandidatesToolStripMenuItem
        '
        Me.NewCandidatesToolStripMenuItem.Name = "NewCandidatesToolStripMenuItem"
        Me.NewCandidatesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.NewCandidatesToolStripMenuItem.Text = "New Candidates"
        '
        'tsHelp
        '
        Me.tsHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsManual, Me.tsAbout, Me.tsHelpS1, Me.tsActivate})
        Me.tsHelp.Name = "tsHelp"
        Me.tsHelp.Size = New System.Drawing.Size(44, 20)
        Me.tsHelp.Text = "&Help"
        '
        'tsManual
        '
        Me.tsManual.Name = "tsManual"
        Me.tsManual.Size = New System.Drawing.Size(166, 22)
        Me.tsManual.Text = "&User Manual"
        '
        'tsAbout
        '
        Me.tsAbout.Name = "tsAbout"
        Me.tsAbout.Size = New System.Drawing.Size(166, 22)
        Me.tsAbout.Text = "&About"
        '
        'tsHelpS1
        '
        Me.tsHelpS1.Name = "tsHelpS1"
        Me.tsHelpS1.Size = New System.Drawing.Size(163, 6)
        '
        'tsActivate
        '
        Me.tsActivate.Name = "tsActivate"
        Me.tsActivate.Size = New System.Drawing.Size(166, 22)
        Me.tsActivate.Text = "Activat&e Software"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 339)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(903, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'RMSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 361)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.msMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMain
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RMSMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recruitment System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents tsFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuditLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RecruitmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewCandidatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsHelpS1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsActivate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplicantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RolesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkillCategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkillGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkillLevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SharedFoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CountriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CountryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProvinceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZipCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutAndCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
