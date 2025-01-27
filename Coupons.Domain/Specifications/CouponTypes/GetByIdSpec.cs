using Ardalis.Specification;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.Domain.Specifications.CouponTypes
{
    public class GetByIdSpec : Specification<CouponType>
    {
        public GetByIdSpec(int couponTypeId)
        {
            Query
                .Where(c => c.Id == couponTypeId);
        }
    }
}
