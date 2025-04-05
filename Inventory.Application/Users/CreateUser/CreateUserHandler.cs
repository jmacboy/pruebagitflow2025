using Inventory.Domain.Abstractions;
using Inventory.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Users.CreateUser;

internal class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        User user = User.Create(request.UserId, request.FullName);

        await _userRepository.AddAsync(user);

        await _unitOfWork.CommitAsync(cancellationToken);

        return user.Id;
    }
}
