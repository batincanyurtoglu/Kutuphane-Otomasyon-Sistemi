using Microsoft.Data.SqlClient;
using System.Data;

namespace KendinTasarla
{
    // Kitap ödünç verme, iade alma ve geciken iadeleri listeleme süreçlerini yöneten sınıftır.
    public static class OduncYonetici
    {
        // Henüz teslim edilmemiş olan aktif ödünç işlemlerini listeler.
        public static DataTable OduncIslemleriniListele()
        {
            // JOIN kullanarak Uyeler ve Kitaplar tablolarını birleştiriyoruz; böylece kullanıcıya sadece ID'leri değil, anlamlı isimleri gösteriyoruz.
            // Ad ve Soyad bilgisini tek bir sütunda (Uye) birleştirip arayüzün temiz görünmesini sağlıyoruz.
            // WHERE o.GercekIadeTarihi IS NULL diyerek sadece elinde kitap olan aktif ödünçleri çekiyoruz.
            string sql = @"SELECT o.OduncID, u.Ad+' '+u.Soyad AS Uye, k.Baslik, 
                           o.OduncTarihi, o.TeslimTarihi, o.Durum 
                           FROM OduncIslemleri o 
                           JOIN Uyeler u ON o.UyeID=u.UyeID 
                           JOIN Kitaplar k ON o.KitapID=k.KitapID 
                           WHERE o.GercekIadeTarihi IS NULL 
                           ORDER BY o.TeslimTarihi";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Bir üyeye belirli bir gün süreliğine kitap ödünç verir.
        public static void KitapOduncVer(int kitapID, int uyeID, int gun)
        {
            var p = new SqlParameter[]
            {
                new("@KitapID", kitapID),
                new("@UyeID", uyeID),
                new("@GunSayisi", gun)
            };
            // Veri tabanında stok kontrolü ve kayıt atma işlemlerini yapan 'sp_KitapOduncVer' procedure'ünü çağırıyoruz.
            DatabaseHelper.ExecuteProcedure("sp_KitapOduncVer", p);
        }

        // Ödünç alınan bir kitabı geri teslim alır.
        public static void KitapIadeAl(int oduncID)
        {
            // Karışıklığı önlemek için sadece Primary Key olan OduncID bilgisini gönderiyoruz.
            DatabaseHelper.ExecuteProcedure("sp_KitapIadeAl", new[] { new SqlParameter("@OduncID", oduncID) });
        }

        // Zamanında teslim edilmeyen ödünç işlemlerini gecikme süresine göre listeler.
        public static DataTable GecikenIadeleriGoster()
        {
            // SQL tarafında önceden hazırladığımız View'ı (vw_GecikenIadeler) çağırıyoruz.
            // Bu sayede karmaşık tarih hesaplama sorgularını C# tarafına yazmayıp performansı artırıyoruz.
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_GecikenIadeler ORDER BY GecikmeSuresi DESC");
        }
    }
}