using dotnet_api.Models;

namespace dotnet_api.Interfaces
{
    public interface IGameRepository
    {
        ICollection<Game> GetGames();
        Game GetGame(int id);
        Game GetGame(string name);

        bool GameExists(int gameId);

        ICollection<Platform> GetPlatformsByGame(int gameId);

        bool CreateGame(int platformId,int studioId, Game Game);

        bool UpdateGame(int platformId,int gameId, Game game);

        bool Save();

    }
}
