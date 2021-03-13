using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Books
{
    public class BookDto : CreateBookDto
    {
        public Guid Id { get; set; }
    }
}
