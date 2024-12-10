using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.ActionClass.Book
{
    public class BookCreate
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public string Isbn { get; set; } = null!;
        [Required]
        public string Publisher { get; set; } = null!;
        [Required]
        public int YearPublished { get; set; }
        [Required]
        public string Genre { get; set; } = null!;
        [Required]
        public int CopiesAvailable { get; set; }
    }
}
