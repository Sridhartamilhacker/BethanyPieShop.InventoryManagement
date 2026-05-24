using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class PickupDelivery : Delivery
{
    public override string DisplayName => "Pickup";

    public override Money CalculateShippingCost(Money subTotal)
    {
        return new Money(0m);
    }
}

