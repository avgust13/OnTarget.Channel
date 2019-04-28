using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTarget.Channel.DataAccess.Data;

namespace OnTarget.Channel.DataAccess.Repositories
{
    public class ChannelEventRepository : IChannelEventRepository
    {
        private readonly IDatabaseContext _context;

        public ChannelEventRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Add(ChannelEvent channelEvent)
        {
            _context.ChannelEvents.Add(channelEvent);
        }

        public IEnumerable<ChannelEvent> GetAll()
        {
            return _context.ChannelEvents.ToList();
        }

        public ChannelEvent GetById(int id)
        {
            return _context.ChannelEvents.FirstOrDefault(e => e.ChannelEventId.Equals(id));
        }

        public void Remove(ChannelEvent channelEvent)
        {
            _context.ChannelEvents.Remove(channelEvent);
        }
    }
}
