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

        public ICollection<Game> GetGames()
        {
            return _context.Games.OrderBy(p => p.Id).ToList();
        }
    }
}
