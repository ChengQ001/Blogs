using ChengQ.Common;
using ChengQ.Entity.Admin;
using ChengQ.Services.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.BLL.Admin
{
    /// <summary>
    /// 后台
    /// </summary>
    public class BlogArticleBLL
    {
        private BlogArticleService service;
        public BlogArticleBLL()
        {
            service = new BlogArticleService();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<Response> GetArticlePageList(int pageIndex, int pageSize, string filter = "")
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
            param.OrderBy = "order by blog_article_id desc";
            param.CurrentPage = pageIndex;
            param.PageSize = pageSize;
          
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

        public async Task<Response> ArticleAdd(BlogArticleAddModel model)
        {
            if (model == null)
                return new Response(ResponseCode.ReqInvalidParameter, "请求参数有误");
            if (model.user_id <= 0 || string.IsNullOrEmpty(model.user_name))
                return new Response(ResponseCode.ReqInvalidParameter, "用户标识不正确");
            if (await service.ArticleAdd(model) > 0)
                return new Response(ResponseCode.RspSuccessed, ResponseMsg.RspSuccessed);
            return new Response();
        }

        public async Task<Response> ArticleUpdate(BlogArticleUpdateModel model)
        {
            if (model == null)
                return new Response(ResponseCode.ReqInvalidParameter, "请求参数有误");
            if (await service.ArticleUpdate(model) > 0)
                return new Response(ResponseCode.RspSuccessed, ResponseMsg.RspSuccessed);
            return new Response();
        }

        public async Task<Response> ArticleDelete(int blog_article_id)
        {
            if (blog_article_id <= 0)
                return new Response(ResponseCode.ReqInvalidParameter, "请求参数有误");

            if (await service.Delete(blog_article_id) > 0)
                return new Response(ResponseCode.RspSuccessed, ResponseMsg.RspSuccessed);
            return new Response();
        }

        /// <summary>
        /// 添加Model
        /// </summary>
        /// <param name="blog_article_id"></param>
        /// <returns></returns>
        public async Task<Response> GetModelArticle(int blog_article_id)
        {
            if (blog_article_id <= 0)
                return new Response(ResponseCode.ReqInvalidParameter, "请求参数有误");
            return new Response(ResponseCode.RspSuccessed, await service.GetModel<BlogArticleEntity>(blog_article_id), ResponseMsg.RspSuccessed);

        }
    }
}
