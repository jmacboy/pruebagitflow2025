using Inventory.Domain.Abstractions;
using Inventory.Domain.Items;
using Inventory.Domain.Transactions;
using Inventory.Domain.Transactions.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Items.EventHanders
{
    public class UpdateStockWhenTransactionIsCompleted : INotificationHandler<TransactionCompleted>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStockWhenTransactionIsCompleted(IItemRepository itemRepository, IUnitOfWork unitOfWork) {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TransactionCompleted domainEvent, CancellationToken cancellationToken) {
            foreach (var item in domainEvent.Details)
            {
                var itemEntity = await _itemRepository.GetByIdAsync(item.ItemId);
                if (itemEntity == null)
                {
                    continue;
                }
                var factor = domainEvent.TransactionType == TransactionType.Entry ? 1 : -1;

                itemEntity.UpdateStockAndCost(factor * item.Quantity, item.unitaryCost);
                await _itemRepository.UpdateAsync(itemEntity);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}
