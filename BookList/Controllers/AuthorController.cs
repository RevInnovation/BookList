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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorController(IAuthorService authorService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<PaginationResponse<AuthorDto>> Get(int page_size = 10, int current_page = 1, Sort sort = 0, string column = null)
        {
            AuthorPaginationDto authorPagination = await _authorService.Find(page_size, current_page, sort, column);
            return PaginationResponse<AuthorDto>.Get(_httpContextAccessor, authorPagination.Total, page_size, current_page, sort, authorPagination.Authors);
        }

        [HttpPost]
        public async Task<Response<AuthorDto>> Add([FromBody] CreateAuthorDto author)
        {
            AuthorDto createdAuthor = await _authorService.Add(author);
            return Response<AuthorDto>.Post(_httpContextAccessor, createdAuthor);
        }

        [HttpPatch]
        public async Task<Response<AuthorDto>> Update(Guid id, [FromBody] CreateAuthorDto author)
        {
            AuthorDto updatedAuthor = await _authorService.Update(id, author);
            return Response<AuthorDto>.Patch(_httpContextAccessor, updatedAuthor);
        }

        [HttpDelete]
        public async Task<Response<AuthorDto>> Remove(Guid id)
        {
            AuthorDto deletedAuthor = await _authorService.Remove(id);
            return Response<AuthorDto>.Patch(_httpContextAccessor, deletedAuthor);
        }
    }
}
