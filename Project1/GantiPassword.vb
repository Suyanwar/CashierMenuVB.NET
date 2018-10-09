Imports System.Data.OleDb
Public Class GantiPassword
    Public Property idnya As String
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox3.Text = TextBox2.Text Then
            provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
            dataFile = "C:\Testing\Project1.mdb"
            connString = provider & dataFile
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim cmd As OleDbCommand = New OleDbCommand("UPDATE petugas SET [password] = '" & TextBox2.Text & "' WHERE [password] = '" & TextBox1.Text & "' AND [ID] = " & Val(idnya), myConnection)
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myConnection.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                MsgBox("Updated!", MsgBoxStyle.OkOnly, "Update Succeed")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("All fields are required Or your password doesn't match", MsgBoxStyle.OkOnly, "Invalid Update")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class