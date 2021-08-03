<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGolfers
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
        Me.cmbGolferChoice = New System.Windows.Forms.ComboBox()
        Me.lblGolferChoice_Tag = New System.Windows.Forms.Label()
        Me.lblFName_Tag = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblEmail_Tag = New System.Windows.Forms.Label()
        Me.lblPhone_Tag = New System.Windows.Forms.Label()
        Me.lblZip_Tag = New System.Windows.Forms.Label()
        Me.lblState_Tag = New System.Windows.Forms.Label()
        Me.lblCity_Tag = New System.Windows.Forms.Label()
        Me.lblAddress_Tag = New System.Windows.Forms.Label()
        Me.lblLName_Tag = New System.Windows.Forms.Label()
        Me.btnAddGolfer = New System.Windows.Forms.Button()
        Me.btnUpdateGolfer = New System.Windows.Forms.Button()
        Me.btnDeleteGolfer = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.lblGender_Tag = New System.Windows.Forms.Label()
        Me.cmbShirtSize = New System.Windows.Forms.ComboBox()
        Me.lblShirtSize_Tag = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbGolferChoice
        '
        Me.cmbGolferChoice.FormattingEnabled = True
        Me.cmbGolferChoice.Location = New System.Drawing.Point(68, 19)
        Me.cmbGolferChoice.Name = "cmbGolferChoice"
        Me.cmbGolferChoice.Size = New System.Drawing.Size(171, 21)
        Me.cmbGolferChoice.TabIndex = 0
        '
        'lblGolferChoice_Tag
        '
        Me.lblGolferChoice_Tag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGolferChoice_Tag.Location = New System.Drawing.Point(12, 19)
        Me.lblGolferChoice_Tag.Name = "lblGolferChoice_Tag"
        Me.lblGolferChoice_Tag.Size = New System.Drawing.Size(50, 21)
        Me.lblGolferChoice_Tag.TabIndex = 1
        Me.lblGolferChoice_Tag.Text = "Golfer:"
        '
        'lblFName_Tag
        '
        Me.lblFName_Tag.Location = New System.Drawing.Point(6, 18)
        Me.lblFName_Tag.Name = "lblFName_Tag"
        Me.lblFName_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblFName_Tag.TabIndex = 2
        Me.lblFName_Tag.Text = "First Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbGender)
        Me.GroupBox1.Controls.Add(Me.lblGender_Tag)
        Me.GroupBox1.Controls.Add(Me.cmbShirtSize)
        Me.GroupBox1.Controls.Add(Me.lblShirtSize_Tag)
        Me.GroupBox1.Controls.Add(Me.txtFName)
        Me.GroupBox1.Controls.Add(Me.txtLName)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtPhone)
        Me.GroupBox1.Controls.Add(Me.txtZip)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.Controls.Add(Me.txtCity)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.lblEmail_Tag)
        Me.GroupBox1.Controls.Add(Me.lblPhone_Tag)
        Me.GroupBox1.Controls.Add(Me.lblZip_Tag)
        Me.GroupBox1.Controls.Add(Me.lblState_Tag)
        Me.GroupBox1.Controls.Add(Me.lblCity_Tag)
        Me.GroupBox1.Controls.Add(Me.lblAddress_Tag)
        Me.GroupBox1.Controls.Add(Me.lblLName_Tag)
        Me.GroupBox1.Controls.Add(Me.lblFName_Tag)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 308)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Golfer Info"
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(95, 14)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(123, 22)
        Me.txtFName.TabIndex = 17
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(95, 42)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(123, 22)
        Me.txtLName.TabIndex = 16
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(53, 210)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(165, 22)
        Me.txtEmail.TabIndex = 15
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(95, 182)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(123, 22)
        Me.txtPhone.TabIndex = 14
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(95, 154)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(123, 22)
        Me.txtZip.TabIndex = 13
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(95, 126)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(123, 22)
        Me.txtState.TabIndex = 12
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(95, 98)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(123, 22)
        Me.txtCity.TabIndex = 11
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(95, 70)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(123, 22)
        Me.txtAddress.TabIndex = 10
        '
        'lblEmail_Tag
        '
        Me.lblEmail_Tag.Location = New System.Drawing.Point(6, 210)
        Me.lblEmail_Tag.Name = "lblEmail_Tag"
        Me.lblEmail_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblEmail_Tag.TabIndex = 9
        Me.lblEmail_Tag.Text = "E-Mail:"
        '
        'lblPhone_Tag
        '
        Me.lblPhone_Tag.Location = New System.Drawing.Point(6, 182)
        Me.lblPhone_Tag.Name = "lblPhone_Tag"
        Me.lblPhone_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblPhone_Tag.TabIndex = 8
        Me.lblPhone_Tag.Text = "Phone:"
        '
        'lblZip_Tag
        '
        Me.lblZip_Tag.Location = New System.Drawing.Point(6, 154)
        Me.lblZip_Tag.Name = "lblZip_Tag"
        Me.lblZip_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblZip_Tag.TabIndex = 7
        Me.lblZip_Tag.Text = "ZIP:"
        '
        'lblState_Tag
        '
        Me.lblState_Tag.Location = New System.Drawing.Point(6, 126)
        Me.lblState_Tag.Name = "lblState_Tag"
        Me.lblState_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblState_Tag.TabIndex = 6
        Me.lblState_Tag.Text = "State:"
        '
        'lblCity_Tag
        '
        Me.lblCity_Tag.Location = New System.Drawing.Point(6, 98)
        Me.lblCity_Tag.Name = "lblCity_Tag"
        Me.lblCity_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblCity_Tag.TabIndex = 5
        Me.lblCity_Tag.Text = "City:"
        '
        'lblAddress_Tag
        '
        Me.lblAddress_Tag.Location = New System.Drawing.Point(6, 70)
        Me.lblAddress_Tag.Name = "lblAddress_Tag"
        Me.lblAddress_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblAddress_Tag.TabIndex = 4
        Me.lblAddress_Tag.Text = "Address:"
        '
        'lblLName_Tag
        '
        Me.lblLName_Tag.Location = New System.Drawing.Point(6, 42)
        Me.lblLName_Tag.Name = "lblLName_Tag"
        Me.lblLName_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblLName_Tag.TabIndex = 3
        Me.lblLName_Tag.Text = "Last Name:"
        '
        'btnAddGolfer
        '
        Me.btnAddGolfer.Location = New System.Drawing.Point(6, 19)
        Me.btnAddGolfer.Name = "btnAddGolfer"
        Me.btnAddGolfer.Size = New System.Drawing.Size(119, 36)
        Me.btnAddGolfer.TabIndex = 4
        Me.btnAddGolfer.Text = "Add New Golfer"
        Me.btnAddGolfer.UseVisualStyleBackColor = True
        '
        'btnUpdateGolfer
        '
        Me.btnUpdateGolfer.Location = New System.Drawing.Point(6, 63)
        Me.btnUpdateGolfer.Name = "btnUpdateGolfer"
        Me.btnUpdateGolfer.Size = New System.Drawing.Size(119, 36)
        Me.btnUpdateGolfer.TabIndex = 5
        Me.btnUpdateGolfer.Text = "Update Golfer"
        Me.btnUpdateGolfer.UseVisualStyleBackColor = True
        '
        'btnDeleteGolfer
        '
        Me.btnDeleteGolfer.Location = New System.Drawing.Point(6, 112)
        Me.btnDeleteGolfer.Name = "btnDeleteGolfer"
        Me.btnDeleteGolfer.Size = New System.Drawing.Size(119, 36)
        Me.btnDeleteGolfer.TabIndex = 6
        Me.btnDeleteGolfer.Text = "Delete Golfer"
        Me.btnDeleteGolfer.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(245, 234)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(131, 50)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddGolfer)
        Me.GroupBox2.Controls.Add(Me.btnUpdateGolfer)
        Me.GroupBox2.Controls.Add(Me.btnDeleteGolfer)
        Me.GroupBox2.Location = New System.Drawing.Point(245, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(131, 155)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Change Golfer info"
        '
        'cmbGender
        '
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Location = New System.Drawing.Point(95, 272)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(123, 24)
        Me.cmbGender.TabIndex = 25
        '
        'lblGender_Tag
        '
        Me.lblGender_Tag.Location = New System.Drawing.Point(6, 272)
        Me.lblGender_Tag.Name = "lblGender_Tag"
        Me.lblGender_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblGender_Tag.TabIndex = 24
        Me.lblGender_Tag.Text = "Gender:"
        '
        'cmbShirtSize
        '
        Me.cmbShirtSize.FormattingEnabled = True
        Me.cmbShirtSize.Location = New System.Drawing.Point(95, 238)
        Me.cmbShirtSize.Name = "cmbShirtSize"
        Me.cmbShirtSize.Size = New System.Drawing.Size(123, 24)
        Me.cmbShirtSize.TabIndex = 23
        '
        'lblShirtSize_Tag
        '
        Me.lblShirtSize_Tag.Location = New System.Drawing.Point(6, 241)
        Me.lblShirtSize_Tag.Name = "lblShirtSize_Tag"
        Me.lblShirtSize_Tag.Size = New System.Drawing.Size(83, 21)
        Me.lblShirtSize_Tag.TabIndex = 22
        Me.lblShirtSize_Tag.Text = "Shirt Size:"
        '
        'frmGolfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 368)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblGolferChoice_Tag)
        Me.Controls.Add(Me.cmbGolferChoice)
        Me.Name = "frmGolfers"
        Me.Text = "Golfers"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbGolferChoice As ComboBox
    Friend WithEvents lblGolferChoice_Tag As Label
    Friend WithEvents lblFName_Tag As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblState_Tag As Label
    Friend WithEvents lblCity_Tag As Label
    Friend WithEvents lblAddress_Tag As Label
    Friend WithEvents lblLName_Tag As Label
    Friend WithEvents lblPhone_Tag As Label
    Friend WithEvents lblZip_Tag As Label
    Friend WithEvents lblEmail_Tag As Label
    Friend WithEvents txtFName As TextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtZip As TextBox
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAddGolfer As Button
    Friend WithEvents btnUpdateGolfer As Button
    Friend WithEvents btnDeleteGolfer As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents lblGender_Tag As Label
    Friend WithEvents cmbShirtSize As ComboBox
    Friend WithEvents lblShirtSize_Tag As Label
End Class
