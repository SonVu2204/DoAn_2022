using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Request_Schedu")]
    public class Rc_Request_Schedu
    {
        [Key]
        public int ID { get; set; }

        public int? Is_Inteview { get; set; }
        public int? Is_Exam { get; set; }

        public int? ExamID { get; set; }
        [ForeignKey("ExamID")]
        [InverseProperty("Rc_Request_Schedus")]
        public Rc_Request_Exam rc_Request_Exam { get; set; }

        public int? InterView_ID { get; set; }
        [ForeignKey("InterView_ID")]
        [InverseProperty("Rc_Request_Schedus")]
        public Rc_Request_InterView rc_Request_InterView { get; set; }

        public DateTime? Date { get; set; }
        [StringLength(100)]
        public string DiaDiem { get; set; }

        public int? HinhThuc { get; set; }
        [ForeignKey("HinhThuc")]
        [InverseProperty("Rc_Request_Schedu2s")]
        public Other_List HinhThucObj { get; set; }

        public int? Candidate_ID { get; set; }
        [ForeignKey("Candidate_ID")]
        [InverseProperty("Rc_Request_Schedus")]
        public Rc_Candidate rc_Candidate { get; set; }

        public string Note { get; set; }
        public int? Expected_Cost { get; set; }

        public DateTime? StartHourExam { get; set; }
        public DateTime? EndHourExam { get;set; }
        public DateTime? Date_Notify { get; set; }

        public int? Status_Contact { get; set; }
        [ForeignKey("Status_Contact")]
        [InverseProperty("Rc_Request_Schedus")]
        public Other_List StatusContactObj { get; set; }

        public DateTime? Gio_PV { get; set; }

        public int? ID_NguoiPV { get; set; }
        [ForeignKey("ID_NguoiPV")]
        [InverseProperty("Rc_Request_Schedus")]
        public Employee NguoiPV { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
