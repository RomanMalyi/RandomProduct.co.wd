using System.Collections.Generic;
using RandomProduct.Core;
using RandomProduct.Models;
using Xunit;

namespace RandomProduct.Test
{
    public class BasketManagerTests
    {
        private readonly BasketManager _basketManager;
        private List<BasketItem> _basketItems;

        public BasketManagerTests()
        {
            _basketManager = new BasketManager();
            SeedBasketItems();
        }

        private void SeedBasketItems()
        {
            _basketItems = new List<BasketItem>()
            {
                new BasketItem()
                {
                    Product = new Product()
                    {
                        Id = "RP-5NS-DITB",
                        Name = "Shurikens",
                        Description = "5 pointed Shurikens made from stainless steel.",
                        Price = 8.95f
                    },
                    ProductsCount = 1
                },
                new BasketItem()
                {
                    Product = new Product()
                    {
                        Id = "RP-25D-SITB ",
                        Name = "Bag of Pogs",
                        Description = "25 Random pogs designs.",
                        Price = 5.31f
                    },
                    ProductsCount = 1
                },
                new BasketItem()
                {
                    Product = new Product()
                    {
                        Id = "RP-1TB-EITB",
                        Name = "Large bowl of Trifle",
                        Description = "Large collectors edition bowl of Trifle.",
                        Price = 2.75f
                    },
                    ProductsCount = 1
                },
                new BasketItem()
                {
                    Product = new Product()
                    {
                        Id = "RP-RPM-FITB",
                        Name = "Paper Mask",
                        Description = "Randomly selected paper mask.",
                        Price = 0.30f
                    },
                    ProductsCount = 1
                }
            };
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
        }
    }
}
