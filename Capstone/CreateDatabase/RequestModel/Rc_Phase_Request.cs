using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("Rc_Phase_Request")]
    public class Rc_Phase_Request
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int? RequestId { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("Rc_Phase_Requests")]
        public Rc_Request rc_Request { get; set; }

        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        [InverseProperty("Rc_Phase_Requests")]
        public Position position { get; set; }

        public string note { get; set; }
        public int? NumberNeed { get; set; }
        public int? Cost { get; set; }
        public int? Status { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<Rc_Request_History> Rc_Request_Histories { get; set; }
        public virtual ICollection<Rc_Candidate> Rc_Candidates { get; set; }
        public virtual ICollection<Rc_Request_Exam> Rc_Request_Exams { get; set; }
        public virtual ICollection<Rc_Request_InterView> Rc_Request_InterViews { get; set; }
    }
}
