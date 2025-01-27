using Ardalis.Result;
using Ardalis.SharedKernel;
using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Authentication.UseCases.Users.Update
{
    public record UpdateUserCommand(int userId, string email, string password, string name) : ICommand<Result<User>>;
}
