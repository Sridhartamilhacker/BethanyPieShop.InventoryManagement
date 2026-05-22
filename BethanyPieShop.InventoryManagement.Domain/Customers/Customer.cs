namespace BethanyPieShop.InventoryManagement.Domain.Customers;

public class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get;}

    public Customer(string firstName, string lastName) : this(firstName, lastName, "unknown@bathenypieshop.com")
    {

    }

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