using Coupons.Domain.Entities;
using Coupons.UseCases.CouponTypes.List;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace Coupons.Api.Endpoints.CouponTypes
{
    public class List(IMediator _mediator, IMapper _mapper) : EndpointWithoutRequest<List<ListCouponTypeResponse>>
    {
        public override void Configure()
        {
            Get("/CouponType");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "List of CouponType";
            });
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListCouponTypeQuery());

            if (result.IsSuccess)
            {
                
                Response = _mapper.Map<List<ListCouponTypeResponse>>(result.Value);

                return;
            }
        }
    }
}
