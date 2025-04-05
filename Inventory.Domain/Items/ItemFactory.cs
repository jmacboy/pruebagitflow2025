using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Items;

public class ItemFactory : IItemFactory
{
    public Item Create(Guid id, string itemName)
    {
        if(id == Guid.Empty)
        {
            throw new ArgumentException("Id is required", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name is required", nameof(itemName));
        }

        return new Item(id, itemName);

    }
}
