using System;
using System.Collections.Generic;
using RandomProduct.Core;
using RandomProduct.Models;
using Xunit;

namespace RandomProduct.Test
{
    public class DiscountManagerTests
    {
        private readonly BasketManager _basketManager;
        private readonly List<BasketItem> _basketItems;

        public DiscountManagerTests()
        {
            var dataHelper = new DataHelper();
            _basketManager = dataHelper.GetBasketManager();
            _basketItems = dataHelper.GetBasketItem();
        }

        [Fact]
        public void ShurikensDiscountTest()
        {
            _basketManager.AddItem(_basketItems[0]);

            Assert.Equal(true, _basketManager.Display().Discounts.Contains(DataHelper.ShurikensDiscountName));
        }

        [Fact]
        public void BagsOfPogsDiscountTest()
        {
            _basketManager.AddItem(_basketItems[1]);

            Assert.Equal(true, _basketManager.Display().Discounts.Contains(DataHelper.BagsOfPogsDiscountName)); 
        }

        [Fact]
        public void LargeBowlOfTrifleDiscountTest()
        {
            _basketManager.AddItem(_basketItems[2]);

            Assert.Equal(true, _basketManager.Display().Discounts.Contains(DataHelper.LargeBowlOfTrifleDiscountName));
        }

        [Fact]
        public void PriceTest()
        {
            _basketManager.AddItem(_basketItems[0]);
            _basketManager.AddItem(_basketItems[1]);
            _basketManager.AddItem(_basketItems[2]);

            Assert.Equal(634, Math.Round(_basketManager.Display().GrandTotalPrice,2));
        }
    }
}
