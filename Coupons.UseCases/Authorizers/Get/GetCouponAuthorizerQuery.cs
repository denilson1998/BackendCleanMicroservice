using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.Authorizers.Get
{
    public record GetCouponAuthorizerQuery(int authorizerId) : IQuery<Result<CouponAuthorizer>>;
}
