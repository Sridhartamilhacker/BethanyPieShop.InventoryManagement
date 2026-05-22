namespace BethanyPieShop.InventoryManagement.Domain.Products;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public decimal UnitPrice { get; private set; }
    public bool IsActive { get; private set; }

    public Product(string productCode, string name, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(productCode))
        {
            throw new ArgumentException("A product code is required",nameof(productCode));
        }
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A Product name is required", nameof(name));
        }
        if(unitPrice <= 0)
        {
            throw new ArgumentException("The product price must be greater than zero", nameof(unitPrice));
        }
        ProductCode = productCode;
        Name = name;
        UnitPrice = unitPrice;
        IsActive = true;
        
    }

    public void ChangePrice(decimal newPrice)
    {
        if(newPrice <= 0)
        {
            throw new ArgumentException("A product price must be greater than zero.");
        }
        UnitPrice = newPrice;
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