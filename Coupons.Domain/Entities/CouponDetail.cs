using Ardalis.SharedKernel;

namespace Coupons.Domain.Entities
{
    public class CouponDetail : EntityBase, IAggregateRoot
    {
        public int Id { get; set; }

        public decimal TotalDiscount { get; set; }

        public DateTime CreationDate { get; set; }

        public int ReferenceNumber { get; set; }

        public string ReferenceType { get; set; }

        public int UserCreated { get; set; }

        public int CounponId { get; set; }

        public virtual Coupon Coupon { get; set; } = null!;
    }
}