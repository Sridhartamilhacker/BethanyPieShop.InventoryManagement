namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public abstract class Delivery
{
    public abstract string DisplayName { get; }
    public abstract decimal CalculateShippingCost();

    public static Delivery ForPickup()
    {
        return new PickupDelivery();
    }

    public static Delivery ForShipping(string shippingAddress)
    {
        return new ShippingDelivery(shippingAddress);
    }
}