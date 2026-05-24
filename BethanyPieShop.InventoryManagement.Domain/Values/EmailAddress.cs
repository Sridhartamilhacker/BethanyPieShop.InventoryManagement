namespace BethanyPieShop.InventoryManagement.Domain.Values;

public sealed class EmailAddress
{
    private string _value = string.Empty;
    public string Value
    {
        get => _value;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The email address is required",nameof(value));
            }

            if (!value.Contains("@"))
            {
                throw new ArgumentException("The email address must contain a @ character", nameof(value));
            }
            _value = value;
        }
    }

    public EmailAddress(string value)
    {
        Value = value;
    }

}