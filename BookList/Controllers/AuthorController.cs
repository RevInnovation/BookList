using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.ApplicationLayer.Authors;
using Boilerplate.Models.Authors;
using Boilerplate.Models.Pagination;
using Boilerplate.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Webservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<PaginationResponse<AuthorDto>> Get(int page_size = 10, int current_page = 1, Sort sort = 0, string column = null)
        {
            AuthorPaginationDto author = await _authorService.Find(page_size, current_page, sort, column);

            return PaginationResponse<AuthorDto>.Get(author.Total, page_size, current_page, sort, author.Authors);
        }

        [HttpPost]
        public async Task<AuthorDto> Add([FromBody] CreateAuthorDto author)
        {
            AuthorDto createdAuthor = await _authorService.Add(author);
            return createdAuthor;
        }

        [HttpPatch]
        public async Task<AuthorDto> Update(Guid id, [FromBody] CreateAuthorDto author)
        {
            AuthorDto createdAuthor = await _authorService.Update(id, author);
            return createdAuthor;
        }

        [HttpDelete]
        public async Task<AuthorDto> Remove(Guid id)
        {
            AuthorDto book = await _authorService.Remove(id);
            return book;
        }
    }
}
