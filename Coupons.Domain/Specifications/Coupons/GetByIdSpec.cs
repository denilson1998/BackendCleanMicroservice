using Ardalis.Specification;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.Domain.Specifications.Coupons
{
    public class GetByIdSpec : Specification<Coupon>
    {
        public GetByIdSpec(int couponId)
        {
            Query
                .Where(c => c.Id == couponId);
        }
    }
}
