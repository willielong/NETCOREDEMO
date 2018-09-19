
/****************************************************************************
* 类名：IRepository
* 描述：EF框架的事务仓储接口-工作单元
* 创建人：Author
* 创建时间：208.05.06 22:11
* 修改人;Author
* 修改时间：208.05.06 22:11
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Workflow.Repository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 开始执行事务
        /// </summary>
        /// <returns></returns>
        DbTransaction BeginTransaction();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// 结束事务
        /// </summary>
        void EndTransaction();
        #region 统一提交
        int SaverChanges();
        #endregion
    }
}
