using OnTarget.Channel.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.DataAccess
{

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<ChannelEvent> ChannelEvents{ get; set; }


        public DatabaseContext()
            : base("DefaultConnection")
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
