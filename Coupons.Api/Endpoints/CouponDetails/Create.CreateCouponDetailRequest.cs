namespace Coupons.Api.Endpoints.CouponDetails
{
    public class CreateCouponDetailRequest
    {
        public const string Route = "/CouponDetail";

        public decimal TotalDiscount { get; set; }

        public int ReferenceNumber { get; set; }

        public string ReferenceType { get; set; }

        public int UserCreated { get; set; }

        public int CounponId { get; set; }
    }
}
