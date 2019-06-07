using RandomProduct.Core.Abstractions.Domain;

namespace RandomProduct.Core.Abstractions.Services
{
    public interface IDiscountManager
    {
        void ApplyDiscounts(IBasket basket);
    }
}
