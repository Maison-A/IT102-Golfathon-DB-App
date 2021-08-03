Option Strict On
Public Class frmEvents
    '-------------------------------------------------------------'
    ' Name: Events_Load
    ' Desc: give a default value of data when form is called
    '-------------------------------------------------------------'
    Private Sub frmEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '------load the events------'
            Load_EventYear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: Load_EventYear
    ' Desc: subroutine to load event data
    '-------------------------------------------------------------'
    Private Sub Load_EventYear()
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
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)
            '---bind ID to size----'
            cmbEventYear.ValueMember = "intEventYearID"
            cmbEventYear.DisplayMember = "intEventYear"
            cmbEventYear.DataSource = dt


            '---close---'
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: ExitEvents_Click
    ' Desc: exit the event form
    '-------------------------------------------------------------'
    Private Sub btnExitEvents_Click(sender As Object, e As EventArgs) Handles btnExitEvents.Click
        Close()
        '----SUB COMPLETE----'
    End Sub



    '-------------------------------------------------------------'
    ' Name: AddEvent_Click
    ' Desc: display the add event form
    '-------------------------------------------------------------'
    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click
        Dim frmNewEvent As New frmNewEvent

        frmNewEvent.ShowDialog()

        '---reload form and add event----'
        frmEvents_Load(sender, e)

        '----SUB COMPLETE----'
    End Sub

End Class