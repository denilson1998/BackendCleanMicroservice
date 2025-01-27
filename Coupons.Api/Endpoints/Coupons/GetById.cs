using Ardalis.Result;
using Coupons.UseCases.Counpons.Get;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;


namespace Coupons.Api.Endpoints.Coupons
{
    public class GetById(IMediator _mediator, IMapper _mapper) : Endpoint<GetCouponRequest, GetCouponResponse>
    {
        public override void Configure()
        {
            Get(GetCouponRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Get Coupon by Id";
            });
        }

        public override async Task HandleAsync(GetCouponRequest request, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(new GetCouponQuery(request.CouponId));

            if (coupon.Status == ResultStatus.NotFound)
            {
                ThrowError(message: coupon.Errors.FirstOrDefault(), 404);
            }

            Response = _mapper.Map<GetCouponResponse>(coupon.Value);
            return;
        }
    }
}
