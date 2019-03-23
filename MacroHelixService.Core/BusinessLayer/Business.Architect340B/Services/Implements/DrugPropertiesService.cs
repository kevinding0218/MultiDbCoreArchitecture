using Business.Architect340B.Services.Contracts;
using Business.Architect340B.Services.Factories;
using Business.Architect340B.ViewModels;
using AutoMapper;
using EFCore.ArchitectMain;
using Entities.ArchitectMain;
using Repo.ArchitectMain.Contracts;
using Repo.ArchitectMain.Implements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Shared.ResponseModel;
using Business.Shared.Messages;
using Business.Shared.Extensions;

namespace Business.Architect340B.Services.Implements
{
    public class DrugPropertiesService : Service, IDrugPropertiesService
    {
        private readonly IDrugPropertiesRepo _drugPropertiesRepo;

        public DrugPropertiesService(ArchitectMainDbContext dbContext)
            : base(dbContext)
        {
            this._drugPropertiesRepo = new DrugPropertiesRepo(dbContext);
        }

        public DrugPropertiesService(IMapper mapper, ArchitectMainDbContext dbContext) : base(mapper, dbContext)
        {
            this._drugPropertiesRepo = new DrugPropertiesRepo(dbContext);
        }

        public Task<ISingleResponse<vmDrugPropertiesResponse>> GetDrugPropertiesByNdc(string Ndc)
        {
            throw new NotImplementedException();
        }

        public async Task<IListResponse<vmDrugPropertiesResponse>> GetListDrugPropertiesAsync()
        {
            var response = new ListResponse<vmDrugPropertiesResponse>();

            try
            {
                var listDrugPropertiesFromDb = await this._drugPropertiesRepo.GetListDrugPropertiesAsync();
                response.Model = _mapper.Map<IEnumerable<DrugProperties>, IEnumerable<vmDrugPropertiesResponse>>(listDrugPropertiesFromDb);
                response.Message = ResponseMessageDisplay.Success;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }
    }

    //public class DrugPropertiesService : DrugManagerSvcFactory, IDrugPropertiesService
    //{
    //    public DrugPropertiesService(ArchitectMainDbContext dbContext) : base(dbContext)
    //    {
    //    }

    //    public DrugPropertiesService(IMapper mapper, ArchitectMainDbContext dbContext) : base(mapper, dbContext)
    //    {
    //    }
    //    public async Task<IListResponse<vmDrugPropertiesResponse>> GetListDrugPropertiesAsync()
    //    {
    //        var response = new ListResponse<vmDrugPropertiesResponse>();

    //        try
    //        {
    //            var listDrugPropertiesFromDb = await DrugPropertiesRepo.GetListDrugPropertiesAsync();
    //            response.Model = _mapper.Map<IEnumerable<DrugProperties>, IEnumerable<vmDrugPropertiesResponse>>(listDrugPropertiesFromDb);
    //            response.Message = ResponseMessageDisplay.Success;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.SetError(ex);
    //        }

    //        return response;
    //    }
    //}
}
