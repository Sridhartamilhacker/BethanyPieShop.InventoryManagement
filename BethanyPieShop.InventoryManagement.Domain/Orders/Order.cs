using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Products;
using System.Collections.ObjectModel;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class Order
{
    private readonly List<OrderLine> _lines = [];
    public Customer Customer { get; }
    public DeliveryDetails DeliveryDetails { get; }
    public IReadOnlyCollection<OrderLine> Lines => new ReadOnlyCollection<OrderLine>(_lines);
    private Order(Customer customer, DeliveryDetails deliveryDetails)
    {
        Customer = customer ??  throw new ArgumentNullException(nameof(customer));
        DeliveryDetails = deliveryDetails ?? throw new ArgumentNullException(nameof(deliveryDetails));
    }

    public static Order CreatePickupOrder(Customer customer)
    {
        return new Order(customer, DeliveryDetails.CreateForPickup());
    }

    public static Order CreateShippingOrder(Customer customer, string shippingAddress)
    {
        return new Order(customer, DeliveryDetails.CreateForShipping(shippingAddress));
    }

    public void AddProduct(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);

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
    public void ChangeProductQuantity(string productCode, int newQuantity)
    {
        var existingLine = _lines.FirstOrDefault(l => l.Product.ProductCode == productCode);
        if (existingLine is null)
        {
            throw new InvalidOperationException("Product code does not exist.");
        }
        existingLine.ChangeQuantity(newQuantity);
    }
    public int GetProductQuantity(string productCode)
    {
        var existingLine = _lines.FirstOrDefault(l => l.Product.ProductCode == productCode);
        return existingLine?.Quantity ?? 0;
    }
    public bool ContainsProduct(string productCode)
    {
        return _lines.Any(l => l.Product.ProductCode == productCode);
    }
    public void RemoveProduct(string productCode)
    {
        var lineToRemove = _lines.FirstOrDefault(l => l.Product.ProductCode == productCode);

        if (lineToRemove is not null)
        {
            _lines.Remove(lineToRemove);
        }
    }
    public void ChangeToPickup()
    {
        DeliveryDetails.ChangeToPickup();
    }
    public void ChangeToShipping(string shippingAddress)
    {
        DeliveryDetails.ChangeToShipping(shippingAddress);
    }
    public decimal CalculateSubtotal()
    {
        return _lines.Sum(line => line.GetLineTotal());
    }
    public decimal CalculateTotal()
    {
        return CalculateSubtotal() + DeliveryDetails.CalculateShippingCost();
    }
}