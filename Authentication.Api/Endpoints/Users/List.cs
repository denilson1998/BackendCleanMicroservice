using Authentication.Api.Controllers.Users.Records;
using Authentication.UseCases.Users.List;
using FastEndpoints;
using MediatR;

namespace Authentication.Api.Controllers.Users
{
    public class List(IMediator _mediator) : EndpointWithoutRequest<ListUserResponse>
    {

        public override void Configure()
        {
            Get("/Users");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Users List";
            });
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListUsersQuery());

            if (result.IsSuccess)
            {
                Response = new ListUserResponse
                {
                    Users = result.Value.Select(u => new UserRecord(u.Id, u.Email, u.Name, u.Password, u.EmailConfirmed)).ToList()
                };
            }
        }
    }
}
