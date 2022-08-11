using API.ResponseModel.Candidate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAuto.Models;
using Services.CandidateService;
using Services.CommonServices;
using Services.ResponseModel.CandidateModel;
using Services.ResponseModel.RequestModel;
using Services.ResponseModel.Schedule;
using Services.ScheduleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateAPIController : AuthorizeByIDController
    {
        private ICandidate rc = new CandidateImpl();
        private ICommon c = new CommonImpl();
        private ISchedule s = new ScheduleImpl();
        [HttpPost("GetSkillSheet")]
        public IActionResult GetSkillSheet(string code1)
        {
            List<OtherList> list = new List<OtherList>();
            list = c.GetOtherList(code1, 0, Int32.MaxValue);
            if (code1.Equals("LANGUAGE"))
            {
                var listReturn = from l in list
                                 select new
                                 {
                                     name = l.Name,
                                     code = l.Code,
                                     note = l.Note,
                                     statusName = l.Status == -1 ? "Active" : "Deactive",
                                     id = l.Id,
                                     ListSkill = from skill in (rc.GetOtherListByAttribute(l.Id))
                                                 select new
                                                 {
                                                     name = skill.Name,
                                                     code = skill.Code,
                                                     note = skill.Note,
                                                     statusName = skill.Status == -1 ? "Active" : "Deactive",
                                                     id = skill.Id,
                                                 }
                                 };

                return Ok(new
                {
                    Data = listReturn
                });
            }
            else
            {
                var listReturn = from l in list
                                 select new
                                 {
                                     name = l.Name,
                                     code = l.Code,
                                     note = l.Note,
                                     statusName = l.Status == -1 ? "Active" : "Deactive",
                                     id = l.Id,
                                     ListSkill = from skill in (c.GetOtherList(l.Type.Level, 0, Int32.MaxValue))
                                                 select new
                                                 {
                                                     name = skill.Name,
                                                     code = skill.Code,
                                                     note = skill.Note,
                                                     statusName = skill.Status == -1 ? "Active" : "Deactive",
                                                     id = skill.Id,
                                                 }
                                 };
                return Ok(new
                {
                    Data = listReturn
                });

            }
        }


        [HttpPost("GetTypeSkill")]
        public IActionResult GetTypeSkill()
        {
            List<OtherListType> list = new List<OtherListType>();
            list = rc.GetSkillType(2);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 id = l.Id
                             };

            return Ok(new
            {
                Data = listReturn
            });

        }



        [HttpPost("InsertRcCandidate")]
        public IActionResult InsertRcCandidate([FromBody] Candidate T)
        {
            string code1 = "";
            try
            {
                bool check;
                Account a = GetCurrentUser();
                // rccandidate
                RcCandidate candidate = new RcCandidate();
                candidate.FullName = T.FullName;
                candidate.CreateBy = a.Employee?.FullName;
                candidate.RecordStatus = T.RecordStatus;
                string code = rc.AddRcCandidate(candidate);
                code1 = code;
                RcCandidate candidate1 = rc.GetCandidateByCode(code);
                // rccandidateCV
                RcCandidateCv cv = new RcCandidateCv();
                cv.CandidateId = candidate1.Id;
                if (T.Dob.Value.Year != 1000)
                {
                    cv.Dob = T.Dob;
                }

                cv.Gender = T.Gender;
                cv.Phone = T.Phone;
                cv.Zalo = T.Zalo;
                cv.Email = T.Email;
                cv.LinkedIn = T.LinkedIn;
                cv.Facebook = T.Facebook;
                cv.Twiter = T.Twiter;
                cv.Skype = T.Skype;
                cv.Website = T.Website;


                cv.NoiO = T.NoiO;
                if (T.NationLive != null)
                {
                    cv.NationLive = T.NationLive;
                }
                if (T.PorvinceLive != null)
                {
                    cv.PorvinceLive = T.PorvinceLive;
                }

                check = rc.AddRcCandidateCV(cv);
                // rccandidate Edu
                RcCandidateEdu edu = new RcCandidateEdu();
                edu.CandidateId = candidate1.Id;
                edu.Major1 = T.Major;
                if (T.Graduate.Value.Year != 1000)
                {
                    edu.Graduate1 = T.Graduate;
                }

                edu.School1 = T.School;
                if (T.Gpa != 0)
                {
                    edu.Gpa1 = T.Gpa;
                }

                edu.Awards1 = T.Awards;
                check = rc.AddRcCandidateEdu(edu);

                // rccandidate skill
                if (T.listSkill != null)
                {
                    List<RcCandidateSkill> list = new List<RcCandidateSkill>();
                    foreach (Skill item in T.listSkill)
                    {

                        RcCandidateSkill skill = new RcCandidateSkill();
                        skill.RcCandidateId = candidate1.Id;
                        if (item.TypeSkill != null)
                        {
                            skill.TypeSkill = item.TypeSkill;
                        }
                        if (item.Type != null && item.Type != 0)
                        {
                            skill.Type = item.Type;
                        }
                        if (item.Level != null && item.Level != 0)
                        {
                            skill.Level = item.Level;
                        }
                        if (item.Goal != "" && item.Goal != "0")
                            skill.Goal = item.Goal;
                        list.Add(skill);
                    }
                    check = rc.AddRcCandidateSkill(list);
                }


                //insert experience + domain
                if (T.listExp != null)
                {
                    List<RcCandidateExp> list1 = new List<RcCandidateExp>();
                    foreach (Exp item in T.listExp)
                    {
                        RcCandidateExp exp = new RcCandidateExp();
                        exp.RcCandidate = candidate1.Id;
                        exp.Firm = item.Firm;
                        if (item.TypeID != 0)
                        {
                            exp.TypeId = item.TypeID;
                        }
                        if (item.Positiob != "")
                        {
                            exp.Position = item.Positiob;
                        }
                        if (item.Time != "")
                        {
                            exp.Time = item.Time;
                        }
                        exp.CreateDate = DateTime.Now;
                        exp.CreateBy = a.Id.ToString();

                        list1.Add(exp);
                    }
                    check = rc.AddRcCandidateExp(list1);
                }


                return Ok(new
                {
                    Status = check,
                    Code = code1
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

        [HttpPost("SetStep1CandidatePV")]
        public IActionResult SetStep1CandidatePV([FromBody] SetStep1 pv)
        {
            try
            {
                bool check = rc.AddStep1(pv);
                return Ok(new
                {
                    Status = check,
                    Thongbao = check == true ? "successful Step1" : "fail Step1"
                });

            }
            catch
            {
                return Ok(new
                {
                    Status = false,
                    Thongbao = "Nhay vao catch"
                });
            }

        }

        [HttpPost("SetStep3CandidatePV")]
        public IActionResult SetStep3CandidatePV([FromBody] List<ScheduleRes> pv)
        {
            try
            {
                bool check = rc.AddStep3(pv);
                return Ok(new
                {
                    Status = check,
                    Thongbao = check == true ? "successful Step3" : "fail Step3"
                });

            }
            catch
            {
                return Ok(new
                {
                    Status = false,
                    Thongbao = "Nhay vao catch"
                });
            }

        }
        [HttpPost("SetStep4CandidatePV")]
        public IActionResult SetStep4CandidatePV([FromBody] SetStep4 pv)
        {
            try
            {
                bool check = rc.AddStep4(pv);
                return Ok(new
                {
                    Status = check,
                    Thongbao = check == true ? "successful Step4" : "fail Step4"
                });

            }
            catch
            {
                return Ok(new
                {
                    Status = false,
                    Thongbao = "Nhay vao catch"
                });
            }

        }
        [HttpPost("SetStep5CandidatePV")]
        public IActionResult SetStep5CandidatePV([FromBody] SetStep5 pv)
        {
            try
            {
                bool check = rc.AddStep5(pv);
                return Ok(new
                {
                    Status = check,
                    Thongbao = check == true ? "successful Step5" : "fail Step5"
                });

            }
            catch
            {
                return Ok(new
                {
                    Status = false,
                    Thongbao = "Nhay vao catch"
                });
            }

        }


        [HttpPost("GetAllCandidate")]
        public IActionResult GetAllCandidate(int index, int size)
        {
            List<CandidateResponeServices> list1 = rc.GetAllCandidate(index, size, 1);
            foreach (var item in list1)
            {
                if (item.positionList.Count > 0)
                {
                    item.lastestPosition = item.positionList.Last().name;
                    item.experience = item.positionList.Last().time;

                }
                string lang = "";
                item.languageList = item.languageList.GroupBy(p => p.name)
                    .Select(g => g.FirstOrDefault())
                    .ToList();
                foreach (var item2 in item.languageList)
                {
                    lang += item2.name + ", ";
                }
                item.language = lang;
            }

            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");

        }

        [HttpPost("GetAllCandidateDraff")]
        public IActionResult GetAllCandidateDraff(int index, int size)
        {
            List<CandidateResponeServices> list1 = rc.GetAllCandidate(index, size, 0);
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");
        }


        [HttpPost("GetAllCandidateByFillter")]
        public IActionResult GetAllCandidateByFillter([FromBody] CandidateFillter obj)
        {
            int totalItem = 0;
            List<CandidateResponeServices> list1 = rc.GetAllCandidateByFillter(obj.index, obj.size, obj.name, obj.yob, obj.phone, obj.email, obj.location, obj.position, obj.yearExp, obj.language, obj.status, ref totalItem);
            foreach (var item in list1)
            {
                if (item.positionList.Count > 0)
                {
                    item.lastestPosition = item.positionList.Last().name;
                    item.experience = item.positionList.Last().time;
                }
                string lang = "";
                item.languageList = item.languageList.GroupBy(p => p.name)
                 .Select(g => g.FirstOrDefault())
                 .ToList();
                if (item.languageList.Count > 0)
                {
                    foreach (var item2 in item.languageList)
                    {
                        lang += item2.name + "  ";
                    }
                }
                item.language = lang;
            }
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = totalItem,
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");

        }

        [HttpPost("GetOneInforCandidate")]
        public IActionResult GetOneInforCandidate(int id)
        {
            RcCandidate c = rc.GetCandidateByID(id);
            if (c != null)
            {
                List<RcCandidate> list = new List<RcCandidate>();
                list.Add(c);
                var list1 = from b in list
                            let cv = rc.GetCandidateCVbyID(b.Id)
                            let edu = rc.GetCandidateEdubyID(b.Id)
                            select new
                            {
                                ID = c.Id,
                                Code = c.Code,
                                FullName = c.FullName,
                                Dob = cv == null ? "" : (cv.Dob == null ? "" : cv.Dob.Value.Year.ToString()),
                                Phone = cv == null ? "" : (cv.Phone == null ? "" : cv.Phone),
                                Email = cv == null ? "" : (cv.Email == null ? "" : cv.Email),
                                Gender = cv == null ? "" : (cv.Gender == null ? "" : cv.Gender.ToString()),
                                Address = cv == null ? "" : (cv.NoiO == null ? "" : cv.NoiO),
                                NationLive = rc.GetNation(cv.NationLive) == null ? "" : rc.GetNation(cv.NationLive).Name,
                                ProvinceLive = rc.GetLocation(cv.PorvinceLive) == null ? "" : rc.GetLocation(cv.PorvinceLive).Name,
                                Zalo = cv == null ? "" : (cv.Zalo == null ? "" : cv.Zalo),
                                Facebook = cv == null ? "" : (cv.Facebook == null ? "" : cv.Facebook),
                                Skype = cv == null ? "" : (cv.Skype == null ? "" : cv.Skype),
                                Website = cv == null ? "" : (cv.Website == null ? "" : cv.Website),

                                Awards = edu == null ? "" : (edu.Awards1 == null ? "" : edu.Awards1),
                                School = edu == null ? "" : (edu.School1 == null ? "" : edu.School1),
                                Major = edu == null ? "" : (edu.Major1 == null ? "" : edu.Major1),
                                Score = edu == null ? "" : (edu.Gpa1 == null ? "" : edu.Gpa1.ToString()),
                                Graduate = edu == null ? "" : (edu.Graduate1 == null ? "" : edu.Graduate1.Value.ToString("dd-MM-yyyy")),
                                Language = from a in rc.GetCandidateLanguagebyID(b.Id)
                                           group a by a.TypeSkill into g
                                           select new
                                           {
                                               Id = rc.GetOtherListTypesCandidate((int)g.Key).Id,
                                               TypeSkill = rc.GetOtherListTypesCandidate((int)g.Key).Name,
                                               Child = from d in g.ToList()
                                                       group d by d.Type into i
                                                       select new
                                                       {
                                                           Type = rc.GetOtherListCandidate((int)i.Key).Name,
                                                           Child = from k in i.ToList()
                                                                   group k by k.Level into k1
                                                                   select new
                                                                   {
                                                                       Level = rc.GetOtherListCandidate((int)k1.Key).Name,
                                                                       Goal = k1.ToList().Find(x => x.Level == k1.Key).Goal

                                                                   }
                                                       }

                                           },

                                SkillSheet = from a in rc.GetCandidateSkillbyID(b.Id)
                                             group a by a.TypeSkill into g
                                             select new
                                             {
                                                 Id = rc.GetOtherListTypesCandidate((int)g.Key).Id,
                                                 TypeSkill = rc.GetOtherListTypesCandidate((int)g.Key).Name,
                                                 Child = from d in g.ToList()
                                                         group d by d.Type into i
                                                         select new
                                                         {
                                                             Type = i.Key == null ? "" : rc.GetOtherListCandidate((int)i.Key).Name,
                                                             Child = from k in i.ToList()
                                                                     group k by k.Level into k1
                                                                     select new
                                                                     {
                                                                         Level = k1.Key == null ? "" : rc.GetOtherListCandidate((int)k1.Key).Name,
                                                                         Goal = k1.ToList().Find(x => x.Level == k1.Key).Goal

                                                                     }
                                                         }

                                             },


                                Domain = from a in rc.GetExpOneCandidate(b.Id, 82)
                                         select new
                                         {
                                             Firm = a.Firm,
                                             Positiob = a.Position,
                                             Time = a.Time
                                         },
                                OutSource = from a in rc.GetExpOneCandidate(b.Id, 81)
                                            select new
                                            {
                                                Firm = a.Firm,
                                                Positiob = a.Position,
                                                Time = a.Time
                                            },
                                Note = c.Note,
                                RecordStatus = c.RecordStatus
                            };

                return Ok(new
                {
                    Status = true,
                    Data = list1
                });
            }
            else
            {
                return Ok(new
                {
                    Status = false,
                    Data = "Dont find"
                });
            }

        }

        [HttpPost("CheckDuplicateCandidate")]
        public IActionResult CheckDuplicateCandidate([FromBody] CheckDuplicateCandidateModel obj)
        {
            return Ok(new
            {
                Data = rc.checkDuplicateCandidate(obj)
            });
        }

        [HttpPost("DeleteCandidate")]
        public IActionResult DeleteCandidate(List<int> ListID)
        {
            return Ok(new
            {
                Status = rc.deleteCandidate(ListID)
            });
        }

        [HttpPost("ActiveCandidate")]
        public IActionResult ActiveCandidate(List<int> ListID)
        {
            return Ok(new
            {
                Status = rc.activeCandidate(ListID)
            });
        }
        [HttpPost("DeActiveCandidate")]
        public IActionResult DeActiveCandidate([FromBody] deactiveResponse obj)
        {
            return Ok(new
            {
                Status = rc.deactiveCandidate(obj.lstCandidateID, obj.comment)
            });
        }



        #region Matching Candidate

        [HttpPost("MatchingCandidate")]
        public IActionResult MatchingCandidate([FromBody] MatchingResponse obj)
        {
            try
            {
                return Ok(new
                {
                    Status = rc.MatchingCandidate(obj.RequestID, obj.lstCandidateID)
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

        [HttpPost("CheckQuantity")]
        public IActionResult CheckQuantity([FromBody] MatchingResponse obj)
        {
            try
            {
                return Ok(new
                {
                    Status = rc.CheckQuantity(obj.RequestID, obj.lstCandidateID)
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

        [HttpPost("DeleteCandidateRequest")]
        public IActionResult DeleteCandidateRequest([FromBody] List<int> listID)
        {
            try
            {
                return Ok(new
                {
                    Status = rc.DeleteCandidateRequest(listID)
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

        [HttpPost("GetCandidateByRequest")]
        public IActionResult GetCandidateByRequest([FromBody] CandidateFillter obj)
        {
            int totalItem = 0;
            List<CandidateResponeServices> list1 = rc.GetCandidateByRequest(obj.requestID ?? 0, obj.index, obj.size, obj.name, obj.yob, obj.phone, obj.email, obj.location, obj.position, obj.yearExp, obj.language, obj.status, ref totalItem);
            foreach (var item in list1)
            {
                if (item.positionList.Count > 0)
                {
                    item.lastestPosition = item.positionList.Last().name;
                    item.experience = item.positionList.Last().time;
                }
                string lang = "";
                if (item.languageList.Count > 0)
                {
                    foreach (var item2 in item.languageList)
                    {
                        lang += item2.name + "  ";
                    }
                }
                item.language = lang;
            }
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = totalItem,
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");
        }

        [HttpPost("CheckDuplicateMatching")]
        public IActionResult CheckDuplicateMatching(List<int> lstCandidateID, int requestID)
        {
            string mess = "";
            return Ok(new
            {
                Status = rc.CheckDuplicateMatching(requestID, lstCandidateID, ref mess),
                mess = mess
            });
        }




        #endregion
        #region " Step"
        [Authorize]
        [HttpPost("GetAllRequestByCandidateID")]
        public IActionResult GetAllRequestByCandidateID(int id)
        {
            Account a = GetCurrentUser();
            List<RequestResponseServices> list = rc.GetAllRequestByCandidateID(id);
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Data = list
                });
            }
            return Ok(new
            {
                Data = new List<RequestResponseServices>()
            });
        }




        [Authorize]
        [HttpPost("GetCandidateRequestInf")]
        public IActionResult GetCandidateRequestInf(int requestId, int candidateId)
        {
            CandidatePV_infor obj = rc.GetCandidateRequestInf(candidateId, requestId);
            return Ok(new
            {
                Data = obj
            });
        }




        [Authorize]
        [HttpPost("Onboard")]
        public IActionResult Onboard(int candidateId, int requestId)
        {
            return Ok(new
            {
                Status = rc.Onboard(candidateId, requestId)
            });
        }



        [HttpPost("CheckInforCandidateEdit")]
        public IActionResult CheckInforCandidateEdit([FromBody] CandidateEdit e)
        {
            string check = rc.CheckInforCandidateEdit(e);
            if (check == "")
            {
                return Ok(new
                {
                    Status = true,
                    Thongbao = "Khong bi trung thong tin"
                });
            }
            else
            {
                return Ok(new
                {
                    Status = false,
                    Thongbao = check + " already existed"
                });
            }
        }

        [HttpPost("EditInforCandidate")]
        public IActionResult EditInforCandidate([FromBody] InforCandidateEdit e)
        {
            try
            {
                bool check = rc.EditCandidateInfor(e);
                return Ok(new
                {
                    Thongbao = check == true ? "Successfull " : "Fail",
                    Status = check
                });
            }
            catch
            {
                return Ok(
                    new
                    {
                        Thongbao = "Dang nhay vao catch",
                        Status = false
                    }
                    );
            }
        }

        [HttpPost("GetOneInforCandidateToEdit")]
        public IActionResult GetOneInforCandidateToEdit(int id)
        {
            RcCandidate c = rc.GetCandidateByID(id);
            if (c != null)
            {
                List<RcCandidate> list = new List<RcCandidate>();
                list.Add(c);
                var list1 = from b in list
                            let cv = rc.GetCandidateCVbyID(b.Id)
                            let edu = rc.GetCandidateEdubyID(b.Id)
                            select new
                            {
                                ID = c.Id,
                                Code = c.Code,
                                FullName = c.FullName,
                                Dob = cv == null ? "" : (cv.Dob == null ? "" : cv.Dob.Value.ToString("dd-MM-yyyy")),
                                Phone = cv == null ? "" : (cv.Phone == null ? "" : cv.Phone),
                                Email = cv == null ? "" : (cv.Email == null ? "" : cv.Email),
                                Gender = cv == null ? "" : (cv.Gender == null ? "" : cv.Gender.ToString()),
                                Address = cv == null ? "" : (cv.NoiO == null ? "" : cv.NoiO),
                                NationLive = cv == null ? "" : (cv.NationLive == null ? "" : cv.NationLive.ToString()),
                                ProvinceLive = cv == null ? "" : (cv.PorvinceLive == null ? "" : cv.PorvinceLive.ToString()),
                                Zalo = cv == null ? "" : (cv.Zalo == null ? "" : cv.Zalo),
                                Facebook = cv == null ? "" : (cv.Facebook == null ? "" : cv.Facebook),
                                Skype = cv == null ? "" : (cv.Skype == null ? "" : cv.Skype),
                                Website = cv == null ? "" : (cv.Website == null ? "" : cv.Website),
                                Awards = edu == null ? "" : (edu.Awards1 == null ? "" : edu.Awards1),
                                School = edu == null ? "" : (edu.School1 == null ? "" : edu.School1),
                                Major = edu == null ? "" : (edu.Major1 == null ? "" : edu.Major1),
                                Score = edu == null ? "" : edu.Gpa1.ToString(),
                                Graduate = edu == null ? "" : (edu.Graduate1 == null ? "" : edu.Graduate1.Value.ToString("dd-MM-yyyy")),
                                Note = c.Note

                            };

                return Ok(new
                {
                    Status = true,
                    Data = list1
                });
            }
            else
            {
                return Ok(new
                {
                    Status = false,
                    Data = "Dont find"
                });
            }

        }
        [HttpPost("GetAllResultStep3")]
        public IActionResult GetAllResultStep3(int requestID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c1 in context.RcCandidatePvs.Where(x => x.RequestId == requestID && x.StepNow == 3).ToList()
                               let candidate = rc.GetCandidateByID((int)c1.CandidateId)
                               select new ResultStep3
                               {
                                   CandidateID = candidate.Id,
                                   RequestID = c1.RequestId,
                                   Name = candidate.FullName,
                                   InterView = s.GettoAddStep3Interview(candidate.Id, (int)c1.RequestId),
                                   Test = s.GettoAddStep3Test(candidate.Id, (int)c1.RequestId)
                               };
                    return Ok(new
                    {
                        Status = true,
                        List = list
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
        [HttpPost("PassStep3to4")]
        public IActionResult PassStep3to4([FromBody] PassStep3 e)
        {
            try
            {
                bool check = rc.PassStep3_4(e);
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
        [HttpPost("ViewStep3RcEvent")]
        public IActionResult ViewStep3RcEvent(int candidate, int request)
        {
            try
            {
                ListSchedule l = new ListSchedule { Interview = s.GettoAddStep3Interview(candidate, request), Test = s.GettoAddStep3Test(candidate, request) };


                return Ok(new
                {
                    Status = true,
                    Data = l
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
