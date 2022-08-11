using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.RequestModel
{
   public class RequestResponseServices
    {
        public int id { get; set; }
        public string code  { get; set; }
        public string name  { get; set; }
        public string requestLevel { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public int? positionID { get; set; }
        public int? quantity  { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? Deadline { get; set; }
        public string createdOnString { get; set; }
        public string DeadlineString { get; set; }
        public string Office { get; set; }
        public int? StatusID { get; set; }
        public string Status { get; set; }
        public int? parentId { get; set; }
        public int? rank { get; set; }
        public string note { get; set; }
        public string comment { get; set; }
        public int? HrInchangeId { get; set; }
        public string HrInchange { get; set; }
        public int? signID { get; set; }
        public int? typeID { get; set; }
        public string typename { get; set; }
        public string OrgnizationName { get; set; }
        public int? OrgnizationID  { get; set; }
        public string projectname { get; set; }
        public int? projectID { get; set; }
        public int? experience { get; set; }
        public int? level { get; set; }
        public string levelName { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? otherSkill { get; set; }
        public string otherSkillname { get; set; }
        public string history { get; set; }
    }
}
