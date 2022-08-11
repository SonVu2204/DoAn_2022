using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class EmployeeEdu
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? EmployeeId1 { get; set; }
        public int? LearningLevel { get; set; }
        public int? InforMaticsLevel1 { get; set; }
        public string School1 { get; set; }
        public string DeeGree1 { get; set; }
        public string Major1 { get; set; }
        public int? Language1 { get; set; }
        public int? InforMaticsLevel2 { get; set; }
        public string School2 { get; set; }
        public string DeeGree2 { get; set; }
        public string Major2 { get; set; }
        public int? Language2 { get; set; }
        public int? InforMaticsLevel3 { get; set; }
        public string School3 { get; set; }
        public string DeeGree3 { get; set; }
        public string Major3 { get; set; }
        public int? Language3 { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? LanScore1 { get; set; }
        public int? LanScore2 { get; set; }
        public int? LanScore3 { get; set; }
        public string Award1 { get; set; }
        public int? LanSkill1 { get; set; }
        public int? LanSkill2 { get; set; }
        public int? LanSkill3 { get; set; }

        public virtual Employee EmployeeId1Navigation { get; set; }
        public virtual OtherList InforMaticsLevel1Navigation { get; set; }
        public virtual OtherList InforMaticsLevel2Navigation { get; set; }
        public virtual OtherList InforMaticsLevel3Navigation { get; set; }
        public virtual OtherList Language1Navigation { get; set; }
        public virtual OtherList Language2Navigation { get; set; }
        public virtual OtherList Language3Navigation { get; set; }
        public virtual OtherList LearningLevelNavigation { get; set; }
    }
}
