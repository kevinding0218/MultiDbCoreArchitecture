using Entities.ArchitectMain;
using Repo.ArchitectMain.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ArchitectMain.Contracts
{
    public interface IDrugPropertiesRepo : IRepository<DrugProperties>
    {
        Task<DrugProperties> GetSingleDrugPropertiesByNdcAsync(string Ndc);
        Task<IEnumerable<DrugProperties>> GetListDrugPropertiesAsync();
    }
}
