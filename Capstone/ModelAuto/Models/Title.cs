using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Title
    {
        public Title()
        {
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
