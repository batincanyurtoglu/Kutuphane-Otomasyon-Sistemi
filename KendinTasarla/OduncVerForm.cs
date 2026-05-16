using System;
using System.Data;
using System.Windows.Forms;

namespace KendinTasarla
{
    // Üyelere kitap ödünç verme işlemlerinin yapıldığı ve teslim tarihlerinin hesaplandığı ekrandır.
    public partial class OduncVerForm : Form
    {
        // Formun yapıcı metodudur. Form belleğe çıktığı an ilk burası çalışır.
        public OduncVerForm()
        {
            InitializeComponent();
            // Formun yüklenme (Load) olayını ilgili metoda bağlıyoruz.
            this.Load += OduncVerForm_Load;
        }

        // Form tamamen ekranda çizilmeden hemen önce tetiklenen olaydır.
        private void OduncVerForm_Load(object sender, EventArgs e)
        {
            // NumericUpDown sayacının sınırlarını ve varsayılan değerini belirliyoruz.
            nudGun.Minimum = 1;   // En az 1 gün
            nudGun.Maximum = 90;  // En fazla 90 gün
            nudGun.Value = 14;    // Varsayılan olarak 14 gün seçili gelir.

            // Varsayılan 14 güne göre teslim tarihini hesaplayıp ekrandaki etikete yazdırıyoruz.
            lblTarih.Text = $"Teslim: {DateTime.Today.AddDays(14):dd.MM.yyyy}";

            // Kullanıcı gün sayısını her değiştirdiğinde teslim tarihini anlık olarak yeniden hesaplıyoruz.
            nudGun.ValueChanged += (s, ev) =>
                lblTarih.Text = $"Teslim: {DateTime.Today.AddDays((int)nudGun.Value):dd.MM.yyyy}";

            // ComboBox (Açılır Liste) bileşenlerini veri tabanından gelen verilerle dolduruyoruz.
            VerileriDoldur();
        }

        // Kitap ve üye listelerini SQL'den çeker ve ComboBox bileşenlerine bağlar.
        private void VerileriDoldur()
        {
            // Tüm aktif kitapları çekip ComboBox'a bağlıyoruz.
            var dtKitap = KitapYonetici.TumKitaplariListele();
            cmbKitap.DisplayMember = "Baslik"; // Kullanıcının ekranda göreceği metin
            cmbKitap.ValueMember = "KitapID"; // Arka planda kodun kullanacağı ID değeri
            cmbKitap.DataSource = dtKitap;

            // Tüm aktif üyeleri çekiyoruz.
            var dtUye = UyeYonetici.TumUyeleriListele();

            // C# tarafında bellekte yeni bir "AdSoyad" kolonu oluşturup üyenin ad ve soyadını birleştiriyoruz.
            dtUye.Columns.Add("AdSoyad", typeof(string));
            foreach (DataRow r in dtUye.Rows)
                r["AdSoyad"] = $"{r["Ad"]} {r["Soyad"]}";

            cmbUye.DisplayMember = "AdSoyad"; // Kullanıcının ekranda göreceği birleştirilmiş tam ad
            cmbUye.ValueMember = "UyeID"; // Arka planda kodun kullanacağı ID değeri
            cmbUye.DataSource = dtUye;
        }

        // Ödünç ver butonuna tıklandığında seçimleri kontrol eder ve işlemi kaydeder.
        private void btnVer_Click(object sender, EventArgs e)
        {
            // Seçim Kontrolü: Kullanıcının kitap veya üye seçmeden butona basmasını engelliyoruz.
            if (cmbKitap.SelectedValue == null || cmbUye.SelectedValue == null)
            {
                MessageBox.Show("Kitap ve üye seçimi zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Seçilen kitap, üye ve gün bilgisini veri tabanına kaydediyoruz.
                OduncYonetici.KitapOduncVer(
                    Convert.ToInt32(cmbKitap.SelectedValue),
                    Convert.ToInt32(cmbUye.SelectedValue),
                    (int)nudGun.Value
                );
                MessageBox.Show("Ödünç işlemi başarıyla kaydedildi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // İşlem başarılıysa formu OK olarak işaretleyip kapatıyoruz.
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
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