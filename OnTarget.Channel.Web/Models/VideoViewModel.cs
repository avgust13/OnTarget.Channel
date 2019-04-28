using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTarget.Channel.Web.Models
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string DirectUrl { get; set; }

        [Required]
        [AllowHtml]
        public string EmbedUrl { get; set; }
    }
}