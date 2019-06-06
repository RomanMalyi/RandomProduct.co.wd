using System.Collections.Generic;

namespace RandomProduct.Models
{
    public class Basket
    {
        public IList<BasketItem> Items { get; set; }
        public float TotalPrice { get; set; }

        public Basket()
        {
            Items = new List<BasketItem>();
        }
    }
}
