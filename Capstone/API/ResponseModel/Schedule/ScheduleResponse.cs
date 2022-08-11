using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Schedule
{
    public class ScheduleResponse
    {
        public int requestId { get; set; }
        public int candidateId { get; set; }
        public List<EventResponse>listEvent { get; set; }
    }
    public class EventResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Classname { get; set; }
    }



    public class ModifyEventResponse
    {
        public int Id { get; set; }
        public int requestId { get; set; }
        public int candidateId { get; set; }
        public string Title { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string Classname { get; set; }
    }
}
