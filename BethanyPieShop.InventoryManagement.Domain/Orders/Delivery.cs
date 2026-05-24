using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public abstract class Delivery
{
    public abstract string DisplayName { get; }
    public abstract Money CalculateShippingCost(Money shippingCost);

    public static Delivery ForPickup()
    {
        return new PickupDelivery();
    }

    public static Delivery ForShipping(ShippingAddress shippingAddress)
    {
        return new ShippingDelivery(shippingAddress);
    }

    public static Delivery ForLocalDelivery(ShippingAddress shippingAddress)
    {
        return new LocalDelivery(shippingAddress);
    }
}