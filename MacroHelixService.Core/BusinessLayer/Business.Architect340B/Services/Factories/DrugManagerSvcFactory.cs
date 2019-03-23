using AutoMapper;
using EFCore.ArchitectMain;
using Repo.ArchitectMain.Contracts;
using Repo.ArchitectMain.Implements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Architect340B.Services.Factories
{
    /// <summary>
    /// In memory
    /// </summary>
    public class DrugManagerSvcFactory
    {
        protected bool Disposed;

        protected readonly ArchitectMainDbContext _dbContext;
        public readonly IMapper _mapper;

        public DrugManagerSvcFactory(ArchitectMainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DrugManagerSvcFactory(IMapper mapper, ArchitectMainDbContext dbContext)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        protected IDrugPropertiesRepo _drugPropertiesRepo;

        protected IDrugPropertiesRepo DrugPropertiesRepo
            => _drugPropertiesRepo ?? (_drugPropertiesRepo = new DrugPropertiesRepo(this._dbContext));
    }
}
