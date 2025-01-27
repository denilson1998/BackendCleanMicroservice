using Coupons.UseCases.Authorizers.List;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace Coupons.Api.Endpoints.Authorizers
{
    public class List(IMediator _mediator, IMapper _mapper) : EndpointWithoutRequest<List<ListAuthorizerResponse>>
    {
        public override void Configure()
        {
            Get("/Authorizer");
            Summary(s =>
            {
                s.Summary = "List Authorizers";
            });
        }

        [Authorize]
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListAuthorizerQuery());

            if (result.IsSuccess)
            {
                Response = _mapper.Map<List<ListAuthorizerResponse>>(result.Value);

                return;
            }
        }
    }
}