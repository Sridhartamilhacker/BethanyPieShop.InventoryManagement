namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class DeliveryDetails
{
    public DeliveryMethod DeliveryMethod { get; set; }
    public string ShippingAddress { get; private set; }

    private DeliveryDetails(DeliveryMethod deliveryMethod, string shippingAddress)
    {
        if (deliveryMethod == DeliveryMethod.Shipping && string.IsNullOrWhiteSpace(shippingAddress))
        {
            throw new ArgumentException(
                "A Shipping address is required when delivery method is shipping",
                nameof(shippingAddress));
        }
        DeliveryMethod = deliveryMethod;
        ShippingAddress = shippingAddress;
    }

    public static DeliveryDetails CreateForPickup()
    {
        return new DeliveryDetails(DeliveryMethod.PickUp, string.Empty);
    }

    public static DeliveryDetails CreateForShipping(string shippingAddress)
    {
        return new DeliveryDetails(DeliveryMethod.Shipping, shippingAddress);
    }

    public void ChangeToPickup()
    {
        DeliveryMethod = DeliveryMethod.PickUp;
        ShippingAddress = string.Empty;
    }

    public void ChangeToShipping(string shippingAddress)
    {
        if (string.IsNullOrWhiteSpace(shippingAddress))
        {
            throw new ArgumentException("Shipping address cannot be empty.", nameof(shippingAddress));
        }
        DeliveryMethod = DeliveryMethod.Shipping;
        ShippingAddress = shippingAddress;
    }
    public decimal CalculateShippingCost()
    {
        return DeliveryMethod == DeliveryMethod.Shipping ? 5m : 0m;
    }
}