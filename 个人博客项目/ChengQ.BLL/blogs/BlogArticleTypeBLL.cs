using ChengQ.Common;
using ChengQ.Entity.Admin;
using ChengQ.Services.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.BLL.blogs
{
    public class BlogArticleTypeBLL
    {
        public async Task<Response> GetArticlePageList(int pageIndex = 0, int pageSize = 0, int type = 0, string filter = "")
        {
            if (pageIndex <= 1)
                pageIndex = 1;
            if (pageSize <= 0)
                pageSize = 20;
            if (type >= 9)
                return new Response(ResponseCode.ReqInvalidParameter, "类别参数错误");
            var param = new PagingQueryParams();
            param.Source = "blog_article";
            param.Columns = "*";
            param.PrimaryKey = "blog_article_id";
            param.OrderBy = "order by blog_article_id desc";
            param.CurrentPage = pageIndex;
            param.PageSize = pageSize;
            param.Filter = string.Format("  blog_article_type={0} ", type);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = CommonHelper.CheckInputStr(filter);
                param.Filter += string.Format("  blog_article_title like  binary '%{0}%' ", filter);
            }
            PagingDataList<BlogArticleEntity> result = await new PageService().PageList<BlogArticleEntity>(param);
            return new Response(ResponseCode.RspSuccessed, result, ResponseMsg.RspSuccessed);
        }
    }
}
