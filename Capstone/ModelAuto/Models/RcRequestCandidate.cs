using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestCandidate
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? CandidateId { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual RcRequest Request { get; set; }
    }
}
