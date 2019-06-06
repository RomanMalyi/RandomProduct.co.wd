using System.Collections.Generic;

namespace RandomProduct.Models
{
    public class BasketView
    {
        public IList<BasketItemView> Items { get; set; }
        public IList<string> Discounts { get; set; }
        public float SubTotalPrice { get; set; }
        public float GrandTotalPrice { get; set; }

        public BasketView()
        {
            Items = new List<BasketItemView>();
            Discounts = new List<string>();
        }
    }
}
