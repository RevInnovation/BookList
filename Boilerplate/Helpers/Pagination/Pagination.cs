using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boilerplate.Helpers.Pagination
{
    public static class Pagination
    {
        public static IEnumerable<T> Paging<T>(IEnumerable<T> datas, int currentPage, int pageSize)
        {
            return datas.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
    }
}
