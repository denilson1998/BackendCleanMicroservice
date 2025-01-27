using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.UseCases.Users.Get
{
    public class GetUserHandler(IUserRepository _userRepository) : IQueryHandler<GetUserQuery, Result<User>>
    {
        public async Task<Result<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetUserByIdAsync(request.UserId);

            if (result == null) return Result.NotFound();

            return Result.Success(result);
        }
    }
}
