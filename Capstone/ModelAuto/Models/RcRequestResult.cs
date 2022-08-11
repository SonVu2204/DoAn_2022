using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestResult
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? StatusRequest { get; set; }
        public int? AvgScore { get; set; }
        public int? ResultInterview { get; set; }
        public string Note { get; set; }
        public int? StatusContact { get; set; }
        public int? IsMoveEmployee { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual OtherList StatusContactNavigation { get; set; }
        public virtual OtherList StatusRequestNavigation { get; set; }
    }
}
