using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class EmployeeCv
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? Gender { get; set; }
        public byte? Image { get; set; }
        public DateTime? Dob { get; set; }
        public string NoiSinh { get; set; }
        public int? NationOb { get; set; }
        public int? PorvinceOb { get; set; }
        public int? ProvinceOb { get; set; }
        public int? DistrictOb { get; set; }
        public int? WardOb { get; set; }
        public string Cmnd { get; set; }
        public string Cmndplace { get; set; }
        public string VisaNumber { get; set; }
        public string VisaPlace { get; set; }
        public string Email { get; set; }
        public string EmailWork { get; set; }
        public string Phone { get; set; }
        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        public int? PorvinceLive { get; set; }
        public int? ProvinceLive { get; set; }
        public int? DistrictLive { get; set; }
        public int? WardLive { get; set; }
        public string HoKhau { get; set; }
        public int? NationHk { get; set; }
        public int? PorvinceHk { get; set; }
        public int? ProvinceHk { get; set; }
        public int? DistrictHk { get; set; }
        public int? WardHk { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? QuocTich { get; set; }
        public int? DanToc { get; set; }

        public virtual OtherList DanTocNavigation { get; set; }
        public virtual District DistrictHkNavigation { get; set; }
        public virtual District DistrictLiveNavigation { get; set; }
        public virtual District DistrictObNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OtherList GenderNavigation { get; set; }
        public virtual Nation NationHkNavigation { get; set; }
        public virtual Nation NationLiveNavigation { get; set; }
        public virtual Nation NationObNavigation { get; set; }
        public virtual Province ProvinceHkNavigation { get; set; }
        public virtual Province ProvinceLiveNavigation { get; set; }
        public virtual Province ProvinceObNavigation { get; set; }
        public virtual Nation QuocTichNavigation { get; set; }
        public virtual Ward WardHkNavigation { get; set; }
        public virtual Ward WardLiveNavigation { get; set; }
        public virtual Ward WardObNavigation { get; set; }
    }
}
