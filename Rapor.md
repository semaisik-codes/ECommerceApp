# E-Ticaret Sistemi Test Raporu

Bu projede temel bir e-ticaret sisteminin Sepet, Ürün ve Sipariþ yönetimi C# kullanýlarak yazýlmýþ ve NUnit ile test edilmiþtir. Sisteme bilinçli olarak býrakýlan mantýksal hatalar, yazýlan 10 test senaryosu ile yakalanmýþtýr.

## Baþarýsýz Olan (Fail) Testler ve Nedenleri

* **BlackBox_ProductPrice_NegativeValue_ShouldFail:** * *Neden Fail Oldu?:* Product sýnýfýnda ürün fiyatýnýn negatif (eksi) bir deðer olmasýný engelleyecek bir validasyon kuralý bulunmuyor. Test, negatif fiyat girildiðinde hata fýrlatmasýný beklerken kod bunu kabul ettiði için baþarýsýz oldu.

* **BlackBox_CartAdd_WithZeroStock_ShouldFail:**
    * *Neden Fail Oldu?:* Cart sýnýfýndaki AddProduct metodunda stok kontrolü yapýlmýyor. Ürünün stoðu 0 olsa dahi sepete eklenmesine izin veriyor. Test bunu yakaladý.

* **GrayBox_OrderService_EmptyCart_ShouldFail:**
    * *Neden Fail Oldu?:* OrderService sýnýfý, sepetin içinde ürün olup olmadýðýný (Items.Count > 0) kontrol etmeden PlaceOrder metodundan "true" döndürüyor. Boþ sepetle sipariþ geçilebildiði için test baþarýsýz oldu.

* **Integration_Order_Completed_ShouldReduceStock:**
    * *Neden Fail Oldu?:* Sipariþ verme iþlemi ve ürün stoðu arasýnda bir entegrasyon eksikliði var. OrderService üzerinden sipariþ tamamlandýðýnda, sepet içindeki ürünlerin Stock deðerleri güncellenmiyor.

## Sonuç
Testler sonucunda sistemdeki kritik 4 "bug" baþarýyla tespit edilmiþtir. Ýlgili eksikliklerin `Core` projesi içerisindeki iþ mantýðýna (Business Logic) eklenmesi gerekmektedir.