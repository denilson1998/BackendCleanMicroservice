namespace Coupons.Api.Endpoints.Authorizers
{
    public class GetCouponAuthorizerRequest
    {
        public const string Route = "/Authorizer/{CouponAuthorizerId:int}";
        public static string BuildRoute(int CouponAuthorizerId) => Route.Replace("{CouponAuthorizerId:int}", CouponAuthorizerId.ToString());

        public int CouponAuthorizerId { get; set; }
    }
}
