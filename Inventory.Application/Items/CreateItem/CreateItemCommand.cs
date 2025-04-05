using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Items.CreateItem
{
    public record CreateItemCommand(Guid Id, string ItemName) : IRequest<Guid>;

}
