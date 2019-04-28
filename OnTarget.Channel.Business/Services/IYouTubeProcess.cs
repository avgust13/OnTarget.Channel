using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Services
{
    public interface IYouTubeProcess
    {
        void PopulateChannelEvents(string channelName, DateTime fromDate);
    }
}
