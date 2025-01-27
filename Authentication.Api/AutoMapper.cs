using Authentication.Api.Controllers.Users;
using Authentication.Domain.UserAggregate.Entities;
using AutoMapper;

namespace Authentication.Api
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<User, CreateUserResult>();
            CreateMap<User, UpdateUserResult>();
        }
    }
}
