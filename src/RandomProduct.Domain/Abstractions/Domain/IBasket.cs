﻿using System.Collections.Generic;

namespace RandomProduct.Domain.Abstractions.Domain
{
    public interface IBasket
    {
        IReadOnlyList<string> Discounts { get; }
        IReadOnlyList<BasketItem> Items { get; }
        float GrandTotalPrice { get; }
        void Add(IProduct product, int productsCount);
        void Remove(string id, int productsCount);
        void AddBonusProduct(IProduct product, int productsCount);
        void RemoveBonusProduct(string id, int productsCount);
        void ClearBasket();
        void ApplyDiscount(IDiscount discount);
        void CancelDiscount(IDiscount discount);
    }
}
