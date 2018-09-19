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

    public class WriteBehavior : WriteBaseBehavior<Company>
    {
        public WriteBehavior(WriteDbContext dbContext) : base(dbContext)
        {
        }
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

        #endregion
    }
}
