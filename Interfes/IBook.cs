using LibraryAPI.ActionClass.Book;
using LibraryAPI.ActionClass.HelperClass.DTO;

namespace LibraryAPI.Interfes
{
    public interface IBook
    {
        public List<BookDTO> GetBook();
        public List<BookDTO> GetBookOfTitle(string title);
        public bool AddBook(BookCreate Book);
        public List<BookDTO> UpdateBook(string login, BookDTO Book);
        public List<string> DeleteBook(long id);
    }
}
