using Boilerplate.Models.Books;
using Boilerplate.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.ApplicationLayer.Books
{
    public interface IBookService
    {
        public Task<BookPaginationDto> Find(int pageSize, int currentPage, Sort sort, string column, string authorId);
        public Task<BookDto> Add(CreateBookDto book);
        public Task<BookDto> Update(Guid id, CreateBookDto book);
        public Task<BookDto> Remove(Guid id);

    }
}
