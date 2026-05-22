namespace BethanyPieShop.InventoryManagement.Domain.Products;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public bool IsActive { get; set; }
}