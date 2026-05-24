namespace BethanyPieShop.InventoryManagement.Domain.Values;

public sealed record Money
{
    private decimal _amount;
    public decimal Amount
    {
        get => _amount;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),"The amount cannot be negative");
            }
            _amount = value;
        }
    }
    public Money(decimal amount)
    {
        Amount = amount;
    }

    public static Money operator +(Money left, Money right)
    {
        return new Money(left.Amount + right.Amount);
    }

    public static Money operator -(Money left, Money right)
    {
        var result = left.Amount - right.Amount;
        return result <= 0 ? new Money(0) : new Money(result);
    }

    public static Money operator *(Money left, int multiplier)
    {
        if (multiplier < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(multiplier),"The multiplier cannot be negative");
        }
        return new Money(left.Amount * multiplier);
    }

    public static Money operator *(Money left, decimal multiplier)
    {
        if (multiplier < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(multiplier),"The multiplier cannot be negative");
        }
        return new Money(left.Amount * multiplier);
    }
}