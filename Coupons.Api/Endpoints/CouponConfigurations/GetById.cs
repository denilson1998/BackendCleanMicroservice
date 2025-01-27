using Coupons.UseCases.CouponConfigurations.Get;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;
using Ardalis.Result;

namespace Coupons.Api.Endpoints.CouponConfigurations
{
    public class GetById(IMediator _mediator, IMapper _mapper) : Endpoint<GetCouponConfigurationRequest, GetCouponConfigurationResponse>
    {
        public override void Configure()
        {
            Get(GetCouponConfigurationRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Get Coupon Configuration by Id";
            });
        }

        public override async Task HandleAsync(GetCouponConfigurationRequest request, CancellationToken cancellationToken)
        {
            var couponConfiguration = await _mediator.Send(new GetCouponConfigurationQuery(request.CouponConfigurationId));

            if (couponConfiguration.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            Response = _mapper.Map<GetCouponConfigurationResponse>(couponConfiguration.Value);
        }
    }
}
