<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PengaturanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TambahPetugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GantiSandiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPetugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPembeliToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataMenuMakananToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembayaranToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PetugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMakananToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembeliToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembayaranToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5)
        Me.Label1.Size = New System.Drawing.Size(49, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PengaturanToolStripMenuItem, Me.DataMenuToolStripMenuItem, Me.KeluarToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.KeluarToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(416, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PengaturanToolStripMenuItem
        '
        Me.PengaturanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TambahPetugasToolStripMenuItem, Me.GantiSandiToolStripMenuItem})
        Me.PengaturanToolStripMenuItem.Name = "PengaturanToolStripMenuItem"
        Me.PengaturanToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.PengaturanToolStripMenuItem.Text = "Pengaturan"
        '
        'TambahPetugasToolStripMenuItem
        '
        Me.TambahPetugasToolStripMenuItem.Name = "TambahPetugasToolStripMenuItem"
        Me.TambahPetugasToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.TambahPetugasToolStripMenuItem.Text = "Tambah Petugas"
        '
        'GantiSandiToolStripMenuItem
        '
        Me.GantiSandiToolStripMenuItem.Name = "GantiSandiToolStripMenuItem"
        Me.GantiSandiToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.GantiSandiToolStripMenuItem.Text = "Ganti Sandi"
        '
        'DataMenuToolStripMenuItem
        '
        Me.DataMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataPetugasToolStripMenuItem, Me.DataPembeliToolStripMenuItem, Me.DataMenuMakananToolStripMenuItem})
        Me.DataMenuToolStripMenuItem.Name = "DataMenuToolStripMenuItem"
        Me.DataMenuToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataMenuToolStripMenuItem.Text = "Data"
        '
        'DataPetugasToolStripMenuItem
        '
        Me.DataPetugasToolStripMenuItem.Name = "DataPetugasToolStripMenuItem"
        Me.DataPetugasToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DataPetugasToolStripMenuItem.Text = "Data Petugas"
        '
        'DataPembeliToolStripMenuItem
        '
        Me.DataPembeliToolStripMenuItem.Name = "DataPembeliToolStripMenuItem"
        Me.DataPembeliToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DataPembeliToolStripMenuItem.Text = "Data Pembeli"
        '
        'DataMenuMakananToolStripMenuItem
        '
        Me.DataMenuMakananToolStripMenuItem.Name = "DataMenuMakananToolStripMenuItem"
        Me.DataMenuMakananToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DataMenuMakananToolStripMenuItem.Text = "Data Menu Makanan"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PembayaranToolStripMenuItem})
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.KeluarToolStripMenuItem.Text = "Transaksi"
        '
        'PembayaranToolStripMenuItem
        '
        Me.PembayaranToolStripMenuItem.Name = "PembayaranToolStripMenuItem"
        Me.PembayaranToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.PembayaranToolStripMenuItem.Text = "Pembayaran"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PetugasToolStripMenuItem, Me.MenuMakananToolStripMenuItem, Me.PembeliToolStripMenuItem, Me.PembayaranToolStripMenuItem1})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'KeluarToolStripMenuItem1
        '
        Me.KeluarToolStripMenuItem1.Name = "KeluarToolStripMenuItem1"
        Me.KeluarToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.KeluarToolStripMenuItem1.Text = "Keluar"
        '
        'PetugasToolStripMenuItem
        '
        Me.PetugasToolStripMenuItem.Name = "PetugasToolStripMenuItem"
        Me.PetugasToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PetugasToolStripMenuItem.Text = "Petugas"
        '
        'MenuMakananToolStripMenuItem
        '
        Me.MenuMakananToolStripMenuItem.Name = "MenuMakananToolStripMenuItem"
        Me.MenuMakananToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.MenuMakananToolStripMenuItem.Text = "Menu Makanan"
        '
        'PembeliToolStripMenuItem
        '
        Me.PembeliToolStripMenuItem.Name = "PembeliToolStripMenuItem"
        Me.PembeliToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PembeliToolStripMenuItem.Text = "Pembeli"
        '
        'PembayaranToolStripMenuItem1
        '
        Me.PembayaranToolStripMenuItem1.Name = "PembayaranToolStripMenuItem1"
        Me.PembayaranToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.PembayaranToolStripMenuItem1.Text = "Pembayaran"
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 261)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainMenu"
        Me.Text = "MainMenu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PengaturanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TambahPetugasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GantiSandiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPetugasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DataPembeliToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataMenuMakananToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PembayaranToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PetugasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuMakananToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PembeliToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PembayaranToolStripMenuItem1 As ToolStripMenuItem
End Class
