using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.ActionClass.HelperClass.DTO
{
    public class BookDTO
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Isbn { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public int YearPublished { get; set; }

        public string Genre { get; set; } = null!;

        public int CopiesAvailable { get; set; }
    }
}
