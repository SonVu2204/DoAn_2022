using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? TitleID { get; set; }
        [ForeignKey("TitleID")]
        [InverseProperty("Position1")]
        public Title Title { get; set; }

        public int? BasicSalary { get; set; }
        [StringLength(100)]
        public string OtherSkill { get; set; }
        public int? FormWorking { get; set; }
        [ForeignKey("FormWorking")]
        [InverseProperty("Positions")]
        public Other_List FormWorkingObj { get; set; }

        public int? Learning_level { get; set; }
        [ForeignKey("Learning_level")]
        [InverseProperty("Position1s")]
        public Other_List LearningLevelObj { get; set; }

        [StringLength(100)]
        public string YearExperience { get; set; }

        public int? majorGroup { get; set; }
        [ForeignKey("majorGroup")]
        [InverseProperty("Position2s")]
        public Other_List MajorGroupObj { get; set; }

        [StringLength(100)]
        public string major { get; set; }

        public int? language { get; set; }
        [ForeignKey("language")]
        [InverseProperty("Position3s")]
        public Other_List LanguageObj { get; set; }

        public int? language_level { get; set; }
        [ForeignKey("language_level")]
        [InverseProperty("Position4s")]
        public Other_List LanguageLevelObj { get; set; }

        public int? Information_level { get; set; }
        [ForeignKey("Information_level")]
        [InverseProperty("Position5s")]
        public Other_List InformationlevelObj { get; set; }


        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
        public virtual ICollection<Rc_Phase_Request> Rc_Phase_Requests { get; set; }

        public virtual ICollection<PositionOrg> PositionOrgs { get; set; }

        public virtual ICollection<Rc_Request> Rc_Requests { get; set; }
    }
}
