using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTarget.Channel.DataAccess.Repositories;

namespace OnTarget.Channel.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public IChannelEventRepository ChannelEvent { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            ChannelEvent = new ChannelEventRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
