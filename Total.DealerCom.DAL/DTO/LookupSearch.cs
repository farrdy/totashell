﻿namespace Services.DTO
{
    public class LookupSearch
    {
        public bool ShowInactive { get; set; }

        public string Lookup { get; set; }

        public int? IDParent { get; set; }
    }
}