using System;
using System.Collections.Generic;
using System.Text;
using Persistence.Data;
using Persistence.Models;
using Persistence.Repositorio;

namespace Persistence.Services
{
    public class BookService : RepositoryBase<Book>
    {
        public BookService(LibraryContext ctx) : base(ctx)
        {
        }
    }
}
