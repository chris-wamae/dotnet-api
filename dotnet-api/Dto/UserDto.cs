using System.ComponentModel.DataAnnotations;

namespace dotnet_api.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters",MinimumLength = 8)]
        public string Password { get; set; }
    }
}
