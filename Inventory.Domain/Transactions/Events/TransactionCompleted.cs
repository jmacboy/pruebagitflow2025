using Inventory.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Transactions.Events;

public record TransactionCompleted : DomainEvent
{
    public Guid TransactionId { get; init; }
    public TransactionType TransactionType { get; init; }

    public ICollection<TransactionCompletedDetail> Details { get; init; }

    public TransactionCompleted(Guid transactionId, 
        TransactionType type, 
        ICollection<TransactionCompletedDetail> details)
    {
        TransactionId = transactionId;
        TransactionType = type;
        Details = details;
    }

    public record TransactionCompletedDetail(Guid ItemId, int Quantity, decimal unitaryCost);
}
