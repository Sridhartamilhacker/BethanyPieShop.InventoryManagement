using BethanyPieShop.InventoryManagement.Domain.Products;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class OrderLine
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public OrderLine(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal GetLineTotal()
    {
        return Product.UnitPrice * Quantity;
    }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("The new quantity must be greaterthan zero.");
        }
        Quantity += quantity;
    }

    public void ChangeQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("The new quantity must be greaterthan zero.");
        }
        Quantity = quantity;
    }
}