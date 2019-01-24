using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Entity.Admin
{
    public  class BlogArticleEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int blog_article_id { get; set; }
        /// <summary>
        /// 文章封面
        /// </summary>
        public string  blog_article_img { get; set; }
        /// <summary>
        /// 文章标签
        /// </summary>
        public string blog_article_label { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string blog_article_title { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 发布人ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string blog_article_content { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string blog_article_details { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int  blog_article_num { get; set; }
        /// <summary>
        /// 点赞
        /// </summary>
        public int blog_article_good { get; set; }
        /// <summary>
        /// 发布人名字
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 评论量
        /// </summary>
        public int blog_article_write { get; set; }
        /// <summary>
        /// 文章类别
        /// </summary>
        public int blog_article_type { get; set; }
        /// <summary>
        /// 文章类别名字
        /// </summary>
        public string blog_article_type_name { get; set; }
        /// <summary>
        /// 排序order
        /// </summary>
        public int order_num { get; set; }
    }
}
