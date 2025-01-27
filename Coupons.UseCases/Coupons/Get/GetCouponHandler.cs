using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Specifications.Coupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.Counpons.Get
{
    public class GetCouponHandler(IReadRepository<Coupon> _couponRepository) : IQueryHandler<GetCouponQuery, Result<Coupon>>
    {
        public async Task<Result<Coupon>> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetByIdSpec(request.couponId);

            var coupon = await _couponRepository.FirstOrDefaultAsync(specification, cancellationToken);

            if (coupon is null) return Result.NotFound("Coupon not found");

            return Result.Success(coupon);
        }
    }
}
