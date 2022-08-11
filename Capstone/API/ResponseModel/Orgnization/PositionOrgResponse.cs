using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Orgnization
{
    public class PositionOrgResponse
    {
        public int Id { get; set; }
        public int? positionID { get; set; }
        public int? OrgID { get; set; }
        public int? Status { get; set; }
        public string positionName { get; set; }
        public string OrgName { get; set; }
        public string Note { get; set; }
    }
}
