namespace RandomProduct.Domain.Abstractions.Domain
{
    public interface IDiscount
    {
        string Name { get; }
        bool IsDiscountConditionsSatisfied(IBasket basket);
        float ApplyDiscount(IBasket basket);
        float CancelDiscount(IBasket basket);
    }
}
