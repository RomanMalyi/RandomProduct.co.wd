using System;
using System.Linq;
using RandomProduct.Models;

namespace RandomProduct.Core
{
    public class BasketManager
    {
        private readonly Basket _basket;
        private readonly DiscountManager _discountManager;

        public BasketManager(DiscountManager discountManager)
        {
            _basket = new Basket();
            _discountManager = discountManager;
        }

        public void AddItem(BasketItem item)
        {
            var existingItem = _basket.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);
            if (existingItem != null)
            {
                existingItem.ProductsCount += item.ProductsCount;
            }
            else
            {
                _basket.Items.Add(item);
            }
        }

        public void RemoveItem(string id)
        {
            var existingItem = _basket.Items.FirstOrDefault(i => i.Product.Id == id);
            if (existingItem == null)
            {
                throw new ArgumentException();
            }

            _basket.Items.Remove(existingItem);
        }

        public void ClearBasket()
        {
            _basket.Items.Clear();
            _basket.SubTotalPrice = 0;
            _basket.GrandTotalPrice = 0;
        }

        public BasketView Display()
        {
            CalculateSubPrice();
            _discountManager.ApplyDiscounts(_basket);

            var result = ConvertBasketToView();
            return result;
        }

        private BasketView ConvertBasketToView()
        {
            var result = new BasketView();
            foreach (var item in _basket.Items)
            {
                var itemPrice = item.ProductsCount * item.Product.Price;
                result.Items.Add(new BasketItemView()
                {
                    ProductName = item.Product.Name,
                    ProductsCount = item.ProductsCount,
                    ItemPrice = itemPrice
                });
            }

            result.Discounts = _basket.Discounts;
            result.SubTotalPrice = _basket.SubTotalPrice;
            result.GrandTotalPrice = _basket.GrandTotalPrice;

            return result;
        }

        private void CalculateSubPrice()
        {
            _basket.SubTotalPrice = 0;
            _basket.GrandTotalPrice = 0;

            foreach (var item in _basket.Items)
            {
                _basket.SubTotalPrice += item.ProductsCount * item.Product.Price;
            }
            _basket.GrandTotalPrice = _basket.SubTotalPrice;
        }
    }
}
