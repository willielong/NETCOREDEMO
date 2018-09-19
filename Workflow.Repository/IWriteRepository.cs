/****************************************************************************
* 类名：IWriteRepositiry
* 描述：EF框架的仓储接口-只写
* 创建人：李文龙
* 创建时间：208.08.10 15:33
* 修改人;李文龙
* 修改时间：208.05.06 15:33
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Workflow.Repository
{
    public interface IWriteRepository<TEntity> : IBaseRepositiry where TEntity : class
    {
        #region 增删改
        #region 编辑    
        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        void Edit(TEntity model);

        /// <summary>
        /// 执行SQL语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        bool Edit(string sql, SqlParameter[] param = null);
        #endregion

        #region 删除
        /// <summary>
        /// 根据查询出的实体删除
        /// </summary>
        /// <param name="model"></param>
        void Delete(TEntity model);

        /// <summary>
        /// 根据主键进行删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        /// 根据SQL语句删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        bool Delete(object sql, SqlParameter[] param = null);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="model"></param>
        void Delete(List<TEntity> model);

        #endregion

        #region 新增
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        void Add(TEntity model);

        /// <summary>
        /// 批量增加数据
        /// </summary>
        /// <param name="models"></param>
        void Add(List<TEntity> models);
        #endregion
        #endregion

        #region 调用存储过程返回一个指定的TResult

        /// <summary>
        /// 执行增删改的存储过程
        /// </summary>
        /// <param name="procSql"></param>
        /// <param name="pamrs"></param>
        /// <returns></returns>
        int ExecuteProc(string procSql, SqlParameter[] pamrs = null);

        #endregion

        #region 进行SQL语句

        /// <summary>
        /// 进行SQL语句处理
        /// </summary>
        /// <typeparam name="TResult">返回的类型</typeparam>
        /// <param name="sql">执行sql语句</param>
        /// <param name="pamrs">传入的参数</param>
        /// <returns></returns>
        int Excute(string sql, SqlParameter[] pamrs = null);

        #endregion
    }
}
