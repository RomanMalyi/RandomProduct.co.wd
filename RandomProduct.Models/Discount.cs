using System;
using System.Linq;

namespace RandomProduct.Models
{
    public class Discount : IBaseDiscount
    {
        public string Name { get; }
        private readonly Func<BasketItem, bool> _conditionsSatisfied;
        private readonly Action<Basket> _applyDiscount;

        public Discount(Func<BasketItem, bool> conditionsSatisfied, Action<Basket> applyDiscount, string name)
        {
            _conditionsSatisfied = conditionsSatisfied;
            _applyDiscount = applyDiscount;
            Name = name;
        }

        public bool IsDiscountConditionsSatisfied(Basket basket)
        {
            return basket.Items.Any(_conditionsSatisfied);
        }

        public void ApplyDiscount(Basket basket)
        {
            _applyDiscount(basket);
        }
    }
}
