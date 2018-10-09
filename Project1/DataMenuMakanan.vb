Imports System.Data.OleDb
Public Class DataMenuMakanan
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Dim detail As String
    Private Sub DataMenuMakanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("Kode Makanan", 50)
        ListView1.Columns.Add("Nama Makanan", 100)
        ListView1.Columns.Add("Jenis", 100)
        ListView1.Columns.Add("Detail", 100)
        ListView1.Columns.Add("Harga", 100)
        Retrieve()
    End Sub
    Private Sub Populate(kode_makanan As String, nama_makanan As String, jenis As String, detail As String, harga As String)
        Dim row As String() = New String() {kode_makanan, nama_makanan, jenis, detail, harga}
        Dim item As ListViewItem = New ListViewItem(row)
        ListView1.Items.Add(item)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        Label6.Text = "Label6"
    End Sub
    Private Sub Insert()
        Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO makanan([nama_makanan], [jenis], [detail], [harga]) VALUES(?, ?, ?, ?)", myConnection)
        cmd.Parameters.Add(New OleDbParameter("nama_makanan", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("jenis", CType(TextBox1.Text, String)))
        If TextBox1.Text = "Paket" Then
            detail = TextBox4.Text
        Else
            detail = "Kosong"
        End If
        cmd.Parameters.Add(New OleDbParameter("detail", CType(detail, String)))
        cmd.Parameters.Add(New OleDbParameter("harga", CType(TextBox5.Text, String)))
        Try
            myConnection.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            MsgBox("Inserted!", MsgBoxStyle.OkOnly, "Insert Succeed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ubah()
        If TextBox1.Text <> "Paket" Then
            detail = "Kosong"
        Else
            detail = TextBox4.Text
        End If
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE makanan SET [nama_makanan] = '" & TextBox2.Text & "', [jenis] = '" & TextBox1.Text & "', [detail] = '" & detail & "', [harga] = '" & TextBox5.Text & "' WHERE [kode_makanan] = " & Val(Label6.Text), myConnection)
        Try
            myConnection.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Label6.Text = "Label6"
            MsgBox("Updated!", MsgBoxStyle.OkOnly, "Update Succeed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Delete()
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("DELETE FROM makanan WHERE [kode_makanan] = " & Val(Label6.Text), myConnection)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Label6.Text = "Label6"
            MsgBox("Deleted!", MsgBoxStyle.OkOnly, "Delete Succeed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox5.Text <> "" Then
            If IsNumeric(TextBox5.Text) Then
                Insert()
                Retrieve()
            Else
                MsgBox("Harga harus angka!", MsgBoxStyle.OkOnly, "Invalid Insert")
            End If
        Else
                MsgBox("All fields are required", MsgBoxStyle.OkOnly, "Invalid Insert")
        End If
    End Sub
    Private Sub Retrieve()
        ListView1.Items.Clear()
        Dim sql As String = "SELECT * FROM makanan"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt)
            For Each row In dt.Rows
                Populate(row(0), row(1), row(2), row(3), row(4))
            Next
            dt.Rows.Clear()
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim index = ListView1.FocusedItem.Index
        Label6.Text = ListView1.Items(index).Text
        TextBox1.Text = ListView1.Items(index).SubItems(2).Text
        TextBox2.Text = ListView1.Items(index).SubItems(1).Text
        TextBox4.Text = ListView1.Items(index).SubItems(3).Text
        TextBox5.Text = ListView1.Items(index).SubItems(4).Text
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Label6.Text <> "Label6" Then
            If IsNumeric(TextBox5.Text) Then
                Ubah()
                Retrieve()
            Else
                MsgBox("Harga harus angka!", MsgBoxStyle.OkOnly, "Invalid Insert")
            End If
        Else
            MsgBox("Pilih salah satu makanan untuk diubah", MsgBoxStyle.OkOnly, "Invalid Update")
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Label6.Text <> "Label6" Then
            Delete()
            Retrieve()
        Else
            MsgBox("Pilih salah satu makanan untuk dihapus", MsgBoxStyle.OkOnly, "Invalid Delete")
        End If
    End Sub
End Class