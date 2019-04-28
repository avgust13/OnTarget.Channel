using AutoMapper;
using OnTarget.Channel.Business.Mapping;
using OnTarget.Channel.Web.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTarget.Channel.Web.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(x =>
			{
				x.AddProfile<BusinessMappingProfile>();
                x.AddProfile<WebMappingProfile>();
            });
        }
    }
}