using Microsoft.Data.SqlClient;
using System.Data;

namespace KendinTasarla
{
    // Üye kayıt, listeleme, arama ve silme gibi iş mantığı süreçlerini yöneten sınıftır.
    public static class UyeYonetici
    {
        public static DataTable TumUyeleriListele()
        {
            // Sadece AktifMi=1 olanları çekiyoruz.
            string sql = "SELECT UyeID, Ad, Soyad, Email, Telefon, KayitTarihi FROM Uyeler WHERE AktifMi=1 ORDER BY Ad";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Yeni bir üyeyi güvenli bir şekilde veri tabanına ekler.
        public static void UyeEkle(string ad, string soyad, string email, string telefon, string adres)
        {
            var p = new SqlParameter[]
            {
                new("@Ad", ad),
                new("@Soyad", soyad),
                new("@Email", email),
                new("@Telefon", telefon),
                new("@Adres", adres)
            };
            // Veri tabanında önceden derlenmiş 'sp_UyeEkle' saklı yordamını (Stored Procedure) çağırıyoruz.
            DatabaseHelper.ExecuteProcedure("sp_UyeEkle", p);
        }

        // Belirtilen ID'ye sahip üyeyi sistemden siler.
        public static void UyeSil(int id)
        {
            // Silme işleminde karışıklığı önlemek için sadece Primary Key olan UyeID bilgisini gönderiyoruz.
            DatabaseHelper.ExecuteProcedure("sp_UyeSil", new[] { new SqlParameter("@UyeID", id) });
        }

        // Üyeler arasında ad, soyad veya e-posta bilgisine göre arama yapar.
        public static DataTable UyeAra(string arama)
        {
            string sql = @"SELECT UyeID, Ad, Soyad, Email, Telefon 
                           FROM Uyeler 
                           WHERE (Ad LIKE @a OR Soyad LIKE @a OR Email LIKE @a) AND AktifMi=1";
            // '%arama%' ifadesi sayesinde kelimenin sadece başında değil, içinde geçen kayıtları da bulabiliyoruz.
            return DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@a", $"%{arama}%") });
        }
    }
}