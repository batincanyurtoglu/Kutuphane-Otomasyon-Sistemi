using System;
using System.Windows.Forms;

namespace KendinTasarla
{
    // Yeni üye verilerinin doğrulanarak sisteme güvenli bir şekilde kaydedilmesini sağlayan ekrandır.
    public partial class UyeEkleForm : Form
    {
        // Formun yapıcı metodudur. Form belleğe çıktığı an ilk burası çalışır.
        public UyeEkleForm()
        {
            InitializeComponent();
        }

        // Kaydet butonuna tıklandığında veri doğrulamalarını yapar ve üyeyi veri tabanına ekler.
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Veri Doğrulama (Validation): Üye adı ve soyadı alanlarının boş geçilmesini engelliyoruz.
            // string.IsNullOrWhiteSpace kullanarak kullanıcının sadece boşluk karakteri girmesini de önlüyoruz.
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve Soyad alanları zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Alanlar boşsa işlemi burada kesiyoruz.
            }

            try
            {
                // Trim() kullanarak kullanıcının kazara girdiği baş ve son boşlukları temizleyerek veriyi işliyoruz.
                UyeYonetici.UyeEkle(
                    txtAd.Text.Trim(),
                    txtSoyad.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefon.Text.Trim(),
                    txtAdres.Text.Trim()
                );
                MessageBox.Show("Üye başarıyla eklendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // İşlem başarılıysa formun sonucunu OK olarak işaretleyip formu kapatıyoruz.
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Veri tabanı seviyesinde oluşabilecek (örneğin mükerrer e-posta) bir hatayı yakalayıp kullanıcıye gösteriyoruz.
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İptal butonuna tıklandığında işlemi iptal eder ve formu kapatır.
        private void btnIptal_Click(object sender, EventArgs e)
        {
            // İşlemi iptal olarak işaretleyip kapatıyoruz; böylece ana liste boş yere yenilenmiyor.
            this.DialogResult = DialogResult.Cancel;
        }
    }
}