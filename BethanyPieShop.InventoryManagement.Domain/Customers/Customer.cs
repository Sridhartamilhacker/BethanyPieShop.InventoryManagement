namespace BethanyPieShop.InventoryManagement.Domain.Customers;

public class Customer
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =  string.Empty;
    public string Email { get; set; } = string.Empty;

    public string GetFullName() => $"{FirstName} {LastName}";
}