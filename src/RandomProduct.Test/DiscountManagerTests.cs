using System;
using System.Collections.Generic;
using RandomProduct.Domain;
using RandomProduct.Domain.Abstractions.Domain;
using Xunit;

namespace RandomProduct.Test
{
    public class DiscountManagerTests
    {
        private readonly Basket _basketManager;
        private readonly IList<IProduct> _products;

        public DiscountManagerTests()
        {
            var dataHelper = new DataHelper();
            _basketManager = dataHelper.GetBasketManager();
            _products = dataHelper.GetProducts();
        }

        [Fact]
        public void ShurikensDiscountTest()
        {
            _basketManager.Add(_products[0], 100);

            Assert.Equal(626.5, Math.Round(_basketManager.GrandTotalPrice, 2));
        }

        [Fact]
        public void BagsOfPogsDiscountTest()
        {
            _basketManager.Add(_products[1], 2);

            Assert.Equal(7.97, Math.Round(_basketManager.GrandTotalPrice, 2));
        }

        [Fact]
        public void LargeBowlOfTrifleDiscountTest()
        {
            _basketManager.Add(_products[2], 1);

            Assert.Equal(2.75, Math.Round(_basketManager.GrandTotalPrice, 2));
        }

        [Fact]
        public void PriceTest()
        {
            _basketManager.Add(_products[0],100);
            _basketManager.Add(_products[1],2);
            _basketManager.Add(_products[2],1);

            Assert.Equal(634, Math.Round(_basketManager.GrandTotalPrice, 2));
        }

        [Fact]
        public void BagsOfPogsDiscountCencelTest()
        {
            _basketManager.Add(_products[1], 2);
            _basketManager.Remove(_products[1].Id,1);

            Assert.Equal(5.31, Math.Round(_basketManager.GrandTotalPrice, 2));
        }

        [Fact]
        public void LargeBowlOfTrifleDiscountCencelTest()
        {
            _basketManager.Add(_products[2], 1);
            _basketManager.Remove(_products[2].Id, 1);

            Assert.Equal(0, _basketManager.Items.Count);
        }
    }
}
