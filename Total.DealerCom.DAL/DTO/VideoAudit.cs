﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DTO
{
    public class VideoAudit
    {
        public int VideoTrackingId { get; set; }
        public int VideoId { get; set; }
        public string UserId { get; set; }
        public DateTime DateAccessed { get; set; }
    }
}
