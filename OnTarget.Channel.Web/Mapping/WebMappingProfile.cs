using AutoMapper;
using OnTarget.Channel.Business.Data;
using OnTarget.Channel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTarget.Channel.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<ChannelEventData, VideoViewModel>();
            CreateMap<VideoViewModel, ChannelEventData>()
                .ForMember(d => d.ChannelEventId, o => o.MapFrom(s => s.Id));
        }
    }
}