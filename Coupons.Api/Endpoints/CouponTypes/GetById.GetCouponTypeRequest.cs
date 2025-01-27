namespace Coupons.Api.Endpoints.CouponTypes
{
    public class GetCouponTypeRequest
    {
        public const string Route = "/CouponType/{CouponTypeId:int}";
        public static string BuildRoute(int CouponTypeId) => Route.Replace("{CouponTypeId:int}", CouponTypeId.ToString());

        public int CouponTypeId { get; set; }
    }
}
