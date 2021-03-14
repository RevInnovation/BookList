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
        public async Task<PaginationResponse<BookDto>> Get(int PageSize = 10, int CurrentPage = 1, Sort Sort = 0)
        {
            BookPaginationDto books = await _bookService.Find(PageSize, CurrentPage, Sort);

            return PaginationResponse<BookDto>.Get(books.Total, PageSize, CurrentPage, Sort, books.Books);
        }

        [HttpPost]
        public async Task<BookDto> Add([FromBody] CreateBookDto createBook)
        {
            BookDto book = await _bookService.Add(createBook);
            return book;
        }

        [HttpPatch]
        public async Task<BookDto> Update(Guid id, [FromBody] CreateBookDto createBookDto)
        {
            BookDto book = await _bookService.Update(id, createBookDto);
            return book;
        }

        [HttpDelete]
        public async Task<BookDto> Remove(Guid id)
        {
            BookDto book = await _bookService.Remove(id);
            return book;
        }
    }
}
