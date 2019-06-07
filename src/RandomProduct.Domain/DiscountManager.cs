using System.Collections.Generic;
using System.Linq;
using RandomProduct.Core.Abstractions.Domain;
using RandomProduct.Core.Abstractions.Services;

namespace RandomProduct.Domain
{
    public class DiscountManager: IDiscountManager
    {
        private readonly List<IDiscount> _discounts;

        public DiscountManager(IEnumerable<IDiscount> discounts)
        {
            _discounts = discounts.ToList();
        }

        public void ApplyDiscounts(IBasket basket)
        {
            foreach (var discount in _discounts)
            {
                if (!discount.IsDiscountConditionsSatisfied(basket)) continue;
                discount.ApplyDiscount(basket);
                basket.AddDiscountName(discount);
            }
        }
    }
}
