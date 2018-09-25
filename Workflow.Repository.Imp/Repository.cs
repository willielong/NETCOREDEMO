/****************************************************************************
* 类名：IRepository
* 描述：EF框架的仓储接口实现类
* 创建人：Author
* 创建时间：208.05.06 22:11
* 修改人;Author
* 修改时间：208.05.06 22:11
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
using Workflow.Entity.Imp.DataBase;
using Microsoft.EntityFrameworkCore.Query;
using System.Data;
using System.Reflection;
using ServiceStack.Text;

namespace Workflow.Repository.Imp
{
    public class Repository<Tentity> : BaseRepositiry, IRepository<Tentity> where Tentity : class
    {


        /// <summary>
        /// 数据集
        /// </summary>
        public virtual DbSet<Tentity> DbSets { get; set; }

        /// <summary>
        /// 进行参数构造
        /// </summary>
        /// <param name="_writeDbContext"></param>
        public Repository(WriteDbContext _DbContext) : base(_DbContext)
        {
            DbSets = _dbContext.Set<Tentity>();
        }

        /// <summary>
        /// 进行参数构造（无参数构造）
        /// </summary>
        /// <param name="_writeDbContext"></param>
        //public Repository() : base()
        //{
        //    DbSets = _dbContext.Set<Tentity>();
        //}


        #region 获取单个数据

        /// <summary>
        /// 根据表达式进行数据查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<Tentity> Get(Expression<Func<Tentity, bool>> predicate)
        {
            return DbSets.Where(predicate);
        }

        ///
        /// <summary>
        /// 根据主键查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Tentity Get(object id)
        {
            return DbSets.Find(id);
        }

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual Tentity Single(object sql, SqlParameter[] param = null)
        {
            IQueryable<Tentity> entitys;
            if (param != null) entitys = DbSets.FromSql(sql.ToString(), param);
            else entitys = DbSets.FromSql(sql.ToString());
            if (entitys.Count() > 0) return entitys.LastOrDefault();
            else return null;
        }

        #endregion

        #region 查询模块

        public IQueryable<Tentity> All()
        {
            return DbSets.AsQueryable();
        }
        /// <summary>
        /// 根据表达式获取所有数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<Tentity> QueryWhere(Expression<Func<Tentity, bool>> predicate)
        {
            return DbSets.Where(predicate);
        }

        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public virtual IQueryable<Tentity> QueryJoin(Expression<Func<Tentity, bool>> predicate, string[] tableNames)
        {
            if (tableNames == null && tableNames.Any() == false)
            {
                throw new Exception("缺少连表名称");
            }

            IQueryable<Tentity> query = DbSets;

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
        public virtual IQueryable<Tentity> OrderBy<TKey>(Expression<Func<Tentity, bool>> predicate, Expression<Func<Tentity, TKey>> keySelector)
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
        public virtual IQueryable<Tentity> OrderByDescending<TKey>(Expression<Func<Tentity, bool>> predicate, Expression<Func<Tentity, TKey>> keySelector)
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
        public virtual IQueryable<Tentity> OrderByPage<TKey>(int pageIndex, int pagesize, Expression<Func<Tentity, bool>> predicate, Expression<Func<Tentity, TKey>> keySelector)
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
        public virtual IQueryable<Tentity> OrderByDescendingPage<TKey>(int pageIndex, int pagesize, Expression<Func<Tentity, bool>> predicate, Expression<Func<Tentity, TKey>> keySelector)
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
            var connection = _dbContext.Database.GetDbConnection() as SqlConnection;
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
        #region 增删除改
        /// <summary>
        /// 进行数据添加
        /// </summary>
        /// <param name="model"></param>
        public virtual void Add(Tentity model)
        {
            DbSets.Add(model);
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="models"></param>
        /// <param name="models"></param>
        public void Add(List<Tentity> models)
        {
            DbSets.AddRange(models);
        }


        /// <summary>
        /// 进行数据删除
        /// </summary>
        /// <param name="id">主键</param>
        public virtual void Delete(object id)
        {
            Tentity entity = DbSets.Find(id);
            // throw new NotImplementedException();
            Delete(entity);
        }


        /// <summary>
        /// 根据实体删除数据
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(Tentity entity)
        {
            //Tentity entity = DbSets.Find(id);
            // throw new NotImplementedException();
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSets.Attach(entity);
            }
            DbSets.Remove(entity);
        }

        /// <summary>
        /// 进行SQL删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        public virtual bool Delete(object sql, SqlParameter[] param = null)
        {
            if (param != null)
                return _dbContext.Database.ExecuteSqlCommand(sql.ToString(), param) >= 0;
            else return _dbContext.Database.ExecuteSqlCommand(sql.ToString()) >= 0;
        }

        /// <summary>
        /// 批量进行删除
        /// </summary>
        /// <param name="model"></param>
        public virtual void Delete(List<Tentity> model)
        {
            if (_dbContext.Entry(model.FirstOrDefault()).State == EntityState.Detached)
                DbSets.AttachRange(model);
            DbSets.RemoveRange(model);
        }

        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        public virtual void Edit(Tentity model)
        {
            DbSets.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 根据sql语句执行编辑方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual bool Edit(string sql, SqlParameter[] param = null)
        {
            if (param != null)
                return _dbContext.Database.ExecuteSqlCommand(sql.ToString(), param) >= 0;
            else return _dbContext.Database.ExecuteSqlCommand(sql.ToString()) >= 0;
        }

        /// <summary>
        /// 执行增删改的存储过程
        /// </summary>
        /// <param name="procSql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public virtual int ExecuteProc(string procSql, SqlParameter[] pamrs = null)
        {
            switch (pamrs)
            {
                case null: { return _dbContext.Database.ExecuteSqlCommand(procSql); }
                default: return _dbContext.Database.ExecuteSqlCommand(procSql, pamrs);
            }
        }

        /// <summary>
        /// 执行增删改的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        public virtual int Excute(string sql, SqlParameter[] pamrs = null)
        {
            switch (pamrs)
            {
                case null: { return _dbContext.Database.ExecuteSqlCommand(sql); }
                default: return _dbContext.Database.ExecuteSqlCommand(sql, pamrs);
            }
        }

        #endregion
    }
}
