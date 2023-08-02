using dotnet_api.Models;

namespace dotnet_api.Interfaces
{
    public interface IPlatformRepository
    {
        ICollection<Platform> GetPlatforms();

        Platform GetPlatformById(int platformId);

        Platform GetPlatformByName(string platformName);

        bool PlatformExists(int id);

        ICollection<Game> GetGamesByPlatform(int platformId);

        bool CreatePlatform(Platform platform);

        bool UpdatePlatform(int gameId, Platform Platform); 

        bool DeletePlatform(Platform platform);

        bool Save();

    }
}
