<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnMngGolfers = New System.Windows.Forms.Button()
        Me.btnMngEvents = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnManageGolferEvent = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMngGolfers
        '
        Me.btnMngGolfers.Location = New System.Drawing.Point(12, 28)
        Me.btnMngGolfers.Name = "btnMngGolfers"
        Me.btnMngGolfers.Size = New System.Drawing.Size(118, 48)
        Me.btnMngGolfers.TabIndex = 0
        Me.btnMngGolfers.Text = "Manage Golfers"
        Me.btnMngGolfers.UseVisualStyleBackColor = True
        '
        'btnMngEvents
        '
        Me.btnMngEvents.Location = New System.Drawing.Point(136, 28)
        Me.btnMngEvents.Name = "btnMngEvents"
        Me.btnMngEvents.Size = New System.Drawing.Size(118, 48)
        Me.btnMngEvents.TabIndex = 1
        Me.btnMngEvents.Text = "Manage Events"
        Me.btnMngEvents.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(136, 82)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(118, 48)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnManageGolferEvent
        '
        Me.btnManageGolferEvent.Location = New System.Drawing.Point(260, 28)
        Me.btnManageGolferEvent.Name = "btnManageGolferEvent"
        Me.btnManageGolferEvent.Size = New System.Drawing.Size(118, 48)
        Me.btnManageGolferEvent.TabIndex = 3
        Me.btnManageGolferEvent.Text = "Manage Event's Golfers"
        Me.btnManageGolferEvent.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 150)
        Me.Controls.Add(Me.btnManageGolferEvent)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnMngEvents)
        Me.Controls.Add(Me.btnMngGolfers)
        Me.Name = "frmMain"
        Me.Text = "Golfathon"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnMngGolfers As Button
    Friend WithEvents btnMngEvents As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnManageGolferEvent As Button
End Class
