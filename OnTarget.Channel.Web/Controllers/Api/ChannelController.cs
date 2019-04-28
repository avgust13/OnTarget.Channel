using OnTarget.Channel.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnTarget.Channel.Web.Controllers.Api
{
    public class ChannelController : ApiController
    {
        private readonly IChannelEventService _channelEventService;

        public ChannelController(IChannelEventService channelEventService)
        {
            _channelEventService = channelEventService;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!_channelEventService.Delete(id))
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
