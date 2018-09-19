using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Business.Imp.BaseBehavior;

namespace Workflow.Business.Imp.Department.Behavior
{
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Workflow.comm;
    using Workflow.Entity.Imp;
    using Workflow.Entity.Imp.DataBase;

    public class ReadBehavior : ReadBaseBehavior<Department>
    {
        public ReadBehavior(ReadDbContext dbContext) : base(dbContext)
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
        public async Task<List<Department>> GetDepartmentsByParentId(object parentId)
        {
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
    }
}
