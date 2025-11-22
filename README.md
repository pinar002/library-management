# Kütüphane Yönetim Sistemi 

Bu proje ASP.NET Core kullanılarak geliştirilmiş bir kütüphane yönetim sistemidir. Kitap ekleme, düzenleme, silme, arama ve stok takibi gibi kütüphane işlemlerini gerçekleştirebilen bir uygulamadır.

### Projenin Amacı

- Kütüphanedeki kitapları dijital bir ortamda tutmak
- Kitap stok durumlarını  takip edebilmek
- Ödünç verme ve iade işlemleri
- Kullanıcı dostu bir arayüz sunmak

## Kullanılan Teknolojiler

### Backend
- ASP.NET Core 6.0 Web API
- Entity Framework Core
- SQLite
- LINQ (Language Integrated Query)

### Frontend
- ASP.NET Core MVC: Sayfa yapısı ve routing
- Bootstrap 5: Responsive tasarım ve hazır bileşenler
- JavaScript: API istekleri ve dinamik sayfa işlemleri
- Fetch API: HTTP istekleri

### Geliştirme Araçları
- .NET SDK
- Git
- GitHub

## Proje Mimarisi

Proje iki ana bileşenden oluşur:

### 1. KutuphaneAPI (Backend)
API katmanı veritabanı ile iletişim kurar ve HTTP isteklerine JSON formatında yanıtlar döner

Katmanlar:
- Models: Veri modelleri (Book.cs - Kitap nesnesi)
- Data: Veritabanı bağlam sınıfı (AppDbContext.cs)
- Controllers: API endpoint'leri (BooksController.cs)

Endpoint'ler:
- `GET /api/books` - Tüm kitapları listele
- `GET /api/books/{id}` - Belirli bir kitabı getir
- `POST /api/books` - Yeni kitap ekle
- `PUT /api/books/{id}` - Kitap güncelle
- `DELETE /api/books/{id}` - Kitap sil
- `GET /api/books/search?query=...` - Kitap ara
- `PUT /api/books/{id}/borrow` - Ödünç al (stok azalt)
- `PUT /api/books/{id}/return` - İade et (stok arttır)

### 2. KutuphaneWeb (Frontend)
MVC  mimarisi ile oluşturulmuştur. JavaScript ile API'e istekler gönderir ve sayfa yenilenmeden veri günceller.

Sayfalar:
- Ana Sayfa (Home/Index): İstatistikler ve son eklenen kitaplar
- Kitap Listesi (Books/Index): Tüm kitapları listeleme, arama ve filtreleme
- Yeni Kitap (Books/Create): Kitap ekleme formu
- Kitap Düzenle (Books/Edit): Kitap bilgilerini güncelleme
- Kitap Detay (Books/Details): Tek bir kitabın detaylı bilgileri

## Sistem Çalışma Mantığı

### Veri Akışı

1. Kullanıcı İsteği: Kullanıcı web arayüzünde bir işlem yapar (örneğin "Yeni Kitap Ekle" butonuna tıklar)

2. JavaScript İsteği: Sayfa JavaScript kodu çalışır ve `fetch()` fonksiyonu ile API'ye HTTP isteği gönderir
3. API İşlemi: API Controller gelen isteği alır ve veritabanı işlemini yapar
4. Veritabanı: SQLite veritabanına kitap kaydı eklenir

5. API Yanıtı: API işlem sonucunu JSON formatında döner

6. Sayfa Güncelleme: JS yanıtı alır ve kullanıcıya bildirim gösterir ve gerekirse sayfayı yeniler
