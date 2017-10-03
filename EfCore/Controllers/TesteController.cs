using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;
using Persistence.Models;
using Persistence.Services;

namespace EfCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TesteController : Controller
    {
        private BookService BookService;
        private AuthorService AuthorService;
        public TesteController(LibraryContext ctx)
        {
            BookService = new BookService(ctx);
            AuthorService = new AuthorService(ctx);
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly-created TodoItem</returns>
        /// <response code="201">Returns the newly-created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet]
        public string Povoa()
        {
            var b = new Book
            {
                Author = new Author { Name = "Joao", MailId = "2" },
                Description = "Meu livro",
                Title = "Livro"
            };
            BookService.Salvar(b);
            return b.BookId.ToString();
        }

        [HttpGet]
        public ICollection<Book> ListarTodos()
        {
            return BookService.ObterTodos();
        }

        [HttpPut]
        public Book PutLivro([FromBody]Book value)
        {
            BookService.Salvar(value);
            return value;
        }

        [HttpDelete("{id}")]
        public void DeleteLivro(int id)
        {
            BookService.ExcluirPorId(id);
        }

        [HttpGet]
        public ICollection<Author> AutoresComMais10Livros()
        {
            return AuthorService.ListarAutoresComMaisDe10Livros();
        }

    }
}
