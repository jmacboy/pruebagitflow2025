using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Items;

public interface IItemFactory
{
    Item Create(Guid id, string itemName);
}
