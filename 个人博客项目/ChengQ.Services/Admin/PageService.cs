using ChengQ.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.Services.Admin
{
    public class PageService : BaseService
    {
        public async Task<PagingDataList<T>> PageList<T>(PagingQueryParams param)
        {
            PagingDataList<T> result = new PagingDataList<T>();
            int currentPage = 0;
            int total = 0;
            int pageCount = 0;
            result.Items = await db.GetPagingDataAsync<T>(param.Source, param.CurrentPage, param.PageSize, param.PrimaryKey, out currentPage, out pageCount, out total, param.Columns, param.SortAsc, param.Filter, param.OrderBy);
            result.CurrentPage = currentPage;
            result.PageCount = pageCount;
            result.PageSize = param.PageSize;
            result.Total = total;
            return result;
        }
    }
}

