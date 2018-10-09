Imports System.Data.OleDb
Public Class Pembayaran
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd, cmd1 As OleDbCommand
    Dim reader As OleDbDataReader
    Dim pesanan As String
    Dim count As Integer
    Dim index As Integer = -1
    Public Property idnya As String
    Public Shared Listv As System.Windows.Forms.ListView
    Public Shared Total As System.Windows.Forms.Label
    Private Sub Pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("Pesanan", 200)
        ListView1.Columns.Add("Jenis", 100)
        ListView1.Columns.Add("Kuantitas", 50)
        ListView1.Columns.Add("Sub Total", 100)
        ListView1.Columns.Add("Keterangan", 200)
        PopulateP()
        Isi_Pelunasan()
    End Sub
    Private Sub Pembayaran_Click(sender As Object, e As EventArgs) Handles Me.Click
        ComboBox1.Items.Clear()
        PopulateP()
    End Sub
    Private Sub PopulateP()
        Dim sql As String = "SELECT [nama] FROM pembeli"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    ComboBox1.Items.Add(reader("nama"))
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub Isi_Pelunasan()
        Dim sql As String = "SELECT COUNT(id_transaksi) FROM transaksi"
        Dim sql1 As String = "SELECT [id_transaksi] FROM transaksi ORDER BY [id_transaksi]"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            count = Convert.ToInt16(cmd.ExecuteScalar())
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
        cmd1 = New OleDbCommand(sql1, myConnection)
        Try
            myConnection.Open()
            reader = cmd1.ExecuteReader()
            If reader.HasRows Then
                Dim a As Integer = 0
                While reader.Read()
                    a += 1
                    If a = count Then
                        Label4.Text = (Val(reader("id_transaksi")) + 1)
                    End If
                End While
            Else
                Label4.Text = "1"
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DataPembeli.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedItem <> "" Or ComboBox1.Text <> "" Then
            Listv = ListView1
            Total = Label12
            Dim obb As New PesanMakanan
            obb.pembelinya = ComboBox1.SelectedItem & Label4.Text
            obb.Show()
        Else
            MsgBox("Input nama pembeli dahulu", MsgBoxStyle.OkOnly, "Invalid Insert")
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If IsNumeric(TextBox6.Text.Substring(2)) Then
            If Val(TextBox6.Text.Substring(2)) >= Val(Label12.Text.Replace(",", "").Substring(2)) Then
                Label15.Text = "Rp" & FormatCurrency(0).Substring(1)
            Else
                Label15.Text = "Rp" & FormatCurrency(Val(Label12.Text.Replace(",", "").Substring(2)) - Val(TextBox6.Text.Substring(2))).Substring(1)
            End If
            Label3.Text = "Ket"
        Else
            Label3.Text = "Harus Angka"
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text.Substring(2)) Then
            If Val(TextBox2.Text.Substring(2)) < Val(TextBox6.Text.Substring(2)) Then
                Label16.Text = "Minimal bayar >= UM"
            Else
                Label16.Text = "Ket"
                Label17.Text = "Rp" & FormatCurrency(Val(TextBox2.Text.Substring(2)) - Val(TextBox6.Text.Substring(2))).Substring(1)
            End If
        Else
            Label16.Text = "Harus Angka"
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = "Rp0"
        TextBox5.Clear()
        TextBox6.Text = "Rp0"
        ListView1.Items.Clear()
        Label12.Text = "Rp0"
        Label15.Text = "Rp0"
        Label3.Text = "Ket"
        Label17.Text = "Rp0"
        Label16.Text = "Ket"
        Isi_Pelunasan()
        ComboBox1.SelectedIndex = 0
        DateTimePicker1.Value = Format(Date.Now)
        DateTimePicker2.Value = Format(Date.Now)
        DateTimePicker3.Value = Format(Date.Now)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.SelectedItem <> "" And ListView1.Items.Count > 0 And Label3.Text <> "Harus Angka" And Label16.Text <> "Harus Angka" And Label16.Text <> "Minimal bayar >= UM" And TextBox2.Text <> "Rp0" And TextBox6.Text <> "Rp0" Then
            PrintDialog1.Document = PrintDocument1
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Else
            MsgBox("All fields are required!", MsgBoxStyle.OkOnly, "Invalid Print")
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "SIMPAN" Then
            If ComboBox1.SelectedItem <> "" And ListView1.Items.Count > 0 And Label3.Text <> "Harus Angka" And Label16.Text <> "Harus Angka" And Label16.Text <> "Minimal bayar >= UM" And TextBox2.Text <> "Rp0" And TextBox6.Text <> "Rp0" Then
                Dim coba() As String = ListView1.Items.Cast(Of ListViewItem).Select(Function(lvi As ListViewItem) lvi.SubItems(0).Text).ToArray()
                pesanan = String.Join(",", coba)
                Insert()
            Else
                MsgBox("All fields are required!", MsgBoxStyle.OkOnly, "Invalid Insert")
            End If
        Else
            If ListView1.Items.Count > 0 And Label3.Text <> "Harus Angka" And Label16.Text <> "Harus Angka" And Label16.Text <> "Minimal bayar >= UM" And TextBox2.Text <> "0" And TextBox6.Text <> "0" Then
                Dim coba() As String = ListView1.Items.Cast(Of ListViewItem).Select(Function(lvi As ListViewItem) lvi.SubItems(0).Text).ToArray()
                pesanan = String.Join(",", coba)
                Ubah()
            Else
                MsgBox("All fields are required!", MsgBoxStyle.OkOnly, "Invalid Insert")
            End If
        End If
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        index = ListView1.FocusedItem.Index
    End Sub
    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        If index <> -1 Then
            Dim obb As New PesanMakanan
            obb.pembelinya = ComboBox1.SelectedItem & Label4.Text
            obb.pesanannya = ListView1.Items(index).Text
            obb.Show()
            If ListView1.Items(index).SubItems(1).Text.Contains("Paket") Then
                obb.RadioButton2.Checked = True
                obb.ComboBox5.Enabled = True
                obb.ComboBox5.SelectedItem = ListView1.Items(index).Text
            Else
                obb.RadioButton1.Checked = True
                Dim pesananArr As String() = ListView1.Items(index).Text.Split(",")
                Dim jenisArr As String() = ListView1.Items(index).SubItems(1).Text.Split(",")
                Dim i As Integer = 0
                For Each jenisnya As String In jenisArr
                    If jenisnya = "Nasi" Then
                        obb.ComboBox1.Enabled = True
                        obb.ComboBox1.SelectedItem = pesananArr(i)
                    ElseIf jenisnya = "Ayam" Then
                        obb.ComboBox2.Enabled = True
                        obb.ComboBox2.SelectedItem = pesananArr(i)
                    ElseIf jenisnya = "Daging" Then
                        obb.ComboBox3.Enabled = True
                        obb.ComboBox3.SelectedItem = pesananArr(i)
                    ElseIf jenisnya = "Tumisan" Then
                        obb.ComboBox4.Enabled = True
                        obb.ComboBox4.SelectedItem = pesananArr(i)
                    Else
                        Console.WriteLine(jenisnya)
                    End If
                    i += 1
                Next
            End If
            obb.TextBox1.Text = ListView1.Items(index).SubItems(4).Text
            obb.NumericUpDown1.Value = ListView1.Items(index).SubItems(2).Text
            obb.Label4.Text = ListView1.Items(index).SubItems(3).Text
            obb.Button2.Text = "SIMPAN"
            'Hapus(ListView1.Items(index).Text)
            Label12.Text = "Rp" & FormatCurrency(Val(Label12.Text.Replace(",", "").Substring(2)) - Val(ListView1.Items(index).SubItems(3).Text.Replace(",", "").Substring(2))).Substring(1)
            ListView1.Items(index).Remove()
        Else
            MsgBox("Pilih salah satu pesanan untuk diubah", MsgBoxStyle.OkOnly, "Invalid Update")
        End If
    End Sub
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        index = ListView1.FocusedItem.Index
        If index <> -1 Then
            If MessageBox.Show("Anda yakin untuk menghapus pesanan?", "Hapus Pesanan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Hapus(ListView1.Items(index).Text)
                Label12.Text = "Rp" & FormatCurrency(Val(Label12.Text.Replace(",", "").Substring(2)) - Val(ListView1.Items(index).SubItems(3).Text.Replace(",", "").Substring(2))).Substring(1)
                ListView1.Items(index).Remove()
            End If
        Else
            MsgBox("Pilih salah satu pesanan untuk dihapus", MsgBoxStyle.OkOnly, "Invalid Delete")
        End If
    End Sub
    Private Sub Hapus(pesanannya As String)
        Dim gabungan As String = ComboBox1.SelectedItem & Label4.Text
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("DELETE * FROM pesanan WHERE pelanggan = '" & gabungan & "' AND item = '" & pesanannya & "'", myConnection)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub Insert()
        Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO transaksi([id_transaksi], [tanggal_pelunasan], [nama], [tanggal_pesan], [tanggal_ambil], [keterangan], [pesanan], [jumlah_total], [uang_muka], [sisa_bayar], [bayar], [kembali]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", myConnection)
        cmd.Parameters.Add(New OleDbParameter("id_transaksi", CType(Label4.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("tanggal_pelunasan", DateTimePicker1.Value.Date))
        cmd.Parameters.Add(New OleDbParameter("nama", ComboBox1.SelectedItem))
        cmd.Parameters.Add(New OleDbParameter("tanggal_pesan", DateTimePicker2.Value.Date))
        cmd.Parameters.Add(New OleDbParameter("tanggal_ambil", DateTimePicker3.Value.Date))
        cmd.Parameters.Add(New OleDbParameter("keterangan", CType(TextBox5.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("pesanan", pesanan))
        cmd.Parameters.Add(New OleDbParameter("jumlah_total", Label12.Text))
        cmd.Parameters.Add(New OleDbParameter("uang_muka", "Rp" & FormatCurrency(Val(TextBox6.Text.Substring(2))).Substring(1)))
        cmd.Parameters.Add(New OleDbParameter("sisa_bayar", Label15.Text))
        cmd.Parameters.Add(New OleDbParameter("bayar", "Rp" & FormatCurrency(Val(TextBox2.Text.Substring(2))).Substring(1)))
        cmd.Parameters.Add(New OleDbParameter("kembali", Label17.Text))
        Try
            myConnection.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            'TextBox2.Text = "Rp0"
            'TextBox5.Clear()
            'TextBox6.Text = "Rp0"
            'ListView1.Items.Clear()
            'Label12.Text = "Rp0"
            'Label15.Text = "Rp0"
            'Label3.Text = "Ket"
            'Label17.Text = "Rp0"
            'Label16.Text = "Ket"
            'ComboBox1.Refresh()
            'DateTimePicker1.Value = Format(Date.Now)
            'DateTimePicker2.Value = Format(Date.Now)
            'DateTimePicker3.Value = Format(Date.Now)
            'myConnection.Close()
            'Isi_Pelunasan()
            MsgBox("Inserted!", MsgBoxStyle.OkOnly, "Insert Succeed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ubah()
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE transaksi SET [tanggal_pelunasan] = '" & DateTimePicker1.Value.Date & "', [tanggal_pesan] = '" & DateTimePicker2.Value.Date & "', [tanggal_ambil] = '" & DateTimePicker3.Value.Date & "', [keterangan] = '" & TextBox5.Text & "', [pesanan] = '" & pesanan & "', [jumlah_total] = '" & Label12.Text & "', [uang_muka] = 'Rp" & FormatCurrency(Val(TextBox6.Text.Substring(2))).Substring(1) & "', [sisa_bayar] = '" & Label15.Text & "', [bayar] = 'Rp" & FormatCurrency(Val(TextBox2.Text.Substring(2))).Substring(1) & "', [kembali] = '" & Label17.Text & "' WHERE [id_transaksi] = '" & Label4.Text & "'", myConnection)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            MsgBox("Updated!", MsgBoxStyle.OkOnly, "Update Succeed")
            Me.Close()
            LihatDataPembayaran.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim H As Integer = 0
        H = 50
        e.Graphics.DrawString("CV. PRIMA RASA", New Drawing.Font("Times New Roman", 16), Brushes.Black, 50, H)
        H += 30
        e.Graphics.DrawString("Jl. H. Naman No. 15", New Drawing.Font("Times New Roman", 14), Brushes.Black, 50, H)
        H += 30
        e.Graphics.DrawString("Pondok Kelapa - Jakarta Timur", New Drawing.Font("Times New Roman", 14), Brushes.Black, 50, H)
        H += 100
        e.Graphics.DrawString("BUKTI PEMBAYARAN", New Drawing.Font("Times New Roman", 14), Brushes.Black, 50, H)
        H += 30
        e.Graphics.DrawString("No. Transaksi", New Drawing.Font("Times New Roman", 12), Brushes.Black, 50, H)
        e.Graphics.DrawString(Label4.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 200, H)
        e.Graphics.DrawString("Tanggal", New Drawing.Font("Times New Roman", 12), Brushes.Black, 400, H)
        e.Graphics.DrawString(DateTimePicker1.Value.Date, New Drawing.Font("Times New Roman", 12), Brushes.Black, 600, H)
        H += 30
        e.Graphics.DrawString("Nama", New Drawing.Font("Times New Roman", 12), Brushes.Black, 50, H)
        e.Graphics.DrawString(ComboBox1.SelectedItem, New Drawing.Font("Times New Roman", 12), Brushes.Black, 200, H)
        e.Graphics.DrawString("No. Telepon", New Drawing.Font("Times New Roman", 12), Brushes.Black, 400, H)
        e.Graphics.DrawString(IsiNoTelp(ComboBox1.SelectedItem), New Drawing.Font("Times New Roman", 12), Brushes.Black, 600, H)
        H += 30
        e.Graphics.DrawString("Alamat", New Drawing.Font("Times New Roman", 12), Brushes.Black, 50, H)
        e.Graphics.DrawString(IsiAlamat(ComboBox1.SelectedItem), New Drawing.Font("Times New Roman", 12), Brushes.Black, 200, H)
        H += 30
        e.Graphics.DrawString("JUMLAH TOTAL", New Drawing.Font("Times New Roman", 12), Brushes.Black, 400, H)
        e.Graphics.DrawString(Label12.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 650, H)
        H += 30
        e.Graphics.DrawString("UANG MUKA", New Drawing.Font("Times New Roman", 12), Brushes.Black, 400, H)
        e.Graphics.DrawString("Rp" & FormatCurrency(Val(TextBox6.Text.Substring(2).Replace(",", ""))).Substring(1), New Drawing.Font("Times New Roman", 12), Brushes.Black, 650, H)
        H += 30
        e.Graphics.DrawString("SISA", New Drawing.Font("Times New Roman", 12), Brushes.Black, 400, H)
        e.Graphics.DrawString(Label15.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 650, H)
        H += 200
        e.Graphics.DrawString("Pelanggan", New Drawing.Font("Times New Roman", 12), Brushes.Black, 100, H)
        e.Graphics.DrawString("Admin", New Drawing.Font("Times New Roman", 12), Brushes.Black, 350, H)
        e.Graphics.DrawString("Pimpinan", New Drawing.Font("Times New Roman", 12), Brushes.Black, 600, H)
        H += 100
        e.Graphics.DrawString(ComboBox1.SelectedItem, New Drawing.Font("Times New Roman", 12), Brushes.Black, 100, H)
        e.Graphics.DrawString(IsiNamaAdmin(idnya), New Drawing.Font("Times New Roman", 12), Brushes.Black, 350, H)
        e.Graphics.DrawString("Oktavyanti Marcella", New Drawing.Font("Times New Roman", 12), Brushes.Black, 600, H)
    End Sub
    Function IsiNoTelp(ByVal nama As String) As String
        Dim no As String
        Dim sql As String = "SELECT [no_telp] FROM pembeli WHERE nama = '" & nama & "'"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    no = reader("no_telp")
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
        IsiNoTelp = no
    End Function
    Function IsiAlamat(ByVal nama As String) As String
        Dim alamat As String
        Dim sql As String = "SELECT [alamat] FROM pembeli WHERE nama = '" & nama & "'"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    alamat = reader("alamat")
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
        IsiAlamat = alamat
    End Function
    Function IsiNamaAdmin(ByVal id As String) As String
        Dim nama As String
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT [username] FROM petugas WHERE [ID] = " & Val(id), myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    nama = reader("username")
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
        IsiNamaAdmin = nama
    End Function
End Class