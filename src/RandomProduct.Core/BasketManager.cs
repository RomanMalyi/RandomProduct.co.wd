using System;
using System.Linq;
using RandomProduct.Models;

namespace RandomProduct.Core
{
    public class BasketManager
    {
        private readonly Basket _basket;

        public BasketManager()
        {
            _basket = new Basket();
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
            _basket.TotalPrice = 0;
        }

        public BasketView Display()
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
                result.SubTotalPrice += itemPrice;
            }

            return result;
        }
    }
}
