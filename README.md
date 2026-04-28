# E-Commerce Test & QA Projesi

Bu proje, temel e-ticaret işlevlerini (Ürün, Sepet, Sipariş) simüle eden ve **yazılım testi (QA)** süreçlerini uygulamak amacıyla bilinçli olarak hatalar (bug) barındıran bir C# uygulamasıdır.

NUnit kullanılarak 4 farklı test yaklaşımıyla toplam 10 test senaryosu yazılmış ve sistemdeki açıklar tespit edilmiştir.

## Kullanılan Teknolojiler
* **Dil:** C#
* **Framework:** .NET 8.0
* **Test Altyapısı:** NUnit & NUnit3TestAdapter

## Kurulum ve Çalıştırma
1. Projeyi bilgisayarınıza klonlayın veya indirin.
2. Visual Studio 2022 üzerinden `ECommerceApp.sln` dosyasını açın.
3. Üst menüden **Test > Tüm Testleri Çalıştır** (Run All Tests) seçeneğine tıklayın veya `Ctrl + R, A` kısayolunu kullanın.

## Proje Dosya Yapısı

```text
ECommerceApp/
 ├── Core/
 │    ├── Product.cs
 │    ├── Cart.cs
 │    └── OrderService.cs
 │
 ├── Tests/
 │    ├── UnitTests/
 │    │    └── UnitTests.cs (White Box, Black Box, Gray Box)
 │    └── IntegrationTests/
 │         └── IntegrationTests.cs
 │
 └── Program.cs
4. Test Explorer ekranından başarılı (Pass) ve bilinçli olarak bırakılan hatalara takılıp başarısız olan (Fail) testleri inceleyebilirsiniz. Testlerin detaylı hata nedenleri repo içindeki `Rapor.md` dosyasında açıklanmıştır.
