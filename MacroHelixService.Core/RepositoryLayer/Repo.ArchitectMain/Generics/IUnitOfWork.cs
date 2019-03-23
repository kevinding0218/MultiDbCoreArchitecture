using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ArchitectMain.Generics
{
    public interface IUnitOfWork
    {
        #region Unit Of Work
        Task<int> CommitChangesAsync();
        #endregion
    }
}
