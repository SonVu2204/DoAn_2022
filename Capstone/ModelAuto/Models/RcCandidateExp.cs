using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateExp
    {
        public int Id { get; set; }
        public int? RcCandidate { get; set; }
        public int? TypeId { get; set; }
        public string Firm { get; set; }
        public string Position { get; set; }
        public string Time { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual RcCandidate RcCandidateNavigation { get; set; }
        public virtual OtherList Type { get; set; }
    }
}
