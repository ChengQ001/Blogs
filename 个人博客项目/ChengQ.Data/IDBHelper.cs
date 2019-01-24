using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ChengQ.Data
{
    /// <summary>
    /// 数据库操作接口层
    /// </summary>
    public interface IDBHelper
    {
        #region 执行SQL语句，返回影响的记录数

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        int ExecuteSql(string SQLString, params DbParameter[] parameters);

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        Task<int> ExecuteSqlAsync(string SQLString, params DbParameter[] parameters);

        #endregion

        #region 得到首行首列

        /// <summary>  
        /// 得到首行首列  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="parms"></param>  
        /// <returns></returns>  
        object ExecuteScalar(string sql, params DbParameter[] parameters);

        /// <summary>  
        /// 得到首行首列  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="parms"></param>  
        /// <returns></returns>  
        Task<object> ExecuteScalarAsync(string sql, params DbParameter[] parameters);

        #endregion

        #region  执行查询语句，返回FirstOrDefault

        /// <summary>
        /// 执行查询语句，返回FirstOrDefault
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>DbParameter</returns>
        T ExecuteSql<T>(string SQLString, params DbParameter[] parameters);

        /// <summary>
        /// 异步执行查询语句，返回FirstOrDefault
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>DbParameter</returns>
        Task<T> ExecuteSqlAsync<T>(string SQLString, params DbParameter[] parameters);

        #endregion

        #region  执行查询，返回数据实体结果集

        /// <summary>
        /// 执行查询，返回数据实体结果集
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>DbParameter[]</returns>
        IEnumerable<T> Query<T>(string SQLString, params DbParameter[] parameters);

        /// <summary>
        /// 异步执行查询，返回数据实体结果集
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>DbParameter[]</returns>
        Task<IEnumerable<T>> QueryAsync<T>(string SQLString, params DbParameter[] parameters);

        #endregion

        #region 执行存储过程,无返回结果集

        /// <summary>
        /// 执行存储过程,无返回结果集  
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        int ExecuteProc(string procName, params DbParameter[] parameters);

        /// <summary>
        /// 异步执行存储过程,无返回结果集  
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        Task<int> ExecuteProcAsync(string procName, params DbParameter[] parameters);

        #endregion

        #region  执行存储过程,返回数据实体结果集 IEnumerable

        /// <summary>
        /// 执行存储过程,返回数据实体结果集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        IEnumerable<T> QueryProc<T>(string proName, params DbParameter[] parameters);

        /// <summary>
        /// 异步执行存储过程,返回数据实体结果集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryProcAsync<T>(string proName, params DbParameter[] parameters);

        #endregion

        #region  执行多条SQL语句，实现数据库事务。

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句（CommandText:sql语句，Parameters:DbParameter[]）</param>
        bool ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList);

        /// <summary>
        /// 异步执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句（CommandText:sql语句，Parameters:DbParameter[]）</param>
        Task<bool> ExecuteSqlTranAsync(System.Collections.Generic.List<CommandInfo> cmdList);

        #endregion

        #region
        /// <summary>
        /// GetPagingData 分页数据
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="source">表名</param>
        /// <param name="pageIndex">页码索引(当前页)</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="primaryKey">表的主键</param>
        /// <param name="CurrentPage">返回当前第几页</param>
        /// <param name="PageCount">返回总页数</param>
        /// <param name="Total">返回当前总记录数</param>
        /// <param name="columns">需要返回的字段，默认所有*</param>
        /// <param name="sortAsc">排序方式，ASC时选择>= ，DESC时选择 <=</param>
        /// <param name="filter">过滤条件where表达式，注意不需要where关键字</param>
        /// <param name="orderBy">排序表达式，包含order by...</param>
        /// <returns>返回实体类型IEnumerable</returns>
        IEnumerable<T> GetPagingData<T>(string source, int pageIndex, int pageSize, string primaryKey, out int CurrentPage, out int PageCount, out int Total, string columns = "*", string sortAsc = "<=", string filter = "", string orderBy = "");


        /// <summary>
        /// GetPagingData 分页数据
        /// </summary>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <param name="source">表名</param>
        /// <param name="pageIndex">页码索引(当前页)</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="primaryKey">表的主键</param>
        /// <param name="CurrentPage">返回当前第几页</param>
        /// <param name="PageCount">返回总页数</param>
        /// <param name="Total">返回当前总记录数</param>
        /// <param name="columns">需要返回的字段，默认所有*</param>
        /// <param name="sortAsc">排序方式，ASC时选择>= ，DESC时选择 <=</param>
        /// <param name="filter">过滤条件where表达式，注意不需要where关键字</param>
        /// <param name="orderBy">排序表达式，包含order by...</param>
        /// <returns>返回实体类型IEnumerable</returns>
        Task<IEnumerable<T>> GetPagingDataAsync<T>(string source, int pageIndex, int pageSize, string primaryKey, out int CurrentPage, out int PageCount, out int Total, string columns = "*", string sortAsc = "<=", string filter = "", string orderBy = "");


        #endregion
        /// <summary>
        /// 生成参数
        /// </summary>
        /// <returns></returns>
        DbParameter CreateDbParameter(string paramName, object value, DbType dbType, int Size = 8, ParameterDirection parameterDirection = ParameterDirection.Input);
    }
}
