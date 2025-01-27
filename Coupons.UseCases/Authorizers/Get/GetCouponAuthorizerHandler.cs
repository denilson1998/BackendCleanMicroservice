using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Specifications.CouponAuthorizers;

namespace Coupons.UseCases.Authorizers.Get
{
    public class GetCouponAuthorizerHandler(IReadRepository<CouponAuthorizer> _couponAuthorizerRepository) : IQueryHandler<GetCouponAuthorizerQuery, Result<CouponAuthorizer>>
    {
        public async Task<Result<CouponAuthorizer>> Handle(GetCouponAuthorizerQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetByIdSpec(request.authorizerId);

            var couponAuthorizer = await _couponAuthorizerRepository.FirstOrDefaultAsync(specification, cancellationToken);

            if (couponAuthorizer == null) return Result.NotFound();

            return Result.Success(couponAuthorizer);
        }
    }
}