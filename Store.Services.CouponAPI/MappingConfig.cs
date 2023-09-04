using AutoMapper;
using Store.Services.CouponAPI.Models;
using Store.Services.CouponAPI.Models.Dto;

namespace Store.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappinConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappinConfig;
        }
    }
}
