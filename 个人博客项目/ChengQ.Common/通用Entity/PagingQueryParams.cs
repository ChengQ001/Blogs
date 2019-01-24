using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Common
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PagingQueryParams
    {
        /// <summary>
        /// 获取或设置需要返回的字段，默认*返回所有字段
        /// </summary>
        public string Columns { get; set; }

        /// <summary>
        /// 获取或设置查询的表名
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 获取或设置表的主键
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// 获取或设置查询条件where表达式
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 获取或设置排序表达式
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// [不再需要此参数] 获取或设置排序方式，ASC时是>=或DESC时是<=
        /// </summary>
        [Obsolete("不再需要此参数")]
        public string SortAsc { get; set; }

        /// <summary>
        /// 获取或设置页码，从1开始
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 获取或设置每页数据记录大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 返回符合当前查询条件的记录总数
        /// </summary>
        public int RecordCount { get; set; }
    }
}
