using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Entity.Admin
{
    public class BlogUserEntity
    {
        public int id { get; set; }
        public string  username { get; set; }
        public string  userpwd { get; set; }
        public int  usertype { get; set; }
        public string  remark { get; set; }
        public string userimg { get; set; }
    }
}
