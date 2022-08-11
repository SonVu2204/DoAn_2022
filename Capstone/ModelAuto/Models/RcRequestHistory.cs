using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestHistory
    {
        public int Id { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string UserLog { get; set; }
        public int? PhaseRequestId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual RcPhaseRequest PhaseRequest { get; set; }
    }
}
