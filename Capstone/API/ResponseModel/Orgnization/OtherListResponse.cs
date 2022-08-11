using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Orgnization
{
    public class OtherListResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Atribute1 { get; set; }
        public string Atribute2 { get; set; }
        public string Atribute3 { get; set; }
        public int TypeID { get; set; }
    }
}
