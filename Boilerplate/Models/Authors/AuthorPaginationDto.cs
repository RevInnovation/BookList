using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Authors
{
    public class AuthorPaginationDto
    {
        public int Total { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
    }
}
