namespace dotnet_api.Models
{

    public class Studio
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDay { get; set; }

        public ICollection<Game> Games { get; set; }

    }

}