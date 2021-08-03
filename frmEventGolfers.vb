Public Class frmEventGolfers
    '-------------------------------------------------------------'
    ' Name: 
    ' Desc: 
    '-------------------------------------------------------------'
    Private Sub frmEventGolfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load will load the combo box. If you setup the combo box with a
        ' selected index change (see below) it will load the players from the
        ' team selected into to team players list box. Form load will also pull 
        ' players from the view in the DB that has players not on a team and load
        ' them into the Available players list box.

        Try

            ' *************************************************************************************
            ' LOAD Event Combo Box
            ' *************************************************************************************

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            cmbEvent.BeginUpdate()

            ' Build the select statement for combo box for teams
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the player ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the players data.
            ' We are binding the column name to the combo box display and value members. 
            cmbEvent.ValueMember = "intEventYearID"
            cmbEvent.DisplayMember = "intEventYear"
            cmbEvent.DataSource = dt

            ' Select the first item in the list by default
            If cmbEvent.Items.Count > 0 Then cmbEvent.SelectedIndex = 0

            ' Show any changes
            cmbEvent.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()


            ' *************************************************************************************
            ' Load Available Golfers
            ' *************************************************************************************
            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            lstAvailable.BeginUpdate()

            ' Build the select statement
            strSelect = "SELECT intGolferID, strLastName FROM VGolfersOut"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the player ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the players data.
            ' We are binding the column name to the combo box display and value members. 
            lstAvailable.ValueMember = "intGolferID"
            lstAvailable.DisplayMember = "strLastName"
            lstAvailable.DataSource = dt1



            ' Select the first item in the list by default
            If lstAvailable.Items.Count > 0 Then lstAvailable.SelectedIndex = 0

            ' Show any changes
            lstAvailable.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub



    '-------------------------------------------------------------'
    ' Name: 
    ' Desc: 
    '-------------------------------------------------------------'
    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' this SUB will add an available golfer to the event in the combo box. The 
        ' golfer will then show up in the event golfers list box when the event is selected
        ' in the combo box.

        Try

            Dim cmdAddGolfer As New OleDb.OleDbCommand()
            Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim intRowsAffected As Integer

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            Try
                ' text to call sproc
                cmdAddGolfer.CommandText = "EXECUTE uspAddGolferEvent '" & intPKID & "'," & lstAvailable.SelectedValue.ToString &
                                            "," & cmbEvent.Items.Count - 1

                cmdAddGolfer.CommandType = CommandType.StoredProcedure

                ' Call stored proc which will insert the record 
                cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)

                ' this return is the # of rows affected
                intRowsAffected = cmdAddGolfer.ExecuteNonQuery()

                '---if successful let user know-----'
                If intRowsAffected > 0 Then
                    MessageBox.Show("Golfer has been added to newest event!")
                    CloseDatabaseConnection()
                    Close()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
            ' close the database connection
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            frmEventGolfers_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub



    '-------------------------------------------------------------'
    ' Name: 
    ' Desc: 
    '-------------------------------------------------------------'
    Private Sub btnDropPlayer_Click(sender As Object, e As EventArgs) Handles btnDropGolfer.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult

        Try



            ' open the database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Player: Last Name-" & lstInEvent.Text & " from " & cmbEvent.Text & " ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from name selected
                    strDelete = "Delete FROM TTeamPlayers Where intPlayerID = " & lstInEvent.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' refresh the form so changes can be seen
            frmEventGolfers_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub



    '-------------------------------------------------------------'
    ' Name: 
    ' Desc: 
    '-------------------------------------------------------------'
    Private Sub cboNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvent.SelectedIndexChanged
        ' create this SUB by double clicking on the combo box. This will load
        ' players on team based on index (DB PK) into the list box for team 
        ' players when combo box index changes.
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            lstInEvent.BeginUpdate()

            ' Build the select statement for listbox with players on team selected
            strSelect = "SELECT intGolferID, strLastName FROM VGolfersIn WHERE intEventYearID = " & cmbEvent.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the player ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the players data.
            ' We are binding the column name to the combo box display and value members. 
            lstInEvent.ValueMember = "intGolferID"
            lstInEvent.DisplayMember = "strLastName"
            lstInEvent.DataSource = dt

            ' Select the first item in the list by default
            If lstInEvent.Items.Count > 0 Then lstInEvent.SelectedIndex = 0

            ' Show any changes
            lstInEvent.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()



        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub


    '-------------------------------------------------------------'
    ' Name: Exit_Click
    ' Desc: close the program
    '-------------------------------------------------------------'
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class