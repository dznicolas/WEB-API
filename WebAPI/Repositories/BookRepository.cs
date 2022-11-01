using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Repositories
{
    // Herdar interface
    public class BookRepository : IBookRepository
    {
        // Readonly leitura da classe, sem implementações
        public readonly BookContext _context;


        // Construtor
        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            // Async permite realizar várias execuções ao mesmo tempo, gerenciando todos os registros que estão sendo feitos
            // await é um "comando" para o código ficar esperando pela conclusão de uma tarefa e continuar a execução normal permitindo que outras execuções possam acontecer simultaneamente
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int id)
        {
            // Find --> Buscar por aquele registro
            var bookDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookDelete);
            await _context.SaveChangesAsync(); // Ação para salvar a alteração
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync(); // Listagem de dados
        }

        public async Task<Book> Get(int id)
        {
            // Buscar o id
            return await _context.Books.FindAsync(id);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified; // Atualizar Base de dados
            await _context.SaveChangesAsync();
        }
    }
}
