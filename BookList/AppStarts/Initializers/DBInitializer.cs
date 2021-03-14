using Boilerplate.DomainLayer.Authors;
using Boilerplate.DomainLayer.Books;
using Boilerplate.InfrastructureLayer;
using Boilerplate.Models.Authors;
using Boilerplate.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Webservice.AppStarts.Initializer
{
    public class DBInitializer
    {
        public static void Initialize(DatabaseEntities context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Author author = Author.Create(new CreateAuthorDto
            {
                Name = "J.K. Rowling"
            });

            context.Authors.Add(author);
            context.SaveChanges();

            List<Book> books = new List<Book>
            {
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("1997-06-26"),
                    Title = "Harry Potter and the Philosopher's Stone"
                }),
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("1998-07-02"),
                    Title = "Harry Potter and the Chamber of Secret"
                }),
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("1999-07-08"),
                    Title = "Harry Potter and the Prisoner of Azkaban"
                }),
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("2000-07-08"),
                    Title = "Harry Potter and the Goblet of Fire"
                }),
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("2003-06-21"),
                    Title = "Harry Potter and the Order of the Phoenix"
                }),
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("2005-07-16"),
                    Title = "Harry Potter and the Half-Blood Prince"
                }),
                Book.Create(new CreateBookDto
                {
                    AuthorId = author.Id,
                    ReleaseDate = DateTime.Parse("2007-07-21"),
                    Title = "Harry Potter and the Deathly Hollows"
                }),
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            context.Database.Migrate();
        }
    }
}
