using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Ward
    {
        public Ward()
        {
            EmployeeCvWardHkNavigations = new HashSet<EmployeeCv>();
            EmployeeCvWardLiveNavigations = new HashSet<EmployeeCv>();
            EmployeeCvWardObNavigations = new HashSet<EmployeeCv>();
            EmployeeFamilies = new HashSet<EmployeeFamily>();
            Orgnizations = new HashSet<Orgnization>();
            RcCandidateCvWardHkNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvWardLiveNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvWardObNavigations = new HashSet<RcCandidateCv>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? DistrictId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvWardHkNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvWardLiveNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvWardObNavigations { get; set; }
        public virtual ICollection<EmployeeFamily> EmployeeFamilies { get; set; }
        public virtual ICollection<Orgnization> Orgnizations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvWardHkNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvWardLiveNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvWardObNavigations { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
    }
}
