using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.OrgnizationModel
{
   public class OrgnizationResponseServices
    {
        public int id { get; set; }
        public string parentName { get; set; }
        public int? parentID { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string numberBusiness { get; set; }
        public string address { get; set; }
        public int? provinceID { get; set; }
        public string provinceName { get; set; }
        public int? nationID { get; set; }
        public string nationName { get; set; }
        public int? districtID { get; set; }
        public string districtName { get; set; }
        public int? wardID { get; set; }
        public string wardName { get; set; }
        public int? managerID { get; set; }
        public string managerName { get; set; }
        public DateTime? effectDate { get; set; }
        public DateTime? dissolutionDate { get; set; }
        public int? Level { get; set; }
        public string office { get; set; }
        public string note { get; set; }
    }
}
