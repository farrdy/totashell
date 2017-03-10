using System;
using System.Collections.Generic;

namespace Services.DTO
{
    public class GeneralChangesRequest
    {
        public int Id { get; set; }

        public Requester Requester { get; set; }

        public DateTime DateCreated { get; set; }

        public string SpecialistVerificationStatus { get; set; }

        public DateTime? SpecialistVerificationStatusDateTime { get; set; }

        public bool IsApproved { get; set; }

        public string SpecialistVerificationComments { get; set; }

        public string MasterDataComments { get; set; }

        public DateTime? ApprovedDateTime { get; set; }

        public string MasterDataStatus { get; set; }

        public DateTime? MasterDataStatusDateTime { get; set; }

        public bool Archive { get; set; }

        public IEnumerable<GeneralChangesLink> GeneralChangesItems { get; set; }

        public bool IsLoaded { get; set; }

        public DateTime? LoadedDateTime { get; set; }

        public string MasterDataUserId { get; set; }

        public string SpecialistVerificationUserId { get; set; }
    }
}
