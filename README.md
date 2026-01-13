# Kütüphane Yönetim Sistemi

Bu proje ASP.NET Core kullanılarak geliştirilmiş kapsamlı bir kütüphane yönetim sistemidir. Kitap, yazar, yayınevi, kategori ve üye yönetimi ile ödünç alma/iade etme süreçlerini kapsayan tam donanımlı bir çözümdür.

## 🎯 Projenin Amacı

- **Kütüphane Envanter Yönetimi**: Kitapları, yazarları, yayınevlerini ve kategorileri dijital ortamda organize etmek.
- **Üye Takibi**: Kütüphane üyelerinin kayıtlarını tutmak.
- **Ödünç Sistemi**: Kitapların üyeler tarafından ödünç alınması ve iade edilmesini takip etmek.
- **Stok Kontrolü**: Kitap stoklarını anlık olarak izlemek.
- **Kullanıcı Dostu Arayüz**: Kolay kullanılabilir bir web arayüzü sunmak.

## 🛠 Kullanılan Teknolojiler

### Backend
- **ASP.NET Core Web API**: RESTful servisler.
- **Entity Framework Core**: ORM aracı.
- **SQLite**: Veritabanı yönetim sistemi.
- **AutoMapper**: Nesne eşleştirme (DTO dönüşümleri).

### Frontend
- **ASP.NET Core MVC**: Arayüz katmanı.
- **Bootstrap 5 & CSS**: Modern ve responsive tasarım.
- **JavaScript (Fetch API)**: Dinamik veri yönetimi ve API iletişimi.

## 🏗 Proje Mimarisi

Proje iki ana katmandan oluşmaktadır:

### 1. KutuphaneAPI (Backend)
Tüm iş mantığının ve veri erişiminin yönetildiği katmandır.

**Temel Modüller ve Endpointler:**

*   **Kitaplar (`/api/books`)**: Ekleme (`POST`), listeleme (`GET`), güncelleme (`PUT`), silme (`DELETE`) ve arama (`GET /search`).
*   **Yazarlar (`/api/authors`)**: Yazar yönetimi işlemleri.
*   **Yayınevleri (`/api/publishers`)**: Yayınevi kayıt ve takibi.
*   **Kategoriler (`/api/categories`)**: Kitap kategorileri yönetimi.
*   **Üyeler (`/api/members`)**: Kütüphane üyelerinin yönetimi.
*   **Ödünç İşlemleri (`/api/loans`)**:
    *   Ödünç verme (`POST`)
    *   İade alma (`PUT /return`)
    *   Aktif ödünçleri listeleme

### 2. KutuphaneWeb (Frontend)
Kullanıcıların sistemle etkileşime girdiği web arayüzüdür.

**Sayfalar:**
*   **Ana Sayfa**: Genel istatistikler ve hızlı erişim.
*   **Kitap Yönetimi**: Kitap listeleme, ekleme ve detay görüntüleme.
*   **Yazar & Yayınevi & Kategori**: İlgili veri tanımlamaları için yönetim sayfaları.
*   **Üyeler**: Üye listesi ve yeni üye kaydı.
*   **Ödünç İşlemleri**: Kitap ödünç verme ve iade alma arayüzleri.

## 🚀 Kurulum ve Çalıştırma

Projenin çalışması için bilgisayarınızda [.NET SDK](https://dotnet.microsoft.com/download) yüklü olmalıdır.

1.  **Projeyi Klonlayın:**
    ```bash
    git clone https://github.com/kullaniciadi/kutuphane-yonetim-sistemi.git
    cd kutuphane-yonetim-sistemi
    ```

2.  **API'yi Başlatın:**
    Yeni bir terminal açın ve `KutuphaneAPI` dizinine gidin:
    ```bash
    cd KutuphaneAPI
    dotnet run
    ```

3.  **Web Arayüzünü Başlatın:**
    Yeni bir terminal açın ve `KutuphaneWeb` dizinine gidin:
    ```bash
    cd KutuphaneWeb
    dotnet run
    ```

4.  **Uygulamaya Erişin:**
    Tarayıcınızdan `https://localhost:7147` (Veya terminalde belirtilen port) adresine gidin.

## 🤝 Katkıda Bulunma

1.  Forklayın.
2.  Yeni bir feature branch oluşturun (`git checkout -b feature/yeni-ozellik`).
3.  Değişikliklerinizi commit yapın (`git commit -m 'Yeni özellik eklendi'`).
4.  Branch'inizi pushlayın (`git push origin feature/yeni-ozellik`).
5.  Pull Request oluşturun.
