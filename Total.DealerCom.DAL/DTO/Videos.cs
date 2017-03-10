using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DTO
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public string VideoDescription { get; set; }
        public string ViewLink { get; set; }
        public string DownloadLink { get; set; }
    }
}
