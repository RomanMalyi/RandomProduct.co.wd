using System.Collections.Generic;
using System.Linq;
using RandomProduct.Domain.Abstractions.Domain;
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
            _basket.Add(_products[0],100);

            Assert.Equal(1, _basket.Items.Count());
        }

        [Fact]
        public void RemoveItemTest()
        {
            _basket.Add(_products[0],2);
            _basket.Remove(_products[0].Id,2);

            Assert.Equal(0, _basket.Items.Count());
        }

        [Fact]
        public void ClearBasketTest()
        {
            _basket.Add(_products[0],100);
            _basket.Add(_products[1],2);
            _basket.Add(_products[2],1);

            _basket.ClearBasket();

            Assert.Equal(0, _basket.Items.Count());
            Assert.Equal(0, _basket.GrandTotalPrice);
        }
    }
}
