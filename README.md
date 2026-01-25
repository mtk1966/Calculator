# Calculator

Basit bir ASP.NET Core MVC tabanlı hesap makinesi uygulaması. Temel aritmetik işlemler (toplama, çıkarma, çarpma, bölme), karekök işlemleri, üslü sayılar ve bazı geometrik hesaplama görünümleri içerir. Proje, web ön yüzü, veri erişimi ve ortak modeller şeklinde ayrılmıştır.

## Hızlı bakış
- Teknolojiler: ASP.NET Core MVC, Entity Framework Core, Identity (uygulama DB'ye hazır), Bootstrap, jQuery
- Proje yapısı (ana klasörler):
  - `Calculator.Web` — Web uygulaması (giriş noktası / UI / Controllers / Views)
  - `Calculator.Data` — EF Core DbContext, migration'lar
  - `Calculator.Common` — Ortak modeller
  - Diğer: `Todos.cs` (yapılacaklar listesi)

## Özellikler
- Temel 4 işlem: Toplama, Çıkarma, Çarpma, Bölme (Controller: `ProcessController`)
- Karekök işlemleri (views: `Calculator.Web/Views/SquareRootOperations`)
- Üslü sayılar için işlemler (models: `ExponentViewModel`)
- Geometrik alan/çevre hesaplama görünümleri (ShapeViewModel)
- EF Core veri tabanı bağlantısı ve migration'lar mevcut (`Calculator.Data/Migrations`)

## Hangi dosyalara bakmalısınız (hızlı rehber)
- `Calculator.Web/Controllers/ProcessController.cs` — Temel işlemler
- `Calculator.Web/Views/*` — Kullanıcı arayüzü sayfaları
- `Calculator.Data/CalculatorDbContext.cs` — DbContext (Identity ile genişletilmiş)
- `Calculator.Common/Models/*` — Paylaşılan ViewModel/model sınıfları
- `Todos.cs` — Proje için planlanan geliştirme adımları

## Nasıl çalıştırılır (yerel)
Ön koşullar:
- .NET 6 / 7 veya proje dosyasında belirtilen hedef framework (IDE: Visual Studio 2022+ veya VS Code + C# eklentileri)
- (Opsiyonel) SQL Server / LocalDB / SQLite vb. — bağlantı dizesine bağlı

Adımlar:
1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/mtk1966/Calculator.git
   cd Calculator
   ```

2. Bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```

3. appsettings.json içinde `ConnectionStrings:DefaultConnection` değerini ayarlayın.
   Örnek (LocalDB):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CalculatorDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```
   Not: Gerçek secret'ları repo'ya koymayın. Üretim için ortam değişkenleri veya secrets kullanın.

4. Migration'ları uygulayın (EF Tools kuruluysa):
   ```bash
   dotnet ef database update --project Calculator.Data --startup-project Calculator.Web
   ```
   Alternatif: Visual Studio Package Manager Console üzerinden `Update-Database`.

5. Uygulamayı başlatın:
   ```bash
   dotnet run --project Calculator.Web
   ```
   Tarayıcıda `https://localhost:5001` veya konsolda görünen URL'yi açın.

## Kullanım
- Ana sayfada yapmak istediğiniz işlem türünü seçin.
- Örnek: "Temel İşlemler" -> "Toplama" -> formdaki alanlara sayıları girip "Topla" butonuna basın.
- Karekök ve üslü işlemler için ilgili sayfalardaki form alanlarını doldurun; sonuç aynı sayfada gösterilir.

## Geliştirme notları / TODO
Projede eksik veya geliştirilmesi önerilen noktalar:
- `Todos.cs` dosyasındaki görevleri tamamlayın (controller refactor, view iyileştirmeleri, auth).
- Kullanıcı kimlik doğrulaması aktif değil; Identity yapılandırması tamamlanmalı (gerekirse rol tabanlı erişim).
- Test projeleri yok — birim testleri ekleyin (xUnit/NUnit + CI).
- Input doğrulama ve hata yönetimi güçlendirilmeli (server-side + client-side).
- Güvenlik: hassas bilgileri (connection strings, API anahtarları) repo'ya koymayın.

## Güvenlik ve yayınlama öncesi kontrol listesi
- Git geçmişinde gizli değer (API anahtarı, parola, token vb.) olmadığını tarayın (gitleaks, truffleHog).
- Eğer gizli bilgi bulunduysa: anahtarları iptal edin/rotasyon yapın ve geçmişten temizlemek için `git filter-repo` veya BFG kullanın.
- `appsettings.*.json` dosyalarında üretim bilgilerini bulundurmayın; GitHub Secrets veya ortam değişkenleri kullanın.
- Lisans ekleyin (örn. MIT) — lisans yoksa kullanım koşullarını belirtin.

## Katkıda bulunma
- Issue açarak eksik özellikleri veya hataları bildirebilirsiniz.
- Yeni feature için branch açın, PR gönderin ve değişiklikleri açıklayan kısa bir özet ekleyin.
- Kod standartları: C# kodlama standartlarına uygunluk, yorum satırları ve temiz commit mesajları tercih edilir.

## Lisans
Projede lisans dosyası yoksa (kontrol edin), eklemenizi öneririm (ör. MIT). Mevcut üçüncü taraf kütüphanelerin lisansları `Calculator.Web/wwwroot/lib/*/LICENSE` içinde bulunuyor (örn. Bootstrap, jQuery).

## İletişim
Proje sahibi: mtk1966 (GitHub). README veya repo üzerinde nasıl ilerlemek istediğinizi belirtirseniz yardımcı olurum — örn. README'yi doğrudan repoya commit etmemi ister misiniz yoksa önce PR mı hazırlayayım?

---

Not: İsterseniz bu README'i doğrudan repoya ekleyip bir pull request oluşturacak şekilde bir örnek commit içeriği veya PR açıklaması hazırlayayım.
