using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Nation
    {
        public Nation()
        {
            EmployeeCvNationHkNavigations = new HashSet<EmployeeCv>();
            EmployeeCvNationLiveNavigations = new HashSet<EmployeeCv>();
            EmployeeCvNationObNavigations = new HashSet<EmployeeCv>();
            EmployeeCvQuocTichNavigations = new HashSet<EmployeeCv>();
            EmployeeFamilies = new HashSet<EmployeeFamily>();
            Orgnizations = new HashSet<Orgnization>();
            Provinces = new HashSet<Province>();
            RcCandidateCvNationHkNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvNationLiveNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvNationObNavigations = new HashSet<RcCandidateCv>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<EmployeeCv> EmployeeCvNationHkNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvNationLiveNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvNationObNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvQuocTichNavigations { get; set; }
        public virtual ICollection<EmployeeFamily> EmployeeFamilies { get; set; }
        public virtual ICollection<Orgnization> Orgnizations { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvNationHkNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvNationLiveNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvNationObNavigations { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
    }
}
