namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class ShippingDelivery : Delivery
{
    public string ShippingAddress { get; }
    public override string DisplayName => "Shipping";

    public  ShippingDelivery(string shippingAddress)
    {
        if (string.IsNullOrWhiteSpace(shippingAddress))
        {
            throw new ArgumentException("The Shipping Address is required",nameof(shippingAddress));
        }

        ShippingAddress = shippingAddress;
    }

    public override decimal CalculateShippingCost()
    {
        return 5m;
    }
}