using Coupons.Domain.Entities;

namespace Coupons.Api.Endpoints.Authorizers
{
    public class GetCouponAuthorizerResponse
    {
        public int Id { get; set; }

        public decimal MaxAmount { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }

        public ICollection<Coupon> Coupons { get; set; }
    }
}
