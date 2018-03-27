using GZY_CMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GZY_CMS.Core.Repository
{
    public class Repository<T, TD> : IRepository<T, TD> where T : class
          where TD : DbContext
    {

        public Repository(TD data)
        {
            Entities = data;
        }

        /// <summary>
        /// 上下文对象
        /// </summary>
        public TD Entities { get; set; }

        private DbSet<T> _model;

        /// <summary>
        /// 获取实体DbSet
        /// </summary>
        protected DbSet<T> Model
        {
            get { return _model ?? (_model = Entities.Set<T>()); }
        }





        #region                =====查询用方法=====

        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>实体</returns>
        public virtual T Get(Expression<Func<T, bool>> @where)
        {

            return Model.FirstOrDefault(where);


        }

        /// <summary>
        /// 根据传进来的实体类型查询该实体(异步)
        /// </summary>
        /// <typeparam name="TM">实体类型</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual TM Get<TM>(Expression<Func<TM, bool>> @where) where TM : class
        {

            var model = Entities.Set<TM>();
            return model.FirstOrDefault(where);

        }

        /// <summary>
        /// 根据条件查询实体(异步)
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>实体</returns>
        public async virtual Task<T> GetAsync(Expression<Func<T, bool>> @where)
        {

            return await Model.FirstOrDefaultAsync(where);


        }

        /// <summary>
        /// 根据条件查询实体集合(需自行tolist,自行异步)
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> @where)
        {

            return Model.AsNoTracking().Where(where);

        }

        /// <summary>
        /// 根据条件查询实体集合(需自行tolist,自行异步)
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public async virtual Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> @where)
        {

            return await Task.Run(() => Model.AsNoTracking().Where(where));

        }


        /// <summary>
        /// 根据传进来的实体类型查询该实体的集合
        /// </summary>
        /// <typeparam name="TM">实体类型</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IQueryable<TM> GetList<TM>(Expression<Func<TM, bool>> @where) where TM : class
        {

            var model = Entities.Set<TM>();
            return model.AsNoTracking().Where(where);

        }
        /// <summary>
        /// 根据传进来的实体类型查询该实体(异步)
        /// </summary>
        /// <typeparam name="TM">实体类型</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public async virtual Task<TM> GetAsync<TM>(Expression<Func<TM, bool>> @where) where TM : class
        {

            var model = Entities.Set<TM>();
            return await model.FirstOrDefaultAsync(where);

        }

        /// <summary>
        /// 根据条件查询实体数量
        /// </summary>
        /// <typeparam name="TM">实体类型</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual int Cout<TM>(Expression<Func<TM, bool>> @where) where TM : class
        {
            try
            {
                var model = Entities.Set<TM>();
                return model.AsNoTracking().Count(where);
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 根据条件查询实体数量(异步)
        /// </summary>
        /// <typeparam name="TM">实体类型</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public async virtual Task<int> CoutAsync<TM>(Expression<Func<TM, bool>> @where) where TM : class
        {
            try
            {
                var model = Entities.Set<TM>();
                return await model.AsNoTracking().CountAsync(where);
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// 根据条件查询实体数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async virtual Task<int> Count(Expression<Func<T, bool>> @where)
        {
            try
            {
                var model = Entities.Set<T>();
                return await model.AsNoTracking().CountAsync(where);
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return -1;
            }
        }

        #endregion


        #region ====添加用方法====
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual bool Add(T m)
        {
            try
            {

                Model.Add(m);
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 添加实体(异步)
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public async virtual Task<bool> AddAsync(T m)
        {
            try
            {

                Model.Add(m);
                await Entities.SaveChangesAsync();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据类型添加实体
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <param name="tm"></param>
        /// <returns></returns>
        public virtual bool Add<TM>(TM tm) where TM : class
        {
            try
            {
                var model = Entities.Set<TM>();
                model.Add(tm);
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbex)
            {
                //Log.Error(dbex + dbex.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual bool AddRange<TM>(IEnumerable<TM> m) where TM : class
        {

            try
            {
                var model = Entities.Set<TM>();
                model.AddRange(m);
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 批量添加实体(异步)
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public async virtual Task<bool> AddRangeAsync(IEnumerable<T> m)
        {

            try
            {
                Model.AddRange(m);
                await Entities.SaveChangesAsync();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }

        #endregion


        #region ====修改用方法====
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool Update(T t)
        {

            try
            {

                Model.Attach(t);
                Entities.Entry(t).State = EntityState.Modified;
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 批量修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool UpdateRange(IEnumerable<T> m)
        {

            try
            {
                foreach (var item in m)
                {
                    Model.Attach(item);
                    Entities.Entry(item).State = EntityState.Modified;
                }
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 批量修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool UpdateRange<TM>(IEnumerable<TM> m) where TM : class
        {

            try
            {
                var model = Entities.Set<TM>();
                foreach (var item in m)
                {

                    model.Attach(item);
                    Entities.Entry(item).State = EntityState.Modified;
                }
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 修改实体(异步)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async virtual Task<bool> UpdateAsync(T t)
        {

            try
            {

                Model.Attach(t);
                Entities.Entry(t).State = EntityState.Modified;
                await Entities.SaveChangesAsync();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据类型修改实体
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <param name="tm"></param>
        /// <returns></returns>
        public virtual bool Update<TM>(TM tm) where TM : class
        {
            try
            {
                var model = Entities.Set<TM>();
                model.Attach(tm);
                Entities.Entry(tm).State = EntityState.Modified;
                Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }

        ///// <summary>
        ///// 批量更新数据
        ///// </summary>
        ///// <param name="where">更新数据的条件 如:u => u.FirstName == "firstname"</param>
        ///// <param name="ex">更新的值 如:u=>new User{FirstName = "newfirstname"}</param>
        ///// <returns>返回影响的条数</returns>
        //public virtual int Update(Expression<Func<T, bool>> @where, Expression<Func<T, T>> ex)
        //{
        //    try
        //    {
        //        return Model.Where(where).Update(ex);
        //    }
        //    catch (InvalidOperationException dbEx)
        //    {
        //        //Log.Error(dbEx + dbEx.Message);
        //        return -1;
        //    }
        //    catch (Exception e)
        //    {
        //        // Log.Error(e + e.Message);
        //        return -1;
        //    }
        //}

        ///// <summary>
        ///// 批量更新数据(异步)
        ///// </summary>
        ///// <param name="where">更新数据的条件 如:u => u.FirstName == "firstname"</param>
        ///// <param name="ex">更新的值 如:u=>new User{FirstName = "newfirstname"}</param>
        ///// <returns>返回影响的条数</returns>
        //public async virtual Task<int> UpdateAsync(Expression<Func<T, bool>> @where, Expression<Func<T, T>> ex)
        //{
        //    try
        //    {
        //        return await Model.Where(where).UpdateAsync(ex);
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        //Log.Error(dbEx + dbEx.Message);
        //        return -1;
        //    }
        //    catch (Exception e)
        //    {
        //        // Log.Error(e + e.Message);
        //        return -1;
        //    }
        //}

        #endregion


        #region ===事务====
        /// <summary>
        /// 运行基本事务,返回bool值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public bool RunTransaction(Action<DbSet<T>> model)
        {

            using (var transaction = Entities.Database.BeginTransaction())
            {
                try
                {
                    model.Invoke(Model);
                    Entities.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (InvalidOperationException dbEx)
                {
                    //Log.Error("EXEC RunTransaction Error:" + dbEx + dbEx.Message);
                    transaction.Rollback();
                    return false;
                }
                catch (Exception ex)
                {
                    //Log.Error("EXEC RunTransaction Error:" + ex + ex.Message);
                    transaction.Rollback();
                    return false;

                }
            }

        }


        ///// <summary>
        ///// 运行系统级事务,返回bool值(效率级低,慎用)
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>

        //public bool RunSopeTransaction(Action<DbSet<T>> model)
        //{

        //    using (TransactionScope transaction = new TransactionScope())
        //    {
        //        try
        //        {
        //            model.Invoke(Model);
        //            Entities.SaveChanges();
        //            transaction.Complete();
        //            return true;
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {
        //            //Log.Error("EXEC RunTransaction Error:" + dbEx + dbEx.Message);
        //            transaction.Dispose();
        //            return false;
        //        }
        //        catch (Exception ex)
        //        {
        //            //Log.Error("EXEC RunTransaction Error:" + ex + ex.Message);
        //            transaction.Dispose();
        //            return false;

        //        }
        //    }

        //}
        /// <summary>
        /// 运行基本事务,返回bool值(异步)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<bool> RunTransactionAsync(Action<DbSet<T>> model)
        {

            using (var transaction = Entities.Database.BeginTransaction())
            {
                try
                {
                    model.Invoke(Model);
                    await Entities.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (InvalidOperationException dbEx)
                {
                    //Log.Error("EXEC RunTransaction Error:" + dbEx + dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    //Log.Error("EXEC RunTransaction Error:" + ex + ex.Message);
                    transaction.Rollback();
                    return false;

                }
            }

        }
        #endregion

        #region======删除用方法====
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool Remove(T t)
        {
            try
            {
                Model.Remove(t);
                Entities.SaveChanges();

            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;

        }

        /// <summary>
        /// 删除实体(异步)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async virtual Task<bool> RemoveAsync(T t)
        {
            try
            {
                Model.Remove(t);
                await Entities.SaveChangesAsync();

            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;

        }

        /// <summary>
        /// 根据类型删除实体
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual bool Remove<TM>(TM m) where TM : class
        {
            try
            {
                var model = Entities.Set<TM>();
                model.Attach(m);
                model.Remove(m);
                Entities.SaveChanges();

            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        ///批量删除实体
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual int RemoveRange(IEnumerable<T> m)
        {

            try
            {
                Model.RemoveRange(m);
                return Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return -1;
            }

        }

        /// <summary>
        ///批量删除实体(异步)
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public async virtual Task<int> RemoveRangeAsync(IEnumerable<T> m)
        {

            try
            {
                Model.RemoveRange(m);
                return await Entities.SaveChangesAsync();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return -1;
            }

        }


        /// <summary>
        /// 根据类型批量删除实体
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <param name="tmMs"></param>
        /// <returns></returns>
        public virtual int RemoveRange<TM>(IEnumerable<TM> tmMs) where TM : class
        {
            try
            {
                var model = Entities.Set<TM>();
                model.RemoveRange(tmMs);
                return Entities.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //Log.Error(dbEx + dbEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //Log.Error(ex + ex.Message);
                return -1;

            }

        }
        #endregion

    }
}
