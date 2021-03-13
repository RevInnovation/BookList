using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Books
{
    public class BookPaginationDto
    {
        public int Total { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
    }
}
