namespace RandomProduct.Core.Abstractions.Domain
{
    public interface IDiscount
    {
        string Name { get; }
        bool IsDiscountConditionsSatisfied(IBasket basket);
        void ApplyDiscount(IBasket basket);
    }
}
