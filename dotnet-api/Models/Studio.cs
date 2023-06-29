namespace dotnet_api.Models {
 
  class Studio {
    
   public int Id {get;set;}

   public string Name {get;set;}

   public string CreationDay {get;set;}

   public ICollection<Game> Games {get;set;}

  }

}