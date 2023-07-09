using dotnet_api.Models;

namespace dotnet_api.Interfaces
{
   public interface IPlatformRepository 
   {
       ICollection<Platform> GetPlatforms();

       Platform GetPlatformById(int platformId);

       Platform GetPlatformByName(string platformName);

       bool PlatformExists(int id);

   }
}
