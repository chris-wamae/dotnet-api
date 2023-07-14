using dotnet_api.Data;
using dotnet_api.Interfaces;
using dotnet_api.Models;

namespace dotnet_api.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        //public bool CreateGame(int platformId, Game game)
        //{
        //    var gamePlatformEntity = _context.Platforms.Where(p => p.Id == platformId).FirstOrDefault();

        //    var gamePlatform = new GamePlatform()
        //    {
        //        Platform = gamePlatformEntity,
        //        Game = game,
        //    };

        //    _context.Add(gamePlatform);
        //    _context.Add(game);           

        //}

        public bool GameExists(int gameId)
        {
            return _context.Games.Any(g => g.Id == gameId);
        }

        public Game GetGame(int id)
        {
            return _context.Games.Where(g => g.Id == id).FirstOrDefault();
        }

        public Game GetGame(string name)
        {
            return _context.Games.Where(g => g.Title == name).FirstOrDefault();
        }

        public ICollection<Game> GetGames()
        {
            return _context.Games.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Platform> GetPlatformsByGame(int gameId)
        {
            return _context.GamePlatforms.Where(g => g.GameId == gameId).Select(g => g.Platform).ToList();
        }

        //public bool Save()
        //{
        //    var saved = _context.SaveChanges();

        //    return saved > 0 ? true : false;
        //}
    }
}
