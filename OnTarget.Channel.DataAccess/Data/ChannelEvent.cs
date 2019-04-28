using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.DataAccess.Data
{
    public class ChannelEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChannelEventId { get; set; }

        public DateTime ChannelEventDate { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string EmbedUrl { get; set; }

        public string DirectUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
