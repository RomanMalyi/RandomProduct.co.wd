using System;
using System.Collections.Generic;
using System.Linq;
using RandomProduct.Domain.Abstractions.Domain;
using RandomProduct.Domain.Abstractions.Services;

namespace RandomProduct.Domain
{
    public class Basket : IBasket
    {
        public IList<string> Discounts { get; }
        private readonly IDiscountManager _discountManager;
        private float _subTotalPrice;
        private readonly IList<BasketItem> _items;
        public float GrandTotalPrice { get; private set; }
        public IReadOnlyList<BasketItem> Items => _items.ToList();

        public Basket(IDiscountManager discountManager)
        {
            _items = new List<BasketItem>();
            Discounts = new List<string>();
            _discountManager = discountManager;
        }

        public void Add(IProduct product, int productsCount)
        {
            AddItem(product, productsCount);
            CalculatePrice();
        }

        public void Remove(string id, int productsCount)
        {
            _discountManager.CancelDiscounts(Discounts, this);
            RemoveItem(id, productsCount);
            CalculatePrice();
        }

        public void ClearBasket()
        {
            _items.Clear();
            Discounts.Clear();
            _subTotalPrice = 0;
            GrandTotalPrice = 0;
        }

        public void ApplyDiscount(IDiscount discount)
        {
            GrandTotalPrice = discount.ApplyDiscount(this);
            Discounts.Add(discount.Name);
        }

        public void CancelDiscount(IDiscount discount)
        {
            GrandTotalPrice = discount.CancelDiscount(this);
            Discounts.Remove(discount.Name);
        }

        public void AddBonusProduct(IProduct product, int productsCount)
        {
            AddItem(product, productsCount);
        }

        public void RemoveBonusProduct(string id, int productsCount)
        {
            RemoveItem(id, productsCount);
        }

        #region PrivateMethods
        private void AddItem(IProduct product, int productsCount)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.ProductsCount += productsCount;
            }
            else
            {
                var newItem = new BasketItem()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ProductsCount = productsCount
                };
                _items.Add(newItem);
            }
        }

        private void RemoveItem(string id, int productsCount)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                throw new ArgumentException($"Item with id: {id} was not found.");
            }

            if (existingItem.ProductsCount > productsCount)
            {
                existingItem.ProductsCount -= productsCount;
            }
            else
            {
                _items.Remove(existingItem);
            }
        }

        private void CalculatePrice()
        {
            if (Discounts.Count > 0)
            {
                _discountManager.CancelDiscounts(Discounts, this);

            }
            _subTotalPrice = 0;
            GrandTotalPrice = 0;

            foreach (var item in _items)
            {
                _subTotalPrice += item.ProductsCount * item.Price;
            }
            GrandTotalPrice = _subTotalPrice;

            _discountManager.ApplyDiscounts(this);
        }

        #endregion
    }
}
