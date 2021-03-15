using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Authors
{
    public class AuthorDto : CreateAuthorDto
    {
        public Guid Id { get; set; }
        public int TotalBook { get; set; }
    }
}
