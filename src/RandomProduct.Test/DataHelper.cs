using System.Collections.Generic;
using System.Linq;
using RandomProduct.Core;
using RandomProduct.Models;

namespace RandomProduct.Test
{
    public class DataHelper
    {
        public static string ShurikensDiscountName = "Buy 100 or more Shurikens and get 30% off whole basket.";
        public static string LargeBowlOfTrifleDiscountName = "Buy a Large bowl of Trifle and get a free Paper Mask.";
        public static string BagsOfPogsDiscountName = "Buy 2 or more Bags of Pogs and get 50% off each bag (excluding the first one).";


        public BasketManager GetBasketManager()
        {
            return new BasketManager(new DiscountManager(CreateDiscounts()));
        }

        public List<BasketItem> GetBasketItem()
        {
            return new List<BasketItem>()
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
                    ProductsCount = 100
                },
                new BasketItem()
                {
                    Product = new Product()
                    {
                        Id = "RP-25D-SITB",
                        Name = "Bag of Pogs",
                        Description = "25 Random pogs designs.",
                        Price = 5.31f
                    },
                    ProductsCount = 2
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

        private List<IBaseDiscount> CreateDiscounts()
        {
            return new List<IBaseDiscount>()
            {
                new Discount(item => item.Product.Id == "RP-25D-SITB" && item.ProductsCount > 1,
                    (basket) =>
                    {
                        var item = basket.Items.FirstOrDefault(i => i.Product.Id == "RP-25D-SITB");

                        if (item != null) basket.GrandTotalPrice -= (item.ProductsCount - 1) * (item.Product.Price / 2);
                    },BagsOfPogsDiscountName
                    ),
                new Discount(item => item.Product.Id == "RP-1TB-EITB" && item.ProductsCount > 0,
                    (basket) =>
                    {
                        var discountedItemCount = basket.Items.FirstOrDefault(i => i.Product.Id == "RP-1TB-EITB").ProductsCount;
                        var bonusItem = new BasketItem()
                        {
                            Product = new Product()
                            {
                                Id = "RP-RPM-FITB",
                                Name = "Paper Mask",
                                Description = "Randomly selected paper mask.",
                                Price = 0.30f
                            },
                            ProductsCount = discountedItemCount
                        };
                        var existingItem = basket.Items.FirstOrDefault(i => i.Product.Id == bonusItem.Product.Id);
                        if (existingItem != null)
                        {
                            existingItem.ProductsCount += bonusItem.ProductsCount;
                        }
                        else
                        {
                            basket.Items.Add(bonusItem);
                        }
                    },LargeBowlOfTrifleDiscountName),
                new Discount(item => item.Product.Id == "RP-5NS-DITB" && item.ProductsCount >= 100,
                    (basket) => { basket.GrandTotalPrice -= basket.GrandTotalPrice * 0.3f; },
                    ShurikensDiscountName)
            };
        }
    }
}
