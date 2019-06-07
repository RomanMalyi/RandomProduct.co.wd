using System.Collections.Generic;

namespace RandomProduct.Core.Abstractions.Models
{
    public interface IBasketModel
    {
        IList<IBasketItemModel> Items { get; set; }
        IList<string> Discounts { get; set; }
        float SubTotalPrice { get; set; }
        float GrandTotalPrice { get; set; }
    }
}
