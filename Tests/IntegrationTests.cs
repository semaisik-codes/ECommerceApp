using NUnit.Framework;
using Core;

namespace Tests.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Integration_Order_Completed_ShouldReduceStock()
        {
            var product = new Product { Id = 7, Name = "Laptop", Price = 10000, Stock = 5 };
            var cart = new Cart();
            cart.AddProduct(product);

            var service = new OrderService();
            service.PlaceOrder(cart);

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

            Assert.That(cart.GetTotalPrice(), Is.EqualTo(30));
        }
    }
}