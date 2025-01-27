using Ardalis.Result;
using Coupons.Domain.Entities;

namespace Coupons.UseCases.Authorizers.Create
{
    public record CreateAuthorizerCommand(decimal maxAmount, bool enabled, int userCreated) : Ardalis.SharedKernel.ICommand<Result<CouponAuthorizer>>;
}