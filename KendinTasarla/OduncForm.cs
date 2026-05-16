using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KendinTasarla
{
    // Aktif ödünç verme ve iade alma süreçlerinin yönetildiği ve listelendiği ekrandır.
    public partial class OduncForm : Form
    {
        // Formun yapıcı metodudur. Form belleğe çıktığı an ilk burası çalışır.
        public OduncForm()
        {
            InitializeComponent();
            // Formun yüklenme (Load) olayını ilgili metoda bağlıyoruz.
            this.Load += OduncForm_Load;
        }

        // Form tamamen ekranda çizilmeden hemen önce tetiklenen olaydır.
        private void OduncForm_Load(object sender, EventArgs e)
        {
            // Grid üzerindeki kullanıcı deneyimini ve veri güvenliğini artıran ayarları yapıyoruz.
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  // Satırın tamamını seçtiriyoruz.
            grid.ReadOnly = true;  // Kullanıcının hücredeki verileri elle değiştirmesini engelliyoruz.
            grid.AllowUserToAddRows = false;  // Grid'in altındaki o boş yeni satır ekleme alanını gizliyoruz.

            // Satırlar ekrana çizilirken çalışacak olan renklendirme olayını bağlıyoruz.
            grid.RowPrePaint += Grid_RowPrePaint;

            // Verileri SQL'den çekip listeliyoruz.OduncleriYukle();
            OduncleriYukle();
        }

        // Tüm aktif ödünç işlemlerini veri tabanından çeker, sütun isimlerini Türkçeleştirir ve grid'e bağlar.
        private void OduncleriYukle()
        {
            var dt = OduncYonetici.OduncIslemleriniListele();
            SutunAdlariniDuzenle(dt);  // Veri tabanından gelen kolon isimlerini arayüz için düzeltiyoruz.
            grid.DataSource = dt;
        }

        // Veri tabanından gelen İngilizce veya bitişik kolon isimlerini Türkçeleştirir.
        private void SutunAdlariniDuzenle(DataTable dt)
        {
            var adlar = new[] { "OduncID", "Üye", "Kitap", "Ödünç Tarihi", "Teslim Tarihi", "Durum" };
            for (int i = 0; i < dt.Columns.Count && i < adlar.Length; i++)
                dt.Columns[i].ColumnName = adlar[i];
        }

        // Satırlar ekrana çizilmeden önce çalışır ve teslim tarihi geçmiş kayıtları kırmızıya boyar.
        private void Grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = grid.Rows[e.RowIndex];

            // Satırdaki teslim tarihi bilgisinin boş olup olmadığını kontrol ediyoruz.
            if (row.Cells["Teslim Tarihi"].Value == null || row.Cells["Teslim Tarihi"].Value == DBNull.Value) return;

            // Teslim tarihi geçerli bir tarih formatı ise kontrol adımlarına geçiyoruz.
            if (DateTime.TryParse(row.Cells["Teslim Tarihi"].Value.ToString(), out DateTime teslim))
            {
                // Eğer teslim tarihi bugünden daha eskiyse (teslim gecikmişse) satırın arka planını kırmızı yapıyoruz.
                if (teslim < DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0);  // Kırmızı arka plan
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);  // Siyah yazı rengi
                }
            }
        }

        // Yeni ödünç verme formunu açar.
        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            var frm = new OduncVerForm();
            // .ShowDialog() kullanarak bu form kapanmadan arkadaki listeye tıklanmasını engelliyoruz.
            // İşlem başarılıysa (OK), listeyi otomatik yeniliyoruz.
            if (frm.ShowDialog() == DialogResult.OK) OduncleriYukle();
        }

        // Seçilen ödünç kaydına göre kitabı geri iade alır.
        private void btnIadeAl_Click(object sender, EventArgs e)
        {
            // Kullanıcı bir satır seçmediyse uyarı verip kodun çökmesini önlüyoruz.
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iade alınacak kaydı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen satırdaki bilgileri değişkenlere aktarıyoruz.
            var satir = grid.SelectedRows[0];
            string uye = satir.Cells["Üye"].Value?.ToString();
            string kitap = satir.Cells["Kitap"].Value?.ToString();
            int oduncID = Convert.ToInt32(satir.Cells["OduncID"].Value);

            // Yanlışlıkla iade alma işleminin önüne geçmek için onay penceresi çıkartıyoruz.
            var onay = MessageBox.Show($"'{uye}' - '{kitap}' iade alınsın mı?", "İade Onayı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // Kitabı iade alma işlemini başlatıp listeyi güncelliyoruz.
                    OduncYonetici.KitapIadeAl(oduncID);
                    OduncleriYukle();
                }
                catch (Exception ex)
                {
                    // Oluşabilecek bir veri tabanı hatasını yakalayıp kullanıcıya gösteriyoruz.
                    MessageBox.Show("Hata: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Listeyi en güncel haliyle yeniden yükler.
        private void btnYenile_Click(object sender, EventArgs e)
        {
            OduncleriYukle();
        }
    }
}