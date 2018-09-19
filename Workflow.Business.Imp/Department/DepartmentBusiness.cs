

/****************************************************************************
* 类名：UserBusiness
* 描述：部门的业务接口-业务类
* 创建人：Author
* 创建时间：2018.5.14 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Business.Imp.Department.Behavior;
using Workflow.comm;
using Workflow.Entity.Imp;
using Workflow.Entity.Imp.DataBase;
using Workflow.Repository.Imp;
using WorkFlow.Business.Department;

namespace Workflow.Business.Imp.Department
{
    public class DepartmentBusiness : UnitOfWork, IDepartmentBusiness
    {
        #region 进行参数的构造
        private WriteBehavior writeBehavior;
        private ReadBehavior readBehavior;

        public DepartmentBusiness(WriteDbContext _writeDbContext, ReadDbContext readDbContext) : base(_writeDbContext)
        {
            ///进行数据库读写分离
            ///进行具体方法实现-写入数据
            if (writeBehavior == null)
            {
                writeBehavior = new WriteBehavior(_writeDbContext);
                //_writeContext = writeContext;
            }
            ///进行具体方法实现-读取
            if (readBehavior == null)
            {
                readBehavior = new ReadBehavior(readDbContext);
            }
        }

        /// <summary>
        /// 无参数的构造函数
        /// </summary>
        public DepartmentBusiness() : base(ServiceLocator.writeContext as WriteDbContext)
        {
            ///进行具体方法实现-写入数据
            if (writeBehavior == null)
            {
                writeBehavior = new WriteBehavior(ServiceLocator.writeContext as WriteDbContext);
            }
            ///进行具体方法实现-读取
            if (readBehavior == null)
            {
                readBehavior = new ReadBehavior(ServiceLocator.readContext as ReadDbContext);
            }
        }

        #endregion


        #region 查询模块


        public List<Entity.Imp.Department> Page(QueryCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public int Count(QueryCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Entity.Imp.Department Single(object criteria)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Imp.Department> GetByParentId(object criteria)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region 操作模块

        public object Add(Entity.Imp.Department data)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entity.Imp.Department data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object criteria)
        {
            throw new NotImplementedException();
        }

        public bool PhysicDelete(object criteria)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
