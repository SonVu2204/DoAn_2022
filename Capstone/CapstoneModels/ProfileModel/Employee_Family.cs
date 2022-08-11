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
    [Table("Employee_Family")]
    public class Employee_Family
    {
        [Key]
        public int Id { get; set; }



        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("Employee_Families")]
        public Employee Employee { get; set; }

        [StringLength(100)]
        public string Fullname { get; set; }


        public int? RelationId { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("Employee_Families")]
        public Other_List Relation { get; set; }


        public int? Is_Deduct { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        public int? NationID { get; set; }
        [ForeignKey("NationID")]
        [InverseProperty("Employee_Families")]
        public Nation Nation { get; set; }


        public int? Porvince { get; set; }
        [ForeignKey("Porvince")]
        [InverseProperty("Employee_Families")]
        public Province province { get; set; }


        public int? DistrictID { get; set; }
        [ForeignKey("DistrictID")]
        [InverseProperty("Employee_Families")]
        public District District { get; set; }


        public int? WardID { get; set; }
        [ForeignKey("WardID")]
        [InverseProperty("Employee_Families")]
        public Ward Ward { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
