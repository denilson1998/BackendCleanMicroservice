using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Coupons.UseCases.Authentication.Login
{
    public record LoginCommand(string email, string password) : ICommand<Result<string>>;
}