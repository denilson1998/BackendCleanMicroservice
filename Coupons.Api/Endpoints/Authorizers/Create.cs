using Coupons.UseCases.Authorizers.Create;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace Coupons.Api.Endpoints.Authorizers
{
    public class Create(IMediator _mediator, IMapper _mapper) : Endpoint<CreateAuthorizerRequest, CreateAuthorizerResponse>
    {
        public override void Configure()
        {
            Post(CreateAuthorizerRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Create Authorizer";
                s.ExampleRequest = new CreateAuthorizerRequest { MaxAmount = 1, Enabled = true, UserCreated = 456};
            });

        }

        public override async Task HandleAsync(CreateAuthorizerRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateAuthorizerCommand(request.MaxAmount, request.Enabled, request.UserCreated));

            Response = _mapper.Map<CreateAuthorizerResponse>(result.Value);

            return;

        }
    }
}
