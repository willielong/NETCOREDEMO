/****************************************************************************
* 类名：DepartmentBehavior
* 描述：部门信息的业务接口-底层类-数据库操作类
* 创建人：李文龙
* 创建时间：2018.07.11 17：28
* 修改人;李文龙
* 修改时间：2018.07.11 17：28
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workflow.Business.Imp.BaseBehavior;

namespace Workflow.Business.Imp.Department
{
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;
    using Workflow.comm;
    using Workflow.Entity.Imp;
    using Workflow.Repository;
    using Workflow.Repository.Imp;

    public class DepartmentBehavior : BaseBehavior<Department>
    {
        public DepartmentBehavior(DbContext dbContext) : base(dbContext)
        {
        }

        #region 查询模块
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public override async Task<List<Department>> All()
        {
            return await repository.All().Include("users").ToListAsync();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<TOther> Get<TOther>(object Id) where TOther : class, new()
        {
            return Task.Run(() =>
            {
                return repository.Single(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [branched], [unitId], [isTree] FROM [dbo].[Department] WHERE ognId = '" + Id + "'") as TOther;
            });
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Department> Single(object Id)
        {
            string id = Id.ToString();
            string[] tableName = new string[] { "users" };
            return await repository.QueryJoin((o => o.ognId == Id.ToString()), tableName).LastOrDefaultAsync();

        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<List<Department>> Gets(object Id)
        {
            return await repository.QueryWhere(o => o.ognId == Id.ToString()).Include("users").ToListAsync();
        }

        /// <summary>
        /// 根据父级编号获取部门列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<Department>> GetDepartmentsByParentId(object parentId) {
            return await repository.QueryWhere(o => o.parentId == parentId.ToString()).Include("users").ToListAsync();
        }

        /// <summary>
        /// 获取数据-分页
        /// </summary>
        /// <typeparam name="TOther">结果类型</typeparam>
        /// <typeparam name="TQuery">条件类型</typeparam>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public List<TOther> Page<TOther>(QueryCriteria criteria)
            where TOther : class, new()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [branched], [unitId], [isTree] FROM [dbo].[Department]  WHERE 1=1");
            if (criteria != null)
            {
                sb.Append(" and ognName like '%'+ @ognName+'%'");
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string value = string.Format("%{0}%", criteria.name);
            parameters.Add(new SqlParameter("@ognName", criteria.name));
            return base.Page<TOther>(sb, criteria.page, criteria.size, parameters).Result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="TOther">结果类型</typeparam>
        /// <typeparam name="TQuery">条件类型</typeparam>
        /// <param name="query">查询条件</param>
        public List<TOther> Query<TOther>(QueryCriteria criteria)
            where TOther : class, new()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [branched], [unitId], [isTree] FROM [dbo].[Department] WHERE 1=1");
            if (criteria != null)
            {
                sb.Append(" and ognName like '%'+ @ognName+'%'");
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string value = string.Format("%{0}%", criteria.name);
            parameters.Add(new SqlParameter("@ognName", criteria.name));
            return base.Query<TOther>(sb, parameters).Result;
        }
        #endregion

        #region 操作模块
        /// <summary>
        /// 删除多条数据-物理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async void PhysicalDelete(string[] ids)
        {
            await Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE  FROM dbo.Department WHERE ognId in('+@ognId+');   ");           
                SqlParameter parameter = new SqlParameter("@ognId", "'" + string.Join(",", ids).Replace(",", "','") + ",");
                repository.Delete(sb.ToString(), new SqlParameter[] { parameter });
            });
        }

        /// <summary>
        /// 删除一条数据-物理删除
        /// </summary>
        /// <param name="prKey"></param>
        public async void PhysicalDelete(object prKey)
        {
            await Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE  FROM dbo.Department WHERE ognId=@ognId;   ");
                SqlParameter parameter = new SqlParameter("@ognId", prKey);
                repository.Delete(sb.ToString(), new SqlParameter[] { parameter });
            });
        }

        /// <summary>
        /// 删除多条数据-逻辑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async void LogicalDelete(string[] ids, int enable = 0)
        {
            await Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE dbo.Department SET enable=@enable  WHERE ognId in('+@ognId+');   ");
                SqlParameter parameter = new SqlParameter("@ognId", "'" + string.Join(",", ids).Replace(",", "','") + ",");
                SqlParameter parameter1 = new SqlParameter("@enable", enable);
                repository.Delete(sb.ToString(), new SqlParameter[] { parameter, parameter1 });
            });
        }

        /// <summary>
        /// 删除一条数据-逻辑删除
        /// </summary>
        /// <param name="prKey"></param>
        public async void LogicalDelete(object prKey, int enable = 0)
        {
            await Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE dbo.Department SET enable=@enable WHERE ognId=@ognId;   ");
                //sb.Append("DELETE  FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId=@ognId);   ");
                //sb.Append("DELETE FROM dbo.UserKey WHERE ognId IN(SELECT ognId FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId=@ognId)); ");
                SqlParameter parameter = new SqlParameter("@ognId", prKey);
                SqlParameter parameter1 = new SqlParameter("@enable", enable);
                repository.Delete(sb.ToString(), new SqlParameter[] { parameter, parameter1 });
            });
        }


        
        #endregion
    }
}
