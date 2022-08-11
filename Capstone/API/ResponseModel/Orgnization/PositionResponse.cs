using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Orgnization
{
    public class PositionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? TitleID { get; set; }
        public string TitleName { get; set; }
        public int? BasicSalary { get; set; }
        public string OtherSkill { get; set; }
        public int? FormWorking { get; set; }
        public string FormWorkingName { get; set; }
        public int? Learning_level { get; set; }
        public string Learning_levelName { get; set; }
        public string year_exp { get; set; }
        public int? majorGroup { get; set; }
        public string majorGroupName { get; set; }
        public string major { get; set; }
        public int? language { get; set; }
        public string languageName { get; set; }
        public int? language_level { get; set; }
        public string language_levelName { get; set; }
        public int? Information_level { get; set; }
        public string Information_levelName { get; set; }
    }
}
