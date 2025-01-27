using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;
using Coupons.UseCases.CouponTypes.Create;

namespace Coupons.UseCases.CoponTypes.Create
{
    public class CreateCouponTypeHandler(IRepository<CouponType> _couponTypeRepository, IUnitOfWork _unitOfWork) : ICommandHandler<CreateCouponTypeCommand, Result<CouponType>>
    {
        public async Task<Result<CouponType>> Handle(CreateCouponTypeCommand request, CancellationToken cancellationToken)
        {
            var couponType = new CouponType()
            {
                Description = request.description,
                Enabled = request.enabled,
                UserCreated = request.userCreated
            };

            await _couponTypeRepository.AddAsync(couponType, cancellationToken);

            //await _unitOfWork.CompleteAsync(cancellationToken);

            return couponType;
        }
    }
}