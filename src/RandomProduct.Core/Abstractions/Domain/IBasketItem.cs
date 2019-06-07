namespace RandomProduct.Core.Abstractions.Domain
{
    public interface IBasketItem
    {
        string Id { get; set; }
        string Name { get; set; }
        float Price { get; set; }
        int ProductsCount { get; set; }
    }
}
