using Ardalis.Specification;
using Coupons.Domain.Entities;

namespace Coupons.Domain.Specifications.CouponConfigurations
{
    public class GetByIdSpec : Specification<CouponConfiguration>
    {
        public GetByIdSpec(int couponConfigurationId)
        {
            Query
                .Where(c => c.Id == couponConfigurationId);
        }
    }
}