using Ardalis.Result;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.UseCases.Users.Create
{
    public record CreateUserCommand(string Name, string Email, string Password, string EmailConfirmed) : Ardalis.SharedKernel.ICommand<Result<User>>;
}
