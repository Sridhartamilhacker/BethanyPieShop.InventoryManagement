using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Products;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public Money UnitPrice { get; private set; }
    public bool IsActive { get; private set; }

    public Product(string productCode, string name, Money unitPrice)
    {
        if (string.IsNullOrWhiteSpace(productCode))
        {
            throw new ArgumentException("A product code is required",nameof(productCode));
        }
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A Product name is required", nameof(name));
        }
        ProductCode = productCode;
        Name = name;
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
        IsActive = true;
        
    }

    public void ChangePrice(decimal newPrice)
    {
        UnitPrice = new Money(newPrice);
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}