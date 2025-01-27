using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.UseCases.Users.List
{
    public record ListUsersQuery() : IQuery<Result<IEnumerable<User>>>;
}
