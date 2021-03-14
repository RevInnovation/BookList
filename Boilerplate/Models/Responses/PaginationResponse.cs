using Boilerplate.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Responses
{
    public class PaginationResponse<T>
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public int StatusCode { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public Sort Sort { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();

        public static PaginationResponse<T> Get(int total, int pageSize, int currentPage, Sort sort, IEnumerable<T> data)
        {
            return new PaginationResponse<T>
            {
                Message = "Get Request Successful",
                IsError = false,
                StatusCode = 200,
                Total = total,
                PageSize = pageSize,
                CurrentPage = currentPage,
                Data = data
            };
        }
    }
}
