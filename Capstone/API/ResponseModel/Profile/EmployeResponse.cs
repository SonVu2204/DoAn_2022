using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Profile
{
    public class EmployeResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrgName { get; set; }
        public string TitleName { get; set; }
        public string PositionName { get; set; }
        public DateTime JoinDate { get; set; }
        public string Status { get; set; }



        public int index { get; set; }
        public int size { get; set; }
        public int orgID { get; set; }
    }
}
