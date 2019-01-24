using ChengQ.BLL;
using ChengQ.BLL.Admin;
using ChengQ.Common;
using ChengQ.Entity.Admin;
using ChengQ.Web.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChengQ.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        #region 视图层
        public IActionResult Index()
        {
            //var auth = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //if (auth.Succeeded)
            //{
            //    var v = auth.Principal.FindAll("user_id").FirstOrDefault().Value;
            //}
            ViewBag.username = ((ClaimsIdentity)this.User.Identity).FindFirst("user_name").Value;
            ViewBag.userimg = ((ClaimsIdentity)this.User.Identity).FindFirst("user_img").Value;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Main()
        {
            return View();
        }
        /// <summary>
        /// 文章列表
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns></returns>
        public IActionResult AddArticle()
        {
            return View();
        }

        /// <summary>
        /// 编辑文章
        /// </summary>
        /// <returns></returns>
        public IActionResult EditArticle(int blog_article_id=0)
        {
            ViewBag.blog_article_id = blog_article_id;
            return View();
        }

        #endregion

        #region  接口层
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpwd"></param>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ApiBlogsLogin(string username = "", string userpwd = "", string ReturnUrl = "/admin/home/index")
        {
            var model = await new BlogUserBLL().GetModel(username, userpwd);
            if (model != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("user_id", model.id.ToString()));
                identity.AddClaim(new Claim("user_name", model.username));
                identity.AddClaim(new Claim("user_type", model.usertype.ToString()));
                identity.AddClaim(new Claim("user_img", model.userimg));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return Json(new Response(ResponseCode.RspSuccessed, ReturnUrl, "登录成功"));
            }
            else
            {
                return Json(new Response(ResponseCode.RspFailed, "账号密码不正确"));
            }

        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="returnurl"></param>
        /// <returns></returns>
        public async Task<IActionResult> Logout(string returnurl = "/admin/home/login")
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(returnurl ?? "~/");
        }

        /// <summary>
        /// 文章分页
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetArticlePageList(int pageIndex = 1, int pageSize = 20, string filter = "")
        {
            return Json(await new BlogArticleBLL().GetArticlePageList(pageIndex, pageSize, filter));
        }
        [HttpPost]
        public async Task<IActionResult> ArticleAdd(BlogArticleAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(this.ModelState.GetAllModelStateErrors());
            }
            if (model != null)
            {
                model.user_id = Int32.Parse((((ClaimsIdentity)User.Identity).FindFirst("user_id").Value));
                model.user_name = ((ClaimsIdentity)User.Identity).FindFirst("user_name").Value;
            }
            return Json(await new BlogArticleBLL().ArticleAdd(model));
        }

        /// <summary>
        /// 删除 文章
        /// </summary>
        /// <param name="blog_article_id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ArticleDelete(int blog_article_id = 0)
        {
            return Json(await new BlogArticleBLL().ArticleDelete(blog_article_id));
        }
        #endregion

        #region 上传图片
        /// <summary>
        /// 文件上传
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                return Json(await new AliyuOssBLL().FileUpload(file.OpenReadStream(), file.ContentType, file.FileName));
            }
            return Json(new UploadImgEntity());
        }
        /// <summary>
        /// kind文件上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> FileUploadKindEditor(IFormFile imgFile)
        {
            
            if (imgFile != null)
            {
                return Json(await new AliyuOssBLL().FileUploadKindEditor(imgFile.OpenReadStream(), imgFile.ContentType, imgFile.FileName));
            }
            return Json(new UploadImgEntity());
        }
        /// <summary>
        /// GetModel
        /// </summary>
        /// <param name="blog_article_id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetModelArticle(int blog_article_id=0)
        {
            return Json(await new BlogArticleBLL().GetModelArticle(blog_article_id));
        }

        [HttpPost]
        public async Task<IActionResult> ArticleUpdate(BlogArticleUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(this.ModelState.GetAllModelStateErrors());
            }
           
            return Json(await new BlogArticleBLL().ArticleUpdate(model));
        }
        #endregion

    }
}