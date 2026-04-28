using System.Linq;

namespace Core
{
    public class OrderService
    {
        public bool PlaceOrder(Cart cart)
        {
            // BUG 1: Sepette ürün var mı diye kontrol etmiyor. Boş sipariş geçilebilir.

            // BUG 2: Sipariş onaylandıktan sonra ürünlerin Stock değerini düşmüyor.
            return true;
        }
    }
}
