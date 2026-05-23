namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class PickupDelivery : Delivery
{
    public override string DisplayName => "Pickup";

    public override decimal CalculateShippingCost()
    {
        return 0m;
    }
}

