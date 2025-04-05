using Inventory.Application.Items.GetItems;
using Inventory.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Handlers.Item;

internal class GetItemsHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDto>>
{
    private readonly StoredDbContext _dbContext;

    public GetItemsHandler(StoredDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Item.AsNoTracking().
            Select(i => new ItemDto()
            {
                Id = i.Id,
                ItemName = i.ItemName
            }).
            ToListAsync(cancellationToken);
    }
}
