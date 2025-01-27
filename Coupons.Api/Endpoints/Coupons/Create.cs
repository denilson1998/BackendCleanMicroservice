using Coupons.UseCases.Coupons.Create;
using Coupons.UseCases.CouponConfigurations.Get;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;
using Ardalis.Result;
using Coupons.UseCases.Authorizers.Get;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Coupons.Api.Endpoints.Coupons
{
    public class Create(IMediator _mediator, IMapper _mapper) : Endpoint<CreateCouponRequest, CreateCouponResponse>
    {
        public override void Configure()
        {
            Post(CreateCouponRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Create Coupon";
                s.ExampleRequest = new CreateCouponRequest { };
            });
        }

        public override async Task HandleAsync(CreateCouponRequest request, CancellationToken cancellationToken)
        {
            var couponConfiguration = await _mediator.Send(new GetCouponConfigurationQuery(request.CouponConfigurationId));

            var couponAuthorizer = await _mediator.Send(new GetCouponAuthorizerQuery(request.CouponAuthorizerId));

            if (couponConfiguration.Status == ResultStatus.NotFound)
            {
                ThrowError("Coupon Configuration not found!", 404);
            }

            if (couponAuthorizer.Status == ResultStatus.NotFound)
            {
                ThrowError("Coupon Authorizer not found!", 404);
                return;
            }

            var result = await _mediator.Send(new CreateCouponCommand(
                request.Amount,
                request.Type,
                request.Percent,
                request.Code,
                request.ExpirationDate,
                request.IsUsed,
                request.State,
                request.UserCreated,
                request.Reference,
                request.CouponConfigurationId,
                request.CouponAuthorizerId,
                couponAuthorizer,
                couponConfiguration));

            if (result.IsSuccess)
            { 

                Response = _mapper.Map<CreateCouponResponse>(result.Value);

                return;
            }
        }
    }
}