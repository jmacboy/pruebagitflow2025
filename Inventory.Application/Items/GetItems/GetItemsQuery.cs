using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Items.GetItems;

public record GetItemsQuery(string SearchTerm) : IRequest<IEnumerable<ItemDto>>;
