Imports System.Data.OleDb
Public Class DataPembeli
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Private Sub DataPembeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("Kode Pembeli", 50)
        ListView1.Columns.Add("Nama Pembeli", 100)
        ListView1.Columns.Add("Alamat", 100)
        ListView1.Columns.Add("No. Telp", 100)
        Retrieve()
    End Sub
    Private Sub Populate(kode_pembeli As String, nama_pembeli As String, alamat As String, no_telp As String)
        Dim row As String() = New String() {kode_pembeli, nama_pembeli, alamat, no_telp}
        Dim item As ListViewItem = New ListViewItem(row)
        ListView1.Items.Add(item)
    End Sub
    Private Sub Retrieve()
        ListView1.Items.Clear()
        Dim sql As String = "SELECT * FROM pembeli"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt)
            For Each row In dt.Rows
                Populate(row(0), row(1), row(2), row(3))
            Next
            dt.Rows.Clear()
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub Insert()
        Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO pembeli([nama], [alamat], [no_telp]) VALUES(?, ?, ?)", myConnection)
        cmd.Parameters.Add(New OleDbParameter("nama", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("alamat", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("no_telp", CType(TextBox3.Text, String)))
        Try
            myConnection.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            MsgBox("Inserted!", MsgBoxStyle.OkOnly, "Insert Succeed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ubah()
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
            myConnection.Open()
            Dim cmd As OleDbCommand = New OleDbCommand("UPDATE pembeli SET [nama] = '" & TextBox1.Text & "', [alamat] = '" & TextBox2.Text & "', [no_telp] = '" & TextBox3.Text & "' WHERE [kode_pembeli] = " & Val(Label5.Text), myConnection)
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myConnection.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                Label5.Text = "Label5"
                MsgBox("Updated!", MsgBoxStyle.OkOnly, "Update Succeed")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("All fields are required Or your password doesn't match", MsgBoxStyle.OkOnly, "Invalid Update")
        End If
    End Sub
    Private Sub Delete()
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("DELETE FROM pembeli WHERE [kode_pembeli] = " & Val(Label5.Text), myConnection)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Label5.Text = "Label5"
            MsgBox("Deleted!", MsgBoxStyle.OkOnly, "Delete Succeed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Label5.Text = "Label5"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Label5.Text <> "Label5" Then
            Ubah()
            Retrieve()
        Else
            MsgBox("Pilih salah satu pembeli untuk diubah", MsgBoxStyle.OkOnly, "Invalid Update")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
            Insert()
            Retrieve()
        Else
            MsgBox("All fields are required", MsgBoxStyle.OkOnly, "Invalid Insert")
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim index = ListView1.FocusedItem.Index
        Label5.Text = ListView1.Items(index).Text
        TextBox1.Text = ListView1.Items(index).SubItems(1).Text
        TextBox2.Text = ListView1.Items(index).SubItems(2).Text
        TextBox3.Text = ListView1.Items(index).SubItems(3).Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Label5.Text <> "Label5" Then
            Delete()
            Retrieve()
        Else
            MsgBox("Pilih salah satu pembeli untuk dihapus", MsgBoxStyle.OkOnly, "Invalid Delete")
        End If
    End Sub
End Class