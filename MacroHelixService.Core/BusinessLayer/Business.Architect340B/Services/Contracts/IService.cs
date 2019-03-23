using EFCore.ArchitectMain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Architect340B.Services.Contracts
{
    public interface IService : IDisposable
    {
        ArchitectMainDbContext DbContext { get; }
    }
}
