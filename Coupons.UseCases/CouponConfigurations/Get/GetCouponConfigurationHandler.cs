using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;
using Coupons.Domain.Specifications.CouponConfigurations;

namespace Coupons.UseCases.CouponConfigurations.Get
{
    public class GetCouponConfigurationHandler(IReadRepository<CouponConfiguration> _couponConfigurationRepository) : IQueryHandler<GetCouponConfigurationQuery, Result<CouponConfiguration>>
    {
        public async Task<Result<CouponConfiguration>> Handle(GetCouponConfigurationQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetByIdSpec(request.couponConfigurationId);

            var couponConfiguration = await _couponConfigurationRepository.FirstOrDefaultAsync(specification, cancellationToken);

            if (couponConfiguration is null) return Result.NotFound();

            return couponConfiguration;
        }
    }
}