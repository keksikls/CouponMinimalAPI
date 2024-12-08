using AutoMapper;
using WebApplication_CouponAPI.Models;
using WebApplication_CouponAPI.Models.DTO;

namespace WebApplication_CouponAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Coupon, CouponCreateDTO>().ReverseMap();
            CreateMap<Coupon, CouponDTO>().ReverseMap();
        }
    }
}
