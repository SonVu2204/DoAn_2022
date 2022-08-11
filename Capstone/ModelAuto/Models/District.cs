using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class District
    {
        public District()
        {
            EmployeeCvDistrictHkNavigations = new HashSet<EmployeeCv>();
            EmployeeCvDistrictLiveNavigations = new HashSet<EmployeeCv>();
            EmployeeCvDistrictObNavigations = new HashSet<EmployeeCv>();
            EmployeeFamilies = new HashSet<EmployeeFamily>();
            Orgnizations = new HashSet<Orgnization>();
            RcCandidateCvDistrictHkNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvDistrictLiveNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvDistrictObNavigations = new HashSet<RcCandidateCv>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? ProvinceId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvDistrictHkNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvDistrictLiveNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvDistrictObNavigations { get; set; }
        public virtual ICollection<EmployeeFamily> EmployeeFamilies { get; set; }
        public virtual ICollection<Orgnization> Orgnizations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvDistrictHkNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvDistrictLiveNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvDistrictObNavigations { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
