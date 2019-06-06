using System.Collections.Generic;

namespace RandomProduct.Models
{
    public class Basket
    {
        public IList<BasketItem> Items { get; set; }
        public IList<string> Discounts { get; set; }
        public float SubTotalPrice { get; set; }
        public float GrandTotalPrice { get; set; }

        public Basket()
        {
            Items = new List<BasketItem>();
            Discounts = new List<string>();
        }
    }
}
