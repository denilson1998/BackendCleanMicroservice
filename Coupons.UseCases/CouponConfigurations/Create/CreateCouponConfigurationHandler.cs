using Ardalis.Result;
using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;
using Coupons.Domain.Specifications.CouponTypes;

namespace Coupons.UseCases.CouponConfigurations.Create
{
    public class CreateCouponConfigurationHandler(IRepository<CouponConfiguration> _couponConfigurationRepository, IReadRepository<CouponType> _couponTypeRepository, IUnitOfWork _unitOfWork) : ICommandHandler<CreateCouponConfigurationCommand, Result<CouponConfiguration>>
    {
        public async Task<Result<CouponConfiguration>> Handle(CreateCouponConfigurationCommand request, CancellationToken cancellationToken)
        {
            var specification = new GetByIdSpec(request.couponTypeId);

            var couponType = await _couponTypeRepository.FirstOrDefaultAsync(specification, cancellationToken);

            if (couponType is null)
            {
                return Result.Invalid();
            }

            var couponConfiguration = SetDtoToEntity(request, couponType);

            await _couponConfigurationRepository.AddAsync(couponConfiguration);

            //await _unitOfWork.CompleteAsync();

            //couponType.CouponConfigurations.Add(couponConfiguration);

            //_couponTypeRepository.UpdateAsync(couponType);

            return couponConfiguration;
        }

        private static CouponConfiguration SetDtoToEntity(CreateCouponConfigurationCommand request, CouponType couponType)
        {
            return new CouponConfiguration
            {
                SellAmount = request.sellAmount,
                Credit = request .credit,
                Cash = request .cash,
                Category = request .category,
                SubCategory = request .subCategory,
                Brand = request .brand,
                Product = request .product,
                ExpenseAccount = request .expenseAccount,
                ApplyOverDiscount = request .applyOverDiscount,
                ApplyOverBundle = request .applyOverBundle,
                IsGeneric = request .isGeneric,
                UserCreated = request .userCreated,
                CouponTypeId = request .couponTypeId,
                CouponType = couponType
            };
        }
    }
}