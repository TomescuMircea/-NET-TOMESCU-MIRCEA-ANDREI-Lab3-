using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Book book);
        Task<Guid> UpdateAsync(Book book);
        Task<Guid> DeleteAsync(Guid id);
    }
}
