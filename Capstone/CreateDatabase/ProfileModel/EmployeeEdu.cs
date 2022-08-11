using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CreateDatabase
{
    [Table("EmployeeEdu")]
    public class EmployeeEdu
    {
        [Key]
        public int ID { get; set; }

        public int? Employee_ID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("EmployeeEdus")]
        public Employee Employee { get; set; }

        public int? Learning_Level { get; set; }
        [ForeignKey("Learning_Level")]
        [InverseProperty("EmployeeEdus")]
        public Other_List LearningLevelObj { get; set; }

        public int? InforMatics_Level1 { get; set; }
        [ForeignKey("InforMatics_Level1")]
        [InverseProperty("EmployeeEdu1s")]
        public Other_List InforMaticsLevelObj1 { get; set; }
        [StringLength(100)]
        public string School1 { get; set; }
        public int? DeeGree1 { get; set; }
        [ForeignKey("DeeGree1")]
        [InverseProperty("EmployeeEdu2s")]
        public Other_List DeeGreeObj1 { get; set; }
        [StringLength(100)]
        public string Major1 { get; set; }
        public int? Language1 { get; set; }
        [ForeignKey("Language1")]
        [InverseProperty("EmployeeEdu3s")]
        public Other_List LanguageObj1 { get; set; }

        // level2 
        public int? InforMatics_Level2 { get; set; }
        [ForeignKey("InforMatics_Level2")]
        [InverseProperty("EmployeeEdu4s")]
        public Other_List InforMaticsLevelObj2 { get; set; }
        [StringLength(100)]
        public string School2 { get; set; }
        public int? DeeGree2 { get; set; }
        [ForeignKey("DeeGree2")]
        [InverseProperty("EmployeeEdu5s")]
        public Other_List DeeGreeObj2 { get; set; }
        [StringLength(100)]
        public string Major2 { get; set; }
        public int? Language2 { get; set; }
        [ForeignKey("Language2")]
        [InverseProperty("EmployeeEdu6s")]
        public Other_List LanguageObj2 { get; set; }
        //level3
        public int? InforMatics_Level3 { get; set; }
        [ForeignKey("InforMatics_Level3")]
        [InverseProperty("EmployeeEdu7s")]
        public Other_List InforMaticsLevelObj3 { get; set; }
        [StringLength(100)]
        public string School3 { get; set; }
        public int? DeeGree3 { get; set; }
        [ForeignKey("DeeGree3")]
        [InverseProperty("EmployeeEdu8s")]
        public Other_List DeeGreeObj3 { get; set; }
        [StringLength(100)]
        public string Major3 { get; set; }
        public int? Language3 { get; set; }
        [ForeignKey("Language3")]
        [InverseProperty("EmployeeEdu9s")]
        public Other_List LanguageObj3 { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
