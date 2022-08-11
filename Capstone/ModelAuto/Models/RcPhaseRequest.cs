using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcPhaseRequest
    {
        public RcPhaseRequest()
        {
            RcRequestHistories = new HashSet<RcRequestHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? RequestId { get; set; }
        public int? PositionId { get; set; }
        public string Note { get; set; }
        public int? NumberNeed { get; set; }
        public int? Cost { get; set; }
        public int? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Position Position { get; set; }
        public virtual RcRequest Request { get; set; }
        public virtual ICollection<RcRequestHistory> RcRequestHistories { get; set; }
    }
}
