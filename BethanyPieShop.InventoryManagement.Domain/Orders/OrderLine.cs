using BethanyPieShop.InventoryManagement.Domain.Products;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class OrderLine
{
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}