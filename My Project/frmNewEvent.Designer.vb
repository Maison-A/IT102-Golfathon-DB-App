<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewEvent
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
        Me.btnNewEventSubmit = New System.Windows.Forms.Button()
        Me.txtNewEventYear = New System.Windows.Forms.TextBox()
        Me.lblNewEventYear_Tag = New System.Windows.Forms.Label()
        Me.btnNewEventExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnNewEventSubmit
        '
        Me.btnNewEventSubmit.Location = New System.Drawing.Point(12, 38)
        Me.btnNewEventSubmit.Name = "btnNewEventSubmit"
        Me.btnNewEventSubmit.Size = New System.Drawing.Size(95, 32)
        Me.btnNewEventSubmit.TabIndex = 0
        Me.btnNewEventSubmit.Text = "Submit"
        Me.btnNewEventSubmit.UseVisualStyleBackColor = True
        '
        'txtNewEventYear
        '
        Me.txtNewEventYear.Location = New System.Drawing.Point(108, 12)
        Me.txtNewEventYear.Name = "txtNewEventYear"
        Me.txtNewEventYear.Size = New System.Drawing.Size(100, 20)
        Me.txtNewEventYear.TabIndex = 1
        '
        'lblNewEventYear_Tag
        '
        Me.lblNewEventYear_Tag.Location = New System.Drawing.Point(7, 12)
        Me.lblNewEventYear_Tag.Name = "lblNewEventYear_Tag"
        Me.lblNewEventYear_Tag.Size = New System.Drawing.Size(100, 23)
        Me.lblNewEventYear_Tag.TabIndex = 2
        Me.lblNewEventYear_Tag.Text = "New Event Year:"
        '
        'btnNewEventExit
        '
        Me.btnNewEventExit.Location = New System.Drawing.Point(113, 38)
        Me.btnNewEventExit.Name = "btnNewEventExit"
        Me.btnNewEventExit.Size = New System.Drawing.Size(95, 32)
        Me.btnNewEventExit.TabIndex = 3
        Me.btnNewEventExit.Text = "Exit"
        Me.btnNewEventExit.UseVisualStyleBackColor = True
        '
        'frmNewEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(218, 90)
        Me.Controls.Add(Me.btnNewEventExit)
        Me.Controls.Add(Me.lblNewEventYear_Tag)
        Me.Controls.Add(Me.txtNewEventYear)
        Me.Controls.Add(Me.btnNewEventSubmit)
        Me.Name = "frmNewEvent"
        Me.Text = "frmNewEvent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNewEventSubmit As Button
    Friend WithEvents txtNewEventYear As TextBox
    Friend WithEvents lblNewEventYear_Tag As Label
    Friend WithEvents btnNewEventExit As Button
End Class
