using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.CouponConfigurations.List
{
    public class ListCouponConfigurationHandler(IReadRepository<CouponConfiguration> _couponConfigurationRepository) : IQueryHandler<ListCouponConfigurationQuery, Result<List<CouponConfiguration>>>
    {
        public async Task<Result<List<CouponConfiguration>>> Handle(ListCouponConfigurationQuery request, CancellationToken cancellationToken)
        {
            var couponConfigurations = await _couponConfigurationRepository.ListAsync();

            return Result.Success(couponConfigurations);
        }
    }
}
