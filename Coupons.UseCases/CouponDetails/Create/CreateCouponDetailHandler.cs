using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;

namespace Coupons.UseCases.CouponDetails.Create
{
    public class CreateCouponDetailHandler(IRepository<CouponDetail> _couponDetailRepository, IRepository<Coupon> _couponRepository) : ICommandHandler<CreateCouponDetailCommand, Result<CouponDetail>>
    {
        public async Task<Result<CouponDetail>> Handle(CreateCouponDetailCommand request, CancellationToken cancellationToken)
        {
            var couponDetail = SetDtoToEntity(request);

            request.coupon.IsUsed = true;

            await _couponDetailRepository.AddAsync(couponDetail);

            return Result.Success(couponDetail);
            
        }

        private static CouponDetail SetDtoToEntity(CreateCouponDetailCommand request)
        {
            return new CouponDetail {
                CreationDate = DateTime.Now,
                TotalDiscount = request.totalDiscount,
                ReferenceNumber = request.referenceNumber,
                ReferenceType = request.referenceType,
                UserCreated = request.userCreated,
                CounponId = request.couponId,
                Coupon = request.coupon
            };
        }
    }
}