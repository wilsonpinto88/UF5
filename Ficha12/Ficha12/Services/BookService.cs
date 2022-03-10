using Ficha12.Models;
using Microsoft.EntityFrameworkCore;

namespace Ficha12.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext context;

        public BookService(LibraryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            var books = context.Books
                .Include(p => p.Publisher);
            return books;
        }

        public Book GetByISBN(string isbn)
        {
            var book = context.Books
                .Include(b => b.Publisher)
                .SingleOrDefault(b => b.ISBN == isbn);
            return book;
        }

        public Book Create(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void DeleteByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public void Update(string isbn, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(string isbn, int publisher)
        {
            throw new NotImplementedException();
        }
    }
}
