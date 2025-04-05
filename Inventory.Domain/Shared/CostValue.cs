using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Shared;

public record CostValue
{
    public decimal Value { get; init; }

    public CostValue(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Cost value cannot be negative", nameof(value));
        }

        Value = value;
    }

    public static implicit operator decimal(CostValue cost)
    {
        return cost == null ? 0 : cost.Value;
    }

    public static implicit operator CostValue(decimal a)
    {
        return new CostValue(a);
    }
}
