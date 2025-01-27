using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.UseCases.Users.Update
{
    public class UpdateUserHandler(IUserRepository _userRepository) : ICommandHandler<UpdateUserCommand, Result<User>>
    {
        public async Task<Result<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = _userRepository.GetUserByIdAsync(request.userId);

            if (user == null )
            {
                return Result.NotFound();
            }

            user.Result.UpdateUser(request.name, request.email, request.password);

            await _userRepository.UpdateUserAsync(user.Result);

            return Result.Success(user.Result);

        }
    }
}
