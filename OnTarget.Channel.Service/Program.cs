using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OnTarget.Channel.Business.Helpers;
using OnTarget.Channel.Business.Services;

namespace OnTarget.Channel.Service
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            _log.Info("Application is working");

            Bootstrap.Start();

            var _youTubeProcess = Bootstrap.container.GetInstance<IYouTubeProcess>();

            _youTubeProcess.PopulateChannelEvents(Config.ChannelName, Config.ChannelFromDate);

            _log.Info("Application is stopped");
        }
    }
}
