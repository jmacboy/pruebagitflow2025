using Inventory.Domain.Abstractions;
using Inventory.Domain.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Transactions.CompleteTransaction;

internal class CompleteTransactionHandler : IRequestHandler<CompleteTransactionCommand, bool>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteTransactionHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork) {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CompleteTransactionCommand request, CancellationToken cancellationToken) {
        var transaction = await _transactionRepository.GetByIdAsync(request.TransactionId);

        if (transaction == null)
        {
            throw new InvalidOperationException("Transaction not found");
        }

        transaction.Complete();

        await _unitOfWork.CommitAsync(cancellationToken);

        return true;

    }
}
