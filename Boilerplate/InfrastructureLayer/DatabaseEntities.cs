using Boilerplate.DomainLayer.Authors;
using Boilerplate.DomainLayer.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.InfrastructureLayer
{
    public class DatabaseEntities : DbContext
    {
        public DatabaseEntities(DbContextOptions<DatabaseEntities> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<Author>();
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}
