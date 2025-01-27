using Coupons.UseCases.Authorizers.Get;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;
using Ardalis.Result;


namespace Coupons.Api.Endpoints.Authorizers
{
    public class GetById(IMediator _mediator, IMapper _mapper) : Endpoint<GetCouponAuthorizerRequest, GetCouponAuthorizerResponse>
    {
        public override void Configure()
        {
            Get(GetCouponAuthorizerRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Get Authorizer";
            });
        }

        public override async Task HandleAsync(GetCouponAuthorizerRequest request, CancellationToken cancellationToken)
        {
            var authorizer = await _mediator.Send(new GetCouponAuthorizerQuery(request.CouponAuthorizerId));

            if (authorizer.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            Response = _mapper.Map<GetCouponAuthorizerResponse>(authorizer.Value);
            return;
        }
    }
}
