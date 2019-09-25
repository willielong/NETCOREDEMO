using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Workflow.comm;
using Workflow.Entity.Imp.DataBase;
using Workflow.Repository;
using Workflow.Repository.Imp;

namespace Workflow.Business.Imp.BaseBehavior
{

    public class ReadBaseBehavior<T> where T : class, new()
    {
        public readonly IReadRepository<T> repository;
        public ReadBaseBehavior()
        {
            repository = new ReadRepository<T>();

        }
        public ReadBaseBehavior(IReadRepository<T> _repository)
        {
            repository = _repository;
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
        public virtual async Task<List<TOther>> Page<TOther>(StringBuilder sb, int page, int size, List<SqlParameter> parameters = null)
            where TOther : class, new()
        {
            return await Task.Run(() =>
            {
                string json = repository.Page(sb.ToString(), "sort", page, size, "DESC", parameters.ToArray()).ToJsonString();
                return json.ToEntity<List<TOther>>();
            });
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="TOther">结果类型</typeparam>
        /// <typeparam name="TQuery">条件类型</typeparam>
        /// <param name="query">查询条件</param>
        public virtual async Task<List<TOther>> Query<TOther>(StringBuilder sb, List<SqlParameter> parameters = null)
            where TOther : class, new()
        {
            return await Task.Run(() =>
            {
                string json = repository.Select(sb.ToString(), parameters.ToArray()).ToJsonString();
                return json.ToEntity<List<TOther>>();
            });
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual async Task<T> Get(object Id)
        {

            switch (repository)
            {
                case null: return null;
                default:
                    return await Task.Run(() =>
                    {
                        return repository.Get(Id);
                    });

            }
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> All()
        {
            switch (repository)
            {
                case null: return null;
                default:
                    return await repository.All().ToListAsync();

            }
            
        }

    }

    public class WriteBaseBehavior<T> where T : class, new()
    {
        public readonly IWriteRepository<T> repository;
        public WriteBaseBehavior()
        {
            repository = new WriteRepository<T>();
        }
        public WriteBaseBehavior(IWriteRepository<T> _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async void Update(T entity)
        {

            switch (repository)
            {
                case null: break;
                default:
                    await Task.Run(() => { repository.Edit(entity); }); break;

            }
        }


        /// <summary>
        /// 添加单条数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async void Add(T entity)
        {
            switch (repository)
            {
                case null: break;
                default:
                    await Task.Run(() => { repository.Add(entity); });
                    break;
            }

        }

        /// <summary>
        ///  添加多条条数据
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual async void Add(List<T> entitys)
        {
            switch (repository)
            {
                case null: break;
                default:
                    await Task.Run(() => { repository.Add(entitys); });
                    break;
            }
        }
    }
}
