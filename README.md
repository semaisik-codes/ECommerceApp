# E-Commerce Test & QA Projesi

Bu proje, temel e-ticaret işlevlerini (Ürün, Sepet, Sipariş) simüle eden ve **yazılım testi (QA)** süreçlerini uygulamak amacıyla bilinçli olarak hatalar (bug) barındıran bir C# uygulamasıdır.

NUnit kullanılarak 4 farklı test yaklaşımıyla toplam 10 test senaryosu yazılmış ve sistemdeki açıklar tespit edilmiştir.

## Kullanılan Teknolojiler
* **Dil:** C#
* **Framework:** .NET 8.0
* **Test Altyapısı:** NUnit & NUnit3TestAdapter

## Proje Mimarisi
* **Core (Class Library):** Sistemin iş mantığını barındırır (`Product.cs`, `Cart.cs`, `OrderService.cs`). Bilinçli mantıksal hatalar bu katmandadır.
* **Tests (NUnit Project):** Yazılan test senaryolarını içerir (`ECommerceTests.cs`).
* **ECommerceApp (Console App):** Ana proje gövdesi.

## Uygulanan Test Türleri
* **White Box Testing:** Kodun iç yapısı bilinerek yapılan testler (Örn: GetTotalPrice metodunun doğru toplaması).
* **Black Box Testing:** Sadece girdi/çıktı kontrolü yapılan testler (Örn: Negatif ürün fiyatı girilmesi durumu).
* **Gray Box Testing:** Hem iç yapı hem de durum odaklı testler (Örn: Boş sepetle sipariş verilmesi).
* **Integration Testing:** Modüllerin birlikte çalışabilirliği (Örn: Sipariş tamamlanınca stoğun düşmesi).

## Kurulum ve Çalıştırma
1. Projeyi bilgisayarınıza klonlayın veya indirin.
2. Visual Studio 2022 üzerinden `ECommerceApp.sln` dosyasını açın.
3. Üst menüden **Test > Tüm Testleri Çalıştır** (Run All Tests) seçeneğine tıklayın veya `Ctrl + R, A` kısayolunu kullanın.
4. Test Explorer ekranından başarılı (Pass) ve bilinçli olarak bırakılan hatalara takılıp başarısız olan (Fail) testleri inceleyebilirsiniz. Testlerin detaylı hata nedenleri repo içindeki `Rapor.md` dosyasında açıklanmıştır.
