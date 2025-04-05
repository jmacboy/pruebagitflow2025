using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Transactions;

public record TransactionQuantity
{
    public int Value { get; init; }

    public TransactionQuantity(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Quantity value must be greater than zero", nameof(value));
        }
        Value = value;
    }

    public static implicit operator int(TransactionQuantity quantity)
    {
        return quantity == null ? 0 : quantity.Value;
    }

    public static implicit operator TransactionQuantity(int a)
    {
        return new TransactionQuantity(a);
    }
}
