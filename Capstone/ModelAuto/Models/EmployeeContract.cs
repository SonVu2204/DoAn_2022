using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class EmployeeContract
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string ContractNo { get; set; }
        public int? ContractTypeId { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? SignId { get; set; }
        public DateTime SignDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? PositionId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? OrgnizationId { get; set; }

        public virtual ContractType ContractType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Orgnization Orgnization { get; set; }
        public virtual Position Position { get; set; }
        public virtual Employee Sign { get; set; }
    }
}
