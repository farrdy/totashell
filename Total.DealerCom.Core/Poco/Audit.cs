using System;

namespace Total.DealerCom.Core
{
    /// <summary>
    /// AuditDTO Domain Object
    /// </summary>
    public partial class Audit
    {

        public int AuditId { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserID { get; set; }
        public string TableName { get; set; }
        public string TableKey { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
