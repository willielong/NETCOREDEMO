/****************************************************************************
* 类名：IRepository
* 描述：EF框架的仓储接口-其他类型
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
using System.Text;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Repository
{
    public interface IBaseRepositiry:IUnitOfWork
    {

        /// <summary>
        /// 链接DBContext
        /// </summary>
         //DbContext _dbContext { get; set; }

        #region 增删改
        #region 编辑    
        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        void Edit<TOther>(TOther model) where TOther : class;

        #endregion

        #region 删除
        /// <summary>
        /// 根据查询出的实体删除
        /// </summary>
        /// <param name="model"></param>
        void Delete<TOther>(TOther model) where TOther : class;


        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="model"></param>
        void Delete<TOther>(List<TOther> model) where TOther : class;

        #endregion

        #region 新增
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        void Add<TOther>(TOther model) where TOther : class;

        /// <summary>
        /// 批量增加数据
        /// </summary>
        /// <param name="models"></param>
        void Add<TOther>(List<TOther> models) where TOther : class;
        #endregion
        #endregion
        
    }
}
