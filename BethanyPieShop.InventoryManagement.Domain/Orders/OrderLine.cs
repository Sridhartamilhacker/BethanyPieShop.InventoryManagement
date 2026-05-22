using BethanyPieShop.InventoryManagement.Domain.Products;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class OrderLine
{
    public Product Product { get;}
    public int Quantity { get; private set; }

    public OrderLine(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (!product.IsActive)
        {
            throw new ArgumentException("Inactive products can't be added to order line", nameof(product));
        }
        if(quantity <= 0)
        {
            throw new ArgumentException("The quantiry mus be greater than zero.", nameof(quantity));
        }
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