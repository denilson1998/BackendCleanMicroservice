using System.ComponentModel.DataAnnotations;

namespace Authentication.Api.Controllers.Users
{
    public class GetUserRequest
    {
        public const string Route = "/Users/{UserId:int}";
        public static string BuildRoute(int UserId) => Route.Replace("{UserId:int}", UserId.ToString());
        
        public int UserId { get; set; }
    }
}
