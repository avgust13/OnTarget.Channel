using log4net;
using OnTarget.Channel.Business.Services;
using OnTarget.Channel.DataAccess;
using OnTarget.Channel.DataAccess.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business
{
    public class Bootstrap
    {
        public static void Start(Container container)
        {
            container.RegisterInstance<ILog>(LogManager.GetLogger(typeof(object)));

            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IChannelEventRepository, ChannelEventRepository>();
            container.Register<IChannelEventService, ChannelEventService>();
            container.Register<IYouTubeProcess, YouTubeProcess>();
        }
    }
}