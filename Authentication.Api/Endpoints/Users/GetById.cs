using Ardalis.Result;
using Authentication.Api.Controllers.Users.Records;
using Authentication.UseCases.Users.Get;
using FastEndpoints;
using MediatR;

namespace Authentication.Api.Controllers.Users
{
    public class GetById(IMediator _mediator) : Endpoint<GetUserRequest, GetUserRecord>
    {

        public override void Configure()
        {
            Get(GetUserRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Get User by Id";
            });
        }

        public override async Task HandleAsync(GetUserRequest request, CancellationToken cancellationToken)
        {
            var command = new GetUserQuery(request.UserId);

            var result = await _mediator.Send(command);

            var result2 = await _mediator.Send(command);

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
            {
                Response = new GetUserRecord(result.Value);
            }
        }

        

    }
}
