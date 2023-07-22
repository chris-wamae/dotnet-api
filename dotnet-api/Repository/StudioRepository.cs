using dotnet_api.Data;
using dotnet_api.Interfaces;
using dotnet_api.Models;

namespace dotnet_api.Repository
{

    public class StudioRepository : IStudioRepository
    {
        private readonly DataContext _context;

        public StudioRepository(DataContext context)
        {
            _context = context;
        }

        public bool StudioExists(int studioId)
        {
            return _context.Studios.Any(s => s.Id == studioId);
        }

        public Studio GetStudioById(int studioId)
        {
            return _context.Studios.Where(s => s.Id == studioId).FirstOrDefault();
        }

        public Studio GetStudioByName(string name)
        {
            return _context.Studios.Where(s => s.Name == name).FirstOrDefault();
        }

        public ICollection<Studio> GetStudios()

        {

            return _context.Studios.OrderBy(s => s.Id).ToList();

        }

        public bool CreateStudio(Studio studio)
        {
         _context.Add(studio);
            return Save();      
        }


        public bool UpdateStudio(Studio studio)
        {
            _context.Update(studio);
            return Save();
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();

            return saved > 0 ? true : false; 
            
        }
    }

}