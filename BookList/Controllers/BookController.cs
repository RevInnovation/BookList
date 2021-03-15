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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookController(IBookService bookService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<PaginationResponse<BookDto>> Get(int page_size = 10, int current_page = 1, Sort sort = 0, string column = null, string author_id = null)
        {
            BookPaginationDto books = await _bookService.Find(page_size, current_page, sort, column, author_id);
            return PaginationResponse<BookDto>.Get(_httpContextAccessor, books.Total, page_size, current_page, sort, books.Books);
        }

        [HttpPost]
        public async Task<Response<BookDto>> Add([FromBody] CreateBookDto book)
        {
            BookDto createdBook = await _bookService.Add(book);
            return Response<BookDto>.Post(_httpContextAccessor, createdBook);
        }

        [HttpPatch]
        public async Task<Response<BookDto>> Update(Guid id, [FromBody] CreateBookDto book)
        {
            BookDto updatedBook = await _bookService.Update(id, book);
            return Response<BookDto>.Patch(_httpContextAccessor, updatedBook);
        }

        [HttpDelete]
        public async Task<Response<BookDto>> Remove(Guid id)
        {
            BookDto deletedBook = await _bookService.Remove(id);
            return Response<BookDto>.Delete(_httpContextAccessor, deletedBook);
        }
    }
}
