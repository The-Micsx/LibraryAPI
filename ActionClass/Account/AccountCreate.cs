using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.ActionClass.Account
{
    public class AccountCreate
    {
        
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PositionName { get; set; } 
    }
}
