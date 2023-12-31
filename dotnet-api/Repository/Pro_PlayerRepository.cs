using dotnet_api.Data;
using dotnet_api.Interfaces;
using dotnet_api.Models;

namespace dotnet_api.Repository
{

    public class Pro_playerRepository : IPro_playerRepository
    {
        private readonly DataContext _context; 

        public Pro_playerRepository(DataContext context)
        {
            _context = context;
        }

        public bool ProExists(int proId)
        {
          return _context.Pros.Any(p => p.Id == proId);
        }

        public Pro_player GetPro_PlayerById(int proId)
        {
            return _context.Pros.Where(pr => pr.Id == proId).FirstOrDefault();
        }

        public Pro_player GetPro_PlayerByName(string name)
        {
            return _context.Pros.Where(pr => pr.Name == name).FirstOrDefault();
        }

        public ICollection<Pro_player> GetPro_Players()
        {
            return _context.Pros.OrderBy(pr => pr.Id).ToList();
        }

        public bool CreatePro_player(Pro_player pro_playerCreate)
        {
            _context.Add(pro_playerCreate);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdatePro_Player(Pro_player pro_playerUpdate) 
        {
            _context.Update(pro_playerUpdate);
            return Save();
        }

        public bool  DeletePro_Player(Pro_player proPlayerToDelete)
        {
            _context.Remove(proPlayerToDelete);

            return Save();
        }
   
    }


}