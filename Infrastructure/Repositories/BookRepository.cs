using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
                return id;
            }
            return Guid.Empty;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var list = context.Books.ToList();
            return list;
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Guid> UpdateAsync(Book book)
        {
            Console.WriteLine(book.Id);
            var existingBook = await context.Books.FindAsync(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.PublicationDate = book.PublicationDate;
                await context.SaveChangesAsync();
                return book.Id;
            }
            return Guid.Empty;
        }
    }
}
