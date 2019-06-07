using RandomProduct.Domain.Abstractions.Domain;

namespace RandomProduct.Domain.Discounts.Base
{
    public abstract class BaseDiscount: IDiscount
    {
        public string Name { get; }

        protected BaseDiscount(string name)
        {
            Name = name;
        }

        public abstract bool IsDiscountConditionsSatisfied(IBasket basket);

        public abstract float ApplyDiscount(IBasket basket);

        public abstract float CancelDiscount(IBasket basket);
    }
}
