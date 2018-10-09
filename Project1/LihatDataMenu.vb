Imports System.Data.OleDb
Public Class LihatDataMenu
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Private Sub LihatDataMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Add("ID", 50)
        ListView1.Columns.Add("Nama", 125)
        ListView1.Columns.Add("Jenis", 75)
        ListView1.Columns.Add("Detail", 300)
        ListView1.Columns.Add("Harga", 100)
        Retrieve()
    End Sub
    Private Sub Populate(kode As String, nama As String, jenis As String, detail As String, harga As String)
        Dim row As String() = New String() {kode, nama, jenis, detail, harga}
        Dim item As ListViewItem = New ListViewItem(row)
        ListView1.Items.Add(item)
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
                Populate(row(0), row(1), row(2), row(3), "Rp" & FormatCurrency(Val(row(4))).Substring(1))
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
        e.Graphics.DrawString("List Data Menu Makanan", New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
        H += 50
        e.Graphics.DrawString("ID", New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
        e.Graphics.DrawString("Nama", New Drawing.Font("Times New Roman", 10), Brushes.Black, 100, H)
        e.Graphics.DrawString("Jenis", New Drawing.Font("Times New Roman", 10), Brushes.Black, 200, H)
        e.Graphics.DrawString("Detail", New Drawing.Font("Times New Roman", 10), Brushes.Black, 300, H)
        e.Graphics.DrawString("Harga", New Drawing.Font("Times New Roman", 10), Brushes.Black, 600, H)
        H += 20
        For Each Itm As ListViewItem In ListView1.Items
            e.Graphics.DrawString(Itm.Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
            e.Graphics.DrawString(Itm.SubItems(1).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 100, H)
            e.Graphics.DrawString(Itm.SubItems(2).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 200, H)
            Dim panjang_pesanan As Integer = Itm.SubItems(3).Text.Length
            Dim iterasi As Integer = 20
            Dim pesanan_baru As String = Itm.SubItems(3).Text
            While panjang_pesanan > 20
                pesanan_baru = pesanan_baru.Insert(iterasi, "" & vbCrLf & "")
                panjang_pesanan -= 20
                iterasi += 20
            End While
            e.Graphics.DrawString(pesanan_baru, New Drawing.Font("Times New Roman", 10), Brushes.Black, 300, H)
            e.Graphics.DrawString(Itm.SubItems(4).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 600, H)
            If iterasi > 20 Then
                H += iterasi - 20
            Else
                H += 20
            End If
        Next
    End Sub
End Class