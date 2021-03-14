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
        public async Task<PaginationResponse<AuthorDto>> Get(int PageSize = 10, int CurrentPage = 1, Sort Sort = 0)
        {
            AuthorPaginationDto author = await _authorService.Find(PageSize, CurrentPage, Sort);

            return PaginationResponse<AuthorDto>.Get(author.Total, PageSize, CurrentPage, Sort, author.Authors);
        }

        [HttpPost]
        public async Task<AuthorDto> Add([FromBody] CreateAuthorDto createAuthorDto)
        {
            AuthorDto author = await _authorService.Add(createAuthorDto);
            return author;
        }

        [HttpPatch]
        public async Task<AuthorDto> Update(Guid id, [FromBody] CreateAuthorDto createAuthorDto)
        {
            AuthorDto author = await _authorService.Update(id, createAuthorDto);
            return author;
        }

        [HttpDelete]
        public async Task<AuthorDto> Remove(Guid id)
        {
            AuthorDto book = await _authorService.Remove(id);
            return book;
        }
    }
}
