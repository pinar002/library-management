# Kütüphane Yönetim Sistemi

Bu proje ASP.NET Core kullanılarak geliştirilmiş kapsamlı bir kütüphane yönetim sistemidir. Kitap, yazar, yayınevi, kategori ve üye yönetimi ile ödünç alma/iade etme süreçlerini kapsayan tam donanımlı bir çözümdür.

## Projenin Amacı

- **Kütüphane Envanter Yönetimi**: Kitapları, yazarları, yayınevlerini ve kategorileri dijital ortamda organize etmek.
- **Üye Takibi**: Kütüphane üyelerinin kayıtlarını tutmak.
- **Ödünç Sistemi**: Kitapların üyeler tarafından ödünç alınması ve iade edilmesini takip etmek.
- **Stok Kontrolü**: Kitap stoklarını anlık olarak izlemek.
- **Kullanıcı Dostu Arayüz**: Kolay kullanılabilir bir web arayüzü sunmak.

## Kullanılan Teknolojiler

### Backend
- **ASP.NET Core Web API**: RESTful servis mimarisine uygun olarak geliştirilmiştir.
- **Entity Framework Core**: Veritabanı işlemleri için ORM (Object-Relational Mapping) aracı olarak kullanılmıştır.
- **SQLite**: Hafif ve taşınabilir bir veritabanı çözümü olarak tercih edilmiştir.
- **AutoMapper**: DTO (Data Transfer Object) ve Entity nesneleri arasındaki dönüşümleri otomatize etmek için kullanılmıştır.

### Frontend
- **ASP.NET Core MVC**: Model-View-Controller desenine uygun sunucu taraflı render işlemleri için kullanılmıştır.
- **Bootstrap 5 & CSS**: Responsive ve modern arayüz tasarımı için kullanılmıştır.
- **JavaScript (Fetch API)**: İstemci tarafında asenkron veri alışverişi ve dinamik içerik güncellemeleri için kullanılmıştır.

## Proje Mimarisi

Proje, sorumlulukların ayrılığı ilkesine (Separation of Concerns) uygun olarak iki ana katman halinde yapılandırılmıştır:

### 1. KutuphaneAPI (Backend Servis Katmanı)
Bu katman, uygulamanın çekirdek iş mantığını ve veri erişim katmanını barındırır. Web arayüzünden bağımsız çalışabilir ve farklı istemciler (Mobil, Web, Desktop) tarafından tüketilebilir.

**Teknik Detaylar:**
*   **Controller-Service-Repository Yapısı**: İstekler Controller'lar tarafından karşılanır, iş kuralları işlenir ve Entity Framework Core aracılığıyla veritabanı işlemleri gerçekleştirilir.
*   **Dependency Injection (DI)**: Servisler ve veritabanı bağlamı, ASP.NET Core'un yerleşik IOC Container'ı üzerinden yönetilir.
*   **DTO (Data Transfer Objects)**: API dışarıya veritabanı varlıklarını (Entity) doğrudan açmaz; bunun yerine istemcinin ihtiyacına göre şekillendirilmiş DTO'lar kullanılır. Bu sayede veri güvenliği ve gereksiz veri transferinin önüne geçilir.
*   **Middleware**: Hata yönetimi ve HTTP isteklerinin loglanması gibi çapraz kesen ilgiler (cross-cutting concerns) için yapılandırılmıştır.

**Ana Modüller:**
*   **Kitap Yönetimi**: Kitapların CRUD işlemleri, stok takibi ve arama algoritmaları.
*   **İlişkisel Veri Yönetimi**: Yazar, Yayınevi ve Kategori gibi ilişkisel verilerin yönetimi.
*   **Hareket İşlemleri**: Üyelerin kitap ödünç alma ve iade etme süreçlerinin transactional olarak yönetilmesi.

### 2. KutuphaneWeb (Frontend Arayüz Katmanı)
Son kullanıcının etkileşime girdiği MVC tabanlı web uygulamasıdır. Backend API ile HTTP protokolü üzerinden haberleşir.

**Teknik Detaylar:**
*   **MVC Deseni**: 
    *   **Model**: Görünüm için hazırlanan ViewModel nesneleri.
    *   **View**: Razor şablon motoru ile oluşturulan dinamik HTML sayfaları.
    *   **Controller**: Kullanıcı etkileşimlerini alıp API'ye istek yapan ve sonucu View'a ileten mekanizma.
*   **Asenkron İletişim**: `HttpClient` veya JavaScript `Fetch API` kullanılarak API ile asenkron iletişim kurulur, bu sayede kullanıcı deneyimi kesintiye uğramaz.
*   **Client-Side Validasyon**: jQuery Validation ve HTML5 özellikleri ile temel veri doğrulamaları istemci tarafında yapılır.

## Sistem Çalışma Mantığı ve Veri Akışı

1.  **Kullanıcı Etkileşimi**: Kullanıcı web arayüzünde bir işlem başlatır (Örn: "Kitap Ödünç Al").
2.  **Frontend İşlemi**: Web uygulaması bu isteği alır ve gerekli parametrelerle birlikte Backend API'nin ilgili endpoint'ine (Örn: `PUT /api/loans`) bir HTTP isteği gönderir.
3.  **API Doğrulama ve İşleme**: Backend API isteği karşılar, validasyon kurallarını işletir (Stok var mı? Üye cezalı mı?) ve işlemi gerçekleştirir.
4.  **Veritabanı Kaydı**: Onaylanan işlem SQLite veritabanına ACID prensiplerine uygun olarak yazılır.
5.  **Geri Bildirim**: API işlemin sonucunu (Başarılı/Hata) Frontend'e döner. Frontend bu sonucu kullanıcıya anlamlı bir mesaj olarak gösterir.
