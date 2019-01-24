using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Common
{
    /// <summary>
    /// 分页格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingDataList<T>
    {
        public PagingDataList()
        {
            items = new List<T>();
        }
        private IEnumerable<T> items;
        /// <summary>
        /// 当前页数据记录
        /// </summary>
        public IEnumerable<T> Items
        {
            get { return items; }
            set { items = value; }
        }

        /// <summary>
        /// 每页数据大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页码，从1开始
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 数据页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 数据总记录数
        /// </summary>
        public int Total { get; set; }
    }
}
