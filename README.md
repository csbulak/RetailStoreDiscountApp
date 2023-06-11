# ShopsRUs Retail Store Discounts API

Bu projede, ShopsRUs perakende mağazasının müşterilerine indirim sunmak için bir RESTful API oluşturulmuştur. API, indirim hesaplama, toplam maliyetleri ve faturaları oluşturma gibi yetenekleri sağlamaktadır.

## Teknik Gereksinimler

- .NET Core SDK (sürüm 7.0.5)
- Git

## Kurulum

1. Projenin bir kopyasını bilgisayarınıza almak için Git'i kullanın:

git clone https://github.com/csbulak/RetailStoreDiscountApp.git


2. Proje dizinine gidin:

cd RetailStoreDiscountApp\API


3. Proje bağımlılıklarını yüklemek için aşağıdaki komutu çalıştırın:

dotnet restore


## Yapılandırma

API'nin çalışması için bazı yapılandırma ayarlarına ihtiyaç vardır. `appsettings.json` dosyasını düzenleyerek bu ayarları yapabilirsiniz. Örneğin, veritabanı bağlantı bilgileri, JWT anahtarı vb.

## Çalıştırma

1. Proje dizininde aşağıdaki komutu çalıştırarak API'yi başlatın:

dotnet run


2. API başarıyla başlatıldıktan sonra tarayıcınızda aşağıdaki URL'yi açın:

https://localhost:7249/


## Testler

1. Testleri yürütmek için aşağıdaki komutu çalıştırın:

dotnet test


2. Testler başarıyla tamamlandıktan sonra kapsama raporunu oluşturmak için aşağıdaki komutu çalıştırın:

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./TestResults/


3. Kapsama raporu `./TestResults/coverage/index.html` dosyasında oluşturulacaktır.

## API Kullanımı

API'yi kullanmak için bir HTTP istemcisi (Postman, cURL vb.) kullanabilirsiniz. API'nin kullanılabilir rotalarını ve örnek istekleri belgeleyin.

## Katkıda Bulunma

1. Bu projeyi kendi GitHub hesabınıza "fork" edin.
2. Yeni bir özellik veya düzeltme üzerinde çalışın.
3. Değişikliklerinizi "pull request" olarak gönderin.
