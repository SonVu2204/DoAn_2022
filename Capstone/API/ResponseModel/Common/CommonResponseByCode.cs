using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Common
{
    public class CommonResponseByCode
    {
        public string code { get; set; }
        public int index { get; set; }
        public int size { get; set; }
    }
}
