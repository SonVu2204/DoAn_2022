using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateFamily
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string Fullname { get; set; }
        public int? RelationId { get; set; }
        public int? IsDeduct { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? Nation { get; set; }
        public int? Porvince { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual District DistrictNavigation { get; set; }
        public virtual Nation NationNavigation { get; set; }
        public virtual Province PorvinceNavigation { get; set; }
        public virtual OtherList Relation { get; set; }
        public virtual Ward WardNavigation { get; set; }
    }
}
