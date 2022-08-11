using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateCv
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? Gender { get; set; }
        public byte? Image { get; set; }
        public DateTime? Dob { get; set; }
        public string NoiSinh { get; set; }
        public int? NationOb { get; set; }
        public int? PorvinceOb { get; set; }
        public int? DistrictOb { get; set; }
        public int? WardOb { get; set; }
        public string Cmnd { get; set; }
        public string Cmndplace { get; set; }
        public string VisaNumber { get; set; }
        public string VisaPlace { get; set; }
        public string Email { get; set; }
        public string EmailWork { get; set; }
        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        public int? PorvinceLive { get; set; }
        public int? DistrictLive { get; set; }
        public int? WardLive { get; set; }
        public string HoKhau { get; set; }
        public int? NationHk { get; set; }
        public int? PorvinceHk { get; set; }
        public int? DistrictHk { get; set; }
        public int? WardHk { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Phone { get; set; }
        public string Zalo { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Twiter { get; set; }
        public string Skype { get; set; }
        public string Website { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual District DistrictHkNavigation { get; set; }
        public virtual District DistrictLiveNavigation { get; set; }
        public virtual District DistrictObNavigation { get; set; }
        public virtual Nation NationHkNavigation { get; set; }
        public virtual Nation NationLiveNavigation { get; set; }
        public virtual Nation NationObNavigation { get; set; }
        public virtual Province PorvinceHkNavigation { get; set; }
        public virtual Province PorvinceLiveNavigation { get; set; }
        public virtual Province PorvinceObNavigation { get; set; }
        public virtual Ward WardHkNavigation { get; set; }
        public virtual Ward WardLiveNavigation { get; set; }
        public virtual Ward WardObNavigation { get; set; }
    }
}
