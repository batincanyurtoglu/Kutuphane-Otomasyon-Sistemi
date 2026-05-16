# 📚 C# WinForms ile Kütüphane Otomasyon Sistemi

Ankara Gazi Üniversitesi Teknoloji Fakültesi Bilgisayar Mühendisliği Bölümü Bilgisayar Programlama dersi kapsamında geliştirilmiş, katmanlı mimari mantığına uygun, güvenli ve sürdürülebilir bir **Kütüphane Yönetim ve Takip Otomasyonu** projesidir.

---

## 🚀 Proje Özellikleri

* **Merkezi Veritabanı Yönetimi (`DatabaseHelper`):** Tüm veritabanı bağlantıları ve komut çalıştırma işlemleri tek bir dinamik sınıf üzerinden soyutlanarak kod tekrarı engellenmiştir.
* **Güvenli Mimari:** SQL Injection gibi kritik güvenlik zafiyetlerini önlemek amacıyla tüm sorgularda `SqlCommand` parametre yapısı (`SqlParameter`) kullanılmıştır.
* **Gelişmiş CRUD ve Yönetici Sınıfları:** Üye, Kitap ve Ödünç işlemleri için yazılan SQL sorguları, iş mantığını ayırmak adına statik yönetici sınıflarında (`UyeYonetici`, `KitapYonetici` vb.) toplanmıştır.
* **Dinamik Stok ve İade Takibi:** Bir kitap ödünç verildiğinde ya da iade alındığında, ilgili kitabın stok durumu arka planda otomatik olarak güncellenir.
* **Akıllı Kullanıcı Arayüzü (UI):** Teslim tarihi geçen ve henüz iade edilmemiş ödünç kitaplara ait satırlar, `RowPrePaint` olayı yakalanarak dinamik olarak **kırmızı** renkle boyanır.

---

## 🛠️ Kullanılan Teknolojiler

* **Dil:** C# (.NET Core / .NET 8.0)
* **Arayüz:** Windows Forms (WinForms)
* **Veritabanı:** Microsoft SQL Server
* **Veri Sağlayıcı:** `Microsoft.Data.SqlClient`

---

## 💻 Proje Sunum Videosu

Projenin arayüz tasarımı, çalışma mantığı ve kod mimarisinin detaylı olarak anlatıldığı YouTube sunum videosuna aşağıdaki bağlantıdan ulaşabilirsiniz:

▶️ **[YouTube Proje Sunum Videosu](https://youtu.be/wHWSEtqUFgg)**

---
Geliştirici: **Batıncan Yurtoğlu** Gazi Üniversitesi Bilgisayar Mühendisliği 1. Sınıf Öğrencisi
