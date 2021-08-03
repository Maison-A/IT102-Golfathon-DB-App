Public Class frmNewEvent
    '-------------------------------------------------------------'
    ' Name: SubmitNewEvent_Click
    ' Desc: subroutine to handle calls after submit event
    '-------------------------------------------------------------'
    Private Sub btnNewEventSubmit_Click(sender As Object, e As EventArgs) Handles btnNewEventSubmit.Click
        Dim strNewEvent_Year = txtNewEventYear.Text

        '----number of rows affected-----'
        Dim intRowsAffected As Integer

        '-----validate-----'
        If ValidationTool() = True Then
            Dim cmdAddEvent As New OleDb.OleDbCommand()
            Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it

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

                ' text to call stored proc
                cmdAddEvent.CommandText = "EXECUTE uspAddEvent '" & intPKID & "'," & strNewEvent_Year
                cmdAddEvent.CommandType = CommandType.StoredProcedure

                ' Call stored proc which will insert the record 
                cmdAddEvent = New OleDb.OleDbCommand(cmdAddEvent.CommandText, m_conAdministrator)

                ' return the # of rows affected
                intRowsAffected = cmdAddEvent.ExecuteNonQuery()

                'Close database connection
                CloseDatabaseConnection()

                '---if successful let user know-----'
                If intRowsAffected > 0 Then
                    MessageBox.Show("Event has been added")
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
End Class