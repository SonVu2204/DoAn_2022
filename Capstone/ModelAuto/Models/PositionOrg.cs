using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class PositionOrg
    {
        public int Id { get; set; }
        public int? PositionId { get; set; }
        public int? OrgId { get; set; }
        public int? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Note { get; set; }

        public virtual Orgnization Org { get; set; }
        public virtual Position Position { get; set; }
    }
}
