/****************************************************************************
* 类名：CompanyBehavior
* 描述：单位的业务接口-底层类-数据库操作类
* 创建人：李文龙
* 创建时间：2018.5.14 16：43
* 修改人;李文龙
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Business.Imp.Company
{
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Workflow.Business.Imp.BaseBehavior;
    using Workflow.comm;
    #region 引用其他类
    using Workflow.Entity.Imp;
    using Workflow.Entity.Imp.DataBase;
    using Workflow.Repository;
    using Workflow.Repository.Imp;
    #endregion

    public class CompanyBehavior : BaseBehavior<Company>
    {
        public CompanyBehavior(WriteDbContext dbContext) : base(dbContext)
        {

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
                sb.Append("DELETE  FROM dbo.Company WHERE ognId in('+@ognId+');   ");
                //sb.Append("DELETE  FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId in('+@ognId+'));   ");
                //sb.Append("DELETE FROM dbo.UserKey WHERE ognId IN(SELECT ognId FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId  in('+@ognId+'))); ");               
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
                sb.Append("DELETE  FROM dbo.Company WHERE ognId=@ognId;   ");
                //sb.Append("DELETE  FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId=@ognId);   ");
                //sb.Append("DELETE FROM dbo.UserKey WHERE ognId IN(SELECT ognId FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId=@ognId)); ");
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
                sb.Append("UPDATE dbo.Company SET enable=@enable  WHERE ognId in('+@ognId+');   ");
                //sb.Append("DELETE  FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId in('+@ognId+'));   ");
                //sb.Append("DELETE FROM dbo.UserKey WHERE ognId IN(SELECT ognId FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId  in('+@ognId+'))); ");
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
                sb.Append("UPDATE dbo.Company SET enable=@enable WHERE ognId=@ognId;   ");
                //sb.Append("DELETE  FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId=@ognId);   ");
                //sb.Append("DELETE FROM dbo.UserKey WHERE ognId IN(SELECT ognId FROM dbo.Department WHERE parentId IN(SELECT ognId FROM dbo.Company WHERE ognId=@ognId)); ");
                SqlParameter parameter = new SqlParameter("@ognId", prKey);
                SqlParameter parameter1 = new SqlParameter("@enable", enable);
                repository.Delete(sb.ToString(), new SqlParameter[] { parameter, parameter1 });
            });
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
                return repository.Single(@"SELECT  [enable], [caretor], [crateDate], [modifier], [modifierDate], [ognId], [ognName], [parentId], [head], [c_head], [sort], [virOgn], [isTree] FROM [Company] WHERE ognId =@ognId",new SqlParameter[] { new SqlParameter("@ognId", Id)}) as TOther;
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
    }
}
