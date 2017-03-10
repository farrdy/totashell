using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.DealerCom.Web.Models
{
    public class IssueResultVm
    {
        public string ProductName { get; set; }
        public string SOCName { get; set; }
        public string DealerName { get; set; }
        public string DateDryFrom { get; set; }
        public string DateDryTo { get; set; }

        public string IDRequestStatus { get; set; }
        public string TankName { get; set; }
        public string OutletNo { get; set; }
        public string IDInstance { get; set; }


    }
}