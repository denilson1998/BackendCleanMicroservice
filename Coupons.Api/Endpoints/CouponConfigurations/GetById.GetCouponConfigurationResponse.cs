using Coupons.Domain.Entities;

namespace Coupons.Api.Endpoints.CouponConfigurations
{
    public class GetCouponConfigurationResponse
    {
        public int Id { get; set; }

        public decimal SellAmount { get; set; }

        public bool Credit { get; set; }

        public bool Cash { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string Brand { get; set; }

        public string Product { get; set; }

        public string ExpenseAccount { get; set; }

        public bool ApplyOverDiscount { get; set; }

        public bool ApplyOverBundle { get; set; }

        public bool IsGeneric { get; set; }

        public int UserCreated { get; set; }

        public int CouponTypeId { get; set; }

        public virtual CouponType CouponType { get; set; } = null!;

        public ICollection<Coupon> Coupons { get; set; }
    }
}
