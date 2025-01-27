namespace Coupons.Api.Endpoints.CouponTypes
{
    public class CreateCouponTypeRequest
    {
        public const string Route = "/CouponType";

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }
    }
}
