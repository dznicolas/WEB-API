using WebAPI.Model;

namespace WebAPI.Repositories
{
    public interface IBookRepository
    {
        // Criação de Métodos de assinaturas
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(int Id);

        Task<Book> Create(Book book);

        Task Update(Book book);

        Task Delete(int Id);


    }
}
