using Ardalis.Result;
using Coupons.Domain.Entities;

namespace Coupons.UseCases.CouponTypes.Create
{
    public record CreateCouponTypeCommand(string description, bool enabled, int userCreated) : Ardalis.SharedKernel.ICommand<Result<CouponType>>;
}