using BethanyPieShop.InventoryManagement.Domain.Orders;

namespace BethanyPieShop.InventoryManagement.Domain.Pricing;

public class OrderPricingService
{
    public decimal CalculateSubtotal(Order order)
    {
        return order.Lines.Sum(line => line.Product.UnitPrice * line.Quantity);
    }

    public decimal CalculateShippingCost(Order order)
    {
        if (order.DeliveryMethod == DeliveryMethod.PickUp)
        {
            return 0m;
        }

        var itemCount = order.Lines.Sum(line => line.Quantity);
        return 4.95m + (0.75m * itemCount);
    }

    public decimal CalculateTotal(Order order)
    {
        var subtotal = CalculateSubtotal(order);
        var shippingCost = CalculateShippingCost(order);

        return subtotal + shippingCost;
    }
}