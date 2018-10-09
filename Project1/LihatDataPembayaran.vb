Imports System.Data.OleDb
Public Class LihatDataPembayaran
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Dim reader As OleDbDataReader
    Dim index As Integer = -1
    Public Property idnya As String
    Dim obb As New Pembayaran
    Private Sub LihatDataPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Add("ID", 30)
        ListView1.Columns.Add("Tgl_Lunas", 70)
        ListView1.Columns.Add("Nama", 100)
        ListView1.Columns.Add("Tgl_Pesan", 70)
        ListView1.Columns.Add("Tgl_Ambil", 70)
        ListView1.Columns.Add("Pesanan", 250)
        ListView1.Columns.Add("Total", 100)
        ListView1.Columns.Add("Uang Muka", 100)
        ListView1.Columns.Add("Sisa Bayar", 100)
        ListView1.Columns.Add("Bayar", 100)
        ListView1.Columns.Add("Kembali", 100)
        Retrieve()
    End Sub
    Private Sub Populate(kode As String, tgl_lunas As String, nama As String, tgl_pesan As String, tgl_ambil As String, pesanan As String, total As String, dp As String, sisa As String, bayar As String, kembali As String)
        Dim row As String() = New String() {kode, tgl_lunas, nama, tgl_pesan, tgl_ambil, pesanan, total, dp, sisa, bayar, kembali}
        Dim item As ListViewItem = New ListViewItem(row)
        ListView1.Items.Add(item)
    End Sub
    Private Sub Retrieve()
        ListView1.Items.Clear()
        Dim sql As String = "SELECT * FROM transaksi"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt)
            For Each row In dt.Rows
                Populate(row(0), row(1), row(2), row(3), row(4), row(6), row(7), row(8), row(9), row(10), row(11))
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
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim H As Integer = 0
        H = 50
        e.Graphics.DrawString("List Data Transaksi", New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
        H += 50
        e.Graphics.DrawString("ID", New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
        e.Graphics.DrawString("Tgl_Lunas", New Drawing.Font("Times New Roman", 10), Brushes.Black, 80, H)
        e.Graphics.DrawString("Nama", New Drawing.Font("Times New Roman", 10), Brushes.Black, 160, H)
        e.Graphics.DrawString("Tgl_Pesan", New Drawing.Font("Times New Roman", 10), Brushes.Black, 260, H)
        e.Graphics.DrawString("Tgl_Ambil", New Drawing.Font("Times New Roman", 10), Brushes.Black, 340, H)
        e.Graphics.DrawString("Pesanan", New Drawing.Font("Times New Roman", 10), Brushes.Black, 420, H)
        e.Graphics.DrawString("Total", New Drawing.Font("Times New Roman", 10), Brushes.Black, 550, H)
        e.Graphics.DrawString("DP", New Drawing.Font("Times New Roman", 10), Brushes.Black, 650, H)
        e.Graphics.DrawString("Sisa", New Drawing.Font("Times New Roman", 10), Brushes.Black, 750, H)
        e.Graphics.DrawString("Bayar", New Drawing.Font("Times New Roman", 10), Brushes.Black, 850, H)
        e.Graphics.DrawString("Kembali", New Drawing.Font("Times New Roman", 10), Brushes.Black, 950, H)
        H += 20
        For Each Itm As ListViewItem In ListView1.Items
            e.Graphics.DrawString(Itm.Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 50, H)
            e.Graphics.DrawString(Itm.SubItems(1).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 80, H)
            e.Graphics.DrawString(Itm.SubItems(2).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 160, H)
            e.Graphics.DrawString(Itm.SubItems(3).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 260, H)
            e.Graphics.DrawString(Itm.SubItems(4).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 340, H)
            Dim panjang_pesanan As Integer = Itm.SubItems(5).Text.Length
            Dim iterasi As Integer = 20
            Dim pesanan_baru As String = Itm.SubItems(5).Text
            While panjang_pesanan > 20
                pesanan_baru = pesanan_baru.Insert(iterasi, "" & vbCrLf & "")
                panjang_pesanan -= 20
                iterasi += 20
            End While
            e.Graphics.DrawString(pesanan_baru, New Drawing.Font("Times New Roman", 10), Brushes.Black, 420, H)
            e.Graphics.DrawString(Itm.SubItems(6).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 550, H)
            e.Graphics.DrawString(Itm.SubItems(7).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 650, H)
            e.Graphics.DrawString(Itm.SubItems(8).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 750, H)
            e.Graphics.DrawString(Itm.SubItems(9).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 850, H)
            e.Graphics.DrawString(Itm.SubItems(10).Text, New Drawing.Font("Times New Roman", 10), Brushes.Black, 950, H)
            If iterasi > 20 Then
                H += iterasi
            Else
                H += 20
            End If
        Next
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        index = ListView1.FocusedItem.Index
    End Sub
    Private Sub IsiKeterangan(id_transaksi As String)
        Dim sql As String = "SELECT [keterangan] FROM transaksi WHERE id_transaksi = '" & id_transaksi & "'"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    obb.TextBox5.Text = reader("keterangan")
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub IsiPesanan(id As String, nama As String)
        Dim gabungan As String = nama & id
        Dim sql As String = "SELECT [item], [jenis], [kuantitas], [ket], [subtotal] FROM pesanan WHERE pelanggan = '" & gabungan & "' ORDER BY ID"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    IsiListView(reader("item"), reader("jenis"), reader("ket"), reader("kuantitas"), reader("subtotal").Replace(",", ""))
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub IsiListView(pesanan As String, jenisitem As String, ket As String, kuantitas As String, subtotal As String)
        Dim row As String() = New String() {pesanan, jenisitem, kuantitas, subtotal, ket}
        Dim item As ListViewItem = New ListViewItem(row)
        obb.ListView1.Items.Add(item)
    End Sub
    Private Sub Hapus(id As String, nama As String)
        Dim gabungan As String = nama & id
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("DELETE * FROM pesanan WHERE pelanggan = '" & gabungan & "'", myConnection)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
        Dim sql As String = "DELETE * FROM transaksi WHERE id_transaksi = '" & id & "'"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        If index <> -1 Then
            obb.idnya = idnya
            obb.Show()
            obb.Label4.Text = ListView1.Items(index).Text
            obb.ComboBox1.SelectedItem = ListView1.Items(index).SubItems(2).Text
            obb.ComboBox1.Enabled = False
            obb.DateTimePicker1.Value = ListView1.Items(index).SubItems(1).Text
            obb.DateTimePicker2.Value = ListView1.Items(index).SubItems(3).Text
            obb.DateTimePicker3.Value = ListView1.Items(index).SubItems(4).Text
            IsiKeterangan(ListView1.Items(index).Text)
            IsiPesanan(ListView1.Items(index).Text, ListView1.Items(index).SubItems(2).Text)
            obb.Label12.Text = ListView1.Items(index).SubItems(6).Text
            obb.TextBox6.Text = ListView1.Items(index).SubItems(7).Text
            obb.Label15.Text = ListView1.Items(index).SubItems(8).Text
            obb.TextBox2.Text = ListView1.Items(index).SubItems(9).Text
            obb.Label17.Text = ListView1.Items(index).SubItems(10).Text
            obb.Button2.Text = "SIMPAN PERUBAHAN"
            Me.Close()
        Else
            MsgBox("Pilih salah satu kwitansi untuk diubah", MsgBoxStyle.OkOnly, "Invalid Update")
        End If
    End Sub
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If index <> -1 Then
            If MessageBox.Show("Anda yakin untuk menghapus pesanan?", "Hapus Pesanan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Hapus(ListView1.Items(index).Text, ListView1.Items(index).SubItems(2).Text)
                Retrieve()
            End If
        Else
            MsgBox("Pilih salah satu kwitansi untuk dihapus", MsgBoxStyle.OkOnly, "Invalid Delete")
        End If
    End Sub
End Class