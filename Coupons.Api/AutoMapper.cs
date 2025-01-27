
using AutoMapper;
using Coupons.Api.Endpoints.Authorizers;
using Coupons.Api.Endpoints.CouponConfigurations;
using Coupons.Api.Endpoints.CouponDetails;
using Coupons.Api.Endpoints.Coupons;
using Coupons.Api.Endpoints.CouponTypes;
using Coupons.Domain.Entities;
using System.Collections.Generic;

namespace Coupons.Api
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Coupon, CreateCouponResponse>();

            CreateMap<Coupon, GetCouponResponse>();


            CreateMap<CouponAuthorizer, CreateAuthorizerResponse>();

            CreateMap<CouponAuthorizer, GetCouponAuthorizerResponse>();

            CreateMap<CouponAuthorizer, ListAuthorizerResponse>();


            CreateMap<CouponType, CreateCouponTypeResponse>();

            CreateMap<CouponType, GetCouponTypeResponse>();

            CreateMap<CouponType, ListCouponTypeResponse>();

            
            CreateMap<CouponConfiguration, CreateCouponConfigurationResponse>();

            CreateMap<CouponConfiguration, GetCouponConfigurationResponse>();

            CreateMap<CouponConfiguration, ListCouponConfigurationResponse>();

            
            CreateMap<CouponDetail, CreateCouponDetailResponse>();
        }
    }
}
