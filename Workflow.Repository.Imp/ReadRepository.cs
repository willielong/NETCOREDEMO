using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Workflow.comm;

namespace Workflow.Repository.Imp
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
    { /// <summary>
      /// 数据集
      /// </summary>
        public virtual DbSet<TEntity> DbSets { get; set; }
        private DbContext ReadContext { get; set; }

        /// <summary>
        /// 进行参数构造
        /// </summary>
        /// <param name="_DbContext"></param>
        public ReadRepository(DbContext _DbContext)
        {
            ReadContext = _DbContext;
            DbSets = _DbContext.Set<TEntity>();
        }

        /// <summary>
        /// 进行参数构造
        /// </summary>
        /// <param name="_DbContext"></param>
        public ReadRepository()
        {
            ReadContext = ServiceLocator.readContext;
            DbSets = ReadContext.Set<TEntity>();
        }

        #region 获取单个数据

        /// <summary>
        /// 根据表达式进行数据查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSets.Where(predicate);
        }

        ///
        /// <summary>
        /// 根据主键查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(object id)
        {
            return DbSets.Find(id);
        }

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual TEntity Single(object sql, SqlParameter[] param = null)
        {
            IQueryable<TEntity> entitys;
            if (param != null) entitys = DbSets.FromSql(sql.ToString(), param);
            else entitys = DbSets.FromSql(sql.ToString());
            if (entitys.Count() > 0) return entitys.LastOrDefault();
            else return null;
        }

        #endregion

        #region 查询模块

        public IQueryable<TEntity> All()
        {
            return DbSets.AsQueryable();
        }
        /// <summary>
        /// 根据表达式获取所有数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSets.Where(predicate);
        }

        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames)
        {
            if (tableNames == null && tableNames.Any() == false)
            {
                throw new Exception("缺少连表名称");
            }

            IQueryable<TEntity> query = DbSets;

            foreach (var table in tableNames)
            {
                query = query.Include(table);
            }

            return query.Where(predicate);
        }

        /// <summary>
        /// 升序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            return DbSets.Where(predicate).OrderBy(keySelector);
        }

        /// <summary>
        /// 降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            return DbSets.Where(predicate).OrderByDescending(keySelector);
        }

        /// <summary>
        /// 升序分页查询数据
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pagesize"></param>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> OrderByPage<TKey>(int pageIndex, int pagesize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            return DbSets.Where(predicate).OrderBy(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize);
        }

        /// <summary>
        /// 降分页查询数据
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pagesize"></param>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> OrderByDescendingPage<TKey>(int pageIndex, int pagesize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            return DbSets.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize);
        }
        #endregion

        #region 进行存储过程处理

        /// <summary>
        /// 执行返回带有查询结果的存储过程
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="procSql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public virtual object QueryProc(string procSql, SqlParameter[] pamrs = null)
        {
            return T_SQL(procSql, pamrs);
        }

        /// <summary>
        /// 执行可分页且带有返回集的存储过程
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="procSql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        //public virtual IQueryable<TResult> PageProc<TResult>(string procSql, int page = 0, int size = 0, SqlParameterCollection pamrs = null) where TResult : class
        //{
        //    throw new NotImplementedException();
        //}


        #endregion

        #region 执行sql语句模块

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
        public virtual object Page(string sql, string orderCloumn, int page = 0, int size = 0, string order = "ASC", SqlParameter[] pamrs = null)
        {

            StringBuilder sb = new StringBuilder();

            switch (page)
            {
                case 0: { sb.Append(sql); } break;
                default:
                    {
                        sql = sql.ToLower().Replace("select", "");
                        sb.AppendFormat("SELECT TOP {0} * FROM (", size);
                        sb.AppendFormat("SELECT ROW_NUMBER() OVER(ORDER BY {0} {1}) AS RowNumber,", orderCloumn, order);
                        sb.AppendFormat(sql);
                        sb.AppendFormat(") A WHERE A.RowNumber >{0}*({1}-1)", size, page);
                    }
                    break;
            }
            return T_SQL(sb.ToString(), pamrs);
        }

        /// <summary>
        /// 进行数据的查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public virtual object Select(string sql, SqlParameter[] pamrs = null)
        {
            return T_SQL(sql, pamrs);
        }


        /// <summary>
        /// 进行数据查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public virtual IQueryable<Dictionary<object, object>> T_SQL(string sql, SqlParameter[] pamrs = null)
        {
            //_dbContext.Database.GetDbConnection
            List<Dictionary<object, object>> Results = new List<Dictionary<object, object>>();
            var connection = ReadContext.Database.GetDbConnection() as SqlConnection;
            //using (SqlConnection connenct = connection)
            //{

            //connection.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand(sql.ToString(), connection);
            switch (pamrs)
            {
                case null: break;
                default: { sqlCommand.Parameters.AddRange(pamrs); } break;
            }
            SqlDataAdapter ap = new SqlDataAdapter(sqlCommand);
            DataSet set = new DataSet();
            ap.Fill(set);
            if (set.Tables.Count > 0)
            {
                DataTable dt = set.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<object, object> result = new Dictionary<object, object>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        result.Add(dc.ColumnName, dr[dc]);
                    }
                    Results.Add(result);
                }
            }
            //connection.Dispose();
            return Results.AsQueryable();
            //}
        }


        #endregion
    }
}
