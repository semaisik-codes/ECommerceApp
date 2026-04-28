using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Cart
    {
        public List<Product> Items { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            // BUG: Stok kontrolü yok! Stok 0 veya eksi olsa bile sepete ekler.
            Items.Add(product);
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(p => p.Price);
        }
    }
}
