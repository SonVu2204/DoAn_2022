using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestSchedu
    {
        public int Id { get; set; }
        public int? IsInteview { get; set; }
        public int? IsExam { get; set; }
        public int? ExamId { get; set; }
        public int? InterViewId { get; set; }
        public DateTime? Date { get; set; }
        public string DiaDiem { get; set; }
        public int? HinhThuc { get; set; }
        public int? CandidateId { get; set; }
        public string Note { get; set; }
        public int? ExpectedCost { get; set; }
        public DateTime? StartHourExam { get; set; }
        public DateTime? EndHourExam { get; set; }
        public DateTime? DateNotify { get; set; }
        public int? StatusContact { get; set; }
        public DateTime? GioPv { get; set; }
        public int? IdNguoiPv { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual RcRequestExam Exam { get; set; }
        public virtual OtherList HinhThucNavigation { get; set; }
        public virtual Employee IdNguoiPvNavigation { get; set; }
        public virtual RcRequestInterView InterView { get; set; }
        public virtual OtherList StatusContactNavigation { get; set; }
    }
}
