using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;
using Persistence.Models;

namespace EfCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        private LibraryContext db;

        public ValuesController(LibraryContext ctx)
        {
            db = ctx;
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
            db.Add(b);
            db.SaveChanges();
            return b.BookId.ToString();

        }
        // GET api/values
        [HttpGet("Todos", Name = "GetAll")]
        public ICollection<Book> Get()
        {

            return db.Book//.Where(x => x.BookId > 10)
                .ToList();
        }
        [HttpGet]
        public ICollection<Book> ListarMaior()
        {

            return db.Book.Where(x => x.BookId > 10)
                .ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void PostLivro([FromBody]Book value)
        {
            db.Add(value);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteLivro(int id)
        {
            db.Remove(db.Book.FirstOrDefault(x => x.BookId == id));
            db.SaveChanges();
        }
    }
}
