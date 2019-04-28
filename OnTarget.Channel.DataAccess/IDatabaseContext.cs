using OnTarget.Channel.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.DataAccess
{
    public interface IDatabaseContext
    {
        DbSet<ChannelEvent> ChannelEvents { get; set; }
    }
}
