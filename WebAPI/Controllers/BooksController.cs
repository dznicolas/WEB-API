using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    // Buscar as rotas dentro das controllers
    [Route("api/[controller]")]
    [ApiController]

    // Herdar a Controller
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet] // Listar
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }


        [HttpGet("{id}")] // Buscar
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost] // Inserir
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")] // Deletar

        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);

            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();


        }

        [HttpPut] // Update
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest();

            await _bookRepository.Update(book);

            return NoContent();
        }
    }
}