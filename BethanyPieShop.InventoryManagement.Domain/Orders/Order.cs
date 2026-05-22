using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Products;
using System.Collections.ObjectModel;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class Order
{
    private readonly List<OrderLine> _lines = [];
    public Customer Customer { get; set; } = new();
    public DeliveryMethod DeliveryMethod { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;

    public IReadOnlyCollection<OrderLine> Lines => new ReadOnlyCollection<OrderLine>(_lines);

    public void AddProduct(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (!product.IsActive)
        {
            throw new InvalidOperationException("Inactive products cannot be added to an order");
        }
        if(quantity <= 0)
        {
            throw new ArgumentException("The Product quantity must be greater than zero.");
        }
        var exitingLine = _lines.FirstOrDefault(l => l.Product.ProductCode == product.ProductCode);
        if(exitingLine is not null)
        {
            exitingLine.IncreaseQuantity(quantity);
            return;
        }

        _lines.Add(new OrderLine(product, quantity));
    }

    public void RemoveProduct(string code)
    {
        ArgumentNullException.ThrowIfNull(code);
        var exitingLine = _lines.FirstOrDefault(l => l.Product.ProductCode == code);
        if(exitingLine is not null)
        {
            _lines.Remove(exitingLine);
        }
    }
    public decimal CalculateSubtotal()
    {
        return _lines.Sum(line => line.GetLineTotal());
    }

    public decimal CalculateShippingCost()
    {
        if (DeliveryMethod == DeliveryMethod.Shipping)
        {
            return 5m;
        }
        return 0m;
    }

    public decimal CalculateTotal()
    {
           return CalculateSubtotal() + CalculateShippingCost();
    }
}