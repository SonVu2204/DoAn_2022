using API.ResponseModel.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAuto.Models;
using Services.ScheduleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleAPIController : AuthorizeByIDController
    {
        private ISchedule schedule = new ScheduleImpl();
        #region "Schedule"

        [Authorize]
        [HttpPost("GetSchedule")]
        public IActionResult GetSchedule(int requestId, int candidateId)
        {
            List<EventResponse> list = new List<EventResponse>();
            try
            {
                list = (from r in schedule.getSchedule(requestId, candidateId)
                        select new EventResponse
                        {
                            Id = r.Id,
                            Title = r.Title,
                            StartHour = r.StartHour,
                            EndHour = r.EndHour,
                            Classname = r.Classname
                        }).ToList();
            }
            catch
            {
            }
            return Ok(new
            {
                Data = list
            });
        }


        [Authorize]
        [HttpPost("DeleteSchedule")]
        public IActionResult DeleteSchedule(List<int> listID)
        {
            try
            {
                var check = schedule.DeleteSchedule(listID);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        [HttpPost("InsertSchedule")]
        public IActionResult InsertSchedule([FromBody] ModifyEventResponse T)
        {
            try
            {
                RcEvent tobj = new RcEvent();
                tobj.RequestId = T.requestId;
                tobj.CandidateId = T.candidateId;
                tobj.Classname = T.Classname;
                tobj.Title = T.Title;
                tobj.StartHour = T.StartHour;
                tobj.EndHour = T.EndHour;
                if (!schedule.CheckTime(tobj))
                {
                    return Ok(new
                    {
                        Mess = "Can't add event because of the same time!",
                        Status = false
                    });
                }
                else
                {
                    var check = schedule.InsertSchedule(tobj);
                    if (check)
                    {
                        return Ok(new
                        {
                            Mess = "Insert Event success!",
                            Status = true
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            Mess = "Something is wrong!",
                            Status = false
                        });
                    }

                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }


        [HttpPost("ModifySchedule")]
        public IActionResult ModifySchedule([FromBody] ModifyEventResponse T)
        {

            try
            {
                RcEvent obj = new RcEvent();
                obj.Id = T.Id;
                obj.RequestId = T.requestId;
                obj.CandidateId = T.candidateId;
                obj.Title = T.Title;
                obj.Classname = T.Classname;
                obj.EndHour = T.EndHour;
                obj.StartHour = T.StartHour;
                var check = schedule.ModifySchedule(obj);
                return Ok(new
                {
                    Status = check
                });
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }



        #endregion
    }
}
