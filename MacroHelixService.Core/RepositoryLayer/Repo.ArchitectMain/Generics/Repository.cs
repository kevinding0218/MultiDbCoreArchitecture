using Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ArchitectMain.Generics
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IUnitOfWork where TEntity : class
    {
        protected IUserInfo _userInfo;
        protected DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public Repository(IUserInfo userInfo, DbContext context)
        {
            _userInfo = userInfo;
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        #region READ
        public async Task<TEntity> GetSingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null) query = query.Where(predicate);

            if (disableTracking) query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate">x => x.FirstName = "Bob"</param>
        /// <param name="count"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            int count = 0,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null) query = query.Where(predicate);

            if (count != 0) query = query.Take(count);

            if (disableTracking) query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        #endregion

        #region Unit Of Work
        public async Task<int> CommitChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
