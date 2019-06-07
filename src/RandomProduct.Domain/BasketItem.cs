using RandomProduct.Core.Abstractions.Domain;

namespace RandomProduct.Domain
{
    public class BasketItem : IBasketItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int ProductsCount { get; set; }
    }
}
