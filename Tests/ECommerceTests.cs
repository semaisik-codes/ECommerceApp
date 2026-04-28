using NUnit.Framework;
using Core;

namespace Tests
{
    [TestFixture]
    public class ECommerceTests
    {
        // ==========================================
        // 1. WHITE BOX TESTS (Kodun iç mantığını bilerek yapılan testler)
        // ==========================================

        [Test]
        public void WhiteBox_GetTotalPrice_ShouldSumCorrectly()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Price = 100 });
            cart.AddProduct(new Product { Id = 2, Price = 150 });

            Assert.That(cart.GetTotalPrice(), Is.EqualTo(250)); // PASS
        }

        [Test]
        public void WhiteBox_OrderService_AlwaysReturnsTrue()
        {
            var service = new OrderService();
            var result = service.PlaceOrder(new Cart());

            Assert.That(result, Is.True); // PASS (Kodda return true yazıyor)
        }

        // ==========================================
        // 2. BLACK BOX TESTS (Sadece girdi ve çıktıya odaklanan testler)
        // ==========================================

        [Test]
        public void BlackBox_ProductPrice_NegativeValue_ShouldFail()
        {
            // Bilerek bırakılan hata: Ürün fiyatı eksi olamaz ama kod izin veriyor.
            var product = new Product { Id = 3, Name = "Mouse", Price = -50 };

            // Fiyatın sıfırdan büyük olması beklenir ama kodda kontrol olmadığı için bu test FAIL verecek.
            Assert.That(product.Price, Is.GreaterThanOrEqualTo(0), "Ürün fiyatı negatif olamaz!");
        }

        [Test]
        public void BlackBox_CartAdd_WithZeroStock_ShouldFail()
        {
            var cart = new Cart();
            var outOfStockProduct = new Product { Id = 4, Name = "Klavye", Stock = 0 };

            cart.AddProduct(outOfStockProduct);

            // Stok 0 iken sepete eklenememesi lazım. Ama eklendiği için bu test FAIL verecek.
            Assert.That(cart.Items.Contains(outOfStockProduct), Is.False, "Stokta olmayan ürün sepete eklenmemeli!");
        }

        [Test]
        public void BlackBox_Product_NormalCreation_ShouldPass()
        {
            var product = new Product { Id = 5, Name = "Kablo", Price = 20, Stock = 100 };
            Assert.That(product.Name, Is.EqualTo("Kablo")); // PASS
        }

        // ==========================================
        // 3. GRAY BOX TESTS (Durum ve veritabanı/mantık bütünlüğü testleri)
        // ==========================================

        [Test]
        public void GrayBox_OrderService_EmptyCart_ShouldFail()
        {
            var cart = new Cart(); // Boş sepet
            var service = new OrderService();

            var isOrderPlaced = service.PlaceOrder(cart);

            // Sepet boşken sipariş verilmemeli. Kod kontrol etmediği için bu test FAIL verecek.
            Assert.That(isOrderPlaced, Is.False, "Boş sepet ile sipariş onaylanmamalı!");
        }

        [Test]
        public void GrayBox_Cart_CheckItemCount_ShouldBeAccurate()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 6 });
            Assert.That(cart.Items.Count, Is.EqualTo(1)); // PASS
        }

        [Test]
        public void GrayBox_Cart_EmptyCartPrice_ShouldBeZero()
        {
            var cart = new Cart();
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(0)); // PASS
        }

        // ==========================================
        // 4. INTEGRATION TESTS (Sistemlerin birlikte çalışması)
        // ==========================================

        [Test]
        public void Integration_Order_Completed_ShouldReduceStock()
        {
            var product = new Product { Id = 7, Name = "Laptop", Price = 10000, Stock = 5 };
            var cart = new Cart();
            cart.AddProduct(product);

            var service = new OrderService();
            service.PlaceOrder(cart); // Sipariş verildi!

            // Sipariş sonrası stok 4'e düşmeli. Ama kodda bu özellik eksik olduğu için test FAIL verecek.
            Assert.That(product.Stock, Is.EqualTo(4), "Siparişten sonra ürün stoğu azalmalı!");
        }

        [Test]
        public void Integration_Cart_And_Product_WorkTogether_Correctly()
        {
            var product1 = new Product { Id = 8, Price = 10 };
            var product2 = new Product { Id = 9, Price = 20 };

            var cart = new Cart();
            cart.AddProduct(product1);
            cart.AddProduct(product2);

            Assert.That(cart.GetTotalPrice(), Is.EqualTo(30)); // PASS
        }
    }
}