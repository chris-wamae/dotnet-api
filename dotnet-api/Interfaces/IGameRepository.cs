using dotnet_api.Models;

namespace dotnet_api.Interfaces
{
    public interface IGameRepository
    {
        ICollection<Game> GetGames();
    }
}
