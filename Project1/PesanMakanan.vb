Imports System.Data.OleDb
Public Class PesanMakanan
    Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Testing\Project1.mdb"
    Dim myConnection As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim reader As OleDbDataReader
    Dim harganasi, hargaayam, hargadaging, hargatumisan, hargapaket As New ArrayList
    Public Property pembelinya As String
    Public Property pesanannya As String
    Dim jenisitem As String = ""
    Private Sub PesanMakanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate("Nasi")
        Populate("Ayam")
        Populate("Daging")
        Populate("Tumisan")
        Populate("Paket")
    End Sub
    Private Sub Populate(jenis As String)
        Dim sql As String = "SELECT * FROM makanan WHERE jenis = '" & jenis & "'"
        cmd = New OleDbCommand(sql, myConnection)
        Try
            myConnection.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    If jenis = "Nasi" Then
                        ComboBox1.Items.Add(reader("nama_makanan"))
                        harganasi.Add(reader("harga"))
                    ElseIf jenis = "Ayam" Then
                        ComboBox2.Items.Add(reader("nama_makanan"))
                        hargaayam.Add(reader("harga"))
                    ElseIf jenis = "Daging" Then
                        ComboBox3.Items.Add(reader("nama_makanan"))
                        hargadaging.Add(reader("harga"))
                    ElseIf jenis = "Tumisan" Then
                        ComboBox4.Items.Add(reader("nama_makanan"))
                        hargatumisan.Add(reader("harga"))
                    Else
                        ComboBox5.Items.Add(reader("nama_makanan"))
                        hargapaket.Add(reader("harga"))
                    End If
                End While
            End If
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.SelectedItem = ""
        ComboBox5.Enabled = False
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.SelectedItem = ""
        ComboBox2.SelectedItem = ""
        ComboBox3.SelectedItem = ""
        ComboBox4.SelectedItem = ""
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, b, c, d, f As Integer
        If ComboBox1.SelectedIndex >= 0 Then
            a = Val(harganasi(ComboBox1.SelectedIndex))
        Else
            a = 0
        End If
        If ComboBox2.SelectedIndex >= 0 Then
            b = Val(hargaayam(ComboBox2.SelectedIndex))
        Else
            b = 0
        End If
        If ComboBox3.SelectedIndex >= 0 Then
            c = Val(hargadaging(ComboBox3.SelectedIndex))
        Else
            c = 0
        End If
        If ComboBox4.SelectedIndex >= 0 Then
            d = Val(hargatumisan(ComboBox4.SelectedIndex))
        Else
            d = 0
        End If
        If ComboBox5.SelectedIndex >= 0 Then
            f = Val(hargapaket(ComboBox5.SelectedIndex))
        Else
            f = 0
        End If
        If f <> 0 Then
            Label4.Text = "Rp" & FormatCurrency(Val(f * NumericUpDown1.Value)).Substring(1)
        Else
            Label4.Text = "Rp" & FormatCurrency(Val((a + b + c + d) * NumericUpDown1.Value)).Substring(1)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pesanan As String = ""
        Dim ket As String
        If Label4.Text <> "0" Or Label4.Text <> "Rp0" Then
            If TextBox1.Text = "" Then
                ket = ""
            Else
                ket = TextBox1.Text
            End If
            If RadioButton1.Checked Then
                If ComboBox1.SelectedItem <> "" Then
                    If pesanan = "" Then
                        pesanan = ComboBox1.SelectedItem
                    Else
                        pesanan = pesanan & "," & ComboBox1.SelectedItem
                    End If
                    If jenisitem = "" Then
                        jenisitem = "Nasi"
                    Else
                        jenisitem = jenisitem & ",Nasi"
                    End If
                End If
                If ComboBox2.SelectedItem <> "" Then
                    If pesanan = "" Then
                        pesanan = ComboBox2.SelectedItem
                    Else
                        pesanan = pesanan & "," & ComboBox2.SelectedItem
                    End If
                    If jenisitem = "" Then
                        jenisitem = "Ayam"
                    Else
                        jenisitem = jenisitem & ",Ayam"
                    End If
                End If
                If ComboBox3.SelectedItem <> "" Then
                    If pesanan = "" Then
                        pesanan = ComboBox3.SelectedItem
                    Else
                        pesanan = pesanan & "," & ComboBox3.SelectedItem
                    End If
                    If jenisitem = "" Then
                        jenisitem = "Daging"
                    Else
                        jenisitem = jenisitem & ",Daging"
                    End If
                End If
                If ComboBox4.SelectedItem <> "" Then
                    If pesanan = "" Then
                        pesanan = ComboBox4.SelectedItem
                    Else
                        pesanan = pesanan & "," & ComboBox4.SelectedItem
                    End If
                    If jenisitem = "" Then
                        jenisitem = "Tumisan"
                    Else
                        jenisitem = jenisitem & ",Tumisan"
                    End If
                End If
            Else
                pesanan = ComboBox5.SelectedItem
                If ComboBox5.SelectedItem <> "" Then
                    jenisitem = jenisitem & "Paket"
                End If
            End If
            If Button2.Text = "SIMPAN" Then
                Ubah(pesanan, ket, NumericUpDown1.Value, Label4.Text, jenisitem)
            Else
                Insert(pesanan, ket, NumericUpDown1.Value, Label4.Text, jenisitem)
            End If
        End If
    End Sub
    Private Sub Insert(pesanan As String, ket As String, kuantitas As String, subtotal As String, jenisitem As String)
        Dim row As String() = New String() {pesanan, jenisitem, kuantitas, subtotal, ket}
        Dim items As ListViewItem = New ListViewItem(row)
        Pembayaran.Total.Text = "Rp" & FormatCurrency(Val(Pembayaran.Total.Text.Replace(",", "").Substring(2)) + Val(subtotal.Replace(",", "").Substring(2))).Substring(1)
        InsertDb(pesanan, ket, kuantitas, subtotal, jenisitem)
        Pembayaran.Listv.Items.Add(items)
        Me.Close()
    End Sub
    Private Sub InsertDb(pesanan As String, ket As String, kuantitas As String, subtotal As String, jenisitem As String)
        Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO pesanan([item], [jenis], [kuantitas], [ket], [subtotal], [pelanggan]) VALUES(?, ?, ?, ?, ?, ?)", myConnection)
        cmd.Parameters.Add(New OleDbParameter("item", pesanan))
        cmd.Parameters.Add(New OleDbParameter("jenis", jenisitem))
        cmd.Parameters.Add(New OleDbParameter("kuantitas", kuantitas))
        cmd.Parameters.Add(New OleDbParameter("ket", ket))
        cmd.Parameters.Add(New OleDbParameter("subtotal", subtotal))
        cmd.Parameters.Add(New OleDbParameter("pelanggan", pembelinya))
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
    Private Sub Ubah(pesanan As String, ket As String, kuantitas As String, subtotal As String, jenisitem As String)
        Dim row As String() = New String() {pesanan, jenisitem, kuantitas, subtotal, ket}
        Dim item As ListViewItem = New ListViewItem(row)
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE pesanan SET [item] = '" & pesanan & "', [jenis] = '" & jenisitem & "', [kuantitas] = '" & kuantitas & "', [ket] = '" & ket & "', [subtotal] = '" & subtotal & "' WHERE [pelanggan] = '" & pembelinya & "' AND [item] = '" & pesanannya & "'", myConnection)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            Pembayaran.Total.Text = "Rp" & FormatCurrency(Val(Pembayaran.Total.Text.Replace(",", "").Substring(2)) + Val(subtotal.Replace(",", "").Substring(2))).Substring(1)
            Pembayaran.Listv.Items.Add(item)
            MsgBox("Updated!", MsgBoxStyle.OkOnly, "Update Succeed")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
        End Try
    End Sub
End Class