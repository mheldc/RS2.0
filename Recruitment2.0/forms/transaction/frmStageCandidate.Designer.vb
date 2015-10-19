<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStageCandidate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStageCandidate))
        Me.tsOps = New System.Windows.Forms.ToolStrip()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CVEvaluationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExaminationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentSubmissionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContractSigningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppointmentAndDeploymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colSetFeedback = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colStageId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStagedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStagedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStageRF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsOps.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsOps
        '
        Me.tsOps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbClose, Me.ToolStripDropDownButton1, Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.tsbCancel, Me.tsbSave, Me.tsbSeparator, Me.tsbSearch, Me.tsbPrint})
        Me.tsOps.Location = New System.Drawing.Point(0, 0)
        Me.tsOps.Name = "tsOps"
        Me.tsOps.Size = New System.Drawing.Size(943, 39)
        Me.tsOps.TabIndex = 2
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
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CVEvaluationToolStripMenuItem, Me.InterviewToolStripMenuItem, Me.ExaminationToolStripMenuItem, Me.DocumentSubmissionToolStripMenuItem, Me.ContractSigningToolStripMenuItem, Me.AppointmentAndDeploymentToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(45, 36)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'CVEvaluationToolStripMenuItem
        '
        Me.CVEvaluationToolStripMenuItem.Image = CType(resources.GetObject("CVEvaluationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CVEvaluationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CVEvaluationToolStripMenuItem.Name = "CVEvaluationToolStripMenuItem"
        Me.CVEvaluationToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.CVEvaluationToolStripMenuItem.Text = "CV Evaluation"
        '
        'InterviewToolStripMenuItem
        '
        Me.InterviewToolStripMenuItem.Image = CType(resources.GetObject("InterviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InterviewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.InterviewToolStripMenuItem.Name = "InterviewToolStripMenuItem"
        Me.InterviewToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.InterviewToolStripMenuItem.Text = "Interview"
        '
        'ExaminationToolStripMenuItem
        '
        Me.ExaminationToolStripMenuItem.Image = CType(resources.GetObject("ExaminationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExaminationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExaminationToolStripMenuItem.Name = "ExaminationToolStripMenuItem"
        Me.ExaminationToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ExaminationToolStripMenuItem.Text = "Examination"
        '
        'DocumentSubmissionToolStripMenuItem
        '
        Me.DocumentSubmissionToolStripMenuItem.Image = CType(resources.GetObject("DocumentSubmissionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DocumentSubmissionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DocumentSubmissionToolStripMenuItem.Name = "DocumentSubmissionToolStripMenuItem"
        Me.DocumentSubmissionToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.DocumentSubmissionToolStripMenuItem.Text = "Document Submission"
        '
        'ContractSigningToolStripMenuItem
        '
        Me.ContractSigningToolStripMenuItem.Image = CType(resources.GetObject("ContractSigningToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ContractSigningToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContractSigningToolStripMenuItem.Name = "ContractSigningToolStripMenuItem"
        Me.ContractSigningToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ContractSigningToolStripMenuItem.Text = "Contract Signing"
        '
        'AppointmentAndDeploymentToolStripMenuItem
        '
        Me.AppointmentAndDeploymentToolStripMenuItem.Image = CType(resources.GetObject("AppointmentAndDeploymentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AppointmentAndDeploymentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AppointmentAndDeploymentToolStripMenuItem.Name = "AppointmentAndDeploymentToolStripMenuItem"
        Me.AppointmentAndDeploymentToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.AppointmentAndDeploymentToolStripMenuItem.Text = "Appointment and Deployment"
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
        Me.tsbAdd.Visible = False
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
        Me.tsbEdit.Visible = False
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
        Me.tsbDelete.Visible = False
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
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(943, 406)
        Me.Panel1.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSetFeedback, Me.colStageId, Me.colStage, Me.colStagedBy, Me.colStagedDate, Me.colStageRF})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 108)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(941, 296)
        Me.DataGridView1.TabIndex = 7
        '
        'colSetFeedback
        '
        Me.colSetFeedback.Frozen = True
        Me.colSetFeedback.HeaderText = ""
        Me.colSetFeedback.Name = "colSetFeedback"
        Me.colSetFeedback.ReadOnly = True
        Me.colSetFeedback.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSetFeedback.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSetFeedback.Text = "Set Feedback"
        Me.colSetFeedback.Width = 120
        '
        'colStageId
        '
        Me.colStageId.Frozen = True
        Me.colStageId.HeaderText = "StageId"
        Me.colStageId.Name = "colStageId"
        Me.colStageId.ReadOnly = True
        Me.colStageId.Visible = False
        '
        'colStage
        '
        Me.colStage.FillWeight = 150.0!
        Me.colStage.Frozen = True
        Me.colStage.HeaderText = "Stage"
        Me.colStage.Name = "colStage"
        Me.colStage.ReadOnly = True
        '
        'colStagedBy
        '
        Me.colStagedBy.Frozen = True
        Me.colStagedBy.HeaderText = "Staged By"
        Me.colStagedBy.Name = "colStagedBy"
        Me.colStagedBy.ReadOnly = True
        Me.colStagedBy.Width = 250
        '
        'colStagedDate
        '
        Me.colStagedDate.Frozen = True
        Me.colStagedDate.HeaderText = "Date Staged"
        Me.colStagedDate.Name = "colStagedDate"
        Me.colStagedDate.ReadOnly = True
        Me.colStagedDate.Width = 150
        '
        'colStageRF
        '
        Me.colStageRF.Frozen = True
        Me.colStageRF.HeaderText = "Remarks / Feedback"
        Me.colStageRF.Name = "colStageRF"
        Me.colStageRF.ReadOnly = True
        Me.colStageRF.Width = 250
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(941, 108)
        Me.Panel2.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(576, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(184, 15)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "[Candidate Id - Candidate Name]"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(420, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Candidate"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(576, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "[Account Name]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(420, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Account Name"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.Location = New System.Drawing.Point(576, 12)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(127, 15)
        Me.LinkLabel2.TabIndex = 8
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "[Account Reference #]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(420, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Account Reference #"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(150, 12)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(101, 15)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "[MR Reference #]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(150, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "[Requirement Type]"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Requirement Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(150, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "[LR Reference #]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "LR Reference #"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MR Reference #"
        '
        'frmStageCandidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 445)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tsOps)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStageCandidate"
        Me.Text = "Candidate Stageing"
        Me.tsOps.ResumeLayout(False)
        Me.tsOps.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colSetFeedback As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colStageId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStagedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStagedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStageRF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CVEvaluationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExaminationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentSubmissionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContractSigningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppointmentAndDeploymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
