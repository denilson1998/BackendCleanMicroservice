using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.UserAggregate.Entities;

namespace Authentication.UseCases.Users.Get
{
    public record GetUserQuery(int UserId) : IQuery<Result<User>>;
}