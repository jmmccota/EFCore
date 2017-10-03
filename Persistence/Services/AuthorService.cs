using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.Data;
using Persistence.Models;
using Persistence.Repositorio;

namespace Persistence.Services
{
    public class AuthorService : RepositoryBase<Author>
    {
        public AuthorService(LibraryContext ctx) : base(ctx)
        {
        }

        public ICollection<Author> ListarAutoresComMaisDe10Livros()
        {
            return Db.Author.Where(x => x.Books.Count() > 10).ToList();
        }
    }
}
