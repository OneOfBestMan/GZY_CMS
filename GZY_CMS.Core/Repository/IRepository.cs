using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GZY_CMS.Core.Repository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T, TD>
         where T : class
         where TD : DbContext
    {

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="m">实体</param>
        /// <returns>是否执行成功</returns>
        bool Add(T m);

        /// <summary>
        /// 添加TM类型的实体
        /// </summary>
        /// <typeparam name="TM">TM类型的实体</typeparam>
        /// <param name="tm">实体</param>
        /// <returns>是否执行成功</returns>
        bool Add<TM>(TM tm) where TM : class;

        /// <summary>
        /// 异步添加实体
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        Task<bool> AddAsync(T m);
        bool AddRange<TM>(IEnumerable<TM> m) where TM : class;
        Task<bool> AddRangeAsync(IEnumerable<T> m);
        Task<int> Count(Expression<Func<T, bool>> where);
        int Cout<TM>(Expression<Func<TM, bool>> where) where TM : class;
        Task<int> CoutAsync<TM>(Expression<Func<TM, bool>> where) where TM : class;
        T Get(Expression<Func<T, bool>> where);
        TM Get<TM>(Expression<Func<TM, bool>> where) where TM : class;
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<TM> GetAsync<TM>(Expression<Func<TM, bool>> where) where TM : class;
        IQueryable<T> GetList(Expression<Func<T, bool>> where);
        IQueryable<TM> GetList<TM>(Expression<Func<TM, bool>> where) where TM : class;
        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> where);
        bool Remove(T t);
        bool Remove<TM>(TM m) where TM : class;
        Task<bool> RemoveAsync(T t);
        int RemoveRange(IEnumerable<T> m);
        int RemoveRange<TM>(IEnumerable<TM> tmMs) where TM : class;
        Task<int> RemoveRangeAsync(IEnumerable<T> m);
        //int Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> ex);
        bool Update(T t);
        bool Update<TM>(TM tm) where TM : class;
        bool UpdateRange(IEnumerable<T> t);
       // bool UpdateRange<TM>(IEnumerable<TM> tm) where TM : class;

        //Task<int> UpdateAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> ex);
        Task<bool> UpdateAsync(T t);
       // bool RunSopeTransaction(Action<DbSet<T>> model);
        bool RunTransaction(Action<DbSet<T>> model);
        Task<bool> RunTransactionAsync(Action<DbSet<T>> model);
    }
}
