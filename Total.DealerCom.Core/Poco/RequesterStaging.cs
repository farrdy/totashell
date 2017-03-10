using System;

namespace Total.DealerCom.Core
{
    /// <summary>
    /// RequesterStagingDTO Domain Object
    /// </summary>
    public partial class RequesterStaging
    {

        public int RequesterID { get; set; }
        public DateTime RequestDate { get; set; }
        public string Motivation { get; set; }
        public string SiteName { get; set; }
        public string SiteNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string RequesterName { get; set; }

    }

}

