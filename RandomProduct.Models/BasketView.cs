using System.Collections.Generic;

namespace RandomProduct.Models
{
    public class BasketView
    {
        public IList<BasketItemView> Items { get; set; }
        public float SubTotalPrice { get; set; }

        public BasketView()
        {
            Items = new List<BasketItemView>();
        }
    }
}
