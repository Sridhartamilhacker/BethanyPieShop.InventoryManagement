using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Pricing;

public class NoDiscountPolicy : IDiscountPolicy
{
    public Money ApplyDiscount(Money totalPrice)
    {
        return totalPrice;
    }
}