using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.OrgnizationModel
{
   public class NationResponseServices
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string note { get; set; }
    }
    public class ProvinceResponseServices
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public int? nationID { get; set; }
        public string nationName { get; set; }
    }
    public class DistrictResponseServices
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public int? provinceID { get; set; }
        public string provinceName { get; set; }
        public int? nationID { get; set; }
        public string nationName { get; set; }
    }
    public class WardResponseServices
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public int? districtID { get; set; }
        public string districtName { get; set; }
        public int? provinceID { get; set; }
        public string provinceName { get; set; }
        public int? nationID { get; set; }
        public string nationName { get; set; }
    }
}
