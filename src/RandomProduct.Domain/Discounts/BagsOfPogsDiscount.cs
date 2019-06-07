using System.Linq;
using RandomProduct.Domain.Abstractions.Domain;
using RandomProduct.Domain.Discounts.Base;

namespace RandomProduct.Domain.Discounts
{
    public class BagsOfPogsDiscount : BaseDiscount
    {
        private const string ProductId = "RP-25D-SITB";
        public BagsOfPogsDiscount(): base("Buy 2 or more Bags of Pogs and get 50% off each bag (excluding the first one).") {}

        public override bool IsDiscountConditionsSatisfied(IBasket basket)
        {
            return basket.Items.Any(i => i.Id == ProductId && i.ProductsCount > 1);
        }

        public override float ApplyDiscount(IBasket basket)
        {
            var item = basket.Items.FirstOrDefault(i => i.Id == ProductId);

            var resultPrice = basket.GrandTotalPrice;
            if (item != null) resultPrice = resultPrice - (item.ProductsCount - 1) * (item.Price / 2);

            return resultPrice;
        }

        public override float CancelDiscount(IBasket basket)
        {
            var item = basket.Items.FirstOrDefault(i => i.Id == ProductId);

            var resultPrice = basket.GrandTotalPrice;
            if (item != null) resultPrice = resultPrice + (item.ProductsCount - 1) * (item.Price / 2);

            return resultPrice;
        }
    }
}
