using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastDate { get; set; }
        public int? Status { get; set; }
        [ForeignKey("Status")]
        [InverseProperty("Employees")]
        public Other_List StatusObj { get; set; }
        public string Note { get; set; }    
        public int? IsFronmRecruit { get; set; }

        //
        


        public int? OrgnizationID { get; set; }
        [ForeignKey("OrgnizationID")]
        [InverseProperty("Employees1")]
        public ORgnization Organization { get; set; }


        public int? PositionID { get; set; }
        [ForeignKey("PositionID")]
        [InverseProperty("Employees")]
        public Position Position { get; set; }

        //

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<ORgnization> ORgnizations { get; set; }


        public virtual ICollection<EmployeeCV> EmployeeCVs { get; set; }

        public virtual ICollection<EmployeeEdu> EmployeeEdus { get; set; }

        public virtual ICollection<Employee_Family> Employee_Families { get; set; }
        public virtual ICollection<Employee_Salary> Employee_Salaries { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }

        public virtual ICollection<Employee_Salary> Employee_Salarie1s { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContract1s { get; set; }

        public virtual ICollection<Rc_Request> Rc_Requests { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }


        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CVs { get; set; }

        public virtual ICollection<Rc_Request_Schedu> Rc_Request_Schedus { get; set; }
    }
}
