Option Strict On

Public Class frmAddGolfer
    '-------------------------------------------------------------'
    ' Name: SubmitNewGolfer_Click
    ' Desc: subroutine to handle calls after click event
    '-------------------------------------------------------------'
    Private Sub btnSubmitNewGolfer_Click(sender As Object, e As EventArgs) Handles btnSubmitNewGolfer.Click
        '---------variables--------'
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhone As String = ""
        Dim strEmail As String = ""
        ' TODO - Set vars to txt
        ' pass
        strFirstName = txtNewGolferFName.Text
        strLastName = txtNewGolferLName.Text
        strAddress = txtNewGolferAddress.Text
        strCity = txtNewGolferCity.Text
        strState = txtNewGolferState.Text
        strZip = txtNewGolferZip.Text
        strPhone = txtNewGolferPhone.Text
        strEmail = txtNewGolferEmail.Text

        '-----validate-----'
        If ValidationTool() = True Then
            ' 
            AddGolfer(strFirstName, strLastName, strAddress, strCity, strState, strZip, strPhone, strEmail)
        End If


        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: AddGolfer
    ' Desc: Subroutine to connect to db and add update table
    '-------------------------------------------------------------'
    Private Sub AddGolfer(ByVal strFirstName As String, ByVal strLastName As String, ByVal strAddress As String _
                        , ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strPhone As String _
                        , ByVal strEmail As String)

        '----number of rows affected-----'
        Dim intRowsAffected As Integer
        If ValidationTool() = True Then
            ' create command object and integer for number of returned rows
            Dim cmdAddGolfer As New OleDb.OleDbCommand()
            Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it
            Dim intShirtIndex As Integer
            Dim intGenderIndex As Integer
            Try
                ' open database
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user 
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If
                intShirtIndex = cmbNewGolferSize.SelectedIndex
                intGenderIndex = cmbNewGolferGender.SelectedIndex

                ' text to call stored proc
                cmdAddGolfer.CommandText = "EXECUTE uspAddGolfer '" & intPKID & "','" & strFirstName & "','" & strLastName &
                         "', '" & strAddress & "','" & strCity & "', '" & strState & "','" & strZip & "','" & strPhone & "','" & strEmail & "', " &
                        intShirtIndex + 1 & ", " & intGenderIndex + 1


                cmdAddGolfer.CommandType = CommandType.StoredProcedure

                ' Call stored proc which will insert the record 
                cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)

                ' this return is the # of rows affected
                intRowsAffected = cmdAddGolfer.ExecuteNonQuery()

                'Close database connection
                CloseDatabaseConnection()

                '---if successful let user know-----'
                If intRowsAffected > 0 Then
                    MessageBox.Show("Golfer has been added")
                    CloseDatabaseConnection()
                    Close()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End Try
        End If
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
            cmbNewGolferSize.ValueMember = "intShirtSizeID"
            cmbNewGolferSize.DisplayMember = "strShirtSizeDesc"
            cmbNewGolferSize.DataSource = dt


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

            '---bind ID to size----'
            cmbNewGolferGender.ValueMember = "intGenderID"
            cmbNewGolferGender.DisplayMember = "strGenderDesc"
            cmbNewGolferGender.DataSource = dt


            '---close---'
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
        '----SUB COMPLETE----'
    End Sub


    '-------------------------------------------------------------'
    ' Name: AddGolfer_Load
    ' Desc: reload golfer data
    '-------------------------------------------------------------'
    Private Sub frmAddGolfer_Load(Sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Load_ShirtSize()
            Load_Gender()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: ValidationTool
    ' Desc: Validate data
    '-------------------------------------------------------------'
    Public Function ValidationTool() As Boolean

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

        Return True
        '----FUNC COMPLETE----'
    End Function



    '-------------------------------------------------------------'
    ' Name: Exit_Click
    ' Desc: subroutine to close the window
    '-------------------------------------------------------------'
    Private Sub btnExitNewGolfer_Click(sender As Object, e As EventArgs) Handles btnExitNewGolfer.Click

        Close()
        '----SUB COMPLETE----'
    End Sub
End Class