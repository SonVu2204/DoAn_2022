using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("Contract_Type")]
    public class Contract_Type
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        [StringLength(100)]
        public string BHXH { get; set; }
        [StringLength(100)]
        public string BHYT { get; set; }
        [StringLength(100)]
        public string BHTN { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        //12
    }
}
