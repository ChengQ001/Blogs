using ChengQ.Common;
using ChengQ.Entity.Admin;
using ChengQ.Services.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.BLL.blogs
{
    /// <summary>
    /// 首页
    /// </summary>
    public class BlogArticleBLL
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<Response> GetArticlePageList(int pageIndex, int pageSize, string filter = "", int blog_article_type = 0)
        {
            var rsp = new Response();
            if (pageIndex <= 1)
                pageIndex = 1;
            if (pageSize <= 0)
                pageSize = 20;
            var param = new PagingQueryParams();
            param.Source = "blog_article";
            param.Columns = "*";
            param.PrimaryKey = "blog_article_id";
            param.OrderBy = "order by create_time desc";
            param.CurrentPage = pageIndex;
            param.PageSize = pageSize;
            param.Filter = string.Format("  blog_article_type={0}  ", blog_article_type);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = CommonHelper.CheckInputStr(filter);
                param.Filter += string.Format("  blog_article_title like  binary '%{0}%' ", filter);
            }
            PagingDataList<BlogArticleEntity> result = await new PageService().PageList<BlogArticleEntity>(param);
            rsp.data = result;
            rsp.code = ResponseCode.RspSuccessed;
            rsp.message = ResponseMsg.RspSuccessed;
            return rsp;
        }
  
        /// <summary>
        /// 添加Model
        /// </summary>
        /// <param name="blog_article_id"></param>
        /// <returns></returns>
        public async Task<BlogArticleEntity> GetModelArticle(int blog_article_id)
        {
            if (blog_article_id <= 0)
                return new BlogArticleEntity();
            return await new BlogArticleService().GetModel<BlogArticleEntity>(blog_article_id);

        }
    }
}
