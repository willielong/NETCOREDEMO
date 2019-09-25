
/****************************************************************************
* 类名：IRepository
* 描述：EF框架的事务仓储接口实现
* 创建人：Author
* 创建时间：208.05.06 22:11
* 修改人;Author
* 修改时间：208.05.06 22:11
* 修改描述：
* **************************************************************************
*/


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Workflow.comm;
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
        /// 无参数的构造函数
        /// </summary>
        /// <param name="_writeDbContext"></param>
        public UnitOfWork()
        {
            writeDbContext = new WriteDbContext();

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
            writeDbContext.Database.CurrentTransaction.Dispose();
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
