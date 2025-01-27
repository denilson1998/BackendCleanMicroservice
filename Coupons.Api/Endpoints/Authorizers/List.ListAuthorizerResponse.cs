namespace Coupons.Api.Endpoints.Authorizers
{
    public class ListAuthorizerResponse
    {
        public int Id { get; set; }

        public decimal MaxAmount { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }

    }
}
