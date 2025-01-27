using Authentication.Api.Controllers.Users.Records;

namespace Authentication.Api.Controllers.Users
{
    public class ListUserResponse
    {
        public List<UserRecord> Users { get; set; } = new();
    }
}
