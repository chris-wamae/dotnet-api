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
            CreateMap<Studio, StudioDto>();
            CreateMap<Pro_player, Pro_playerDto>();
            CreateMap<Platform, PlatformDto>();
            CreateMap<StudioDto, Studio>();
            CreateMap<PlatformDto, Platform>();
            CreateMap<Pro_playerDto, Pro_player>();
            CreateMap<GameDto,Game>();
        }

    }
}
