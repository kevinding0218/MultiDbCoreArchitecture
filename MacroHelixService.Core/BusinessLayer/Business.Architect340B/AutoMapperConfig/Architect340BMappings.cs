using Business.Architect340B.ViewModels;
using AutoMapper;
using Entities.ArchitectMain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Architect340B.AutoMapperConfig
{
    public class Architect340BMappings : Profile
    {
        public override string ProfileName => nameof(Architect340BMappings);

        public Architect340BMappings()
        {
            #region view model to dto
            this.CreateMap<vmDrugPropertiesResponse, DrugProperties>();
            #endregion

            #region dto to view model
            this.CreateMap<DrugProperties, vmDrugPropertiesResponse>();
            #endregion
        }
    }
}
