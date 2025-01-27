namespace Coupons.Api.Endpoints.Authorizers
{
    public class CreateAuthorizerResponse
    {
        public int Id { get; set; }

        public decimal MaxAmount { get; set; }

        public bool Enabled { get; set; }
    }
}
