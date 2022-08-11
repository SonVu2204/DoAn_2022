using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Orgnization
    {
        public Orgnization()
        {
            EmployeeContracts = new HashSet<EmployeeContract>();
            Employees = new HashSet<Employee>();
            PositionOrgs = new HashSet<PositionOrg>();
            RcRequests = new HashSet<RcRequest>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public DateTime? DissolutionDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NumberBussines { get; set; }
        public string Address { get; set; }
        public int? NationId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? ManagerId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? Effectdate { get; set; }

        public virtual District District { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual Nation Nation { get; set; }
        public virtual Province Province { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<PositionOrg> PositionOrgs { get; set; }
        public virtual ICollection<RcRequest> RcRequests { get; set; }
    }
}
