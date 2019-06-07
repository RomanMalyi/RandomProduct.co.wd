using System;
using System.Collections.Generic;
using System.Linq;
using RandomProduct.Core.Abstractions.Domain;
using RandomProduct.Domain;
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
            _basketManager.AddItem(_products[0],100);

            Assert.Equal(true, _basketManager.GetBasketModel().Discounts.Contains(DataHelper.ShurikensDiscountName));
        }

        [Fact]
        public void BagsOfPogsDiscountTest()
        {
            _basketManager.AddItem(_products[1],2);

            Assert.Equal(true, _basketManager.GetBasketModel().Discounts.Contains(DataHelper.BagsOfPogsDiscountName)); 
        }

        [Fact]
        public void LargeBowlOfTrifleDiscountTest()
        {
            _basketManager.AddItem(_products[2],1);

            Assert.Equal(true, _basketManager.GetBasketModel().Discounts.Contains(DataHelper.LargeBowlOfTrifleDiscountName));
        }

        [Fact]
        public void PriceTest()
        {
            _basketManager.AddItem(_products[0],100);
            _basketManager.AddItem(_products[1],2);
            _basketManager.AddItem(_products[2],1);

            Assert.Equal(634, Math.Round(_basketManager.GetBasketModel().GrandTotalPrice,2));
        }
    }
}
