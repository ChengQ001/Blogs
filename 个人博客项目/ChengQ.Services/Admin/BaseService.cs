using ChengQ.Common;
using ChengQ.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Services.Admin
{
   public  class BaseService
    {
        public OperateSqlHelper db;
        public BaseService()
        {
            db = new OperateSqlHelper(DatabaseType.MySql, ReadConfig.ReadConnect());
        }
    }
}
