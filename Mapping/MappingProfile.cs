using AutoMapper;
using SmartServe.API.Models;
using SmartServe.Domain.Models;

namespace SmartServe.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginResponse, LoginResponseDto>().ReverseMap();

        }
    }

}
