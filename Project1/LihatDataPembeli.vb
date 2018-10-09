﻿Imports System.Data.OleDb
Public Class LihatDataPembeli
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Private Sub LihatDataPembeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Add("ID", 50)
        ListView1.Columns.Add("Nama", 100)
        ListView1.Columns.Add("Alamat", 100)
        ListView1.Columns.Add("No Telp", 100)
        Retrieve()
    End Sub
    Private Sub Populate(kode As String, nama As String, alamat As String, no_telp As String)
        Dim row As String() = New String() {kode, nama, alamat, no_telp}
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDialog1.Document = PrintDocument1
        PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        PrintPreviewDialog1.ShowDialog()
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim H As Integer = 0
        H = 50
        e.Graphics.DrawString("List Data Pembeli", New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
        H += 50
        e.Graphics.DrawString("ID", New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
        e.Graphics.DrawString("Username", New Drawing.Font("Times New Roman", 10), Brushes.Black, 100, H)
        e.Graphics.DrawString("Alamat", New Drawing.Font("Times New Roman", 10), Brushes.Black, 200, H)
        e.Graphics.DrawString("No. Telp", New Drawing.Font("Times New Roman", 10), Brushes.Black, 300, H)
        H += 20
        For Each Itm As ListViewItem In ListView1.Items
            e.Graphics.DrawString(Itm.Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
            e.Graphics.DrawString(Itm.SubItems(1).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 100, H)
            e.Graphics.DrawString(Itm.SubItems(2).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 200, H)
            e.Graphics.DrawString(Itm.SubItems(3).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 300, H)
            H += 20
        Next
    End Sub
End Class