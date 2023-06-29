namespace dotnet_api.Models{
  
  class Platform{
    
    public  int Id {get;set;}

    public  string Name {get;set;}

    public  DateTime CreationTime {get;set;}

    public ICollection<GamePlatform> Games {get;set;}

  }


}