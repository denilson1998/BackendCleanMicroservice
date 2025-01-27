namespace Coupons.Api.Endpoints.Coupons
{
    public class GetCouponRequest
    {
        public const string Route = "/Coupon/{CouponId:int}";

        public static string BuilRoute(int CouponId) => Route.Replace("{CouponId}", CouponId.ToString());

        public int CouponId { get; set; }
    }
}
