using Inventory.Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.StoredModel
{
    internal class StoredDbContext : DbContext
    {
        public DbSet<ItemStoredModel> Item { get; set; }
        public DbSet<TransactionStoredModel> Transaction { get; set; }
        public DbSet<TransactionItemStoredModel> TransactionItem { get; set; }
        public DbSet<UserStoredModel> User { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {

        }

    }
}
