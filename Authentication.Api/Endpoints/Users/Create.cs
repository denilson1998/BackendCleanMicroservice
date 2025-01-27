
using Authentication.Domain.Persistence.Repositories;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using IMapper = AutoMapper.IMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Ardalis.Result;
using Authentication.UseCases.Users.Create;

namespace Authentication.Api.Controllers.Users
{
    public class Create(IMapper _mapper, IMediator _mediator) : Endpoint<CreateUserRequest, CreateUserResult>
    {

        public override void Configure()
        {
            Post(CreateUserRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                // XML Docs are used by default but are overridden by these properties:
                s.Summary = "Create an User.";
                //s.Description = "Create a new Contributor. A valid name is required.";
                s.ExampleRequest = new CreateUserRequest { Name = "User Name", Email = "User Email", Password = "User Password", EmailConfirmed = "Email Confirmation"};
            });
        }

        public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {

            var userCreated = await _mediator.Send(new CreateUserCommand(request.Name, request.Email, request.Password, request.EmailConfirmed));

            if (userCreated.IsSuccess)
            {
                var result = _mapper.Map<CreateUserResult>(userCreated.Value);

                Response = result;

                return;
            }
        }
        
    }
}
