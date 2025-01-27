using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;

namespace Coupons.UseCases.Coupons.Create
{
    public class CreateCouponHandler(IRepository<Coupon> _couponRespository, IUnitOfWork _unitOfWork) : ICommandHandler<CreateCouponCommand, Result<Coupon>>
    {
        public async Task<Result<Coupon>> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = SetDtoToEntity(request);

            await _couponRespository.AddAsync(coupon);

            //await _unitOfWork.CompleteAsync();

            return coupon;
        }

        private static Coupon SetDtoToEntity(CreateCouponCommand request)
        {
            return new Coupon()
            {
                CreationDate = DateTime.Now,
                Amount = request.amount,
                Type = request.type,
                Percent = request.percent,
                Code = request.code,
                ExpirationDate = request.expirationDate,
                IsUsed = request.isUsed,
                State = request.state,
                UserCreated = request.userCreated,
                Reference = request.reference,
                CouponConfigurationId = request.couponConfigurationId,
                CouponAuthorizerId = request.couponAuthorizerId,
                CouponAuthorizer = request.couponAuthorizer,
                CouponConfiguration = request.couponConfiguration
            };
        }
    }
}