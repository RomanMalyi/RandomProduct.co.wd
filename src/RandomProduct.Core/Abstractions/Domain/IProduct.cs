namespace RandomProduct.Core.Abstractions.Domain
{
    public interface IProduct
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        float Price { get; set; }
    }
}
