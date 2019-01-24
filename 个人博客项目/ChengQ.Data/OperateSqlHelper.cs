using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ChengQ.Data
{
    /// <summary>
    /// 数据库类别
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// 数据库类型：SqlServer
        /// </summary>
        SqlServer,
        /// <summary>
        /// 数据库类型：MySql
        /// </summary>
        MySql,
        /// <summary>
        /// 数据库类型：Oracle
        /// </summary>
        Oracle,
        /// <summary>
        /// 数据库类型：Access
        /// </summary>
        Access,
        /// <summary>
        /// 数据库类型：SQLite
        /// </summary>
        SQLite
    }
    /// <summary>
    /// 数据库执行库 ChengQ
    /// </summary>
    public class OperateSqlHelper
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        private DatabaseType dataBaseType { get; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string ConnectionString { get; set; }
        /// <summary>
        /// 数据访问对象
        /// </summary>
        private IDBHelper db = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="_DbType"></param>
        /// <param name="_connectionString"></param>
        public OperateSqlHelper(DatabaseType _DbType, string _connectionString)
        {
            this.dataBaseType = _DbType;
            this.ConnectionString = _connectionString;
            switch (dataBaseType)
            {
                case DatabaseType.SqlServer:
                    db = new MsSqlDBHelper(ConnectionString);
                    break;
                case DatabaseType.MySql:
                    db = new MySqlDBHelper(ConnectionString);
                    break;
                case DatabaseType.Oracle:
                    break;
                case DatabaseType.Access:
                    break;
                case DatabaseType.SQLite:
                    break;
                default:
                    break;
            }
        }

        #region 执行SQL语句，返回影响的记录数

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params DbParameter[] parameters)
        {
            return db.ExecuteSql(SQLString, parameters);
        }

        /// <summary>
        /// 异步执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>影响的记录数</returns>
        public async Task<int> ExecuteSqlAsync(string SQLString, params DbParameter[] parameters)
        {
            return await db.ExecuteSqlAsync(SQLString, parameters);
        }

        #endregion

        #region 得到首行首列

        /// <summary>  
        /// 得到首行首列  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="parms"></param>  
        /// <returns></returns>  
        public object ExecuteScalar(string sql, params DbParameter[] parameters)
        {
            return db.ExecuteScalar(sql, parameters);
        }

        /// <summary>  
        /// 得到首行首列  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="parms"></param>  
        /// <returns></returns>  
        public async Task<object> ExecuteScalarAsync(string sql, params DbParameter[] parameters)
        {
            return await db.ExecuteScalarAsync(sql, parameters);
        }

        #endregion

        #region  执行查询语句，返回FirstOrDefault

        /// <summary>
        /// 执行查询语句，返回FirstOrDefault
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DbParameter</returns>
        public T ExecuteSql<T>(string SQLString, params DbParameter[] parameters)
        {
            return db.ExecuteSql<T>(SQLString, parameters);
        }

        /// <summary>
        /// 异步执行查询语句，返回FirstOrDefault
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DbParameter</returns>
        public async Task<T> ExecuteSqlAsync<T>(string SQLString, params DbParameter[] parameters)
        {
            return await db.ExecuteSqlAsync<T>(SQLString, parameters);
        }

        #endregion

        #region  执行查询，返回数据实体结果集

        /// <summary>
        /// 执行查询，返回数据实体结果集
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>返回数据实体结果集</returns>
        public IEnumerable<T> Query<T>(string SQLString, params DbParameter[] parameters)
        {
            return db.Query<T>(SQLString, parameters);
        }

        /// <summary>
        /// 执行查询，返回数据实体结果集
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>返回数据实体结果集</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string SQLString, params DbParameter[] parameters)
        {
            return await db.QueryAsync<T>(SQLString, parameters);
        }

        #endregion

        #region 执行存储过程,无返回结果集  

        /// <summary>
        /// 执行存储过程,无返回结果集  
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        public int ExecuteProc(string procName, params DbParameter[] parameters)
        {
            return db.ExecuteProc(procName, parameters);
        }

        /// <summary>
        /// 异步执行存储过程,无返回结果集  
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        public async Task<int> ExecuteProcAsync(string procName, params DbParameter[] parameters)
        {
            return await db.ExecuteProcAsync(procName, parameters);
        }

        #endregion

        #region  执行存储过程,返回数据实体结果集 IEnumerable

        /// <summary>
        /// 执行存储过程,返回数据实体结果集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        public IEnumerable<T> QueryProc<T>(string proName, params DbParameter[] parameters)
        {
            return db.QueryProc<T>(proName, parameters);
        }

        /// <summary>
        /// 异步执行存储过程,返回数据实体结果集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryProcAsync<T>(string proName, params DbParameter[] parameters)
        {
            return await db.QueryProcAsync<T>(proName, parameters);
        }

        #endregion

        #region  执行多条SQL语句，实现数据库事务。

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句（CommandText:sql语句，Parameters:DbParameter[]）</param>
        public bool ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        {
            return db.ExecuteSqlTran(cmdList);
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句（CommandText:sql语句，Parameters:DbParameter[]）</param>
        public async Task<bool> ExecuteSqlTranAsync(List<CommandInfo> cmdList)
        {
            return await db.ExecuteSqlTranAsync(cmdList);
        }

        #endregion

        #region 分页 未实现
        /// <summary>
        /// 分页为实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="primaryKey"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageCount"></param>
        /// <param name="total"></param>
        /// <param name="columns"></param>
        /// <param name="sortAsc"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetPagingDataAsync<T>(string source, int pageNo, int pageSize, string primaryKey, out int currentPage, out int pageCount, out int total,
        string columns = "*", string sortAsc = "<=", string filter = "", string orderBy = "")
        {

            return db.GetPagingDataAsync<T>(source, pageNo, pageSize, primaryKey, out currentPage, out pageCount, out total,
         columns, sortAsc = "<=", filter, orderBy);

        }

        /// <summary>
        /// 分页为实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="primaryKey"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageCount"></param>
        /// <param name="total"></param>
        /// <param name="columns"></param>
        /// <param name="sortAsc"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPagingData<T>(string source, int pageNo, int pageSize, string primaryKey, out int currentPage, out int pageCount, out int total, string columns = "*", string sortAsc = "<=", string filter = "", string orderBy = "")
        {
            return db.GetPagingData<T>(source, pageNo, pageSize, primaryKey, out currentPage, out pageCount, out total, columns, sortAsc = "<=", filter, orderBy);
        }

        public DbParameter CreateDbParameter(string paramName, object value, DbType dbType, int Size = 8, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return db.CreateDbParameter(paramName, value, dbType, Size, parameterDirection);
        }
        #endregion
    }
}
