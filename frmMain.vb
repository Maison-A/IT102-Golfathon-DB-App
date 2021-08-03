' *****************************************************************************
' Arroyo, Maison
' 25 May 2021
' 
' This program will pull Golfers from a Golfathon's last name from DB and
' load combo box. Once the golfer's last name is selected, it will then display the
' golfers data
' *****************************************************************************
Option Strict On
'-------------------------------------------------------------'
' Name: MngGolfers_Click
' Desc: display golfer data form
'-------------------------------------------------------------'
Public Class frmMain
    Private Sub btnMngGolfers_Click(sender As Object, e As EventArgs) Handles btnMngGolfers.Click
        Dim frmGolfers As New frmGolfers

        frmGolfers.ShowDialog()

    End Sub



    '-------------------------------------------------------------'
    ' Name: MngEvents_Click
    ' Desc: display events form
    '-------------------------------------------------------------'
    Private Sub btnMngEvents_Click(sender As Object, e As EventArgs) Handles btnMngEvents.Click
        Dim frmEvents As New frmEvents

        frmEvents.ShowDialog()

    End Sub



    '-------------------------------------------------------------'
    ' Name: Exit_Click
    ' Desc: close the program
    '-------------------------------------------------------------'
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnManageGolferEvent_Click(sender As Object, e As EventArgs) Handles btnManageGolferEvent.Click
        Dim frmEventGolfers As New frmEventGolfers

        frmEventGolfers.ShowDialog()
    End Sub
End Class
