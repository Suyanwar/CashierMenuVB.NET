Public Class MainMenu
    Public Property idnya As String
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = idnya
    End Sub
    Private Sub TambahPetugasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahPetugasToolStripMenuItem.Click
        TambahPetugas.Show()
    End Sub
    Private Sub DataPetugasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPetugasToolStripMenuItem.Click
        LihatPetugas.Show()
    End Sub
    Private Sub GantiSandiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GantiSandiToolStripMenuItem.Click
        Dim obb As New GantiPassword
        obb.idnya = idnya
        obb.Show()
    End Sub
    Private Sub DataPembeliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPembeliToolStripMenuItem.Click
        DataPembeli.Show()
    End Sub
    Private Sub DataMenuMakananToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMenuMakananToolStripMenuItem.Click
        DataMenuMakanan.Show()
    End Sub
    Private Sub PembayaranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembayaranToolStripMenuItem.Click
        'Pembayaran.Show()
        Dim obb As New Pembayaran
        obb.idnya = idnya
        obb.Show()
    End Sub
    Private Sub PetugasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetugasToolStripMenuItem.Click
        LihatPetugas.Show()
    End Sub
    Private Sub MenuMakananToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuMakananToolStripMenuItem.Click
        LihatDataMenu.Show()
    End Sub
    Private Sub PembeliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembeliToolStripMenuItem.Click
        LihatDataPembeli.Show()
    End Sub
    Private Sub PembayaranToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PembayaranToolStripMenuItem1.Click
        'LihatDataPembayaran.Show()
        Dim obb As New LihatDataPembayaran
        obb.idnya = idnya
        obb.Show()
    End Sub
    Private Sub KeluarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem1.Click
        Me.Close()
        Login.Show()
    End Sub
End Class