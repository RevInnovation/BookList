using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boilerplate.Helpers.Sorting
{
    public static class DynamicSorting
    {
        public static IEnumerable<T> SortColumn<T>(IEnumerable<T> datas, int sort, System.Reflection.PropertyInfo column)
        {
            switch (sort)
            {
                case 1:
                    datas = datas.OrderBy(x => column.GetValue(x));
                    break;
                case 2:
                    datas = datas.OrderByDescending(x => column.GetValue(x));
                    break;
                default:
                    datas = datas.OrderBy(x => column.GetValue(x));
                    break;
            }

            return datas;
        }
        public static IEnumerable<T> SortJoinColumn<T, TKey>(IEnumerable<T> datas, int sort, Func<T, TKey> columnSelector)
        {
            switch (sort)
            {
                case 1:
                    datas = datas.OrderBy(columnSelector);
                    break;
                case 2:
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
