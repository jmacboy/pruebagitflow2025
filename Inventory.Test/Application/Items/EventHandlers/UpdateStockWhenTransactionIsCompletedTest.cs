using Inventory.Application.Items.EventHanders;
using Inventory.Domain.Abstractions;
using Inventory.Domain.Items;
using Inventory.Domain.Transactions;
using Inventory.Domain.Transactions.Events;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Inventory.Domain.Transactions.Events.TransactionCompleted;

namespace Inventory.Test.Application.Items.EventHandlers
{
    public class UpdateStockWhenTransactionIsCompletedTest
    {
        private readonly Mock<IItemRepository> _itemRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        public UpdateStockWhenTransactionIsCompletedTest()
        {
            _itemRepository = new Mock<IItemRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }
        [Fact]
        public async Task HandleIsValidWithOneItem()
        {
            // Arrange
            Guid itemId1 = Guid.NewGuid();
            string itemName1 = "Item 1";
            Item item1 = new Item(itemId1, itemName1);


            _itemRepository.Setup(x => x.GetByIdAsync(itemId1, false))
                         .ReturnsAsync(item1);


            UpdateStockWhenTransactionIsCompleted eventHandler
                = new UpdateStockWhenTransactionIsCompleted(_itemRepository.Object, _unitOfWork.Object);
            Guid transactionId = Guid.NewGuid();
            var details = new List<TransactionCompletedDetail>
            {
                new TransactionCompletedDetail(itemId1, 10, 10),
            };
            TransactionCompleted transactionCompleted = new TransactionCompleted(transactionId, TransactionType.Entry, details);
            var tcs = new CancellationTokenSource(1000);

            // Act
            await eventHandler.Handle(transactionCompleted, tcs.Token);

            // Assert
            _itemRepository.Verify(x => x.UpdateAsync(It.IsAny<Item>()), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
        [Fact]
        public async Task HandleIsValidWithMultipleItems()
        {
            // Arrange
            Guid itemId1 = Guid.NewGuid();
            string itemName1 = "Item 1";
            Item item1 = new Item(itemId1, itemName1);
            Guid itemId2 = Guid.NewGuid();
            Item item2 = new Item(itemId2, "Item 2");

            _itemRepository.Setup(x => x.GetByIdAsync(itemId1, false))
                         .ReturnsAsync(item1);
            _itemRepository.Setup(x => x.GetByIdAsync(itemId2, false))
                         .ReturnsAsync(item2);

            UpdateStockWhenTransactionIsCompleted eventHandler
                = new UpdateStockWhenTransactionIsCompleted(_itemRepository.Object, _unitOfWork.Object);
            Guid transactionId = Guid.NewGuid();
            var details = new List<TransactionCompletedDetail>
            {
                new TransactionCompletedDetail(itemId1, 10, 10),
                new TransactionCompletedDetail(itemId2, 20, 100)
            };
            TransactionCompleted transactionCompleted = new TransactionCompleted(transactionId, TransactionType.Entry, details);
            var tcs = new CancellationTokenSource(1000);

            // Act
            await eventHandler.Handle(transactionCompleted, tcs.Token);

            // Assert
            _itemRepository.Verify(x => x.UpdateAsync(It.IsAny<Item>()), Times.Exactly(2));
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
        [Fact]
        public async Task HandleIsEmptyWithNull()
        {
            // Arrange
            Guid itemId1 = Guid.NewGuid();
            _itemRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), false))
                                                     .ReturnsAsync((Item?)null);


            UpdateStockWhenTransactionIsCompleted eventHandler
                = new UpdateStockWhenTransactionIsCompleted(_itemRepository.Object, _unitOfWork.Object);
            Guid transactionId = Guid.NewGuid();
            var details = new List<TransactionCompletedDetail>
            {
                new TransactionCompletedDetail(itemId1, 10, 10),
            };
            TransactionCompleted transactionCompleted = new TransactionCompleted(transactionId, TransactionType.Entry, details);
            var tcs = new CancellationTokenSource(1000);

            // Act
            await eventHandler.Handle(transactionCompleted, tcs.Token);

            // Assert
            _itemRepository.Verify(x => x.UpdateAsync(It.IsAny<Item>()), Times.Never);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
