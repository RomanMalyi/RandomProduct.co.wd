using System;
using RandomProduct.Models;

namespace RandomProduct.Core
{
    public class BasketManager
    {
        private Basket _basket;

        public BasketManager()
        {
            _basket = new Basket();
        }

        public void AddItem(BasketItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string id)
        {
            throw new NotImplementedException();
        }

        public void ClearBasket()
        {
            throw new NotImplementedException();
        }

        public BasketView Display()
        {
            throw new NotImplementedException();
        }
    }
}
