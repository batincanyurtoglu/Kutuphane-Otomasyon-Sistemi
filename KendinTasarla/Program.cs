namespace KendinTasarla
{
    internal static class Program
    {
        //  Uygulamanın ana giriş noktası.
        [STAThread]
        static void Main()
        {
            // Uygulamanın ekran çözünürlüğü ve görsel arayüz ayarlarını, form ayarlarını başlatır.
            ApplicationConfiguration.Initialize();

            // Form1 penceresini projenin ana ekranı olarak belleğe yükler ve çalıştırır.
            Application.Run(new Form1());
        }
    }
}