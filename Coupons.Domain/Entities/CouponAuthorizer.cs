using Ardalis.SharedKernel;

namespace Coupons.Domain.Entities
{
    public class CouponAuthorizer : EntityBase, IAggregateRoot
    {
        public int Id { get; set; }

        public decimal MaxAmount { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }

        public ICollection<Coupon> Coupons { get; set; }
    }
}