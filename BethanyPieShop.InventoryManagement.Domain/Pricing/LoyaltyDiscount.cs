using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Pricing;

public class LoyaltyDiscount : IDiscountPolicy, IDiscountDescriber
{
    private readonly decimal _percentage;

    public LoyaltyDiscount(decimal percentage)
    {
        if(percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage),"percentage must be between 0 and 100");
        }
        _percentage = percentage;
    }
    public Money ApplyDiscount(Money totalPrice)
    {
        var discount = totalPrice.Amount * (_percentage / 100);
        return new Money(totalPrice.Amount - discount);
    }

    public string DescribeDiscount()
    {
        return $"Loyalty discount for {_percentage:0.##}% off";
    }
}