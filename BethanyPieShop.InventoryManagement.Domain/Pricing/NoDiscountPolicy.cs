namespace BethanyPieShop.InventoryManagement.Domain.Pricing;

public class NoDiscountPolicy : IDiscountPolicy
{
    public decimal ApplyDiscount(decimal totalPrice)
    {
        return totalPrice;
    }
}