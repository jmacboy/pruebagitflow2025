using Inventory.Application.Transactions.GetTransaccionById;
using Inventory.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Handlers.Transaction;

internal class GetTransactionByIdHandler : IRequestHandler<GetTransaccionByIdQuery, TransactionDto>
{
    private readonly StoredDbContext _dbContext;

    public GetTransactionByIdHandler(StoredDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TransactionDto?> Handle(GetTransaccionByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.TransactionId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request.TransactionId));
        }

        var transaction = await _dbContext.Transaction.AsNoTracking()
            .Where(t => t.Id == request.TransactionId)
            .Select(t => new TransactionDto()
            {
                Id = t.Id,
                CreationDate = t.CreationDate,
                CompletedDate = t.CompletedDate ?? default,
                CancelDate = t.CancelDate ?? default,
                Type = t.TransactionType,
                TotalCost = t.TotalCost
            })
            .FirstOrDefaultAsync(cancellationToken);

        return transaction;
    }
}
