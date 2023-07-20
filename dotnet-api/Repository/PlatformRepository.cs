using dotnet_api.Data;
using dotnet_api.Interfaces;
using dotnet_api.Models;
using System.Reflection.Metadata.Ecma335;

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

        public Platform GetPlatformById(int platformId)
        {
            return _context.Platforms.Where(p => p.Id == platformId).FirstOrDefault();
        }

        public Platform GetPlatformByName(string platformName)
        {
            return _context.Platforms.Where(p => p.Name == platformName).FirstOrDefault();
        }

        public ICollection<Platform> GetPlatforms()
        {
            return _context.Platforms.OrderBy(p => p.Id).ToList();
        }


        public ICollection<Game> GetGamesByPlatform(int platformId)
        {
            return _context.GamePlatforms.Where(p => p.PlatformId == platformId).Select(p => p.Game).ToList();
        }

        public bool CreatePlatform(Platform platform)
        {
            _context.Add(platform);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
