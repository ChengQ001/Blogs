using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChengQ.Entity.Admin
{
    public class BlogArticleUpdateModel
    {
        [Required(ErrorMessage = "文章ID不能为空.")]
        public int blog_article_id { get; set; }
        /// <summary>
        /// 文章封面
        /// </summary>
        [Required(ErrorMessage = "文章封面不能为空.")]
        public string blog_article_img { get; set; }
        /// <summary>
        /// 文章标签
        /// </summary>
        [Required(ErrorMessage = "文章标签不能为空.")]
        public string blog_article_label { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        [Required(ErrorMessage = "文章标题不能为空.")]
        public string blog_article_title { get; set; }
       
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "内容不能为空.")]
        public string blog_article_content { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [Required(ErrorMessage = "摘要不能为空.")]
        public string blog_article_details { get; set; }

        /// <summary>
        /// 文章类别
        /// </summary>
        [Required(ErrorMessage = "文章类别不能为空.")]
        public int blog_article_type { get; set; }
        /// <summary>
        /// 文章类别名字
        /// </summary>
        [Required(ErrorMessage = "文章类别名字不能为空.")]
        public string blog_article_type_name { get; set; }
        /// <summary>
        /// 排序order
        /// </summary>
        [Required(ErrorMessage = "排序order不能为空.")]
        public int order_num { get; set; }
    }
}
