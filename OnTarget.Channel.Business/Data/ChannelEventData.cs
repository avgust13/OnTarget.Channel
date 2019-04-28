using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Data
{
    public class ChannelEventData
    {
        public int ChannelEventId { get; set; }

        public DateTime ChannelEventDate { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string EmbedUrl { get; set; }

        public string DirectUrl { get; set; }
    }
}
