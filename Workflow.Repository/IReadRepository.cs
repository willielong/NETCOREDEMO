/****************************************************************************
* 类名：IWriteRepositiry
* 描述：EF框架的仓储接口-只读
* 创建人：Author
* 创建时间：208.08.10 15:33
* 修改人;Author
* 修改时间：208.05.06 15:33
* 修改描述：
* **************************************************************************
*/


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Workflow.Repository
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        #region 查询


        /// <summary>
        /// 使用拉姆达表达式获取单个数据，获取第一条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(object id);

        /// <summary>
        /// 根据SQL语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        TEntity Single(object sql, SqlParameter[] param = null);

        /// <summary>
        /// 单表查询-全部数据
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> QueryWhere(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        IQueryable<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames);

        /// <summary>
        /// 升序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="IsQueryOrderBy"></param>
        /// <returns></returns>
        IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector);

        /// <summary>
        /// 降序查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        IQueryable<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector);

        /// <summary>
        /// 升序分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <returns></returns>
        IQueryable<TEntity> OrderByPage<TKey>(int pageIndex, int pagesize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector);


        /// <summary>
        /// 降序分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <returns></returns>
        IQueryable<TEntity> OrderByDescendingPage<TKey>(int pageIndex, int pagesize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector);


        /// <summary>
        /// 进行数据查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        IQueryable<Dictionary<object, object>> T_SQL(string sql, SqlParameter[] pamrs = null);



        /// <summary>
        /// 不分页的执行存储过程查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        object QueryProc(string procSql, SqlParameter[] pamrs = null);


        /// <summary>
        /// 分页的进行SQL语句进行数据查询
        /// </summary>
        /// <typeparam name="TResult">返回的类型</typeparam>
        /// <param name="sql">执行sql语句</param> 
        /// <param name="orderCloumn">排序字段</param>
        /// <param name="order">排序字段</param>
        /// <param name="page">传入页数</param>
        /// <param name="size">传入每页显示数量</param>
        /// <param name="pamrs">传入参数</param>
        /// <returns></returns>
        object Page(string sql, string orderCloumn, int page = 0, int size = 0, string order = "ASC", SqlParameter[] pamrs = null);

        /// <summary>
        /// 部分页的进行数据查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        object Select(string sql, SqlParameter[] pamrs = null);

        #endregion
        
    }
}
