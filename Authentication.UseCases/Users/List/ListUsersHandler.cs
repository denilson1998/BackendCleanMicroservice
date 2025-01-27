using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.UseCases.Users.List
{
    public class ListUsersHandler(IUserRepository _userRespository) : IQueryHandler<ListUsersQuery, Result<IEnumerable<User>>>
    {
        public async Task<Result<IEnumerable<User>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRespository.ListAsync();

            return Result.Success(result); 
        }
    }
}
