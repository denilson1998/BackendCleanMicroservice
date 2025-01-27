using FastEndpoints;
using FluentValidation;

namespace Coupons.Api.Endpoints.Authorizers
{
    public class CreateAuthorizerValidator : Validator<CreateAuthorizerRequest>
    {
        public CreateAuthorizerValidator()
        {
            RuleFor(x => x.MaxAmount)
                .NotEmpty()
                .WithMessage("MaxAmount is required!")
                .GreaterThan(0)
                .WithMessage("Number must be greatter than 0");
        }
    }
}
