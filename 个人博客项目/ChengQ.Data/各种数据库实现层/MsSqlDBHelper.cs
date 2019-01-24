using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChengQ.Data
{
    /// <summary>
    /// MsSql数据访问实现库 ChengQ
    /// </summary>
    public class MsSqlDBHelper : IDBHelper
    {
        #region MyRegion

      
        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        public string cnnstr { get; }

        public MsSqlDBHelper(string connectionString)
        {
            cnnstr = connectionString;
        }

        #region 创建连接
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        private IDbConnection GetConnection()
        {
            IDbConnection cnn = new SqlConnection(cnnstr);
            cnn.Open();
            return cnn;
        }

        #endregion
        #endregion
        #region 执行SQL语句，返回影响的记录数

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params DbParameter[] parameters)
        {
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    int i = con.Execute(SQLString, param);
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 异步执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>影响的记录数</returns>
        public async Task<int> ExecuteSqlAsync(string SQLString, params DbParameter[] parameters)
        {
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return await con.ExecuteAsync(SQLString, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var param = DbParameterToDynamicParameters(parameters);
            object objresult = null;
            try
            {
                using (var conn = GetConnection())
                {
                    objresult = conn.ExecuteScalar(sql, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objresult;
        }

        /// <summary>  
        /// 得到首行首列  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="parms"></param>  
        /// <returns></returns>  
        public async Task<object> ExecuteScalarAsync(string sql, params DbParameter[] parameters)
        {
            var param = DbParameterToDynamicParameters(parameters);
            object objresult = null;
            try
            {
                using (var conn = GetConnection())
                {
                    objresult = await conn.ExecuteScalarAsync(sql, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objresult;
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
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return con.QueryFirstOrDefault<T>(SQLString, param);
                }
            }
            catch (Exception ex)
            {
                //return default(T);
                throw ex;
            }
        }

        /// <summary>
        /// 异步执行查询语句，返回FirstOrDefault
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DbParameter</returns>
        public async Task<T> ExecuteSqlAsync<T>(string SQLString, params DbParameter[] parameters)
        {
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return await con.QueryFirstOrDefaultAsync<T>(SQLString, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return con.Query<T>(SQLString, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行查询，返回数据实体结果集
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>返回数据实体结果集</returns>
        public Task<IEnumerable<T>> QueryAsync<T>(string SQLString, params DbParameter[] parameters)
        {
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return con.QueryAsync<T>(SQLString, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    int result = con.Execute(procName, param, null, null, CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 异步执行存储过程,无返回结果集  
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="param">DbParameter[]</param>
        /// <returns></returns>
        public async Task<int> ExecuteProcAsync(string procName, params DbParameter[] parameters)
        {
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return await con.ExecuteAsync(procName, param, null, null, CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return con.Query<T>(proName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var param = DbParameterToDynamicParameters(parameters);
            try
            {
                using (var con = GetConnection())
                {
                    return await con.QueryAsync<T>(proName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>DbParameter转换成DynamicParameters
        /// DbParameter转换成DynamicParameters
        /// </summary>
        /// <param name="dbparameter"></param>
        /// <returns></returns>
        private DynamicParameters DbParameterToDynamicParameters(DbParameter[] dbparameter)
        {
            var p = new DynamicParameters();
            if (dbparameter != null)
            {
                dbparameter.ToList().ForEach(x => p.Add(
                    name: x.ParameterName,
                    value: x.Value,
                    dbType: x.DbType,
                    direction: x.Direction,
                    size: x.Size
                    ));
            }
            return p;
        }

        #region  执行多条SQL语句，实现数据库事务。

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句（CommandText:sql语句，Parameters:DbParameter[]）</param>
        public bool ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        {
            bool result = true;
            using (var con = GetConnection())
            {
                IDbTransaction trans = con.BeginTransaction();
                try
                {
                    foreach (var cmdinfo in cmdList)
                    {
                        var param = DbParameterToDynamicParameters(cmdinfo.Parameters);
                        con.Execute(cmdinfo.CommandText, param, trans);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    if (con != null && con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }

                    trans.Rollback();
                    result = false;

                }
                finally
                {
                    if (con != null && con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句（CommandText:sql语句，Parameters:DbParameter[]）</param>
        public async Task<bool> ExecuteSqlTranAsync(List<CommandInfo> cmdList)
        {
            bool result = true;
            using (var con = GetConnection())
            {
                IDbTransaction trans = con.BeginTransaction();
                try
                {
                    foreach (var cmdinfo in cmdList)
                    {
                        var param = DbParameterToDynamicParameters(cmdinfo.Parameters);
                        await con.ExecuteAsync(cmdinfo.CommandText, param, trans);
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result = false;
                    throw ex;
                }
                if (con != null && con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return result;
        }

        #endregion

        #region 分页
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
            total = 0;
            pageCount = 0;
            currentPage = 0;

            return null;

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
            if (pageNo <= 0)
            {
                pageNo = 1;
            }
            total = 0;
            pageCount = 0;
            total = 0;
            currentPage = 0;
            pageCount = 0;
            pageSize = 0;


            return null;

        }
        #endregion

        #region 生成参数
        /// <summary>
        /// 生成参数
        /// </summary>
        /// <returns></returns>
        public DbParameter CreateDbParameter(string parameterName, object value, DbType dbType, int size = 8, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            DbParameter mysqlparameter = new SqlParameter();
            mysqlparameter.ParameterName = parameterName;
            mysqlparameter.Value = value;
            mysqlparameter.DbType = dbType;
            mysqlparameter.Size = size;
            mysqlparameter.Direction = parameterDirection;
            return mysqlparameter;

        }
        #endregion
    }
}
