using System;
using System.Collections.Generic;
using System.Linq;
using RandomProduct.Core.Abstractions.Domain;
using RandomProduct.Core.Abstractions.Models;
using RandomProduct.Models;

namespace RandomProduct.Domain
{
    public class Basket : IBasket
    {
        private readonly IList<string> _discounts;
        private readonly DiscountManager _discountManager;
        private float _subTotalPrice;
        private readonly IList<IBasketItem> _items;
        public float GrandTotalPrice { get; set; }
        public IReadOnlyList<IBasketItem> Items => _items.ToList();

        public Basket(DiscountManager discountManager)
        {
            _items = new List<IBasketItem>();
            _discounts = new List<string>();
            _discountManager = discountManager;
        }

        public void AddItem(IProduct product, int productsCount)
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

        public void RemoveItem(string id)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                throw new ArgumentException($"Item with id: {id} was not found.");
            }

            _items.Remove(existingItem);
        }

        public void ClearBasket()
        {
            _items.Clear();
        }

        public IBasketModel GetBasketModel()
        {
            _discounts.Clear();
            CalculateSubPrice();
            _discountManager.ApplyDiscounts(this);

            var result = ConvertBasketToModel();
            return result;
        }

        public void AddDiscount(IDiscount discount)
        {
            _discounts.Add(discount.Name);
        }

        private IBasketModel ConvertBasketToModel()
        {
            var result = new BasketModel();
            foreach (var item in _items)
            {
                var itemPrice = item.ProductsCount * item.Price;
                result.Items.Add(new BasketItemModel()
                {
                    ProductName = item.Name,
                    ProductsCount = item.ProductsCount,
                    ItemPrice = itemPrice
                });
            }

            result.Discounts = _discounts;
            result.SubTotalPrice = _subTotalPrice;
            result.GrandTotalPrice = GrandTotalPrice;

            return result;
        }

        private void CalculateSubPrice()
        {
            _subTotalPrice = 0;
            GrandTotalPrice = 0;

            foreach (var item in _items)
            {
                _subTotalPrice += item.ProductsCount * item.Price;
            }
            GrandTotalPrice = _subTotalPrice;
        }
    }
}
