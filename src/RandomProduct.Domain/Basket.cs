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
        public IList<IBasketItem> Items { get; }
        public  IList<string> Discounts { get; set; }
        private float _subTotalPrice;
        public float GrandTotalPrice { get; set; }
        private readonly DiscountManager _discountManager;

        public Basket(DiscountManager discountManager)
        {
            Items = new List<IBasketItem>();
            Discounts = new List<string>();
            _discountManager = discountManager;
        }

        public void AddItem(IProduct product, int productsCount)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == product.Id);
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
                Items.Add(newItem);
            }
        }

        public void RemoveItem(string id)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                throw new ArgumentException($"Item with id: {id} was not found.");
            }

            Items.Remove(existingItem);
        }

        public void ClearBasket()
        {
            Items.Clear();
        }

        public IBasketModel Display()
        {
            CalculateSubPrice();
            _discountManager.ApplyDiscounts(this);

            var result = ConvertBasketToView();
            return result;
        }

        private IBasketModel ConvertBasketToView()
        {
            var result = new BasketModel();
            foreach (var item in Items)
            {
                var itemPrice = item.ProductsCount * item.Price;
                result.Items.Add(new BasketItemModel()
                {
                    ProductName = item.Name,
                    ProductsCount = item.ProductsCount,
                    ItemPrice = itemPrice
                });
            }

            result.Discounts = Discounts;
            result.SubTotalPrice = _subTotalPrice;
            result.GrandTotalPrice = GrandTotalPrice;

            return result;
        }

        private void CalculateSubPrice()
        {
            _subTotalPrice = 0;
            GrandTotalPrice = 0;

            foreach (var item in Items)
            {
                _subTotalPrice += item.ProductsCount * item.Price;
            }
            GrandTotalPrice = _subTotalPrice;
        }
    }
}
