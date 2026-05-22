using BethanyPieShop.InventoryManagement.Domain.Customers;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class Order
{
    public Customer Customer { get; set; } = new();
    public List<OrderLine> Lines { get; set; } = [];
    public DeliveryMethod DeliveryMethod { get; set; } = DeliveryMethod.PickUp;
    public string ShippingAddress { get; set; } = string.Empty;

}