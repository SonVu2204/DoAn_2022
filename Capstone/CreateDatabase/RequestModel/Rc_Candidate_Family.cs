using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("Rc_Candidate_Family")]
   public class Rc_Candidate_Family
    {
        [Key]
        public int Id { get; set; }

        public int? CandidateID { get; set; }
        [ForeignKey("CandidateID")]
        [InverseProperty("Rc_Candidate_Families")]
        public Rc_Candidate rc_Candidate { get; set; }
        [StringLength(100)]
        public string Fullname { get; set; }


        public int? RelationId { get; set; }
        [ForeignKey("RelationId")]
        [InverseProperty("Rc_Candidate_Families")]
        public Other_List Relation { get; set; }

        public int? Is_Deduct { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        public int? Nation { get; set; }
        [ForeignKey("Nation")]
        [InverseProperty("Rc_Candidate_Families")]
        public Nation nation { get; set; }


        public int? Porvince { get; set; }
        [ForeignKey("Porvince")]
        [InverseProperty("Rc_Candidate_Families")]
        public Province province { get; set; }


        public int? District { get; set; }
        [ForeignKey("District")]
        [InverseProperty("Rc_Candidate_Families")]
        public District district { get; set; }
        public int? Ward { get; set; }
        [ForeignKey("Ward")]
        [InverseProperty("Rc_Candidate_Families")]
        public Ward ward { get; set; }
        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
