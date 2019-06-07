using System.Collections.Generic;
using RandomProduct.Core.Abstractions.Models;

namespace RandomProduct.Core.Abstractions.Domain
{
    public interface IBasket
    {
        IList<IBasketItem> Items { get; }
        IList<string> Discounts { get; set; }
        float GrandTotalPrice { get; set; }
        void AddItem(IProduct product, int productsCount);
        void RemoveItem(string id);
        void ClearBasket();
        IBasketModel Display();
    }
}
