﻿using OnTarget.Channel.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.DataAccess
{
    public interface IUnitOfWork
    {
        IChannelEventRepository ChannelEvent { get; }

        void Complete();
    }
}
