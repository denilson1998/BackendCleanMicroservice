using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.Authorizers.List
{
    public class ListAuthorizerHandler(IReadRepository<CouponAuthorizer> _couponAuthorizerRepository) : IQueryHandler<ListAuthorizerQuery, Result<List<CouponAuthorizer>>>
    {
        public async Task<Result<List<CouponAuthorizer>>> Handle(ListAuthorizerQuery request, CancellationToken cancellationToken)
        {
            var authorizers = await _couponAuthorizerRepository.ListAsync();

            return Result.Success(authorizers);
        }
    }
}
