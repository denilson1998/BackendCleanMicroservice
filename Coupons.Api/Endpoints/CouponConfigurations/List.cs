using Coupons.UseCases.CouponConfigurations.List;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;


namespace Coupons.Api.Endpoints.CouponConfigurations
{
    public class List(IMediator _mediator, IMapper _mapper) : EndpointWithoutRequest<List<ListCouponConfigurationResponse>>
    {
        public override void Configure()
        {
            Get("/CouponConfiguration");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "List CouponConfigurations";
            });
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListCouponConfigurationQuery());

            if (result.IsSuccess)
            {
                Response = _mapper.Map<List<ListCouponConfigurationResponse>>(result.Value);
                return;
            }
        }
    }
}
