using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.CouponTypes.List
{
    public class ListCouponTypeHandler(IReadRepository<CouponType> _couponTypeRepository) : IQueryHandler<ListCouponTypeQuery, Result<List<CouponType>>>
    {
        public async Task<Result<List<CouponType>>> Handle(ListCouponTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _couponTypeRepository.ListAsync();

            return Result.Success(result);
        }
    }
}
