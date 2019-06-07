using System;
using RandomProduct.Core.Abstractions.Domain;

namespace RandomProduct.Models
{
    public class Discount : IDiscount
    {
        public string Name { get; }
        private readonly Func<IBasket, bool> _conditionsSatisfied;
        private readonly Action<IBasket> _applyDiscount;

        public Discount(Func<IBasket, bool> conditionsSatisfied, Action<IBasket> applyDiscount, string name)
        {
            _conditionsSatisfied = conditionsSatisfied;
            _applyDiscount = applyDiscount;
            Name = name;
        }

        public bool IsDiscountConditionsSatisfied(IBasket basket)
        {
            return _conditionsSatisfied(basket);
        }

        public void ApplyDiscount(IBasket basket)
        {
            _applyDiscount(basket);
            basket.Discounts.Add(Name);
        }
    }
}
