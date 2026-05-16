using System;
using System.Data;
using System.Windows.Forms;

namespace KendinTasarla
{
    // Kütüphanedeki üyelerin listelendiği, arandığı ve silindiği yönetim ekranıdır.
    public partial class UyeListeForm : Form
    {
        // Formun yapıcı metodudur. Form belleğe çıktığı an ilk burası çalışır.
        public UyeListeForm()
        {
            InitializeComponent();
            // Formun yüklenme (Load) olayını ilgili metoda bağlıyoruz.
            this.Load += UyeListeForm_Load;
        }

        // Form tamamen ekranda çizilmeden hemen önce tetiklenen olaydır.
        private void UyeListeForm_Load(object sender, EventArgs e)
        {
            // Form açılırken en güncel aktif üye listesini SQL'den çekip yüklüyoruz.
            UyeleriYukle();
        }

        // Tüm aktif üyeleri veri tabanından çeker, sütun isimlerini Türkçeleştirir ve grid'e bağlar.
        private void UyeleriYukle()
        {
            var dt = UyeYonetici.TumUyeleriListele();
            SutunAdlariniDuzenle(dt);  // Veri tabanından gelen kolon isimlerini arayüz için düzeltiyoruz.
            grid.DataSource = dt;  // Tabloyu DataGridView bileşenine bağlıyoruz.
        }

        // Veri tabanından gelen İngilizce veya bitişik kolon isimlerini Türkçeleştirir.
        private void SutunAdlariniDuzenle(DataTable dt)
        {
            var adlar = new[] { "UyeID", "Ad", "Soyad", "Email", "Telefon", "Kayıt Tarihi" };
            for (int i = 0; i < dt.Columns.Count && i < adlar.Length; i++)
                dt.Columns[i].ColumnName = adlar[i];
        }

        // Arama butonuna tıklandığında ad, soyad veya e-postaya göre filtreleme yapar.
        private void btnAra_Click(object sender, EventArgs e)
        {
            // Eğer arama kutusu boşsa veya sadece boşluk tuşuna basılmışsa tüm listeyi tazeler ve metodu bitiririz.
            if (string.IsNullOrWhiteSpace(txtArama.Text)) { UyeleriYukle(); return; }

            // Trim() fonksiyonu ile kelimenin başındaki ve sonundaki gereksiz boşlukları temizliyoruz.
            var dt = UyeYonetici.UyeAra(txtArama.Text.Trim());
            SutunAdlariniDuzenle(dt);
            grid.DataSource = dt;
        }

        // Arama kutusunu temizler ve listeyi ilk haline döndürür.
        private void btnYenile_Click(object sender, EventArgs e)
        {
            txtArama.Clear();  // Arama kutusunun içeriğini siler.
            UyeleriYukle();  // Listeyi yeniden doldurur.
        }

        // Yeni üye ekleme formunu açar.
        private void btnEkle_Click(object sender, EventArgs e)
        {
            var frm = new UyeEkleForm();
            // .ShowDialog() kullanarak bu form kapanmadan arkadaki listeye tıklanmasını engelliyoruz.
            // Eğer ekleme işlemi başarıyla tamamlanmışsa (DialogResult.OK), listeyi otomatik yeniliyoruz.
            if (frm.ShowDialog() == DialogResult.OK) UyeleriYukle();
        }

        // Seçilen satırdaki üyeyi sistemden tamamen siler.
        private void btnSil_Click(object sender, EventArgs e)
        {
            // Kullanıcı bir satır seçmediyse uyarı verip kodun çökmesini önlüyoruz.
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz üyeyi seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen ilk satırdaki bilgileri değişkenlere alıyoruz.
            var satir = grid.SelectedRows[0];
            string ad = $"{satir.Cells["Ad"].Value} {satir.Cells["Soyad"].Value}";
            int id = Convert.ToInt32(satir.Cells["UyeID"].Value);

            // Yanlışlıkla silme işleminin önüne geçmek için onay penceresi çıkarıyoruz.
            var onay = MessageBox.Show($"'{ad}' silinsin mi?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // Üyeyi veri tabanından silip (veya pasife çekip) listeyi güncelliyoruz.
                    UyeYonetici.UyeSil(id);
                    UyeleriYukle();
                }
                catch (Exception ex)
                {
                    // Eğer üye üzerinde teslim edilmemiş bir kitap varsa oluşabilecek hatayı yakalıyoruz.
                    MessageBox.Show("Hata: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}