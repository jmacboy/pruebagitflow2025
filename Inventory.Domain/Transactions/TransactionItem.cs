using Inventory.Domain.Abstractions;
using Inventory.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Transactions;

public class TransactionItem : Entity
{
    public Guid  ItemId { get; private set; }
    public CostValue UnitaryCost { get; private set; }
    public CostValue SubTotal { get; private set; }

    public TransactionQuantity Quantity { get; private set; }

    public TransactionItem(Guid itemId, int quantity, decimal unitaryCost) : base(Guid.NewGuid())
    {
        ItemId = itemId;
        Quantity = quantity;
        UnitaryCost = unitaryCost;
        SubTotal = Quantity * UnitaryCost;
    }

    internal void Update(int quantity, decimal unitaryCost)
    {
        Quantity = quantity;
        UnitaryCost = unitaryCost;
        SubTotal = Quantity * UnitaryCost;
    }

    //Need for EF Core
    private TransactionItem() { }
}
