using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateEdu
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? LearningLevel { get; set; }
        public int? InforMaticsLevel1 { get; set; }
        public string School1 { get; set; }
        public int? DeeGree1 { get; set; }
        public string Major1 { get; set; }
        public int? Language1 { get; set; }
        public int? InforMaticsLevel2 { get; set; }
        public string School2 { get; set; }
        public int? DeeGree2 { get; set; }
        public string Major2 { get; set; }
        public int? Language2 { get; set; }
        public int? InforMaticsLevel3 { get; set; }
        public string School3 { get; set; }
        public int? DeeGree3 { get; set; }
        public string Major3 { get; set; }
        public int? Language3 { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? Graduate1 { get; set; }
        public DateTime? Graduate2 { get; set; }
        public DateTime? Graduate3 { get; set; }
        public decimal? Gpa1 { get; set; }
        public decimal? Gpa2 { get; set; }
        public decimal? Gpa3 { get; set; }
        public string Awards1 { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual OtherList DeeGree1Navigation { get; set; }
        public virtual OtherList DeeGree2Navigation { get; set; }
        public virtual OtherList DeeGree3Navigation { get; set; }
        public virtual OtherList InforMaticsLevel1Navigation { get; set; }
        public virtual OtherList InforMaticsLevel2Navigation { get; set; }
        public virtual OtherList InforMaticsLevel3Navigation { get; set; }
        public virtual OtherList Language1Navigation { get; set; }
        public virtual OtherList Language2Navigation { get; set; }
        public virtual OtherList Language3Navigation { get; set; }
        public virtual OtherList LearningLevelNavigation { get; set; }
    }
}
