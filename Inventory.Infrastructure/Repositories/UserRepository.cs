using Inventory.Domain.Users;
using Inventory.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DomainDbContext _dbContext;

    public UserRepository(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User entity)
    {
        await _dbContext.User.AddAsync(entity);
    }

    public async Task<User?> GetByIdAsync(Guid id, bool readOnly = false)
    {
        if (readOnly)
        {
            return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        else
        {
            return await _dbContext.User.FindAsync(id);
        }
    }
}
