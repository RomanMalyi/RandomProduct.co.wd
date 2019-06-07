using System.Linq;
using RandomProduct.Domain.Abstractions.Domain;
using RandomProduct.Domain.Discounts.Base;

namespace RandomProduct.Domain.Discounts
{
    public class ShurikensDiscount: BaseDiscount
    {
        private const string ProductId = "RP-5NS-DITB";
        public ShurikensDiscount() : base("Buy 100 or more Shurikens and get 30% off whole basket.") { }

        public override bool IsDiscountConditionsSatisfied(IBasket basket)
        {
            return basket.Items.Any(i => i.Id == ProductId && i.ProductsCount > 1);
        }

        public override float ApplyDiscount(IBasket basket)
        {
            var resultPrice = basket.GrandTotalPrice * 0.7f;
            return resultPrice;
        }

        public override float CancelDiscount(IBasket basket)
        {
            var resultPrice = basket.GrandTotalPrice / 0.7f;
            return resultPrice;
        }
    }
}
