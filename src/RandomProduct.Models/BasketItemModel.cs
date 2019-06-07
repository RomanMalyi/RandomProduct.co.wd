using RandomProduct.Core.Abstractions.Models;

namespace RandomProduct.Models
{
    public class BasketItemModel: IBasketItemModel
    {
        public string ProductName { get; set; }
        public int ProductsCount { get; set; }
        public float ItemPrice { get; set; }
    }
}
