using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.ProfileModel
{
   public class ContractEmployeeResponse
    {
        public int ID { get; set; }
        public string OrgnizationName { get; set; }
        public int? OrgnizationId { get; set; }

        public string Position { get; set; }
        public int? PositionId { get; set; }

        public string Status { get; set; }
        public string ContractNo { get; set; }
        public string ContractType { get; set; }
        public int? ContractTypeId { get; set; }
        public string EffectDate { get; set; }
        public string ExpireDate { get; set; }

        public DateTime? Effect { get; set; }
        public DateTime? Expire { get; set; }


        public string Note { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? EmployeeId { get; set; }
    }
}
