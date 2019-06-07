using RandomProduct.Core.Abstractions.Domain;

namespace RandomProduct.Domain
{
    public class Product : IProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
