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

                        Platform = new Platform()
                        {
                         Name = "Play station",
                         CreationTime = new DateTime(1993,9,11)
                        }
                    },
                     new GamePlatform()
                    {
                        Game = new Game()
                        {
                            Title = "Elden Ring",
                            ReleaseDate = new DateTime(1923,2,2),
                            Pro_Players = new List<Pro_player>()
                            {
                                new Pro_player {Name = "GameMan", StartDate = new DateTime(1999,2,4)},
                                // Pro_player = new Pro_player(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Pro_player {Name = "Ninja", StartDate = new DateTime(1997,4,4)},
                                // Pro_player = new Pro_player(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Pro_player {Name = "Tyler2", StartDate = new DateTime(1994,4,4)}
                                // Pro_player = new Pro_player(){ FirstName = "Jessica", LastName = "McGregor" } },
                            },
                            Studio = new Studio()
                           {
                            Name = "Ubisoft",
                            CreationDay = new DateTime(1990,3,3)
                           }
                        },

                        Platform = new Platform()
                        {
                         Name = "Nintendo Switch",
                         CreationTime = new DateTime(1993,9,11)
                        }
                    },
                      new GamePlatform()
                    {
                        Game = new Game()
                        {
                            Title = "Fortnite",
                            ReleaseDate = new DateTime(1903,1,1),
                            Pro_Players = new List<Pro_player>()
                            {
                                new Pro_player {Name = "UnknownXarmy", StartDate = new DateTime(1999,2,4)},
                                // Pro_player = new Pro_player(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Pro_player {Name = "Cloakzy", StartDate = new DateTime(1997,4,4)},
                                // Pro_player = new Pro_player(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Pro_player {Name = "Bugha", StartDate = new DateTime(1994,4,4)}
                                // Pro_player = new Pro_player(){ FirstName = "Jessica", LastName = "McGregor" } },
                            },
                            Studio = new Studio()
                           {
                            Name = "Epic Games",
                            CreationDay = new DateTime(1990,3,3)
                           }
                        },

                        Platform = new Platform()
                        {
                         Name = "PC",
                         CreationTime = new DateTime(1993,9,11)
                        }
                    }

                    };
                dataContext.GamePlatforms.AddRange(GamePlatforms);
                dataContext.SaveChanges();
            }
        }
    }
}

