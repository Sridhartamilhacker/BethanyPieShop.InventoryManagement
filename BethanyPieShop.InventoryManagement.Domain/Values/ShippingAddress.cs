namespace BethanyPieShop.InventoryManagement.Domain.Values;

public sealed record ShippingAddress
{
    private string _street = string.Empty;
    private string _city = string.Empty;
    private string _postalCode = string.Empty;

    public string Street
    {
        get => _street;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A Street is required", nameof(value));
            }
            _street = value;
        }
    }
    public string City
    {
        get => _city;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A City is required", nameof(value));
            }
            _city = value;
        }
    }
    public string PostalCode
    {
        get => _postalCode;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A PostalCode is required", nameof(value));
            }
            _postalCode = value;
        }
    }

    public ShippingAddress(string street, string city, string postalCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }
}