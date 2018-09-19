﻿/****************************************************************************
* 类名：CompanyBusiness
* 描述：单位的业务接口-底层类-业务实现
* 创建人：Author
* 创建时间：208.5.14 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Entity.Imp.DataBase;
using Workflow.Repository;
using WorkFlow.Business.Company;


namespace Workflow.Business.Imp.Company
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using Workflow.Business.Imp.Company.Behavior;
    using Workflow.comm;
    using Workflow.Entity.Imp;
    using Workflow.Repository.Imp;

    public class CompanyBusiness : UnitOfWork, ICompanyBusiness
    {
        #region 进行函数构造
        private WriteBehavior writeBehavior;
        private ReadBehavior readBehavior;

        public CompanyBusiness(WriteDbContext writeContext, ReadDbContext readDbContext) : base(writeContext)
        {
            ///进行具体方法实现-写入数据
            if (writeBehavior == null)
            {
                writeBehavior = new WriteBehavior(writeContext);
            }
            ///进行具体方法实现-读取
            if (readBehavior == null)
            {
                readBehavior = new ReadBehavior(readDbContext);
            }
        }
        public CompanyBusiness() : base(ServiceLocator.writeContext as WriteDbContext)
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

        #region 进行数据操作
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public object Add(Company data)
        {
            data.ognId = Guid.NewGuid().ToString();
            writeBehavior.Add(data);
            SaverChanges();
            return data.ognId;
        }

        /// <summary>
        /// 进行数据删除
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public bool Delete(object criteria)
        {
            try
            {
                BeginTransaction();
                if (criteria is string)
                    writeBehavior.LogicalDelete(criteria);
                else
                    writeBehavior.LogicalDelete(criteria as string[]);
                CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }
        }


        /// <summary>
        /// 进行数据删除-物理删除
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public bool PhysicDelete(object criteria)
        {
            try
            {
                BeginTransaction();
                if (criteria is string)
                    writeBehavior.PhysicalDelete(criteria);
                else
                    writeBehavior.PhysicalDelete(criteria as string[]);
                CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }
        }
        /// <summary>
        /// 进行数据修改
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Company data)
        {
            try
            {
                BeginTransaction();
                data.modifierDate = DateTime.Now;
                writeBehavior.Update(data);
                CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }
        }
        #endregion


        #region 查询模块

        /// <summary>
        /// 获取单位列表的条数
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public int Count(QueryCriteria criteria)
        {
            return readBehavior.Query<Company>(criteria).Count;
        }

        /// <summary>
        /// 获取组织结构树
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<Company> GetTreeUnit(object criteria = null)
        {
            switch (criteria)
            {
                case null: return readBehavior.All().Result;
                default: return new List<Company>() { readBehavior.Single(criteria).Result };
            }
        }

        /// <summary>
        /// 获取单位列表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<Company> Page(QueryCriteria criteria)
        {
            return readBehavior.Page<Company>(criteria);
        }

        public Company Single()
        {
            try
            {
                BeginTransaction();
                var data = readBehavior.Page<Company>(new QueryCriteria() { name = "龙", page = 0, size = 10 });
                ///打开事务              

                var da = readBehavior.own().Result;
                var ss = readBehavior.All().Result;
                Company company = readBehavior.Single("01").Result;
                company.c_head = "lijian";

                writeBehavior.Update(company);
                ///进行事务提交并写入数据
                CommitTransaction();
                return company;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }

        }

        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public Company Single(object criteria)
        {
            return readBehavior.Single(criteria).Result;
        }
        #endregion
    }
}