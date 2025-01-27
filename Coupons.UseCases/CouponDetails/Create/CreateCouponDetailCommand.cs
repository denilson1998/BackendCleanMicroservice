using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.CouponDetails.Create
{
    public record CreateCouponDetailCommand(
        decimal totalDiscount,
        int referenceNumber,
        string referenceType,
        int userCreated,
        int couponId,
        Coupon coupon
        ) : ICommand<Result<CouponDetail>>;
}
