using System.Collections.Generic;
using RandomProduct.Domain;
using RandomProduct.Domain.Abstractions.Domain;
using RandomProduct.Domain.Discounts;

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

        private IEnumerable<IDiscount> CreateDiscounts()
        {
            return new List<IDiscount>()
            {
                new BagsOfPogsDiscount(),
                new LargeBowlOfTrifleDiscount(),
                new ShurikensDiscount()
            };
        }
    }
}
