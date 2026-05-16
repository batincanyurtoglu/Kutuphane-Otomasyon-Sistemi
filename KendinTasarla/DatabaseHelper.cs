using System.Data;
using Microsoft.Data.SqlClient;

namespace KendinTasarla
{
    // Veri tabanı bağlantısını ve sorgu süreçlerini tek bir merkezden yöneten static bir yardımcı sınıftır.
    // Sınıfın static olma sebebi, her seferinde yeni bir kopyasının oluşturulmasını (new) engellemek ve belleği yormamaktır.
    public static class DatabaseHelper
    {
        //ConnectionString Değişekni ile veri tabanı adresi tanımlanıyor 
        //Server adı  ve verleri cekeceğimiz database ismi belirtiyoruz 
        // SQL Server bağlantı cümlesi.
        // readonly yapısı ile bu bilginin sadece bir kez belleğe yüklenmesi ve sonradan değiştirilememesi sağlanır.
        private static readonly string ConnectionString =
            "Server=.\\SQLEXPRESS01;Database=KutuphaneSistemi;Trusted_Connection=True;TrustServerCertificate=True;";

        // SQL Server'a yeni bir bağlantı nesnesi oluşturur.
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static int ExecuteProcedure(string procName, SqlParameter[] parameters = null)
        {
            // 'using' kullanımı sayesinde bu fonksiyon bittiğinde bağlantı otomatik kapanır ve bellekten temizlenir.
            using var conn = GetConnection();
            using var cmd = new SqlCommand(procName, conn);

            // Komut tipinin bir SQL sorgusu değil, önceden derlenmiş bir Stored Procedure olduğunu belirtiriz.
            cmd.CommandType = CommandType.StoredProcedure;

            // Eğer dışarıdan parametre gelmişse, komuta güvenli bir şekilde ekleriz.
            if (parameters != null) cmd.Parameters.AddRange(parameters);

            conn.Open();  // Bağlantıyı açarız.
            return cmd.ExecuteNonQuery();  // Sorguyu çalıştırıp etkilenen satır sayısını döndürürüz.
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            // 'using' kullanımı sayesinde bu fonksiyon bittiğinde bağlantı otomatik kapanır ve bellekten temizlenir.
            using var conn = GetConnection();
            using var cmd = new SqlCommand(query, conn);

            // Komut tipinin düz metin (SQL sorgusu) olduğunu belirtiriz.
            cmd.CommandType = CommandType.Text;

            if (parameters != null) cmd.Parameters.AddRange(parameters);

            conn.Open();
            var dt = new DataTable();  // Gelen verileri dolduracağımız sanal tabloyu oluştururuz.

            // SqlDataAdapter, veri tabanındaki verileri alıp DataTable içine dolduran bir köprü görevi görür.
            new SqlDataAdapter(cmd).Fill(dt);
            return dt;
        }
    }
}