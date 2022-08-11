using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
    public class CandidateSkillModel
    {
        public string TypeSkill { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }   
        public string Goal { get; set; }    
    }
    public class CandidateExpModel
    {
        public string TypeId { get; set; }
        public string Firm { get; set; }
        public string Position { get; set; }
        public string Time { get; set; }
    }
}
