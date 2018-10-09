Imports System.Data.OleDb
Public Class TambahPetugas
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And
            TextBox5.Text = TextBox4.Text Then
            provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
            dataFile = "C:\Testing\Project1.mdb"
            connString = provider & dataFile
            myConnection.ConnectionString = connString
            myConnection.Open()

            Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO petugas([username], [password], [alamat], [no_telp]) VALUES(?, ?, ?, ?)", myConnection)
            cmd.Parameters.Add(New OleDbParameter("username", CType(TextBox1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("password", CType(TextBox4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("alamat", CType(TextBox2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("no_telp", CType(TextBox3.Text, String)))
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myConnection.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                MsgBox("Inserted!", MsgBoxStyle.OkOnly, "Insert Succeed")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("All fields are required or your password doesn't match", MsgBoxStyle.OkOnly, "Invalid Insert")
        End If
    End Sub
End Class