/****************************************************************************
* 类名：IRepository
* 描述：EF框架的直接调用仓储接口实现类
* 创建人：Author
* 创建时间：208.05.10 10:11
* 修改人;Author
* 修改时间：208.05.10 10:11
* 修改描述：
* **************************************************************************
*/




using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Workflow.comm;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Repository.Imp
{
    public class BaseRepositiry :UnitOfWork,IBaseRepositiry
    {
        /// <summary>
        /// 链接DBContext
        /// </summary>
        private DbContext _dbContext { get; set; }


        /// <summary>
        /// 进行构造
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepositiry(WriteDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 无参数的构造函数
        /// </summary>
        public BaseRepositiry() : base()
        {
            _dbContext = new WriteDbContext();
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        public virtual void Add<TOther>(TOther model) where TOther : class
        {
            _dbContext.Set<TOther>().Add(model);
        }

        /// <summary>
        /// 批量增加数据
        /// </summary>
        /// <param name="models"></param>
        public virtual void Add<TOther>(List<TOther> models) where TOther : class
        {
            _dbContext.Set<TOther>().AddRange(models);
        }

        /// <summary>
        /// 根据查询出的实体删除
        /// </summary>
        /// <param name="model"></param>
        public virtual void Delete<TOther>(TOther model) where TOther : class
        {
            if (_dbContext.Entry(model).State == EntityState.Detached)
            {
                _dbContext.Set<TOther>().Attach(model);
            }
            _dbContext.Set<TOther>().Remove(model);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="model"></param>
        public virtual void Delete<TOther>(List<TOther> model) where TOther : class
        {
            if (_dbContext.Entry(model[0]).State == EntityState.Detached)
            {
                _dbContext.Set<TOther>().AttachRange(model);
            }
            _dbContext.Set<TOther>().RemoveRange(model);
        }

        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        public virtual void Edit<TOther>(TOther model) where TOther : class
        {
            _dbContext.Set<TOther>().Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }
     
    }
}
