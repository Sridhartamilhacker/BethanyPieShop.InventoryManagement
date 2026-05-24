using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public sealed class LocalDelivery : Delivery
{
    public ShippingAddress ShippingAddress { get; }
    public override string DisplayName => "Shipping";

    public  LocalDelivery(ShippingAddress shippingAddress)
    {
        ShippingAddress = shippingAddress ??  throw new ArgumentNullException(nameof(shippingAddress));
    }

    public override Money CalculateShippingCost(Money subTotal)
    {
        return subTotal.Amount >= 50m ? new Money(0m) : new Money(2.5m);
    }
}