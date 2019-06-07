using System.Collections.Generic;
using System.Linq;
using RandomProduct.Domain.Abstractions.Domain;
using RandomProduct.Domain.Abstractions.Services;

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
                basket.ApplyDiscount(discount);
            }
        }

        public void CancelDiscounts(IList<string> discounts, IBasket basket)
        {
            for (var i = discounts.Count-1; i >= 0; --i)
            {
                var discount = _discounts.First(e => e.Name == discounts[i]);
                basket.CancelDiscount(discount);
            }
        }
    }
}
