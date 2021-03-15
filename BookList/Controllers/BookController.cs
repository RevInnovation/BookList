using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.ApplicationLayer.Books;
using Boilerplate.Models.Books;
using Boilerplate.Models.Pagination;
using Boilerplate.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Webservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<PaginationResponse<BookDto>> Get(int page_size = 10, int current_page = 1, Sort sort = 0)
        {
            BookPaginationDto books = await _bookService.Find(page_size, current_page, sort);

            return PaginationResponse<BookDto>.Get(books.Total, page_size, current_page, sort, books.Books);
        }

        [HttpPost]
        public async Task<BookDto> Add([FromBody] CreateBookDto book)
        {
            BookDto createdBook = await _bookService.Add(book);
            return createdBook;
        }

        [HttpPatch]
        public async Task<BookDto> Update(Guid id, [FromBody] CreateBookDto book)
        {
            BookDto createdBook = await _bookService.Update(id, book);
            return createdBook;
        }

        [HttpDelete]
        public async Task<BookDto> Remove(Guid id)
        {
            BookDto book = await _bookService.Remove(id);
            return book;
        }
    }
}
