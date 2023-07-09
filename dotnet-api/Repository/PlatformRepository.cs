using dotnet_api.Data;
using dotnet_api.Interfaces;
using dotnet_api.Models;

namespace dotnet_api.Repository
{
   public class PlatformRepository : IPlatformRepository

   {

    private readonly DataContext _context;

    public PlatformRepository(DataContext context)
    {
       _context = context;
    }


    public bool PlatformExists(int platformId)
    {
        return _context.Platforms.Any(p => p.Id == platformId);
    }

    public Platform GetPlatform(int platformId)
    {
        return _context.Platforms.Where(p => p.Id == platformId).FirstOrDefault();
    }

    public Platform GetPlatform(string platformName)
     {
        return _context.Platforms.Where(p => p.Name == platformName).FirstOrDefault();
     }

    public ICollection<Platform> GetPlatforms()
    {
      return _context.Platforms.OrderBy(p => p.Id).ToList();
    }

   }
}
