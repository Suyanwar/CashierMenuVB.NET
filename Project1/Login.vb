Imports System.Data.OleDb
Public Class Login
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim id As Integer
    Dim myConnection As OleDbConnection = New OleDbConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
            dataFile = "C:\Testing\Project1.mdb"
            connString = provider & dataFile
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [petugas] WHERE [username] = '" & TextBox1.Text & "' AND [password] = '" & TextBox2.Text & "'", myConnection)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            Dim userFound As Boolean = False
            While dr.Read
                userFound = True
                id = dr("ID").ToString
            End While
            If userFound = True Then
                Dim obb As New MainMenu
                obb.idnya = id
                TextBox1.Clear()
                TextBox2.Clear()
                Me.Hide()
                obb.Show()
            Else
                TextBox1.Text = ""
                TextBox2.Text = ""
                MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "Invalid Login")
            End If
            myConnection.Close()
        Else
            MsgBox("All fields are required", MsgBoxStyle.OkOnly, "Invalid Login")
        End If
    End Sub
End Class
