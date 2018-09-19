
/****************************************************************************
* 类名：IRepository
* 描述：EF框架的事务仓储接口实现
* 创建人：李文龙
* 创建时间：208.05.06 22:11
* 修改人;李文龙
* 修改时间：208.05.06 22:11
* 修改描述：
* **************************************************************************
*/


using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Repository.Imp
{
    public class UnitOfWork : IUnitOfWork
    {
        public WriteDbContext writeDbContext;

        public UnitOfWork(WriteDbContext _writeDbContext)
        {
            writeDbContext = _writeDbContext;

        }

        /// <summary>
        /// 开始执行事务
        /// </summary>
        /// <returns></returns>
        public virtual DbTransaction BeginTransaction()
        {
            writeDbContext.Database.BeginTransaction();
            return writeDbContext.Database.CurrentTransaction.GetDbTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public virtual void CommitTransaction()
        {
            writeDbContext.SaveChanges();
            writeDbContext.Database.CommitTransaction();
        }

        /// <summary>
        /// 结束事务
        /// </summary>
        public virtual void EndTransaction()
        {
           
           
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <returns></returns>
        public virtual void RollbackTransaction()
        {
            writeDbContext.Database.RollbackTransaction();
        }

        /// <summary>
        /// 进行数据统一提交
        /// </summary>
        /// <returns></returns>
        public virtual int SaverChanges()
        {
            return writeDbContext.SaveChanges();
        }
    }
}
