using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Domain.Customers;

public class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
    public EmailAddress Email { get; }

    public Customer(string firstName, string lastName, EmailAddress email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("The first name is requred", nameof(firstName));
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("the last name is required",nameof(lastName));
        }
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string GetFullName() => $"{FirstName} {LastName}";
}