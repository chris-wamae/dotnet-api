namespace dotnet_api.Models{
  
 public class Platform{
    
    public  int Id {get;set;}

    public  string Name {get;set;}

    public  DateTime CreationTime {get;set;}

    public ICollection<GamePlatform> GamePlatforms {get;set;}

  }


}