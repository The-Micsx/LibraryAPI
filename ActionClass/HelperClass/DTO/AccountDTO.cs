using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.ActionClass.HelperClass.DTO
{
    public class AccountDTO
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PositionName { get; set; } = null!;

    }
}
