using Ardalis.SharedKernel;

namespace Coupons.Domain.Entities
{
    public class CouponType : EntityBase, IAggregateRoot
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int UserCreated { get; set; }

        public ICollection<CouponConfiguration> CouponConfigurations { get; set; }
    }
}