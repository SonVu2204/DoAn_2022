using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("EmployeeCV")]
    public class EmployeeCV
    {
        [Key]
        public int ID { get; set; }
        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("EmployeeCVs")]
        public Employee Employee { get; set; }


        public int? Gender { get; set; }
        [ForeignKey("Gender")]
        [InverseProperty("EmployeeCVs")]
        public Other_List GenderObj { get; set; }
        public byte? Image { get; set; }
        public DateTime? Dob { get; set; }
        // noi sinh
        [StringLength(100)]
        public string NoiSinh { get; set; }
        public int? NationOB { get; set; }
        [ForeignKey("NationOB")]
        [InverseProperty("EmployeeCV1s")]
        public Nation Nation1 { get; set; }
        public int? PorvinceOB { get; set; }
        [ForeignKey("ProvinceOB")]
        [InverseProperty("EmployeeCV1s")]
        public Province Province1 { get; set; }
        public int? DistrictOB { get; set; }
        [ForeignKey("DistrictOB")]
        [InverseProperty("EmployeeCV1s")]
        public District District1 { get; set; }
        public int? WardOB { get; set; }
        [ForeignKey("WardOB")]
        [InverseProperty("EmployeeCV1s")]
        public Ward Ward1 { get; set; }
        [StringLength(100)]
        public string CMND { get; set; }
        [StringLength(100)]
        public string CMNDPlace { get; set; }
        [StringLength(100)]
        public string VisaNumber { get; set; }
        [StringLength(100)]
        public string VisaPlace { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string EmailWork { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        // noi o
        [StringLength(100)]
        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        [ForeignKey("NationLive")]
        [InverseProperty("EmployeeCV2s")]
        public Nation Nation2 { get; set; }


        public int? PorvinceLive { get; set; }
        [ForeignKey("ProvinceLive")]
        [InverseProperty("EmployeeCV2s")]
        public Province Province2 { get; set; }


        public int? DistrictLive { get; set; }
        [ForeignKey("DistrictLive")]
        [InverseProperty("EmployeeCV2s")]
        public District District2 { get; set; }
        public int? WardLive { get; set; }
        [ForeignKey("WardLive")]
        [InverseProperty("EmployeeCV2s")]
        public Ward Ward2 { get; set; }




        // Ho khau thuong chu
        [StringLength(100)]
        public string HoKhau { get; set; }
        public int? NationHK { get; set; }
        [ForeignKey("NationHK")]
        [InverseProperty("EmployeeCV3s")]
        public Nation Nation3 { get; set; }
        public int? PorvinceHK { get; set; }
        [ForeignKey("ProvinceHK")]
        [InverseProperty("EmployeeCV3s")]
        public Province Province3 { get; set; }
        public int? DistrictHK { get; set; }
        [ForeignKey("DistrictHK")]
        [InverseProperty("EmployeeCV3s")]
        public District District3 { get; set; }
        public int? WardHK { get; set; }
        [ForeignKey("WardHK")]
        [InverseProperty("EmployeeCV3s")]
        public Ward Ward3 { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
