using Boilerplate.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boilerplate.Helpers.Sorting
{
    public static class DynamicSorting
    {
        public static IEnumerable<T> SortColumn<T>(IEnumerable<T> datas, Sort sort, System.Reflection.PropertyInfo column)
        {
            switch (sort)
            {
                case Sort.Ascending:
                    datas = datas.OrderBy(x => column.GetValue(x));
                    break;
                case Sort.Descending:
                    datas = datas.OrderByDescending(x => column.GetValue(x));
                    break;
                default:
                    datas = datas.OrderBy(x => column.GetValue(x));
                    break;
            }

            return datas;
        }
        public static IEnumerable<T> SortJoinColumn<T, TKey>(IEnumerable<T> datas, Sort sort, Func<T, TKey> columnSelector)
        {
            switch (sort)
            {
                case Sort.Ascending:
                    datas = datas.OrderBy(columnSelector);
                    break;
                case Sort.Descending:
                    datas = datas.OrderByDescending(columnSelector);
                    break;
                default:
                    datas = datas.OrderBy(columnSelector);
                    break;
            }

            return datas;
        }
    }
}
