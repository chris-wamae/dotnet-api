using dotnet_api.Data;

using dotnet_api.Models;

namespace dotnet_api
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.GamePlatforms.Any())
            {
                var GamePlatforms = new List<GamePlatform>()
                {
                    new GamePlatform()
                    {
                        Game = new Game()
                        {
                            Title = "Super Mario",
                            ReleaseDate = new DateTime(1903,1,1),
                            Pro_Players = new List<Pro_player>()
                            {
                                new Pro_player {Name = "Tenz", StartDate = new DateTime(1999,2,4)},
                                // Pro_player = new Pro_player(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Pro_player {Name = "Tfue", StartDate = new DateTime(1997,4,4)},
                                // Pro_player = new Pro_player(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Pro_player {Name = "Tyler1", StartDate = new DateTime(1994,4,4)}
                                // Pro_player = new Pro_player(){ FirstName = "Jessica", LastName = "McGregor" } },
                            },
                            Studio = new Studio()
                           {
                            Name = "Bethesda",
                            CreationDay = new DateTime(1990,3,3)
                           }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Gym = "Brocks Gym",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    }
                    };
                dataContext.GamePlatforms.AddRange(GamePlatforms);
                dataContext.SaveChanges();
            }
        }
    }
}

