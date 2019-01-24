using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ChengQ.Data
{
    /// <summary>
    ///执行多条SQL语句 Entity
    /// </summary>
    public class CommandInfo
    {
        /// <summary>
        /// Sql语句
        /// </summary>
        public string CommandText;
        /// <summary>
        /// 参数
        /// </summary>
        public System.Data.Common.DbParameter[] Parameters;

        public CommandInfo()
        {

        }
        public CommandInfo(string sqlText, DbParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }
    }
}
