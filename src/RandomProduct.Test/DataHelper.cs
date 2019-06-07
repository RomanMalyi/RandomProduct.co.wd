using System.Collections.Generic;
using System.Linq;
using RandomProduct.Core.Abstractions.Domain;
using RandomProduct.Domain;
using RandomProduct.Models;

namespace RandomProduct.Test
{
    public class DataHelper
    {
        public static string ShurikensDiscountName = "Buy 100 or more Shurikens and get 30% off whole basket.";
        public static string LargeBowlOfTrifleDiscountName = "Buy a Large bowl of Trifle and get a free Paper Mask.";
        public static string BagsOfPogsDiscountName = "Buy 2 or more Bags of Pogs and get 50% off each bag (excluding the first one).";


        public Basket GetBasketManager()
        {
            return new Basket(new DiscountManager(CreateDiscounts()));
        }

        public IList<IProduct> GetProducts()
        {
            return new List<IProduct>()
            {
                new Product()
                {
                    Id = "RP-5NS-DITB",
                    Name = "Shurikens",
                    Description = "5 pointed Shurikens made from stainless steel.",
                    Price = 8.95f
                },

                new Product()
                {
                    Id = "RP-25D-SITB",
                    Name = "Bag of Pogs",
                    Description = "25 Random pogs designs.",
                    Price = 5.31f
                },

                new Product()
                {
                    Id = "RP-1TB-EITB",
                    Name = "Large bowl of Trifle",
                    Description = "Large collectors edition bowl of Trifle.",
                    Price = 2.75f
                },

                new Product()
                {
                    Id = "RP-RPM-FITB",
                    Name = "Paper Mask",
                    Description = "Randomly selected paper mask.",
                    Price = 0.30f
                }
            };
        }

        private List<IDiscount> CreateDiscounts()
        {
            return new List<IDiscount>()
            {
                new Discount(item =>item.Items.Any(i=>i.Id == "RP-25D-SITB" && i.ProductsCount > 1) ,
                    (basket) =>
                    {
                        var item = basket.Items.FirstOrDefault(i => i.Id == "RP-25D-SITB");

                        if (item != null) basket.GrandTotalPrice -= (item.ProductsCount - 1) * (item.Price / 2);
                    },BagsOfPogsDiscountName
                    ),
                new Discount(item =>item.Items.Any(i=>i.Id == "RP-1TB-EITB" && i.ProductsCount > 0),
                    (basket) =>
                    {
                        var discountedItemCount = basket.Items.FirstOrDefault(i => i.Id == "RP-1TB-EITB").ProductsCount;
                        var bonusProduct = new Product()
                        {
                            Id = "RP-RPM-FITB",
                            Name = "Paper Mask",
                            Description = "Randomly selected paper mask.",
                            Price = 0.30f
                        };
                        var existingItem = basket.Items.FirstOrDefault(i => i.Id == bonusProduct.Id);
                        if (existingItem != null)
                        {
                            existingItem.ProductsCount += discountedItemCount;
                        }
                        else
                        {
                            basket.AddItem(bonusProduct, discountedItemCount);
                        }
                    },LargeBowlOfTrifleDiscountName),
                new Discount(item =>item.Items.Any(i=>i.Id == "RP-5NS-DITB" && i.ProductsCount >= 100),
                    (basket) => { basket.GrandTotalPrice -= basket.GrandTotalPrice * 0.3f; },
                    ShurikensDiscountName)
            };
        }
    }
}
