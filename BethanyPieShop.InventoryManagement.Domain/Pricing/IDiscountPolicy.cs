using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Pricing;

public interface IDiscountPolicy
{
    Money ApplyDiscount(Money totalPrice);

}