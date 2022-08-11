using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Other_List_Type")]
    public class Other_List_Type
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int PhanHe { get; set; }
        public int IsSystem { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<Other_List> Other_Lists { get; set; }    
    }
}
