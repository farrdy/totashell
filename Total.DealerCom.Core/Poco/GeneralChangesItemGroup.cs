using System.Collections.Generic;

namespace Total.DealerCom.Core
{
    public class GeneralChangesItemGroup
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public bool Active { get; set; }

        public int SortOrder { get; set; }

        public IEnumerable<GeneralChangesItem> GeneralChangesItems { get; set; }

        public byte MaxSelectionCount { get; set; }

        public byte MinSelectionCount { get; set; }

        public bool Approvable { get; set; }
    }
}
