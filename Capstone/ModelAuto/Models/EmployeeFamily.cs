using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class EmployeeFamily
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Fullname { get; set; }
        public int? RelationId { get; set; }
        public int? IsDeduct { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? NationId { get; set; }
        public int? Porvince { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual District District { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OtherList EmployeeNavigation { get; set; }
        public virtual Nation Nation { get; set; }
        public virtual Province PorvinceNavigation { get; set; }
        public virtual Ward Ward { get; set; }
    }
}
