using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestInterView
    {
        public RcRequestInterView()
        {
            RcRequestInterViewResults = new HashSet<RcRequestInterViewResult>();
            RcRequestSchedus = new HashSet<RcRequestSchedu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? RequestId { get; set; }

        public virtual RcRequest Request { get; set; }
        public virtual ICollection<RcRequestInterViewResult> RcRequestInterViewResults { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestSchedus { get; set; }
    }
}
