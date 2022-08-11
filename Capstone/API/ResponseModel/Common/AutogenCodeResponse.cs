using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Common
{
    public class AutogenCode3Response
    {
        public string table { get; set; }
        public string code { get; set; }
    }
    public class AutogenCodeResponse
    {
        public string table { get; set; }
        public int rank { get; set; }
        public string collumName { get; set; }
         public int ParentId { get; set; }
    }

}
