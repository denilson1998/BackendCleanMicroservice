namespace Authentication.Api.Controllers.Users
{
    public class CreateUserRequest
    {
        public const string Route = "/Users";
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; } = string.Empty;
    }
}
