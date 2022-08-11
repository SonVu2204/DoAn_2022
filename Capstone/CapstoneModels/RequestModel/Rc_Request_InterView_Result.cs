using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels
{
    [Table("Rc_Request_InterView_Result")]
   public class Rc_Request_InterView_Result
    {
        [Key]
        public int Id { get; set; }
        public int? CandidateID { get; set; }
        [ForeignKey("CandidateID")]
        [InverseProperty("Rc_Request_InterView_Results")]
        public Rc_Candidate rc_Candidate { get; set; }

        public int? InterviewID { get; set; }
        [ForeignKey("InterviewID")]
        [InverseProperty("rc_Request_InterView_Result")]
        public Rc_Request_InterView rc_Request_InterView { get; set; }


        public int? Status { get; set; }
        public string Note { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
