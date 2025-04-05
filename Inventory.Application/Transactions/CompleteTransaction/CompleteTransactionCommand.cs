using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Transactions.CompleteTransaction
{
    public record CompleteTransactionCommand(Guid TransactionId) : IRequest<bool>;
}
