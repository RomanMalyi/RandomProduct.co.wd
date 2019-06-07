using System.Collections.Generic;
using RandomProduct.Domain.Abstractions.Domain;

namespace RandomProduct.Domain.Abstractions.Services
{
    public interface IDiscountManager
    {
        void ApplyDiscounts(IBasket basket);
        void CancelDiscounts(IList<string> discounts, IBasket basket);
    }
}
