using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Position
    {
        public Position()
        {
            EmployeeContracts = new HashSet<EmployeeContract>();
            Employees = new HashSet<Employee>();
            PositionOrgs = new HashSet<PositionOrg>();
            RcPhaseRequests = new HashSet<RcPhaseRequest>();
            RcRequests = new HashSet<RcRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? TitleId { get; set; }
        public int? BasicSalary { get; set; }
        public string OtherSkill { get; set; }
        public int? FormWorking { get; set; }
        public int? LearningLevel { get; set; }
        public string YearExperience { get; set; }
        public int? MajorGroup { get; set; }
        public string Major { get; set; }
        public int? Language { get; set; }
        public int? LanguageLevel { get; set; }
        public int? InformationLevel { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual OtherList FormWorkingNavigation { get; set; }
        public virtual OtherList InformationLevelNavigation { get; set; }
        public virtual OtherList LanguageLevelNavigation { get; set; }
        public virtual OtherList LanguageNavigation { get; set; }
        public virtual OtherList LearningLevelNavigation { get; set; }
        public virtual OtherList MajorGroupNavigation { get; set; }
        public virtual Title Title { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<PositionOrg> PositionOrgs { get; set; }
        public virtual ICollection<RcPhaseRequest> RcPhaseRequests { get; set; }
        public virtual ICollection<RcRequest> RcRequests { get; set; }
    }
}
