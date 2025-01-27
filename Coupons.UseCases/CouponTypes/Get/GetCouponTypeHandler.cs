using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;
using Coupons.Domain.Specifications.CouponTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.CouponTypes.Get
{
    public class GetCouponTypeHandler(IReadRepository<CouponType> _couponTypeRepository) : IQueryHandler<GetCouponTypeQuery, Result<CouponType>>
    {
        public async Task<Result<CouponType>> Handle(GetCouponTypeQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetByIdSpec(request.couponTypeId);

            var couponType = await _couponTypeRepository.FirstOrDefaultAsync(specification, cancellationToken);

            if (couponType == null) return Result.NotFound(errorMessages: "CouponType not found!");

            return couponType;
        }
    }
}
