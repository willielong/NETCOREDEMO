/****************************************************************************
* 类名：ICompanyBusiness
* 描述：单位的业务接口
* 创建人：Author
* 创建时间：208.05.14 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/


using System;
using System.Collections.Generic;
using System.Text;



namespace WorkFlow.Business.Company
{
    using Workflow.comm;
    #region 引用其他类
    using Workflow.Entity.Imp;
    using Workflow.Repository;
    #endregion

    public interface ICompanyBusiness
    {

        #region Other
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        Company Single();
        #endregion

        #region 操作数据模块
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Add(Company data);

        /// <summary>
        /// 进行数据修改
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Company data);

        /// <summary>
        /// 进行数据删除-逻辑删除
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        bool Delete(object criteria);


        /// <summary>
        /// 进行数据删除-物理删除
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        bool PhysicDelete(object criteria);

        #endregion

        #region 查询模块

        /// <summary>
        /// 获取单位列表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<Company> Page(QueryCriteria criteria);

        /// <summary>
        /// 获取单位列表的条数
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        int Count(QueryCriteria criteria);

        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Company Single(object criteria);
        
        /// <summary>
        /// 获取树形结构
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<Company> GetTreeUnit(object criteria);

        #endregion
    }
}
