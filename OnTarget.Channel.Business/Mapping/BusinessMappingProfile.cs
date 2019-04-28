using AutoMapper;
using OnTarget.Channel.Business.Data;
using OnTarget.Channel.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Mapping
{
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            CreateMap<ChannelEventData, ChannelEvent>();
        }
    }
}
