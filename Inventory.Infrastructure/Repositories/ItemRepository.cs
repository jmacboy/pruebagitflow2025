using Inventory.Domain.Items;
using Inventory.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private readonly DomainDbContext _dbContext;

        public ItemRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Item entity)
        {
            await _dbContext.Item.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Item.Remove(obj);
        }

        public async Task<Item?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Item.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Item.FindAsync(id);
            }
        }


        public Task UpdateAsync(Item item)
        {
            _dbContext.Item.Update(item);

            return Task.CompletedTask;

        }
    }
}
