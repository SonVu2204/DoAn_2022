using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.CandidateModel
{
    public class CandidateResponeServices
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? yob { get; set; }
        public DateTime? dob { get; set; }
        public string dobString { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string nation { get; set; }
        public int? nationID { get; set; }
        public string province { get; set; }
        public int? provinceID { get; set; }
        public string language { get; set; }
        public string experience { get; set; }
        public string lastestPosition { get; set; }
        public string status { get; set; }
        public int? statusId { get; set; }
        public string statusName { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string note { get; set; }
        public List<languageObj> languageList { get; set; }
        public List<positionObj> positionList { get; set; }
    }
    public class positionObj
    {
        public int id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }
    public class languageObj
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
