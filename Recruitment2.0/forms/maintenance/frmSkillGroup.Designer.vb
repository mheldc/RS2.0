<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSkillGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSkillGroup))
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.cboSkillType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGroupCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGroupDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tsOps = New System.Windows.Forms.ToolStrip()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancel = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.pnlInfo.SuspendLayout()
        Me.tsOps.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInfo
        '
        Me.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfo.Controls.Add(Me.cboSkillType)
        Me.pnlInfo.Controls.Add(Me.Label5)
        Me.pnlInfo.Controls.Add(Me.txtGroupCode)
        Me.pnlInfo.Controls.Add(Me.Label4)
        Me.pnlInfo.Controls.Add(Me.txtGroupDesc)
        Me.pnlInfo.Controls.Add(Me.Label2)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfo.Location = New System.Drawing.Point(0, 39)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(460, 151)
        Me.pnlInfo.TabIndex = 4
        '
        'cboSkillType
        '
        Me.cboSkillType.FormattingEnabled = True
        Me.cboSkillType.Location = New System.Drawing.Point(102, 15)
        Me.cboSkillType.Name = "cboSkillType"
        Me.cboSkillType.Size = New System.Drawing.Size(329, 23)
        Me.cboSkillType.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Skill Type"
        '
        'txtGroupCode
        '
        Me.txtGroupCode.Location = New System.Drawing.Point(102, 39)
        Me.txtGroupCode.Name = "txtGroupCode"
        Me.txtGroupCode.ReadOnly = True
        Me.txtGroupCode.Size = New System.Drawing.Size(160, 23)
        Me.txtGroupCode.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Group Code"
        '
        'txtGroupDesc
        '
        Me.txtGroupDesc.Location = New System.Drawing.Point(102, 63)
        Me.txtGroupDesc.Multiline = True
        Me.txtGroupDesc.Name = "txtGroupDesc"
        Me.txtGroupDesc.Size = New System.Drawing.Size(329, 71)
        Me.txtGroupDesc.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Description"
        '
        'tsOps
        '
        Me.tsOps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbClose, Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.tsbSave, Me.tsbCancel, Me.tsbSeparator, Me.tsbSearch, Me.tsbPrint})
        Me.tsOps.Location = New System.Drawing.Point(0, 0)
        Me.tsOps.Name = "tsOps"
        Me.tsOps.Size = New System.Drawing.Size(460, 39)
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
        'frmSkillGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 190)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.tsOps)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSkillGroup"
        Me.Text = "Skill Group"
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.tsOps.ResumeLayout(False)
        Me.tsOps.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGroupDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents cboSkillType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
