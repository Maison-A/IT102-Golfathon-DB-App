<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEventGolfers
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
        Me.lblAvailableGolfers_Tag = New System.Windows.Forms.Label()
        Me.lblEventGolfers_Tag = New System.Windows.Forms.Label()
        Me.lblEvent_Tag = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDropGolfer = New System.Windows.Forms.Button()
        Me.btnAddGolfer = New System.Windows.Forms.Button()
        Me.lstAvailable = New System.Windows.Forms.ListBox()
        Me.lstInEvent = New System.Windows.Forms.ListBox()
        Me.cmbEvent = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAvailableGolfers_Tag
        '
        Me.lblAvailableGolfers_Tag.Location = New System.Drawing.Point(276, 78)
        Me.lblAvailableGolfers_Tag.Name = "lblAvailableGolfers_Tag"
        Me.lblAvailableGolfers_Tag.Size = New System.Drawing.Size(126, 20)
        Me.lblAvailableGolfers_Tag.TabIndex = 18
        Me.lblAvailableGolfers_Tag.Text = "Available Golfers:"
        '
        'lblEventGolfers_Tag
        '
        Me.lblEventGolfers_Tag.Location = New System.Drawing.Point(62, 78)
        Me.lblEventGolfers_Tag.Name = "lblEventGolfers_Tag"
        Me.lblEventGolfers_Tag.Size = New System.Drawing.Size(109, 13)
        Me.lblEventGolfers_Tag.TabIndex = 17
        Me.lblEventGolfers_Tag.Text = "Event Golfers:"
        '
        'lblEvent_Tag
        '
        Me.lblEvent_Tag.Location = New System.Drawing.Point(27, 16)
        Me.lblEvent_Tag.Name = "lblEvent_Tag"
        Me.lblEvent_Tag.Size = New System.Drawing.Size(70, 19)
        Me.lblEvent_Tag.TabIndex = 16
        Me.lblEvent_Tag.Text = "Event:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(191, 247)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 32)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDropGolfer
        '
        Me.btnDropGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.btnDropGolfer.Location = New System.Drawing.Point(204, 172)
        Me.btnDropGolfer.Name = "btnDropGolfer"
        Me.btnDropGolfer.Size = New System.Drawing.Size(46, 38)
        Me.btnDropGolfer.TabIndex = 14
        Me.btnDropGolfer.Text = "→"
        Me.btnDropGolfer.UseVisualStyleBackColor = True
        '
        'btnAddGolfer
        '
        Me.btnAddGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddGolfer.Location = New System.Drawing.Point(204, 116)
        Me.btnAddGolfer.Name = "btnAddGolfer"
        Me.btnAddGolfer.Size = New System.Drawing.Size(46, 35)
        Me.btnAddGolfer.TabIndex = 13
        Me.btnAddGolfer.Text = "←"
        Me.btnAddGolfer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddGolfer.UseVisualStyleBackColor = True
        '
        'lstAvailable
        '
        Me.lstAvailable.FormattingEnabled = True
        Me.lstAvailable.ItemHeight = 16
        Me.lstAvailable.Location = New System.Drawing.Point(279, 101)
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(106, 116)
        Me.lstAvailable.TabIndex = 12
        '
        'lstInEvent
        '
        Me.lstInEvent.FormattingEnabled = True
        Me.lstInEvent.ItemHeight = 16
        Me.lstInEvent.Location = New System.Drawing.Point(65, 101)
        Me.lstInEvent.Name = "lstInEvent"
        Me.lstInEvent.Size = New System.Drawing.Size(106, 116)
        Me.lstInEvent.TabIndex = 11
        '
        'cmbEvent
        '
        Me.cmbEvent.FormattingEnabled = True
        Me.cmbEvent.Location = New System.Drawing.Point(30, 38)
        Me.cmbEvent.Name = "cmbEvent"
        Me.cmbEvent.Size = New System.Drawing.Size(106, 24)
        Me.cmbEvent.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAvailableGolfers_Tag)
        Me.GroupBox1.Controls.Add(Me.lblEventGolfers_Tag)
        Me.GroupBox1.Controls.Add(Me.lblEvent_Tag)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnDropGolfer)
        Me.GroupBox1.Controls.Add(Me.btnAddGolfer)
        Me.GroupBox1.Controls.Add(Me.lstAvailable)
        Me.GroupBox1.Controls.Add(Me.lstInEvent)
        Me.GroupBox1.Controls.Add(Me.cmbEvent)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 328)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage Event's Golfers"
        '
        'frmEventGolfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 347)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmEventGolfers"
        Me.Text = "Event's Golfers"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblAvailableGolfers_Tag As Label
    Friend WithEvents lblEventGolfers_Tag As Label
    Friend WithEvents lblEvent_Tag As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDropGolfer As Button
    Friend WithEvents btnAddGolfer As Button
    Friend WithEvents lstAvailable As ListBox
    Friend WithEvents lstInEvent As ListBox
    Friend WithEvents cmbEvent As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
