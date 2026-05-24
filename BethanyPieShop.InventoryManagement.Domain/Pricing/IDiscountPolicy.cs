namespace BethanyPieShop.InventoryManagement.Domain.Pricing;

public interface IDiscountPolicy
{
    decimal ApplyDiscount(decimal totalPrice);

}