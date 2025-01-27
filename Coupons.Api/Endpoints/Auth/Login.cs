using Coupons.UseCases.Authentication.Login;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace Coupons.Api.Endpoints.Auth
{
    public class Login(IMediator _mediator, IMapper _mapper) : Endpoint<LoginRequest,LoginResponse>
    {
        public override void Configure()
        {
            Post("/Login");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Login to get Token!";
            });
        }

        public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var verify = await _mediator.Send(new LoginCommand(request.email, request.password));

            if (!string.IsNullOrEmpty(verify.Value))
            {
                Response = new LoginResponse { token = verify.Value };
                return;
            };
        }
    }
}
