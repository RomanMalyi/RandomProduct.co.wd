using System.Collections.Generic;
using RandomProduct.Core.Abstractions.Domain;
using Xunit;

namespace RandomProduct.Test
{
    public class BasketManagerTests
    {
        private readonly IBasket _basket;
        private readonly IList<IProduct> _products;

        public BasketManagerTests()
        {
            var dataHelper = new DataHelper();
            _basket = dataHelper.GetBasketManager();
            _products = dataHelper.GetProducts();
        }

        [Fact]
        public void AddItemTest()
        {
            _basket.AddItem(_products[0],100);

            Assert.Equal(1, _basket.GetBasketModel().Items.Count);
        }

        [Fact]
        public void RemoveItemTest()
        {
            _basket.AddItem(_products[0],2);
            _basket.RemoveItem(_products[0].Id);

            Assert.Equal(0, _basket.GetBasketModel().Items.Count);
        }

        [Fact]
        public void ClearBasketTest()
        {
            _basket.AddItem(_products[0],100);
            _basket.AddItem(_products[1],2);
            _basket.AddItem(_products[2],1);

            _basket.ClearBasket();

            Assert.Equal(0, _basket.GetBasketModel().Items.Count);
            Assert.Equal(0, _basket.GetBasketModel().SubTotalPrice);
            Assert.Equal(0, _basket.GetBasketModel().GrandTotalPrice);
        }
    }
}
