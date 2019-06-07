using System.Collections.Generic;
using RandomProduct.Core.Abstractions.Models;

namespace RandomProduct.Core.Abstractions.Domain
{
    public interface IBasket
    {
        IReadOnlyList<IBasketItem> Items { get; }
        float GrandTotalPrice { get; set; }
        void AddItem(IProduct product, int productsCount);
        void RemoveItem(string id);
        void ClearBasket();
        IBasketModel GetBasketModel();
        void AddDiscountName(IDiscount discount);
    }
}
