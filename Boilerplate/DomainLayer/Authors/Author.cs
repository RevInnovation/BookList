using Boilerplate.DomainLayer.Books;
using Boilerplate.Helpers.Domain;
using Boilerplate.Models.Authors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boilerplate.DomainLayer.Authors
{
    [Table("TB_AUTHOR")]
    public class Author : IAggregateRoot<Guid>
    {
        [Key]
        [Required]
        [Column("ID")]
        public Guid Id { get; protected set; }

        [Required]
        [Column("Name")]
        public string Name { get; protected set; }
        public virtual IEnumerable<Book> Books { get; protected set; }
        public static Author Create(CreateAuthorDto author)
        {
            return new Author
            {
                Id = Guid.NewGuid(),
                Name = author.Name,
            };
        }
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
