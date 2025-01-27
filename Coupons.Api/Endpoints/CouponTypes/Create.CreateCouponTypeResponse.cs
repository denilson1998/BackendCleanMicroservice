namespace Coupons.Api.Endpoints.CouponTypes
{
    public class CreateCouponTypeResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }
    }
}
