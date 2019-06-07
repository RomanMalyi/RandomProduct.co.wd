using System.Collections.Generic;
using RandomProduct.Core.Abstractions.Domain;

namespace RandomProduct.Domain
{
    public class DiscountManager
    {
        private readonly List<IDiscount> _discounts;

        public DiscountManager(List<IDiscount> discounts)
        {
            _discounts = discounts;
        }

        public void ApplyDiscounts(Basket basket)
        {
            foreach (var discount in _discounts)
            {
                if (!discount.IsDiscountConditionsSatisfied(basket)) continue;
                discount.ApplyDiscount(basket);
            }
        }
    }
}
