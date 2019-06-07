using System;
using System.Linq;
using RandomProduct.Domain.Abstractions.Domain;
using RandomProduct.Domain.Discounts.Base;

namespace RandomProduct.Domain.Discounts
{
    public class LargeBowlOfTrifleDiscount: BaseDiscount
    {
        private const string ProductId = "RP-1TB-EITB";
        private readonly Product _bonusProduct;

        public LargeBowlOfTrifleDiscount() : base("Buy a Large bowl of Trifle and get a free Paper Mask.")
        {
            _bonusProduct = new Product()
            {
                Id = "RP-RPM-FITB",
                Name = "Paper Mask",
                Description = "Randomly selected paper mask.",
                Price = 0.30f
            };
        }

        public override bool IsDiscountConditionsSatisfied(IBasket basket)
        {
            return basket.Items.Any(i => i.Id == ProductId && i.ProductsCount > 0);
        }

        public override float ApplyDiscount(IBasket basket)
        {
            var discountedItemCount = basket.Items.FirstOrDefault(i => i.Id == ProductId).ProductsCount;

            var existingItem = basket.Items.FirstOrDefault(i => i.Id == _bonusProduct.Id);
            if (existingItem != null)
            {
                existingItem.ProductsCount += discountedItemCount;
            }
            else
            {
                basket.AddBonusProduct(_bonusProduct, discountedItemCount);
            }

            return basket.GrandTotalPrice;
        }

        public override float CancelDiscount(IBasket basket)
        {
            var discountedItemCount = basket.Items.FirstOrDefault(i => i.Id == ProductId)?.ProductsCount;
            if (discountedItemCount == null)
                throw new ArgumentException($"{Name}.Item with id: {ProductId} was not found.");

            var existingItem = basket.Items.FirstOrDefault(i => i.Id == _bonusProduct.Id);
            if (existingItem == null)
                throw new ArgumentException($"{Name}.Item with id: {_bonusProduct.Id} was not found.");

            if (existingItem.ProductsCount > discountedItemCount)
            {
                existingItem.ProductsCount -= discountedItemCount.Value;
            }
            else
            {
                basket.RemoveBonusProduct(_bonusProduct.Id, discountedItemCount.Value);
            }

            return basket.GrandTotalPrice;
        }
    }
}
