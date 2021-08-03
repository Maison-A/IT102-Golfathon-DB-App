Option Strict On
Public Class frmGolfers
    '-------------------------------------------------------------'
    ' Name: Golfers_Load
    ' Desc: subroutine to populate data and load it in upon launch
    '-------------------------------------------------------------'
    Private Sub frmGolfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '------load the shirt size and gender combo box------'
            Load_ShirtSize()
            Load_Gender()

            '------load all other data------'
            Load_Names()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: Load_Names
    ' Desc: subroutine to load all golfer names
    '-------------------------------------------------------------'
    Private Sub Load_Names()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            '------textbox loop------'
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            '-----database open-------'
            If OpenDatabaseConnectionSQLServer() = False Then

                '---if db doesn't open warn user----'
                MessageBox.Show(Me, "Database application error." & vbNewLine &
                                "The application will now close.",
                                 Me.Text + "Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                Me.Close()

            End If
            '-----select statement-----'
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"

            '---yoink the records---'
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            '-----------load table from data reader---------'
            dt.Load(drSourceTable)

            '---bind golfer PK to combo box selection----'
            cmbGolferChoice.ValueMember = "intGolferID"

            '-----bind golfer last name to be displayed----'
            cmbGolferChoice.DisplayMember = "strLastName"

            '--------feed in the data from the data table------'
            cmbGolferChoice.DataSource = dt

            '-----select first item in list as default----'
            If cmbGolferChoice.Items.Count > 0 Then

                cmbGolferChoice.SelectedIndex = 0
            End If

            '----close the reader----'
            drSourceTable.Close()

            '----close connection---'
            CloseDatabaseConnection()

        Catch ex As Exception
            '---display error----'
            MessageBox.Show(ex.Message)
        End Try

        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: AddGolfer_Click
    ' Desc: subroutine to call the add(new) golfer form
    '-------------------------------------------------------------'
    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click
        Dim frmAddGolfer As New frmAddGolfer

        frmAddGolfer.ShowDialog()

        '---reload form and add player in----'
        frmGolfers_Load(sender, e)
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: UpdateGolfer_Click
    ' Desc: subroutine to handle the update golfer event
    '-------------------------------------------------------------'
    Private Sub btnUpdateGolfer_Click(sender As Object, e As EventArgs) Handles btnUpdateGolfer.Click
        Dim strSelect As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhone As String = ""
        Dim strEmail As String = ""
        Dim intRowsAffected As Integer

        Try
            '---update statement---'
            Dim cmdUpdate As OleDb.OleDbCommand

            '----validation----'
            If Validation() = True Then
                '----pop open the db-----'

                '----check if the server connection was established------'
                If OpenDatabaseConnectionSQLServer() = False Then

                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
                If Validation() = True Then

                    '-------set the data variables-------'
                    strFirstName = txtFName.Text
                    strLastName = txtLName.Text
                    strAddress = txtAddress.Text
                    strCity = txtCity.Text
                    strState = txtState.Text
                    strZip = txtZip.Text
                    strPhone = txtPhone.Text
                    strEmail = txtEmail.Text

                    '------Build the select statement--------'
                    strSelect = "Update TGolfers Set strFirstName = '" & strFirstName & "', " &
                        "strLastName = '" & strLastName & "', " & "strStreetAddress = '" & strAddress & "', " &
                        "strCity = '" & strCity & "', " & "strState = '" & strState & "', " &
                        "strZip = '" & strZip & "'," & "strPhoneNumber = '" & strPhone & "', " &
                        "strEmail = '" & strEmail & "'" & "Where intGolferID = " & cmbGolferChoice.SelectedValue.ToString

                    '----test message-----'
                    'MessageBox.Show(strSelect)

                    '-----connect | inject select statement----'
                    cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                    '-----execute-----'
                    intRowsAffected = cmdUpdate.ExecuteNonQuery

                    '----display to user if successful----'
                    If intRowsAffected = 1 Then
                        MessageBox.Show("Update successful")
                    Else
                        MessageBox.Show("Update failed")
                    End If

                    '---close connection | shockingly straight-forward command lol----'
                    CloseDatabaseConnection()

                    '---------reload the form with whatever magic parameters those are----------'
                    frmGolfers_Load(sender, e)
                End If
            End If

        Catch ex As Exception

            '----display exception-----'
            MessageBox.Show(ex.Message)
        End Try

        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: DeleteGolfer_Click
    ' Desc: subroutine to close the window
    '-------------------------------------------------------------'
    Private Sub btnDeleteGolfer_Click(sender As Object, e As EventArgs) Handles btnDeleteGolfer.Click
        Dim strDelete As String = ""
        Dim strSelect As String = ""
        Dim strName As String = ""

        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand
        Dim dt As DataTable = New DataTable
        Dim result As DialogResult

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
            '----ensure the user wishes to delete the record----'
            result = MessageBox.Show("Are you sure you want to delete golfer: Last Name - " & cmbGolferChoice.Text _
                                     & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel _
                                     , MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")

                Case DialogResult.No
                    MessageBox.Show("Action Canceled")

                '-----if yes, build and execute delete statement------'
                Case DialogResult.Yes
                    '-----delete child tables first-------'
                    strDelete = "DELETE FROM TGolferEventYearSponsors WHERE intGolferID = " & cmbGolferChoice.SelectedValue.ToString
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    strDelete = "DELETE FROM TGolferEventYears WHERE intGolferID = " & cmbGolferChoice.SelectedValue.ToString
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    '----delete parent table-----'
                    strDelete = "DELETE FROM TGolfers WHERE intGolferID = " & cmbGolferChoice.SelectedValue.ToString
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()



                    If intRowsAffected > 0 Then

                        MessageBox.Show("Delete Successful!")
                    End If

            End Select

            CloseDatabaseConnection()

            frmGolfers_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: GolferChoice_SelectedIndexChange
    ' Desc: change the data presented once the selected golfer changes
    '-------------------------------------------------------------'
    Private Sub cmbGolferChoice_SelectedIndexChange(sender As Object, e As EventArgs) Handles cmbGolferChoice.SelectedIndexChanged
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim intShirtSize As Integer
        Dim intGender As Integer

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                '----basically the same situation as the default load sub------'
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
            '----Build select statement based off PK----'
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail," _
            & "intShirtSizeID, intGenderID FROM TGolfers Where intGolferID = " _
            & cmbGolferChoice.SelectedValue.ToString

            '----snag the records------'
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            '-----load the data table from the reader--------'
            dt.Load(drSourceTable)

            '----populate the data | each item is the next column in the row-------'
            txtFName.Text = dt.Rows(0).Item(0).ToString
            txtLName.Text = dt.Rows(0).Item(1).ToString
            txtAddress.Text = dt.Rows(0).Item(2).ToString
            txtCity.Text = dt.Rows(0).Item(3).ToString
            txtState.Text = dt.Rows(0).Item(4).ToString
            txtZip.Text = dt.Rows(0).Item(5).ToString
            txtPhone.Text = dt.Rows(0).Item(6).ToString
            txtEmail.Text = dt.Rows(0).ItemArray(7).ToString

            '-----set shirt and gender combo-boxes to proper value-----'
            intShirtSize = CInt(dt.Rows(0).Item(8))
            cmbShirtSize.SelectedValue = intShirtSize


            intGender = CInt(dt.Rows(0).Item(9))
            cmbGender.SelectedValue = intGender

            '----close the connection----'
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: Load_ShirtSize
    ' Desc: reload and insert shirt size into combo box
    '-------------------------------------------------------------'
    Private Sub Load_ShirtSize()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            '---attempt to open db----'
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()
            End If

            '----if connection works, continue with building statements-----'
            strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            '---bind ID to size----'
            cmbShirtSize.ValueMember = "intShirtSizeID"
            cmbShirtSize.DisplayMember = "strShirtSizeDesc"
            cmbShirtSize.DataSource = dt


            '---close---'
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: Load_Gender
    ' Desc: reload and insert gender into combo box
    '-------------------------------------------------------------'
    Private Sub Load_Gender()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            '---attempt to open db----'
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If

            '----if connection works, continue with building statements-----'
            strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            '---bind ID to gender----'
            cmbGender.ValueMember = "intGenderID"
            cmbGender.DisplayMember = "strGenderDesc"
            cmbGender.DataSource = dt


            '---close---'
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: Validation
    ' Desc: validation tool
    '-------------------------------------------------------------'
    '----Validation function-----'
    Public Function Validation() As Boolean

        ' loop through the textboxes and check to make sure there is data in them
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        'every this is good so return true
        Return True
        '----FUNC COMPLETE----'
    End Function



    '-------------------------------------------------------------'
    ' Name: Exit_Click
    ' Desc: subroutine to close the window
    '-------------------------------------------------------------'
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

        '----SUB COMPLETE----'
    End Sub

End Class