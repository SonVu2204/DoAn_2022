using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class EmployeeSalary
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string DecisiongNo { get; set; }
        public string Note { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? SignId { get; set; }
        public DateTime? SignDate { get; set; }
        public int? Status { get; set; }
        public int? SalRank { get; set; }
        public int? SalBasic { get; set; }
        public int? IsWage { get; set; }
        public int? SalTotal { get; set; }
        public int? Kpi { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee Sign { get; set; }
    }
}
