using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.OrgnizationModel
{
    public class PositionInOrgResponse
    {
        public int Id { get; set; }
        public string orgName { get; set; }
        public string orgCode { get; set; }
        public int? orgId { get; set; }
        public string positionName { get; set; }
        public string positionCode { get; set; }
        public int? positionId { get; set; }
        public string titleName { get; set; }
        public string titleCode { get; set; }
        public int? titleId { get; set; }
        public string note { get; set; }
        public string statusName { get; set; }
    }
}
