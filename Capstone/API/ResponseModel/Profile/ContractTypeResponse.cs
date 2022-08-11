using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Profile
{
    public class ContractTypeResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string BHXH { get; set; }
        public string BHYT { get; set; }
        public string BHTN { get; set; }
        public string Term { get; set; }
    }
}
