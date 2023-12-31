using dotnet_api.Models;

namespace dotnet_api.Interfaces
{

    public interface IPro_playerRepository
    {
        ICollection<Pro_player> GetPro_Players();
        Pro_player GetPro_PlayerById(int proId);
        Pro_player GetPro_PlayerByName(string name);
        bool ProExists(int proId);

        bool CreatePro_player(Pro_player pro_playerCreate);

        bool UpdatePro_Player(Pro_player pro_playerUpdate);

        bool DeletePro_Player(Pro_player pro_Player);

        bool Save();

    }
    

}