using Ardalis.Result;
using Coupons.Domain.Entities;

namespace Coupons.UseCases.CouponConfigurations.Create
{
    public record CreateCouponConfigurationCommand(
        decimal sellAmount,
        bool credit,
        bool cash,
        string category,
        string subCategory,
        string brand,
        string product,
        string expenseAccount,
        bool applyOverDiscount,
        bool applyOverBundle,
        bool isGeneric,
        int userCreated,
        int couponTypeId) : Ardalis.SharedKernel.ICommand<Result<CouponConfiguration>>;
}