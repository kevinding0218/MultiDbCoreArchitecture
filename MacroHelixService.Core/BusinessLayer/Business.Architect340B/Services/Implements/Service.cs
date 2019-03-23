using Business.Architect340B.Services.Contracts;
using AutoMapper;
using EFCore.ArchitectMain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Architect340B.Services.Implements
{
    public abstract class Service : IService
    {
        protected bool Disposed;
        public readonly IMapper _mapper;

        public Service(ArchitectMainDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public Service(IMapper mapper, ArchitectMainDbContext dbContext)
        {
            this._mapper = mapper;
            this.DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!this.Disposed)
            {
                DbContext?.Dispose();

                this.Disposed = true;
            }
        }

        public ArchitectMainDbContext DbContext { get; }
    }
}
