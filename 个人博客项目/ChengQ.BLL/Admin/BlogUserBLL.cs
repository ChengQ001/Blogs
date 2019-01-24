
using ChengQ.Common;
using ChengQ.Entity.Admin;
using ChengQ.Services.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.BLL.Admin
{
    public class BlogUserBLL
    {
        private BlogUserService service;
        public BlogUserBLL()
        {
            service = new BlogUserService();
        }
        public async Task<BlogUserEntity> GetModel(string username, string userpwd)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userpwd))
                return new BlogUserEntity();
            return await service.GetUserModel<BlogUserEntity>(username, userpwd);
        }
    }
}
