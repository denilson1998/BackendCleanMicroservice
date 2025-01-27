using Ardalis.Specification;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.Domain.Specifications.CouponAuthorizers
{
    public class GetByIdSpec : Specification<CouponAuthorizer>
    {
        public GetByIdSpec(int couponAuthorizerId)
        {
            Query
                .Where(c => c.Id == couponAuthorizerId);
        }
    }
}
