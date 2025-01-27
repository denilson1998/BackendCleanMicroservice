using Ardalis.Result;
using Coupons.UseCases.CouponTypes.Get;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace Coupons.Api.Endpoints.CouponTypes
{
    public class GetById(IMediator _mediator, IMapper _mapper) : Endpoint<GetCouponTypeRequest, GetCouponTypeResponse>
    {
        public override void Configure()
        {
            Get(GetCouponTypeRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetCouponTypeRequest request, CancellationToken cancellationToken)
        {
            var couponType = await _mediator.Send(new GetCouponTypeQuery(request.CouponTypeId));

            if (couponType.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }
            if (couponType.IsSuccess)
            {
                Response = _mapper.Map<GetCouponTypeResponse>(couponType.Value);
                return;
            }
        }
    }
}