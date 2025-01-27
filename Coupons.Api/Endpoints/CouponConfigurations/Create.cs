using Coupons.UseCases.CouponConfigurations.Create;
using Coupons.UseCases.CouponTypes.Get;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;
using Ardalis.Result;

namespace Coupons.Api.Endpoints.CouponConfigurations
{
    public class Create(IMediator _mediator, IMapper _mapper) : Endpoint<CreateCouponConfigurationRequest, CreateCouponConfigurationResponse>
    {
        public override void Configure()
        {
            Post("/CouponConfiguration");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Create CouponConfiguration";
                s.ExampleRequest = new CreateCouponConfigurationRequest { };
            });
        }

        public override async Task HandleAsync(CreateCouponConfigurationRequest request, CancellationToken cancellationToken)
        {
            var couponType = await _mediator.Send(new GetCouponTypeQuery(request.CouponTypeId));

            if (couponType.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            var couponConfiguration = await _mediator.Send(new CreateCouponConfigurationCommand(
                                                           request.SellAmount,
                                                           request.Credit,
                                                           request.Cash,
                                                           request.Category,
                                                           request.SubCategory,
                                                           request.Brand,
                                                           request.Product,
                                                           request.ExpenseAccount,
                                                           request.ApplyOverDiscount,
                                                           request.ApplyOverBundle,
                                                           request.IsGeneric,
                                                           request.UserCreated,
                                                           request.CouponTypeId));

            if (couponConfiguration.IsSuccess)
            {
                Response = _mapper.Map<CreateCouponConfigurationResponse>(couponConfiguration);
                return;
            }
        }
    }
}