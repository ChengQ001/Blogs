using ChengQ.BLL.blogs;
using ChengQ.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChengQ.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //DefaultConnection
            //string str = new ReadConfig("Config/databaseconfig.json").ReadSectionValue("DefaultConnection");
            return View();
        }
        /// <summary>
        /// .net
        /// </summary>
        /// <returns></returns>
        public IActionResult Net()
        {
            return View();
        }

        /// <summary>
        /// 数据库
        /// </summary>
        /// <returns></returns>
        public IActionResult Sql()
        {
            return View();
        }
        /// <summary>
        /// Java
        /// </summary>
        /// <returns></returns>
        public IActionResult Java()
        {
            return View();
        }

        /// <summary>
        /// 其他相关
        /// </summary>
        /// <returns></returns>
        public IActionResult Other()
        {
            return View();
        }
        /// <summary>
        /// 留言版
        /// </summary>
        /// <returns></returns>
        public IActionResult Message()
        {
            return View();
        }

        /// <summary>
        /// 最新文章
        /// </summary>
        /// <returns></returns>
        public IActionResult New()
        {
            return View();
        }
        /// <summary>
        /// 黑科技
        /// </summary>
        /// <returns></returns>
        public IActionResult BlackTechnology()
        {
            return View();
        }

        /// <summary>
        /// 网络安全
        /// </summary>
        /// <returns></returns>
        public IActionResult NetworkSecurity()
        {
            return View();
        }

        /// <summary>
        /// 关于作者
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// 免费资源
        /// </summary>
        /// <returns></returns>
        public IActionResult FreeResources()
        {
            return View();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <returns></returns>
        public IActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// 心情琐事
        /// </summary>
        /// <returns></returns>
        public IActionResult XinQing()
        {
            return View();
        }
        /// <summary>
        /// 程序人生
        /// </summary>
        /// <returns></returns>
        public IActionResult ChengXunRS()
        {
            return View();
        }
        /// <summary>
        /// 捐赠本站
        /// </summary>
        /// <returns></returns>
        public IActionResult JuanZheng()
        {
            return View();
        }

        /// <summary>
        /// 页面详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int id = 0)
        {
            var model= await new BlogArticleBLL().GetModelArticle(id);
            ViewBag.title = model?.blog_article_title;
            ViewBag.content = model?.blog_article_content;
            ViewBag.typename = model?.blog_article_type_name;
            return View();
        }
        #region 接口
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="blog_article_type"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetArticlePageList(int pageIndex = 1, int pageSize = 20, string filter = "", int blog_article_type = 0)
        {
            return Json(await new BlogArticleBLL().GetArticlePageList(pageIndex, pageSize, filter, blog_article_type));
        }

        #endregion

    }
}
