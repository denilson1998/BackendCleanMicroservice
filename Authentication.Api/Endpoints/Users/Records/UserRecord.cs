namespace Authentication.Api.Controllers.Users.Records
{
    public record UserRecord(int Id, string Name, string Password, string Email, string EmailConfirmed);
}
