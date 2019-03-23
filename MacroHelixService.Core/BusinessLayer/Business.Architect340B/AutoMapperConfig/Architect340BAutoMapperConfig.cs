using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Architect340B.AutoMapperConfig
{
    public class Architect340BAutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<Architect340BMappings>();
            });
        }
    }
}
