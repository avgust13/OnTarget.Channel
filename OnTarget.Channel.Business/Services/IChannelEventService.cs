using OnTarget.Channel.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Services
{
    public interface IChannelEventService
    {
        void Add(ChannelEventData channelEvent);
        bool Delete(int id);
        void Update(ChannelEventData channelEvent);
        IEnumerable<ChannelEventData> GetChannelEvents();
        ChannelEventData GetById(int id);
    }
}
