using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Business.Imp.BaseBehavior;

namespace Workflow.Business.Imp.Company.Behavior
{
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Workflow.comm;
    using Workflow.Entity.Imp;
    using Workflow.Entity.Imp.DataBase;

    public class ReadBehavior : ReadBaseBehavior<Company>
    {
        public ReadBehavior(ReadDbContext dbContext) : base(dbContext)
        {
        }
        #region 查询模块
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<TOther> Get<TOther>(object Id) where TOther : class, new()
        {
            return Task.Run(() =>
            {
                return repository.Single(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [isTree] FROM [Company] WHERE ognId =@ognId", new SqlParameter[] { new SqlParameter("@ognId", Id) }) as TOther;
            });
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Company> Single(object Id)
        {
            //return Task.Run(() =>
            //{
            string id = Id.ToString();
            string[] tableName = new string[] { "Departments" };
            //var data = repository.QueryJoin((o => o.ognId == Id.ToString()), tableName).ToList();
            return await repository.QueryJoin((o => o.ognId == Id.ToString()), tableName).LastOrDefaultAsync();
            // return repository.Single(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [isTree] FROM [Company] WHERE ognId = '"+Id+"'") as TOther;
            //});
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<List<Company>> Gets(object Id)
        {
            return await repository.QueryWhere(o => o.ognId == Id.ToString()).Include("Departments").ToListAsync();
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
            sb.Append(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [isTree] FROM [Company] WHERE 1=1");
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
            sb.Append(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [isTree] FROM [Company] WHERE 1=1");
            if (criteria != null)
            {
                sb.Append(" and ognName like '%'+ @ognName+'%'");
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string value = string.Format("%{0}%", criteria.name);
            parameters.Add(new SqlParameter("@ognName", criteria.name));
            return base.Query<TOther>(sb, parameters).Result;
        }
        public async Task<object> own()
        {
            //return await repository.All().Include("Departments").ToListAsync();
            return await Task.Run(() => repository.QueryProc("SELECT * FROM dbo.Company"));
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public override async Task<List<Company>> All()
        {
            return await repository.All().Include("Departments").ToListAsync();
            // return await repository.T_SQL("SELECT * FROM dbo.Company").Include("Departments").ToListAsync();
        }
        #endregion
    }
}
