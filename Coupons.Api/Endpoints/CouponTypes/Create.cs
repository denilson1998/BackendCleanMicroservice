using Coupons.UseCases.CouponTypes.Create;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;


namespace Coupons.Api.Endpoints.CouponTypes
{
    public class Create(IMediator _mediator, IMapper _mapper) : Endpoint<CreateCouponTypeRequest, CreateCouponTypeResponse>
    {
        public override void Configure()
        {
            Post(CreateCouponTypeRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Create CouponType";
                s.ExampleRequest = new CreateCouponTypeRequest { Description = "description", Enabled = true, UserCreated = 456 };
            });
        }

        public override async Task HandleAsync(CreateCouponTypeRequest request, CancellationToken cancellationToken)
        {
            var couponType = await _mediator.Send(new CreateCouponTypeCommand(request.Description, request.Enabled, request.UserCreated));

            Response = _mapper.Map<CreateCouponTypeResponse>(couponType.Value);

            return;
        }
    }
}
