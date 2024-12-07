using WebApplication_CouponAPI.Models;

namespace WebApplication_CouponAPI.Data
{
    public static class CouponStore
    {
        public static List<Coupon> couponslist = new List<Coupon> 
        { 
            new Coupon{Id = 1, Name = "100FF", Percent = 10, IsActive = true },
            new Coupon{Id = 2, Name = "20OFF", Percent = 20, IsActive = false }
        };
    }
}
