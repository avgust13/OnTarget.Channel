using AutoMapper;
using OnTarget.Channel.Business.Mapping;
using OnTarget.Channel.Business.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Service
{
    public class Bootstrap
    {
        public static Container container;

        public static void Start()
        {
            container = new Container();

            Business.Bootstrap.Start(container);

            Mapper.Initialize(x =>
            {
                x.AddProfile<BusinessMappingProfile>();
            });
        }
    }
}
