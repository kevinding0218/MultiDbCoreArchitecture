using EFCore.ArchitectMain;
using Entities.ArchitectMain;
using Entities.Shared;
using Repo.ArchitectMain.Contracts;
using Repo.ArchitectMain.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ArchitectMain.Implements
{
    public class DrugPropertiesRepo : Repository<DrugProperties>, IDrugPropertiesRepo
    {
        public DrugPropertiesRepo(ArchitectMainDbContext dbContext)
            : base(dbContext)
        {
        }

        public DrugPropertiesRepo(IUserInfo userInfo, ArchitectMainDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public async Task<IEnumerable<DrugProperties>> GetListDrugPropertiesAsync()
                => await GetListAsync(count: 500);

        public Task<DrugProperties> GetSingleDrugPropertiesByNdcAsync()
        {
            throw new NotImplementedException();
        }
    }
}
