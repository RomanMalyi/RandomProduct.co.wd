namespace RandomProduct.Models
{
    public interface IBaseDiscount
    {
        string Name { get; }
        bool IsDiscountConditionsSatisfied(Basket basket);
        void ApplyDiscount(Basket basket);
    }
}
