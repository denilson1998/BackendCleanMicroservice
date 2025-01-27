using System.ComponentModel.DataAnnotations;

namespace Coupons.Api.Endpoints.CouponConfigurations
{
    public class CreateCouponConfigurationRequest
    {
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

        [Required]
        public int UserCreated { get; set; }

        [Required]
        public int CouponTypeId { get; set; }
    }
}
