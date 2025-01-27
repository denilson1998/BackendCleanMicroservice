using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Persistence.Repositories;

namespace Coupons.UseCases.Authentication.Login
{
    public class LoginHandler(IJwtProvider _jwtProvider) : ICommandHandler<LoginCommand, Result<string>>
    {
        //private readonly IJwtProvider _jwtProvider;

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.email) || string.IsNullOrEmpty(request.password))
            {
                return Result.Invalid(new ValidationError { ErrorMessage = "\"Invalid Credentials\"" });
            };

            string token = _jwtProvider.GenerateJwt(request.email, request.password);

            return token;
        }
    }
}