using System.Collections.Generic;
using RandomProduct.Models;

namespace RandomProduct.Core
{
    public class DiscountManager
    {
        private readonly List<IBaseDiscount> _discounts;

        public DiscountManager(List<IBaseDiscount> discounts)
        {
            _discounts = discounts;
        }

        public void ApplyDiscounts(Basket basket)
        {
            foreach (var discount in _discounts)
            {
                if (!discount.IsDiscountConditionsSatisfied(basket)) continue;
                discount.ApplyDiscount(basket);
                basket.Discounts.Add(discount.Name);
            }
        }
    }
}
