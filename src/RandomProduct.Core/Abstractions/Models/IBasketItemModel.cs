namespace RandomProduct.Core.Abstractions.Models
{
    public interface IBasketItemModel
    {
        string ProductName { get; set; }
        int ProductsCount { get; set; }
        float ItemPrice { get; set; }
    }
}
