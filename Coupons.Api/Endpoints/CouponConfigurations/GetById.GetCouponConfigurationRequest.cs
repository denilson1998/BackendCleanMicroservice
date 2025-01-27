namespace Coupons.Api.Endpoints.CouponConfigurations
{
    public class GetCouponConfigurationRequest
    {
        public const string Route = "/CouponConfiguration/{CouponConfigurationId:int}";
        public static string BuildRoute(int CouponConfigurationId) => Route.Replace("{CouponConfigurationId:int}", CouponConfigurationId.ToString());

        public int CouponConfigurationId { get; set; }
    }
}
