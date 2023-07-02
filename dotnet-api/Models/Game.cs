namespace dotnet_api.Models{

public class Game{
  
public  int Id {get;set;}

public  string Title {get;set;}

public  DateTime ReleaseDate {get;set;}

public  Studio Studio {get;set;}

public  ICollection<Pro_player> Pro_Players {get;set;}

public  ICollection<GamePlatform> GamePlatforms {get;set;}

}

}