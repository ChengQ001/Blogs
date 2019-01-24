using ChengQ.Common;
using ChengQ.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.Services.Admin
{
    public class BlogArticleService : BaseService
    {
        /// <summary>
        /// 添加文章
        /// </summary>
        public async Task<int> ArticleAdd(BlogArticleAddModel model)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.AppendLine("INSERT INTO blog_article (");
            sql.AppendLine("	blog_article_img,");
            sql.AppendLine("	blog_article_label,");
            sql.AppendLine("	blog_article_title,");
            sql.AppendLine("	user_id,");
            sql.AppendLine("	blog_article_content,");
            sql.AppendLine("	user_name,");
            sql.AppendLine("	blog_article_type,");
            sql.AppendLine("	blog_article_type_name,");
            sql.AppendLine("	blog_article_details,");
            sql.AppendLine("order_num");
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("	(@blog_article_img,");
            sql.AppendLine("	@blog_article_label,");
            sql.AppendLine("	@blog_article_title,");
            sql.AppendLine("	@user_id,");
            sql.AppendLine("	@blog_article_content,");
            sql.AppendLine("	@user_name,");
            sql.AppendLine("	@blog_article_type,");
            sql.AppendLine("	@blog_article_type_name,");
            sql.AppendLine("	@blog_article_details,");
            sql.AppendLine("@order_num)");
            DbParameter[] parameters = {
                        db.CreateDbParameter("@blog_article_img",model.blog_article_img,DbType.String,200),
                        db.CreateDbParameter("@blog_article_label",model.blog_article_label,DbType.String,500),
                        db.CreateDbParameter("@blog_article_title",model.blog_article_title,DbType.String,800),
                        db.CreateDbParameter("@blog_article_content",model.blog_article_content,DbType.String,model.blog_article_content.Length),
                          db.CreateDbParameter("@blog_article_details",model.blog_article_details,DbType.String,model.blog_article_details.Length),
                db.CreateDbParameter("@user_id",model.user_id,DbType.Int32),
                        db.CreateDbParameter("@user_name",model.user_name,DbType.String,50),
                        db.CreateDbParameter("@blog_article_type_name",model.blog_article_type_name,DbType.String,20),
                        db.CreateDbParameter("@blog_article_type",model.blog_article_type,DbType.Int32),
                        db.CreateDbParameter("@order_num",model.order_num,DbType.Int32),
                };
            return await db.ExecuteSqlAsync(sql.ToString(), parameters);
        }

        public async Task<int> ArticleUpdate(BlogArticleUpdateModel model)
        {
            #region
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update blog_article set ");
            strSql.Append(" blog_article_img=@blog_article_img, ");
            strSql.Append(" blog_article_label=@blog_article_label, ");
            strSql.Append(" blog_article_title=@blog_article_title, ");
            strSql.Append(" blog_article_content=@blog_article_content, ");
            strSql.Append(" blog_article_details=@blog_article_details, ");
            strSql.Append(" blog_article_type=@blog_article_type, ");
            strSql.Append(" blog_article_type_name=@blog_article_type_name, ");
            strSql.Append(" order_num=@order_num ");
            strSql.Append(" where blog_article_id=@blog_article_id ");                      //主键ID

            DbParameter[] parameters = {
                        db.CreateDbParameter("@blog_article_img",model.blog_article_img,DbType.String,200),
                        db.CreateDbParameter("@blog_article_label",model.blog_article_label,DbType.String,500),
                        db.CreateDbParameter("@blog_article_title",model.blog_article_title,DbType.String,800),
                        db.CreateDbParameter("@blog_article_content",model.blog_article_content,DbType.String,model.blog_article_content.Length),
                          db.CreateDbParameter("@blog_article_details",model.blog_article_details,DbType.String,model.blog_article_details.Length),
                        db.CreateDbParameter("@blog_article_type_name",model.blog_article_type_name,DbType.String,20),
                        db.CreateDbParameter("@blog_article_type",model.blog_article_type,DbType.Int32),
                        db.CreateDbParameter("@order_num",model.order_num,DbType.Int32),
                           db.CreateDbParameter("@blog_article_id",model.blog_article_id,DbType.Int32),
                };

            return await db.ExecuteSqlAsync(strSql.ToString(), parameters);
            #endregion
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="blog_article_id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int blog_article_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from blog_article ");
            strSql.Append(" where blog_article_id=@blog_article_id ");
            DbParameter[] parameters = {
                        db.CreateDbParameter("@blog_article_id",blog_article_id,DbType.Int32)
                };
            int rows = await db.ExecuteSqlAsync(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blog_article_id"></param>
        /// <returns></returns>
        public async Task<T> GetModel<T>(int blog_article_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *  from blog_article ");
            strSql.Append(" where blog_article_id=@blog_article_id ");
            DbParameter[] parameters = {
                        db.CreateDbParameter("@blog_article_id",blog_article_id,DbType.Int32)
                };
            return await db.ExecuteSqlAsync<T>(strSql.ToString(), parameters);
        }
    }
}
