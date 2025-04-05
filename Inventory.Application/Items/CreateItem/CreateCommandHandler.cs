using Inventory.Domain.Abstractions;
using Inventory.Domain.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Items.CreateItem
{
    internal class CreateCommandHandler : IRequestHandler<CreateItemCommand, Guid>
    {
        private readonly IItemFactory _itemFactory;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IItemFactory itemFactory,
            IItemRepository itemRepository,
            IUnitOfWork unitOfWork) {
            _itemFactory = itemFactory;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken) {
            var item = _itemFactory.Create(request.Id, request.ItemName);

            await _itemRepository.AddAsync(item);

            await _unitOfWork.CommitAsync(cancellationToken);

            return item.Id;
        }
    }
}
