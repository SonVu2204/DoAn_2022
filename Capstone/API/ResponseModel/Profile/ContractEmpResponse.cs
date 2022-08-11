using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Profile
{
    public class ContractEmpResponse
    {
        public int Id { get; set; }
        public string OrgnizationName { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string ContractNo { get; set; }
        public string ContractType { get; set; }
        public DateTime EffectDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int index { get; set; }
        public int size { get; set; }
        public int? OrgnizationId { get; set; }
        public int? PositionId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
