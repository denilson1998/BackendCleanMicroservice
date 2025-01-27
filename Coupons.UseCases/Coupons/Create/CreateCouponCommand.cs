using Ardalis.Result;

using Coupons.Domain.Entities;

namespace Coupons.UseCases.Coupons.Create
{
    public record CreateCouponCommand(
        decimal amount, 
        string type, 
        decimal percent,
        string code,
        DateTime expirationDate,
        bool isUsed,
        string state,
        int userCreated,
        string reference,
        int couponConfigurationId,
        int couponAuthorizerId,
        CouponAuthorizer couponAuthorizer,
        CouponConfiguration couponConfiguration) : Ardalis.SharedKernel.ICommand<Result<Coupon>>;
}