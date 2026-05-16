using System;
using System.Data;
using System.Windows.Forms;

namespace KendinTasarla
{
    // Kütüphanedeki kitapların listelendiği, arandığı ve silindiği yönetim ekranıdır.
    public partial class KitapListeForm : Form
    {
        // Formun yapıcı metodudur. Form belleğe yüklendiğinde çalışır.
        public KitapListeForm()
        {
            InitializeComponent();
            // Formun yüklenme (Load) olayını ilgili metoda bağlıyoruz.
            this.Load += KitapListeForm_Load;
        }

        // Form tamamen ekranda çizilmeden hemen önce tetiklenen olaydır.
        private void KitapListeForm_Load(object sender, EventArgs e)
        {
            // Form açılırken en güncel kitap listesini SQL'den çekip yüklüyoruz.
            KitaplariYukle();
        }

        // Tüm kitapları veri tabanından çeker, sütun isimlerini Türkçeleştirir ve grid'e bağlar.
        private void KitaplariYukle()
        {
            var dt = KitapYonetici.TumKitaplariListele();
            SutunAdlariniDuzenle(dt);  // Veri tabanından gelen kolon isimlerini arayüz için düzeltiyoruz.
            grid.DataSource = dt;  // Tabloyu DataGridView bileşenine bağlıyoruz.
        }

        // Veri tabanından gelen İngilizce veya bitişik kolon isimlerini Türkçeleştirir.
        private void SutunAdlariniDuzenle(DataTable dt)
        {
            var adlar = new[] { "KitapID", "ISBN", "Başlık", "Yazar", "Kategori", "Mevcut Adet", "Toplam Adet" };
            for (int i = 0; i < dt.Columns.Count && i < adlar.Length; i++)
                dt.Columns[i].ColumnName = adlar[i];
        }

        // Arama butonuna tıklandığında başlık, yazar veya ISBN'e göre filtreleme yapar.
        private void btnAra_Click(object sender, EventArgs e)
        {
            // Eğer arama kutusu boşsa veya sadece boşluk tuşuna basılmışsa tüm listeyi tazeler ve metodu bitiririz.
            if (string.IsNullOrWhiteSpace(txtArama.Text)) { KitaplariYukle(); return; }

            // Trim() fonksiyonu ile kelimenin başındaki ve sonundaki gereksiz boşlukları temizliyoruz.
            var dt = KitapYonetici.KitapAra(txtArama.Text.Trim());
            SutunAdlariniDuzenle(dt);
            grid.DataSource = dt;
        }

        // Arama kutusunu temizler ve listeyi ilk haline döndürür.
        private void btnYenile_Click(object sender, EventArgs e)
        {
            txtArama.Clear();  // Arama kutusunun içeriğini siler.
            KitaplariYukle();  // Listeyi yeniden doldurur.
        }

        // Yeni kitap ekleme formunu açar.
        private void btnEkle_Click(object sender, EventArgs e)
        {
            var frm = new KitapEkleForm();
            // .ShowDialog() kullanarak bu form kapanmadan arkadaki listeye tıklanmasını engelliyoruz.
            // Eğer ekleme işlemi başarıyla tamamlanmışsa (DialogResult.OK), listeyi otomatik yeniliyoruz.
            if (frm.ShowDialog() == DialogResult.OK) KitaplariYukle();
        }

        // Seçilen satırdaki kitabı sistemden tamamen siler.
        private void btnSil_Click(object sender, EventArgs e)
        {
            // Kullanıcı bir satır seçmediyse uyarı verip kodun çökmesini önlüyoruz.
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kitabı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen ilk satırdaki bilgileri değişkenlere alıyoruz.
            var satir = grid.SelectedRows[0];
            string baslik = satir.Cells["Başlık"].Value?.ToString();
            int id = Convert.ToInt32(satir.Cells["KitapID"].Value);

            // Yanlışlıkla silme işleminin önüne geçmek için onay penceresi çıkarıyoruz.
            var onay = MessageBox.Show($"'{baslik}' silinsin mi?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // Kitabı veri tabanından silip listeyi güncelliyoruz.
                    KitapYonetici.KitapSil(id);
                    KitaplariYukle();
                }
                catch (Exception ex)
                {
                    // Eğer kitap başka bir üyeye ödünç verilmişse oluşabilecek veri tabanı hatasını yakalıyoruz.
                    MessageBox.Show("Hata: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}