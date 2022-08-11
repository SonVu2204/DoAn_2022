using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateSkill
    {
        public int Id { get; set; }
        public int? RcCandidateId { get; set; }
        public int? TypeSkill { get; set; }
        public int? Type { get; set; }
        public int? Level { get; set; }
        public string Goal { get; set; }

        public virtual OtherList LevelNavigation { get; set; }
        public virtual RcCandidate RcCandidate { get; set; }
        public virtual OtherList TypeNavigation { get; set; }
        public virtual OtherListType TypeSkillNavigation { get; set; }
    }
}
