using Coupons.Domain.Entities;

namespace Coupons.Api.Endpoints.Coupons
{
    public class CreateCouponResponse
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }

        public decimal Percent { get; set; }

        public string Code { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsUsed { get; set; }

        public string State { get; set; }

        public int UserCreated { get; set; }

        public string Reference { get; set; } //ClientId

        public int CouponConfigurationId { get; set; }

        public virtual CouponConfiguration CouponConfiguration { get; set; } = null!;

        public int CouponAuthorizerId { get; set; }

        public virtual CouponAuthorizer CouponAuthorizer { get; set; } = null!;

        public ICollection<CouponDetail> CouponDetail { get; set; } = null!;
    }
}
