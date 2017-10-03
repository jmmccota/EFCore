using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Data
{
    public class DbInitialize
    {
        public static void Initialize(LibraryContext ctx)
        {
            ctx.Database.EnsureCreated();
        }
    }
}
