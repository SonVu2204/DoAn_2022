using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            EmployeeContractEmployees = new HashSet<EmployeeContract>();
            EmployeeContractSigns = new HashSet<EmployeeContract>();
            EmployeeCvs = new HashSet<EmployeeCv>();
            EmployeeEdus = new HashSet<EmployeeEdu>();
            EmployeeFamilies = new HashSet<EmployeeFamily>();
            EmployeeSalaryEmployees = new HashSet<EmployeeSalary>();
            EmployeeSalarySigns = new HashSet<EmployeeSalary>();
            Orgnizations = new HashSet<Orgnization>();
            RcCandidates = new HashSet<RcCandidate>();
            RcRequestHrInchangeNavigations = new HashSet<RcRequest>();
            RcRequestSchedus = new HashSet<RcRequestSchedu>();
            RcRequestSigns = new HashSet<RcRequest>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? IsFronmRecruit { get; set; }
        public int? OrgnizationId { get; set; }
        public int? PositionId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Orgnization Orgnization { get; set; }
        public virtual Position Position { get; set; }
        public virtual OtherList StatusNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContractEmployees { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContractSigns { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvs { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEdus { get; set; }
        public virtual ICollection<EmployeeFamily> EmployeeFamilies { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaryEmployees { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalarySigns { get; set; }
        public virtual ICollection<Orgnization> Orgnizations { get; set; }
        public virtual ICollection<RcCandidate> RcCandidates { get; set; }
        public virtual ICollection<RcRequest> RcRequestHrInchangeNavigations { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestSchedus { get; set; }
        public virtual ICollection<RcRequest> RcRequestSigns { get; set; }
    }
}
