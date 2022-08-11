using ModelAuto.Models;
using Services.CandidateService;
using Services.CommonServices;
using Services.ResponseModel.CandidateModel;
using Services.ResponseModel.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ScheduleServices
{
    public class ScheduleImpl : ISchedule
    {

        ICandidate c = new CandidateImpl();

        public bool DeleteSchedule(List<int> listID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listID)
                    {
                        RcEvent tobj = new RcEvent();
                        tobj = context.RcEvents.Where(x => x.Id == item).FirstOrDefault();
                        context.RcEvents.Remove(tobj);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool InsertSchedule(RcEvent T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcEvent tobj = new RcEvent();
                    tobj.Classname = T.Classname;
                    tobj.Title = T.Title;
                    tobj.RequestId = T.RequestId;
                    tobj.CandidateId = T.CandidateId;
                    tobj.StartHour = T.StartHour;
                    tobj.EndHour = T.EndHour;
                    context.RcEvents.Add(tobj);
                    context.SaveChanges();
                    // add vào bước 2
                    List<RcEvent> listintestview = context.RcEvents.Where(x => x.CandidateId == T.CandidateId && x.RequestId == T.RequestId && x.Classname == "interview").ToList();
                    List<RcEvent> listtest = context.RcEvents.Where(x => x.CandidateId == T.CandidateId && x.RequestId == T.RequestId && x.Classname == "test").ToList();
                    SetStep2 step2 = new SetStep2();
                    step2.CandidateId = T.CandidateId;
                    step2.RequestId = T.RequestId;
                    if (listintestview.Count > 0)
                    {
                        step2.Step2InterView = 1;
                    }
                    if (listtest.Count > 0)
                    {
                        step2.Step2Test = 1;
                    }
                    bool check = c.AddStep2(step2);
                    return true;
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return false;
            }
        }


        public bool ModifySchedule(RcEvent T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcEvent tobj = context.RcEvents.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Classname = T.Classname;
                    tobj.Title = T.Title;
                    tobj.RequestId = T.RequestId;
                    tobj.CandidateId = T.CandidateId;
                    tobj.StartHour = T.StartHour;
                    tobj.EndHour = T.EndHour;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<RcEvent> getSchedule(int requestId, int candidateId)
        {
            List<RcEvent> list = new List<RcEvent>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    list = context.RcEvents.Where(x => x.RequestId == requestId && x.CandidateId == candidateId).ToList();
                }
            }
            catch
            {

            }
            return list;
        }

        public bool CheckTime(RcEvent T)
        {
            bool check = false;
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    DateTime startHour = Convert.ToDateTime(T.StartHour);
                    DateTime endHour = Convert.ToDateTime(T.EndHour);
                    List<RcEvent> list = new List<RcEvent>();
                    list = context.RcEvents.Where(x => x.RequestId == T.RequestId && x.CandidateId == T.CandidateId).ToList();
                    if (list.Count == 0)
                    {
                        check = true;
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            DateTime from = Convert.ToDateTime(item.StartHour);
                            DateTime to = Convert.ToDateTime(item.EndHour);
                            if (startHour < from && endHour <= from || startHour >= to && endHour > to)
                            {
                                check = true;
                            }
                            else
                            {
                                check = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return check;
        }
        public List<ScheduleRes> GettoAddStep3Interview(int candidate, int request)
        {

            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcEvents.Where(x => x.RequestId == request && x.CandidateId == candidate && x.Classname == "interview").ToList()
                               select new ScheduleRes { Id = c.Id, Title = c.Title, Score = c.Score, Note = c.Note };
                    return list.OrderBy(x => x.Id).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ScheduleRes> GettoAddStep3Test(int candidate, int request)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcEvents.Where(x => x.RequestId == request && x.CandidateId == candidate && x.Classname == "test").ToList()
                               select new ScheduleRes { Id = c.Id, Title = c.Title, Score = c.Score, Note = c.Note };
                    return list.OrderBy(x => x.Id).ToList();
                }
            }
            catch
            {
                return null;
            }
        }


    }
}
