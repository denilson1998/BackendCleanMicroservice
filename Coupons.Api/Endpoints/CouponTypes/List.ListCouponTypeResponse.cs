using Coupons.Domain.Entities;

namespace Coupons.Api.Endpoints.CouponTypes
{
    public class ListCouponTypeResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }

    }
}
