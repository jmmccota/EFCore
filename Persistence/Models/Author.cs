using System.Collections;
using System.Collections.Generic;

namespace Persistence.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string MailId { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}