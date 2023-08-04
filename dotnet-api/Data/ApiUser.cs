using Microsoft.AspNetCore.Identity;

namespace dotnet_api.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
