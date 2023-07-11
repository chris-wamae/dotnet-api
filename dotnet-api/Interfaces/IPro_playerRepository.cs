using dotnet_api.Models;

namespace dotnet_api.Interfaces
{

    public interface IPro_playerRepository
    {
        ICollection<Pro_player> GetPro_Players();
        Pro_player GetPro_PlayerById(int proId);
        Pro_player GetPro_PlayerByName(string name);
        bool ProExists(int proId);

    }

}