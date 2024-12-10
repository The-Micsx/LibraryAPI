using LibraryAPI.ActionClass.Book;
using LibraryAPI.ActionClass.HelperClass.DTO;
using LibraryAPI.Contecst;
using LibraryAPI.Interfes;

namespace LibraryAPI.ActionClass
{
    public class BookClass : IBook
    {
        private readonly LibraryContext _context;
        public BookClass(LibraryContext context) => _context = context;

        public bool AddBook(BookCreate Book)
        {
            throw new NotImplementedException();
        }

        public List<string> DeleteBook(long id)
        {
            try
            {
                var book = _context.Books.Find(id);

                if (book == null)
                {
                    return new List<string> { "Книга не найдена" };
                }

                var Loanssions = _context.Loans.Where(us => us.BookId == id).ToList();

                if (Loanssions.Any())
                {
                    _context.RemoveRange(Loanssions);
                    _context.SaveChanges();
                }
                if(book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();

                    return new List<string> { "Книга успешно удалена" };
                }
                Results.NoContent();

                return new List<string> { "Операция завершена" };
            }
            catch 
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
            
        }

        public List<BookDTO> GetBook()
        {
            try
            {
                var data = _context.Books.Select(x => new BookDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Isbn = x.Isbn,
                    Publisher = x.Publisher,
                    YearPublished = x.YearPublished,
                    Genre = x.Genre,
                    CopiesAvailable = x.CopiesAvailable
                }
                ).ToList();
                return (List<BookDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<BookDTO> GetBookOfTitle(string title)
        {
            try
            {
                var data = _context.Books.Where(u => u.Title == title).Select(x => new BookDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Isbn = x.Isbn,
                    Publisher = x.Publisher,
                    YearPublished = x.YearPublished,
                    Genre = x.Genre,
                    CopiesAvailable = x.CopiesAvailable
                }
                ).ToList();
                return (List<BookDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<BookDTO> UpdateBook(string login, BookDTO Book)
        {
            throw new NotImplementedException();
        }
    }
}
