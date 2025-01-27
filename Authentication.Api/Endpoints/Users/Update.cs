using Ardalis.Result;
using Authentication.UseCases.Users.Update;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace Authentication.Api.Controllers.Users
{
    public class Update(IMediator _mediator, IMapper _mapper) : Endpoint<UpdateUserRequest, UpdateUserResult>
    {
        public override void Configure()
        {
            Put(UpdateUserRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new UpdateUserCommand(request.Id, request.Email, request.Password, request.Name));

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
            {
                Response = _mapper.Map<UpdateUserResult>(result.Value);
                return;

            }
        }
    }
}
