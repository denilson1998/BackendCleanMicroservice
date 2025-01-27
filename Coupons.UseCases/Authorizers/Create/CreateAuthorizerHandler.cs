using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.UseCases.Authorizers.Create
{
    public class CreateAuthorizerHandler(IRepository<CouponAuthorizer> _repository, IUnitOfWork _unitOfWork) : ICommandHandler<CreateAuthorizerCommand, Result<CouponAuthorizer>>
    {
        public async Task<Result<CouponAuthorizer>> Handle(CreateAuthorizerCommand request, CancellationToken cancellationToken)
        {

            var authorizer = new CouponAuthorizer()
            {
                CreationDate = DateTime.Now,
                MaxAmount = request.maxAmount,
                Enabled = request.enabled,
                UserCreated = request.userCreated
            };

            await _repository.AddAsync(authorizer);

            //await _unitOfWork.CompleteAsync();

            return authorizer;

        }
    }
}
