


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Business.Imp.BaseBehavior
{
    public interface IBasebavior<T> where T : class, new()
    {
        /// <summary>
        /// 添加单条数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Add(T entity);

        /// <summary>
        ///  添加多条条数据
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        void Add(List<T> entitys);

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(string[] prKey);

        /// <summary>
        /// 删除单条数据
        /// 删除单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(object prKey);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> Get(object prKey);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<TOther> Get<TOther>(object Id) where TOther : class, new();

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<List<T>> Gets(object Id);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<T>> All();

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <typeparam name="TQuery"></typeparam>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<List<TOther>> Page<TOther, TQuery>(TQuery query) where TOther : class, new() where TQuery : class;

        /// <summary>
        /// 部分页的获取数据
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <typeparam name="TQuery"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<List<TOther>> Query<TOther, TQuery>(TQuery query) where TOther : class, new() where TQuery : class;
    }
}
