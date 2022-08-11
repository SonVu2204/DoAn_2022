using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.ProfileModel
{
    public class EmployeeResponseServices
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string OrgnizationName { get; set; }
        public string PositionName { get; set; }
        public int? OrgId { get; set; }
        public int? PositionId { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public string TitleName { get; set; }
        public int? TitleId { get; set; }
        public string JoinDate { get; set; }
        public string ContractNo { get; set; }
    }

    public class EmployeeProfileResponseServices
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string PositionName { get; set; }
        public string OrgnizationName { get; set; }
        public int? StatusId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? OutDate { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public int? DanToc { get; set; }
        public int? QuocTich { get; set; }
        public string CMND { get; set; }
        public string CMND_Place { get; set; }
        public string HoKhau { get; set; }
        public int? NationHK { get; set; }
        public int? ProvinceHK { get; set; }
        public int? DistrictHK { get; set; }
        public int? WardHK { get; set; }
        public string NoiO { get; set; }
        public int? NationNoiO { get; set; }
        public int? ProvinceNoiO { get; set; }
        public int? DistrictNoiO { get; set; }
        public int? WardNoiO { get; set; }
        public int? LearningLV { get; set; }
        public string School { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string Award { get; set; }
        public int? informaticLV { get; set; }
        public int? Language1 { get; set; }
        public int? Language2 { get; set; }
        public int? Skill1 { get; set; }
        public int? Skill2 { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
    }
}
