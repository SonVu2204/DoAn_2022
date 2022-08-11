using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.CandidateModel
{
   public class CheckDuplicateCandidateModel
    {
        public string phone { get; set; }
        public string zalo { get; set; }
        public string email { get; set; }
        public string linkIn { get; set; }
        public string faceBook { get; set; }
        public string twitter { get; set; }
        public string skype { get; set; }
        public string website { get; set; }
    }

    public class checkResponse
    {
        public bool check { get; set; }
        public string mess { get; set; }
    }

    public class checkDuplicateMatching
    {
        public int candidateId { get; set; }
        public string candidateName { get; set; }
    }
}
