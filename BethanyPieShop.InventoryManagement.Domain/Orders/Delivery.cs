using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public abstract class Delivery
{
    public abstract string DisplayName { get; }
    public abstract Money CalculateShippingCost();

    public static Delivery ForPickup()
    {
        return new PickupDelivery();
    }

    public static Delivery ForShipping(ShippingAddress shippingAddress)
    {
        return new ShippingDelivery(shippingAddress);
    }
}