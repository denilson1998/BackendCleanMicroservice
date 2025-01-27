using System.ComponentModel.DataAnnotations;

namespace Coupons.Api.Endpoints.Authorizers
{
    public class CreateAuthorizerRequest
    {
        public const string Route = "/Authorizer";

        public decimal MaxAmount { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }
    }
}
