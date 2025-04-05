using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Transactions;

public interface ITransactionFactory
{
    Transaction CreateEntryTransaction(Guid userCreatorId);
    Transaction CreateExitTransaction(Guid userCreatorId);
}
