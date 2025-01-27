using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.UseCases.Users.Create
{
    public class CreateUserHandler(IUserRepository _userRepository) : ICommandHandler<CreateUserCommand, Result<User>>
    {
        public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User(request.Name, request.Email, request.Password, request.EmailConfirmed);

            var userCreated = await _userRepository.CreateUserAsync(newUser);

            return userCreated;

        }
    }
}
