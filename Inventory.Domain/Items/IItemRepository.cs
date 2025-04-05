using Inventory.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Items;

public interface IItemRepository : IRepository<Item>
{
    Task UpdateAsync(Item item);
    Task DeleteAsync(Guid id);
}
