# CustomerManagementApp

Bu proje, .NET Core MVC kullanılarak geliştirilmiş basit bir müşteri yönetim uygulamasını içerir. Uygulama, admin girişi yaparak müşteri listelerini görüntülemenizi ve yeni müşteriler eklemenizi sağlar.

## Başlangıç

Aşağıdaki adımları takip ederek projeyi yerel makinenizde çalıştırabilirsiniz:

1. **Gereksinimler:**
   - .NET Core SDK
   - Bir IDE (örn. Visual Studio, Visual Studio Code)
   - Bir veritabanı sunucusu (örn. SQL Server)

2. **Veritabanı Ayarları:**
   - `appsettings.json` dosyasında veritabanı bağlantı dizesini güncelleyin.
   - Projeyi ilk kez çalıştırdığınızda, Entity Framework Migration'ları çalıştırarak veritabanını oluşturun: `dotnet ef database update`

3. **Projeyi Çalıştırma:**
   - Proje klasörüne gidin: `cd CustomerManagementApp`
   - Uygulamayı başlatın: `dotnet run`
   - Tarayıcınızda `https://localhost:5001` adresine giderek uygulamayı görüntüleyin.

## Kullanım

Uygulama başlatıldığında, Admin Girişi ekranı açılır. Doğru kullanıcı adı ve parolayı girerseniz, Müşteri Listesi sayfasına yönlendirilirsiniz. Aksi takdirde giriş başarısız olur.

### Müşteri Listesi

- Müşteri Listesini görüntülemek için Admin Girişi yapın.
- Müşteri Listesi sayfasında "Yeni Müşteri Ekle" butonuna tıklayarak yeni müşteri eklemek için sayfaya yönlendirilirsiniz.

### Müşteri Detayları

- Müşteri Listesi sayfasında herhangi bir müşteri adına tıklayarak müşterinin detaylarını görüntüleyebilirsiniz.

## Katkıda Bulunma

Pull talepleri ve geri bildirimler her zaman hoş karşılanır. Büyük değişiklikler yapmadan önce lütfen tartışma bölümünde konuyu açın.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasını inceleyebilirsiniz.
