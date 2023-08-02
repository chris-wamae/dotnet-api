using dotnet_api.Models;

namespace dotnet_api.Interfaces
{

    public interface IStudioRepository
    {
        ICollection<Studio> GetStudios();
        Studio GetStudioById(int Id);
        Studio GetStudioByName(string name);
        bool StudioExists(int Id);
        bool CreateStudio(Studio studio);
        bool UpdateStudio(Studio studio); 

        bool DeleteStudio(Studio studio);

        bool Save();

        
    }
}


