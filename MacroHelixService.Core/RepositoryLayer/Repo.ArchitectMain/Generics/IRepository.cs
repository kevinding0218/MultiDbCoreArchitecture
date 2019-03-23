using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ArchitectMain.Generics
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region READ
        //var students = repository.Get(x => x.FirstName = "Bob",q => q.OrderBy(s => s.LastName));
        Task<TEntity> GetSingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            bool disableTracking = true);

        Task<IEnumerable<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            int count = 0,
            bool disableTracking = true);
        #endregion
    }
}
