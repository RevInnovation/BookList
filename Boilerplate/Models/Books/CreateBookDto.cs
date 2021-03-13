using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boilerplate.Models.Books
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
