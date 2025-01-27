using System.ComponentModel.DataAnnotations;

namespace Authentication.Api.Controllers.Users
{
    public class UpdateUserRequest
    {
        public const string Route = "/Users";

        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
