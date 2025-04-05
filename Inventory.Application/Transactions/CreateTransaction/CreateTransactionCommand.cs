using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Transactions.CreateTransaction
{
    public record CreateTransactionCommand(Guid UserCreatorId, string Type, ICollection<CreateTransacionItemCommand> Items) : IRequest<Guid>;

    public record CreateTransacionItemCommand(Guid ItemId, int Quantity, decimal UnitaryCost);
}
