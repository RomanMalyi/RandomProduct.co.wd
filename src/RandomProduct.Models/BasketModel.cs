using System.Collections.Generic;
using RandomProduct.Core.Abstractions.Models;

namespace RandomProduct.Models
{
    public class BasketModel: IBasketModel
    {
        public IList<IBasketItemModel> Items { get; set; }
        public IList<string> Discounts { get; set; }
        public float SubTotalPrice { get; set; }
        public float GrandTotalPrice { get; set; }

        public BasketModel()
        {
            Items = new List<IBasketItemModel>();
            Discounts = new List<string>();
        }
    }
}
