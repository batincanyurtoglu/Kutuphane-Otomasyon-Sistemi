namespace KendinTasarla
{
    // Uygulamanın ana menü (Dashboard) ekranıdır. 
    // Kullanıcının kitap, üye ve ödünç işlemlerine geçiş yapmasını sağlar.
    public partial class Form1 : Form
    {
        // Formun yapıcı metodudur. Form belleğe çıktığı an ilk burası çalışır.
        public Form1()
        {
            // Tasarımda (Form1.Designer.cs) oluşturduğumuz tüm buton ve pencereleri ekrana çizer.
            InitializeComponent();
        }

        // Kitap İşlemleri butonuna tıklandığında çalışır.
        private void btnKitap_Click(object sender, EventArgs e)
        {
            // Bellekte yeni bir KitapListeForm nesnesi oluşturup ekrana getiririz.
            // .Show() kullandığımız için arkadaki ana menü ekranı kilitlenmez.
            new KitapListeForm().Show();
        }

        // Üye İşlemleri butonuna tıklandığında çalışır.
        private void btnUye_Click(object sender, EventArgs e)
        {
            // Üye yönetim ekranını açar.
            new UyeListeForm().Show();
        }

        // Ödünç İşlemleri butonuna tıklandığında çalışır.
        private void btnOdunc_Click(object sender, EventArgs e)
        {
            // Ödünç alma ve iade etme işlemlerinin yürütüldüğü ekranı açar.
            new OduncForm().Show();
        }
    }
}