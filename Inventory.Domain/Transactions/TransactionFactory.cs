using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Transactions;

public class TransactionFactory : ITransactionFactory
{
    public Transaction CreateEntryTransaction(Guid userCreatorId)
    {
        if(userCreatorId == Guid.Empty)
        {
            throw new ArgumentException("User creator id is required");
        }
        var transaction = new Transaction(userCreatorId, TransactionType.Entry);

        

        return transaction;
    }

    public Transaction CreateExitTransaction(Guid userCreatorId)
    {
        if (userCreatorId == Guid.Empty)
        {
            throw new ArgumentException("User creator id is required");
        }
        var transaction = new Transaction(userCreatorId, TransactionType.Exit);

        return transaction;
    }
}
