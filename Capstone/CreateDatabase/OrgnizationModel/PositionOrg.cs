using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabase
{
    [Table("PositionOrg")]
   public class PositionOrg
    {
        [Key]
        public int Id { get; set; }
        public int? positionID { get; set; }
        [ForeignKey("positionID")]
        [InverseProperty("PositionOrgs")]
        public Position position { get; set; }

        public int? OrgID { get; set; }
        [ForeignKey("OrgID")]
        [InverseProperty("PositionOrgs")]
        public ORgnization oRgnization { get; set; }

        public int? Status { get; set; }


        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
