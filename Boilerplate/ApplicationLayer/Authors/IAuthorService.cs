using Boilerplate.Models.Authors;
using Boilerplate.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.ApplicationLayer.Authors
{
    public interface IAuthorService
    {
        public Task<AuthorPaginationDto> Find(int pageSize, int currentPage, Sort sort);
        public Task<AuthorDto> Add(CreateAuthorDto book);
        public Task<AuthorDto> Update(Guid id, CreateAuthorDto book);
        public Task<AuthorDto> Remove(Guid id);
    }
}
