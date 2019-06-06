using System.Collections.Generic;
using RandomProduct.Core;
using RandomProduct.Models;
using Xunit;

namespace RandomProduct.Test
{
    public class BasketManagerTests
    {
        private readonly BasketManager _basketManager;
        private readonly List<BasketItem> _basketItems;

        public BasketManagerTests()
        {
            var dataHelper = new DataHelper();
            _basketManager = dataHelper.GetBasketManager();
            _basketItems = dataHelper.GetBasketItem();
        }

        [Fact]
        public void AddItemTest()
        {
            _basketManager.AddItem(_basketItems[0]);

            Assert.Equal(1, _basketManager.Display().Items.Count);
        }

        [Fact]
        public void RemoveItemTest()
        {
            _basketManager.AddItem(_basketItems[0]);
            _basketManager.RemoveItem(_basketItems[0].Product.Id);

            Assert.Equal(0, _basketManager.Display().Items.Count);
        }

        [Fact]
        public void ClearBasketTest()
        {
            _basketManager.AddItem(_basketItems[0]);
            _basketManager.AddItem(_basketItems[1]);
            _basketManager.AddItem(_basketItems[2]);

            _basketManager.ClearBasket();

            Assert.Equal(0, _basketManager.Display().Items.Count);
            Assert.Equal(0, _basketManager.Display().SubTotalPrice);
            Assert.Equal(0, _basketManager.Display().GrandTotalPrice);
        }
    }
}
