using System;
using System.Windows.Forms;

namespace KendinTasarla
{
    // Yeni kitap verilerinin doğrulanarak sisteme güvenli bir şekilde kaydedilmesini sağlayan ekrandır.
    public partial class KitapEkleForm : Form
    {
        // Formun yapıcı metodudur. Form belleğe çıktığı an ilk burası çalışır.
        public KitapEkleForm()
        {
            InitializeComponent();
        }

        // Kaydet butonuna tıklandığında veri doğrulamalarını yapar ve kitabı veri tabanına ekler.
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Veri Doğrulama (Validation): Kitap adı ve yazar alanlarının boş geçilmesini engelliyoruz.
            // string.IsNullOrWhiteSpace kullanarak kullanıcının sadece boşluk karakteri girmesini de önlüyoruz.
            if (string.IsNullOrWhiteSpace(txtBaslik.Text) || string.IsNullOrWhiteSpace(txtYazar.Text))
            {
                MessageBox.Show("Başlık ve Yazar alanları zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Alanlar boşsa işlemi burada kesiyoruz.
            }

            // Sayısal Veri Kontrolü: Kullanıcı harf girdiğinde veya boş bıraktığında programın çökmesini engelliyoruz.
            // int.TryParse başarılı olmazsa yılı içinde bulunduğumuz geçerli yıla, adedi ise varsayılan olarak 1'e eşitliyoruz.
            if (!int.TryParse(txtYil.Text, out int yil)) yil = DateTime.Now.Year;
            if (!int.TryParse(txtAdet.Text, out int adet)) adet = 1;

            try
            {
                // Trim() kullanarak kullanıcının kazara girdiği baş ve son boşlukları temizleyerek veriyi işliyoruz.
                KitapYonetici.KitapEkle(
                    txtISBN.Text.Trim(),
                    txtBaslik.Text.Trim(),
                    txtYazar.Text.Trim(),
                    txtYayinevi.Text.Trim(),
                    yil,
                    txtKategori.Text.Trim(),
                    adet
                );
                MessageBox.Show("Kitap başarıyla eklendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // İşlem başarılıysa formun sonucunu OK olarak işaretleyip formu kapatıyoruz.
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Veri tabanı seviyesinde oluşabilecek bir hatayı yakalayıp kullanıcıya gösteriyoruz.
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