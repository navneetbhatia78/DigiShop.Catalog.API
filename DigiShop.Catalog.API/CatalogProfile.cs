using AutoMapper;
using DigiShop.Catalog.API.Models;
using System;

namespace DigiShop.Catalog.API
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<ProductRequest, Product>()
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Size, opt => opt.MapFrom(src => src.Size))
                .ForMember(dst => dst.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dst => dst.SellerId, opt => opt.MapFrom(src => src.SellerId))
                .AfterMap((s, d) =>
                {
                    d.CreatedDate = DateTime.Today.Date;
                    d.CreatedUserId = 2;
                });

            CreateMap<BrandRequest, Brand>()
                .ForMember(dst => dst.BrandName, opt => opt.MapFrom(src => src.BrandName))
                .AfterMap((s, d) =>
                {
                    d.CreatedUserId = 2;
                    d.CreatedDate = DateTime.Today.Date;
                });

            CreateMap<CategoryRequest, Category>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .AfterMap((s, d) =>
                {
                    d.CreatedUserId = 2;
                    d.CreatedDate = DateTime.Today.Date;
                });
        }
    }
}