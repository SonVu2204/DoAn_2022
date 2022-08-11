using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.Schedule
{
    public class ScheduleRes
    {
        public int Id { get; set; }
     
        public string Title { get; set; }
        public Decimal? Score { get; set; }
        public string Note { get; set; }
    }
    public class ListSchedule
    {
        public List<ScheduleRes> Test { get; set; }
        public List<ScheduleRes> Interview { get; set; }
    }
}
