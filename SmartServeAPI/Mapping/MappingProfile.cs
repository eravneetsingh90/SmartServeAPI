using AutoMapper;
using SmartServe.API.Models;
using SmartServe.Application.Models;

namespace SmartServe.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequest, LoginRequestDto>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseDto>().ReverseMap();

        }
    }

}
