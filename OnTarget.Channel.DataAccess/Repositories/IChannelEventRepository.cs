using OnTarget.Channel.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.DataAccess.Repositories
{
    public interface IChannelEventRepository
    {
        void Add(ChannelEvent channelEvent);
        IEnumerable<ChannelEvent> GetAll();
        ChannelEvent GetById(int id);
        void Remove(ChannelEvent channelEvent);
    }
}
