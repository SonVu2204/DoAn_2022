using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcEvent
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
        public string Title { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Classname { get; set; }
        public decimal? Score { get; set; }
        public string Note { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual RcRequest Request { get; set; }
    }
}
