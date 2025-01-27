using Ardalis.Result;
using Coupons.Api.Endpoints.Coupons;
using Coupons.UseCases.Counpons.Get;
using Coupons.UseCases.CouponDetails.Create;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace Coupons.Api.Endpoints.CouponDetails
{
    public class Create(IMediator _mediator, IMapper _mapper) : Endpoint<CreateCouponDetailRequest, CreateCouponDetailResponse>
    {
        public override void Configure()
        {
            Post(CreateCouponDetailRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Create Coupon Detail";
                s.ExampleRequest = new CreateCouponDetailRequest { };
            });
        }

        public override async Task HandleAsync(CreateCouponDetailRequest request, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(new GetCouponQuery(request.CounponId));

            if (coupon.Status == ResultStatus.NotFound)
            {
                ThrowError(message: coupon.Errors.FirstOrDefault(), 404);
            }

            var couponDetail = await _mediator.Send(new CreateCouponDetailCommand(
                request.TotalDiscount,
                request.ReferenceNumber,
                request.ReferenceType,
                request.UserCreated,
                request.CounponId,
                coupon));

            if (couponDetail.IsSuccess)
            {
                Response = _mapper.Map<CreateCouponDetailResponse>(couponDetail.Value);
                return;
            }
        }
    }
}
