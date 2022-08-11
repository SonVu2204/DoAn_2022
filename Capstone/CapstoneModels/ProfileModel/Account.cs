using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Pass { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("Accounts")]
        public Employee Employee { get; set; }

        public int? Rule { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        //12


    }
}
