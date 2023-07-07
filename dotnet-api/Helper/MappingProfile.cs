using AutoMapper;
using dotnet_api.Dto;
using dotnet_api.Models;

namespace dotnet_api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>();
        }

    }
}
