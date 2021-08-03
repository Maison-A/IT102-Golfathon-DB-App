<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvents
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
        Me.cmbEventYear = New System.Windows.Forms.ComboBox()
        Me.lblEventYear_Tag = New System.Windows.Forms.Label()
        Me.btnExitEvents = New System.Windows.Forms.Button()
        Me.btnAddEvent = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbEventYear
        '
        Me.cmbEventYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEventYear.FormattingEnabled = True
        Me.cmbEventYear.Location = New System.Drawing.Point(101, 12)
        Me.cmbEventYear.Name = "cmbEventYear"
        Me.cmbEventYear.Size = New System.Drawing.Size(121, 24)
        Me.cmbEventYear.TabIndex = 0
        '
        'lblEventYear_Tag
        '
        Me.lblEventYear_Tag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEventYear_Tag.Location = New System.Drawing.Point(12, 13)
        Me.lblEventYear_Tag.Name = "lblEventYear_Tag"
        Me.lblEventYear_Tag.Size = New System.Drawing.Size(83, 24)
        Me.lblEventYear_Tag.TabIndex = 1
        Me.lblEventYear_Tag.Text = "Event Year:"
        '
        'btnExitEvents
        '
        Me.btnExitEvents.Location = New System.Drawing.Point(123, 56)
        Me.btnExitEvents.Name = "btnExitEvents"
        Me.btnExitEvents.Size = New System.Drawing.Size(105, 40)
        Me.btnExitEvents.TabIndex = 2
        Me.btnExitEvents.Text = "Exit"
        Me.btnExitEvents.UseVisualStyleBackColor = True
        '
        'btnAddEvent
        '
        Me.btnAddEvent.Location = New System.Drawing.Point(12, 56)
        Me.btnAddEvent.Name = "btnAddEvent"
        Me.btnAddEvent.Size = New System.Drawing.Size(105, 40)
        Me.btnAddEvent.TabIndex = 3
        Me.btnAddEvent.Text = "Add Event"
        Me.btnAddEvent.UseVisualStyleBackColor = True
        '
        'frmEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 112)
        Me.Controls.Add(Me.btnAddEvent)
        Me.Controls.Add(Me.btnExitEvents)
        Me.Controls.Add(Me.lblEventYear_Tag)
        Me.Controls.Add(Me.cmbEventYear)
        Me.Name = "frmEvents"
        Me.Text = "Events"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbEventYear As ComboBox
    Friend WithEvents lblEventYear_Tag As Label
    Friend WithEvents btnExitEvents As Button
    Friend WithEvents btnAddEvent As Button
End Class
