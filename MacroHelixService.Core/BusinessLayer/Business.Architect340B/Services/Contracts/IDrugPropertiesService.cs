using Business.Architect340B.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Shared.ResponseModel;

namespace Business.Architect340B.Services.Contracts
{
    //public interface IDrugPropertiesService //Using Factory Pattern
    public interface IDrugPropertiesService : IService
    {
        Task<ISingleResponse<vmDrugPropertiesResponse>> GetDrugPropertiesByNdc(string Ndc);
        Task<IListResponse<vmDrugPropertiesResponse>> GetListDrugPropertiesAsync();
    }
}
