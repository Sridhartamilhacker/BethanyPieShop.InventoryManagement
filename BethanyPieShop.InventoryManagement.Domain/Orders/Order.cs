using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Products;
using System.Collections.ObjectModel;
using BethanyPieShop.InventoryManagement.Domain.Pricing;
using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class Order
{
    private readonly List<OrderLine> _lines = [];
    public Customer Customer { get; }
    public Delivery Delivery { get; }
    public IReadOnlyCollection<OrderLine> Lines => new ReadOnlyCollection<OrderLine>(_lines);
    private Order(Customer customer, Delivery delivery)
    {
        Customer = customer ??  throw new ArgumentNullException(nameof(customer));
        Delivery = delivery ?? throw new ArgumentNullException(nameof(delivery));
    }

    public static Order CreatePickupOrder(Customer customer)
    {
        return new Order(customer, Delivery.ForPickup());
    }

    public static Order CreateShippingOrder(Customer customer, ShippingAddress shippingAddress)
    {
        return new Order(customer, Delivery.ForShipping(shippingAddress));
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
        Delivery.ForPickup();
    }
    public void ChangeToShipping(ShippingAddress shippingAddress)
    {
        Delivery.ForShipping(shippingAddress);
    }
    public Money CalculateSubtotal()
    {
        return _lines.Select( line => line.GetLineTotal()).
            Aggregate(new Money(0),(current,next) => current + next);
    }
    public Money CalculateTotal()
    {
        return CalculateSubtotal() + Delivery.CalculateShippingCost();
    }

    public Money CalculateTotal(IDiscountPolicy discountPolicy)
    {
        ArgumentNullException.ThrowIfNull(discountPolicy);
        var totalBeforeDiscount = CalculateTotal();
        return discountPolicy.ApplyDiscount(totalBeforeDiscount);
    }
}