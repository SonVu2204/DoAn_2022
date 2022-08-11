using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }

        public int? NationID { get; set; }
        [ForeignKey("NationID")]
        public Nation Nation { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<District> Districts { get; set; }    
        public virtual ICollection<ORgnization> ORgnizations { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV1s { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV2s { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV3s { get; set; }
        public virtual ICollection<Employee_Family> Employee_Families { get; set; }
        public virtual ICollection<Rc_Candidate_Family> Rc_Candidate_Families { get; set; }
        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CVs { get; set; }
        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CV1s { get; set; }
        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CV2s { get; set; }
    }
}
