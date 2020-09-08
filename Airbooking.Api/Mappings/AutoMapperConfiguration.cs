using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Airbooking.Api.Mappings
{
    /// <summary>
    /// Auto Mapper Configuration class
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Configures the mapping.
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}