using Microsoft.Data.SqlClient;
using System.Data;

namespace KendinTasarla
{
    // Kitap ekleme, silme, listeleme ve arama gibi iş mantığı süreçlerini yöneten sınıftır.
    public static class KitapYonetici
    {
        public static DataTable TumKitaplariListele()
        {
            // Sadece arayüzde (DataGridView üzerinde) göstereceğimiz gerekli sütunları çekiyoruz.
            // ORDER BY Baslik diyerek kitapların alfabetik sırada listelenmesini sağlıyoruz.
            string sql = "SELECT KitapID, ISBN, Baslik, Yazar, Kategori, MevcutAdet, ToplamAdet FROM Kitaplar ORDER BY Baslik";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Yeni bir kitabı güvenli bir şekilde veri tabanına ekler.
        public static void KitapEkle(string isbn, string baslik, string yazar, string yayinevi, int yil, string kategori, int adet)
        {
            var p = new SqlParameter[]
            {
                new("@ISBN", isbn),
                new("@Baslik", baslik),
                new("@Yazar", yazar),
                new("@Yayinevi", yayinevi),
                new("@YayinYili", yil),
                new("@Kategori", kategori),
                new("@Adet", adet)
            };
            // Veri tabanında önceden derlenmiş 'sp_KitapEkle' saklı yordamını (Stored Procedure) çağırıyoruz.
            DatabaseHelper.ExecuteProcedure("sp_KitapEkle", p);
        }

        // Belirtilen ID'ye sahip kitabı sistemden siler.
        public static void KitapSil(int id)
        {
            // Silme işleminde karışıklığı önlemek için sadece Primary Key olan KitapID bilgisini gönderiyoruz.
            DatabaseHelper.ExecuteProcedure("sp_KitapSil", new[] { new SqlParameter("@KitapID", id) });
        }

        // Kitaplar arasında başlık, yazar veya ISBN numarasına göre arama yapar.
        public static DataTable KitapAra(string arama)
        {
            // Kullanıcının girdiği kelimeyi hem başlıkta hem yazarda hem de ISBN içinde aratıyoruz.
            string sql = @"SELECT KitapID, ISBN, Baslik, Yazar, Kategori, MevcutAdet, ToplamAdet 
                           FROM Kitaplar 
                           WHERE Baslik LIKE @arama OR Yazar LIKE @arama OR ISBN LIKE @arama";
            // '%arama%' ifadesi sayesinde kelimenin sadece başında değil, içinde geçen kayıtları da bulabiliyoruz.
            return DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@arama", $"%{arama}%") });
        }
    }
}