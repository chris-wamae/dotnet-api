using dotnet_api.Models;

namespace dotnet_api.Repository
{

    public interface IStudioRepository
    {
        ICollection<Studio> GetStudios();
        Studio GetStudioById(int Id);
        Studio GetStudioByName(string name);
        bool StudioExists(int Id);
    }
}


