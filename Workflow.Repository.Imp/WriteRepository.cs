using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Repository.Imp
{
    public class WriteRepository<Tentity> : BaseRepositiry, IWriteRepository<Tentity> where Tentity : class
    {
        /// <summary>
        /// 数据集
        /// </summary>
        public virtual DbSet<Tentity> DbSets { get; set; }
        /// <summary>
        /// 链接DBContext
        /// </summary>
        private DbContext _dbContext { get; set; }

        /// <summary>
        /// 进行参数构造
        /// </summary>
        /// <param name="_writeDbContext"></param>
        public WriteRepository(WriteDbContext _DbContext) : base(_DbContext)
        {
            _dbContext = _DbContext;
            DbSets = _dbContext.Set<Tentity>();
        }

        /// <summary>
        /// 无参数进行参数构造
        /// </summary>
        /// <param name="_writeDbContext"></param>
        public WriteRepository() : base()
        {
            DbSets = _dbContext.Set<Tentity>();
        }


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
