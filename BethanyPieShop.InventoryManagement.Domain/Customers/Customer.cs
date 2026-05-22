namespace BethanyPieShop.InventoryManagement.Domain.Customers;

public class Customer
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =  string.Empty;
    public string Email { get; set; } = string.Empty;

    public Customer(string firstName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("The first name is requred", nameof(firstName));
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("the last name is required",nameof(lastName));
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("The email is required", nameof(email));
        }
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string GetFullName() => $"{FirstName} {LastName}";
}