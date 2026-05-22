using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Products;
using System.Collections.ObjectModel;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class Order
{
    private readonly List<OrderLine> _lines = [];

    public Customer Customer { get; }
    public DeliveryMethod DeliveryMethod { get; private set; }
    public string ShippingAddress { get; private set; }

    public IReadOnlyCollection<OrderLine> Lines => new ReadOnlyCollection<OrderLine>(_lines);

    public Order(Customer customer, DeliveryMethod deliveryMethod, string shippingAddress = "")
    {
        ArgumentNullException.ThrowIfNull(customer);

        if (deliveryMethod == DeliveryMethod.Shipping && string.IsNullOrWhiteSpace(shippingAddress))
        {
            throw new ArgumentException(
                "A shipping address is required when the delivery method is shipping.",
                nameof(shippingAddress));
        }

        Customer = customer;
        DeliveryMethod = deliveryMethod;
        ShippingAddress = shippingAddress;
    }

    public void AddProduct(Product product, int quantity)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (!product.IsActive)
        {
            throw new InvalidOperationException("Inactive products cannot be added to an order.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentException("The quantity must be greater than zero.");
        }

        var existingLine = _lines.FirstOrDefault(l => l.Product.ProductCode == product.ProductCode);

        if (existingLine is not null)
        {
            existingLine.IncreaseQuantity(quantity);
            return;
        }

        _lines.Add(new OrderLine(product, quantity));
    }

    public void RemoveProduct(string productCode)
    {
        var lineToRemove = _lines.FirstOrDefault(l => l.Product.ProductCode == productCode);

        if (lineToRemove is not null)
        {
            _lines.Remove(lineToRemove);
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