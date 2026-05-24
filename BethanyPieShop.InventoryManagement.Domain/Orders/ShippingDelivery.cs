using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class ShippingDelivery : Delivery
{
    public ShippingAddress ShippingAddress { get; }
    public override string DisplayName => "Shipping";

    public  ShippingDelivery(ShippingAddress shippingAddress)
    {
        ShippingAddress = shippingAddress ??  throw new ArgumentNullException(nameof(shippingAddress));
    }

    public override Money CalculateShippingCost()
    {
        return new Money(5m);
    }
}