using Boilerplate.Helpers.Domain;
using Boilerplate.Models.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boilerplate.DomainLayer.Books
{
    [Table("TB_BOOK")]
    public class Book : IAggregateRoot<Guid>
    {
        [Key]
        [Required]
        [Column("ID")]
        public Guid Id { get; protected set; }

        [Required]
        [Column("AUTHOR_ID")]
        public Guid AuthorId { get; protected set; }

        [Required]
        [Column("TITLE")]
        public string Title { get; protected set; }

        [Required]
        [Column("RELEASE_DATE")]
        public DateTime ReleaseDate { get; protected set; }

        public static Book Create(CreateBookDto book)
        {
            return new Book
            {
                Id = Guid.NewGuid(),
                AuthorId = book.AuthorId,
                Title = book.Title,
                ReleaseDate = book.ReleaseDate
            };
        }
    }
}
