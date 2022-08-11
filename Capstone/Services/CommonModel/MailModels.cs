using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonModel
{
    public class MailDTO
    {
        public string fromMail { get; set; }
        public string pass { get; set; }
        public string tomail { get; set; }
        public string content { get; set; }
        public string subject { get; set; }
        public List<string> listCC { get; set; }
        public List<string> listBC { get; set; }
    }
}
