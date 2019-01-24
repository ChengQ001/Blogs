using ChengQ.Common;
using ChengQ.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.Services.Admin
{
    public class BlogUserService:BaseService
    {
        public async Task<T> GetUserModel<T>(string username, string userpwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * ");
            strSql.Append(" from blog_user    ");
            strSql.Append(" where username=@username and userpwd=@userpwd");         //广告ID
            DbParameter[] parameters = {
                        db.CreateDbParameter("@username",username,DbType.String,100),
                         db.CreateDbParameter("@userpwd",userpwd,DbType.String,100)
            };
            return await db.ExecuteSqlAsync<T>(strSql.ToString(), parameters);
        }

    }
}
