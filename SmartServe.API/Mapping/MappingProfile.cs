using AutoMapper;
using SmartServe.API.Models;
using SmartServe.Application.Models;
using SmartServe.Domain.Entities;

namespace SmartServe.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseResponse, BaseResponseDto>().ReverseMap();
            CreateMap<LoginRequest, LoginRequestDto>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequestDto>().ReverseMap();
            CreateMap<Category, BulkUpdateCategoryRequestDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductRequestDto>().ReverseMap();
            CreateMap<Product, UpdateProductRequestDto>().ReverseMap();
            CreateMap<Product, BulkUpdateProductRequestDto>().ReverseMap();
        }
    }

}
