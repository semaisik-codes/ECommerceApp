using NUnit.Framework;
using Core;

namespace Tests.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        // --- WHITE BOX ---
        [Test]
        public void WhiteBox_GetTotalPrice_ShouldSumCorrectly()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Price = 100 });
            cart.AddProduct(new Product { Id = 2, Price = 150 });
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(250));
        }

        [Test]
        public void WhiteBox_OrderService_AlwaysReturnsTrue()
        {
            var service = new OrderService();
            Assert.That(service.PlaceOrder(new Cart()), Is.True);
        }

        // --- BLACK BOX ---
        [Test]
        public void BlackBox_ProductPrice_NegativeValue_ShouldFail()
        {
            var product = new Product { Id = 3, Name = "Mouse", Price = -50 };
            Assert.That(product.Price, Is.GreaterThanOrEqualTo(0), "Ürün fiyatı negatif olamaz!");
        }

        [Test]
        public void BlackBox_CartAdd_WithZeroStock_ShouldFail()
        {
            var cart = new Cart();
            var outOfStockProduct = new Product { Id = 4, Name = "Klavye", Stock = 0 };
            cart.AddProduct(outOfStockProduct);
            Assert.That(cart.Items.Contains(outOfStockProduct), Is.False, "Stokta olmayan ürün sepete eklenmemeli!");
        }

        [Test]
        public void BlackBox_Product_NormalCreation_ShouldPass()
        {
            var product = new Product { Id = 5, Name = "Kablo", Price = 20, Stock = 100 };
            Assert.That(product.Name, Is.EqualTo("Kablo"));
        }

        // --- GRAY BOX ---
        [Test]
        public void GrayBox_OrderService_EmptyCart_ShouldFail()
        {
            var service = new OrderService();
            var isOrderPlaced = service.PlaceOrder(new Cart());
            Assert.That(isOrderPlaced, Is.False, "Boş sepet ile sipariş onaylanmamalı!");
        }

        [Test]
        public void GrayBox_Cart_CheckItemCount_ShouldBeAccurate()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 6 });
            Assert.That(cart.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void GrayBox_Cart_EmptyCartPrice_ShouldBeZero()
        {
            var cart = new Cart();
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(0));
        }
    }
}