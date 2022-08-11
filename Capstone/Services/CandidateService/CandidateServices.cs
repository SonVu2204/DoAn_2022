using ModelAuto.Models;
using Services.CommonServices;
using Services.ResponseModel.CandidateModel;
using Services.ResponseModel.RequestModel;
using Services.ResponseModel.Schedule;
using Services.ScheduleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
    public class CandidateImpl : ICandidate
    {
       
        public List<OtherList> GetOtherListByAttribute(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<OtherList> listReturn = context.OtherLists.Where(x => x.Atribute1 == ID.ToString()).ToList();
                    return listReturn;
                }
            }
            catch
            {
                return new List<OtherList>();
            }
        }

        ICommon c = new CommonImpl();
        public string AddRcCandidate(RcCandidate r)
        {
            string code1;
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    List<RcCandidate> list = context.RcCandidates.ToList();
                    RcCandidate r1 = new RcCandidate();
                    if (list.Count == 0)
                    {
                        r1.Code = "UV1";
                    }
                    else
                    {


                        RcCandidate r2 = list.Last();
                        string index = r2.Code.Substring(2);
                        r1.Code = "UV" + (int.Parse(index) + 1);
                    }
                    r1.FullName = r.FullName;
                    r1.StepCv = 1;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    r1.RecordStatus = r.RecordStatus;
                    context.RcCandidates.Add(r1);
                    context.SaveChanges();
                    code1 = r1.Code;
                }
                return code1;

            }
            catch
            {
                return null;
            }
        }

        public bool AddRcCandidateCV(RcCandidateCv r)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidateCv r1 = new RcCandidateCv();
                    r1.CandidateId = r.CandidateId;
                    r1.Dob = r.Dob;
                    r1.Gender = r.Gender;
                    r1.Phone = r.Phone;
                    r1.Zalo = r.Zalo;
                    r1.Email = r.Email;
                    r1.LinkedIn = r.LinkedIn;
                    r1.Facebook = r.Facebook;
                    r1.Twiter = r.Twiter;
                    r1.NoiO = r.NoiO;
                    r1.Skype = r.Skype;
                    r1.Website = r.Website;
                    r1.NationLive = r.NationLive;
                    r1.PorvinceLive = r.PorvinceLive;
                    r1.DistrictLive = r.DistrictLive;
                    r1.WardLive = r.WardLive;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    context.RcCandidateCvs.Add(r1);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddRcCandidateEdu(RcCandidateEdu r)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidateEdu r1 = new RcCandidateEdu();
                    r1.CandidateId = r.CandidateId;
                    r1.Major1 = r.Major1;
                    r1.Graduate1 = r.Graduate1;
                    r1.School1 = r.School1;
                    r1.Gpa1 = r.Gpa1;
                    r1.Awards1 = r.Awards1;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    context.RcCandidateEdus.Add(r1);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AddRcCandidateSkill(List<RcCandidateSkill> r)
        {
            try
            {
                using var context = new CapstoneProject2022Context();
                context.RcCandidateSkills.AddRange(r);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool deleteCandidate(List<int> list)
        {
            try
            {
                using var context = new CapstoneProject2022Context();

                // xóa exp
                var listExp = (from l1 in context.RcCandidateExps.Where(x => list.Contains(x.RcCandidate ?? 0))
                               select new RcCandidateExp
                               {
                                   Id = l1.Id
                               }).ToList();
                foreach (var item in listExp)
                {
                    RcCandidateExp o = context.RcCandidateExps.Where(x => x.Id == item.Id).FirstOrDefault();
                    context.RcCandidateExps.Remove(o);
                }
                // xóa skill
                var listSkill = (from l1 in context.RcCandidateSkills.Where(x => list.Contains(x.RcCandidateId ?? 0))
                                 select new RcCandidateSkill
                                 {
                                     Id = l1.Id
                                 }).ToList();
                foreach (var item in listSkill)
                {
                    RcCandidateSkill o = context.RcCandidateSkills.Where(x => x.Id == item.Id).FirstOrDefault();
                    context.RcCandidateSkills.Remove(o);
                }

                // xóa edu
                var listedu = (from l1 in context.RcCandidateEdus.Where(x => list.Contains(x.CandidateId ?? 0))
                               select new RcCandidateEdu
                               {
                                   Id = l1.Id
                               }).ToList();
                foreach (var item in listedu)
                {
                    RcCandidateEdu o = context.RcCandidateEdus.Where(x => x.Id == item.Id).FirstOrDefault();
                    context.RcCandidateEdus.Remove(o);
                }

                // xóa cv
                var listCV = (from l1 in context.RcCandidateCvs.Where(x => list.Contains(x.CandidateId ?? 0))
                              select new RcCandidateCv
                              {
                                  Id = l1.Id
                              }).ToList();
                foreach (var item in listCV)
                {
                    RcCandidateCv o = context.RcCandidateCvs.Where(x => x.Id == item.Id).FirstOrDefault();
                    context.RcCandidateCvs.Remove(o);
                }

                foreach (var item in list)
                {
                    RcCandidate o = context.RcCandidates.Where(x => x.Id == item).FirstOrDefault();
                    context.RcCandidates.Remove(o);
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string exm = ex.Message.ToString();
                return false;
            }

        }

        public bool activeCandidate(List<int> list)
        {
            using var context = new CapstoneProject2022Context();
            foreach (var item in list)
            {
                RcCandidate c = context.RcCandidates.Where(x => x.Id == item).FirstOrDefault();
                c.RecordStatus = 1;
                c.Note = "";
            }
            context.SaveChanges();
            return true;
        }
        public bool deactiveCandidate(List<int> list, string comment)
        {
            try
            {
                using var context = new CapstoneProject2022Context();
                foreach (var item in list)
                {
                    RcCandidate c = context.RcCandidates.Where(x => x.Id == item).FirstOrDefault();
                    c.Note = comment;
                    c.RecordStatus = 0;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public List<CandidateResponeServices> GetAllCandidate(int index, int size, int status)
        {
            List<CandidateResponeServices> list = new List<CandidateResponeServices>();
            try
            {
                using var context = new CapstoneProject2022Context();
                var query = from c in context.RcCandidates.Where(x => x.RecordStatus == status)
                            from cv in context.RcCandidateCvs.Where(x => x.CandidateId == c.Id).DefaultIfEmpty()
                            from na in context.Nations.Where(x => x.Id == cv.NationLive).DefaultIfEmpty()
                            from pr in context.Provinces.Where(x => x.Id == cv.PorvinceLive).DefaultIfEmpty()
                            select new CandidateResponeServices
                            {
                                id = c.Id,
                                name = c.FullName,
                                code = c.Code,
                                yob = cv.Dob.Value.Year,
                                dob = cv.Dob,
                                dobString = Convert.ToDateTime(cv.Dob).ToString("dd/MM/YYYY"),
                                phoneNumber = cv.Phone,
                                email = cv.Email,
                                nation = na.Name,
                                province = pr.Name,
                                nationID = na.Id,
                                provinceID = pr.Id,
                                location = na.Name + " - " + pr.Name,
                                status = c.RecordStatus.ToString(),
                                statusId = c.RecordStatus,
                                note = c.Note,
                                positionList = (from p in context.RcCandidateExps.Where(x => x.RcCandidate == c.Id)
                                                select new positionObj { id = p.Id, name = p.Position, time = p.Time }).ToList(),
                                languageList = (from lstla in context.RcCandidateSkills.Where(x => x.RcCandidateId == c.Id)
                                                from ot in context.OtherLists.Where(x => x.Id == lstla.Type).DefaultIfEmpty()
                                                where ot.TypeId == 14
                                                select new languageObj { name = ot.Name }).ToList()
                            };

                list = query.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
            }
            catch (Exception ex)
            {
                string a = ex.Message.ToString();

            }
            return list;
        }

        public List<CandidateResponeServices> GetAllCandidateByFillter(int index, int size, string name, int yob, string phone, string email, string location, string position, string yearExp, string language, int status, ref int totalItems)
        {
            List<CandidateResponeServices> list = new List<CandidateResponeServices>();
            try
            {
                using var context = new CapstoneProject2022Context();
                var query = from c in context.RcCandidates
                            from cv in context.RcCandidateCvs.Where(x => x.CandidateId == c.Id).DefaultIfEmpty()
                            from na in context.Nations.Where(x => x.Id == cv.NationLive).DefaultIfEmpty()
                            from pr in context.Provinces.Where(x => x.Id == cv.PorvinceLive).DefaultIfEmpty()
                            select new CandidateResponeServices
                            {
                                id = c.Id,
                                name = c.FullName,
                                code = c.Code,
                                yob = cv.Dob.Value.Year,
                                dob = cv.Dob,
                                dobString = Convert.ToDateTime(cv.Dob).ToString("dd/MM/YYYY"),
                                phoneNumber = cv.Phone,
                                email = cv.Email,
                                nation = na.Name,
                                province = pr.Name,
                                nationID = na.Id,
                                provinceID = pr.Id,
                                location = na.Name + " - " + pr.Name,
                                status = c.RecordStatus.ToString(),
                                statusId = c.RecordStatus,
                                positionList = (from p in context.RcCandidateExps.Where(x => x.RcCandidate == c.Id)
                                                select new positionObj { id = p.Id, name = p.Position, time = p.Time }).ToList(),
                                languageList = (from lstla in context.RcCandidateSkills.Where(x => x.RcCandidateId == c.Id)
                                                from ot in context.OtherLists.Where(x => x.Id == lstla.Type).DefaultIfEmpty()
                                                where ot.TypeId == 14
                                                select new languageObj { name = ot.Name }).ToList(),
                                statusName = c.RecordStatus == 1 ? "Active" : "Draft"
                            };

                list = query.ToList();
                if (!name.Trim().Equals(""))
                {
                    list = list.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
                }
                if (yob != 0)
                {
                    list = list.Where(x => x.yob == yob).ToList();
                }
                if (!phone.Trim().Equals(""))
                {
                    list = list.Where(x => x.phoneNumber.ToLower().Contains(phone.ToLower())).ToList();
                }
                if (!email.Trim().Equals(""))
                {
                    list = list.Where(x => x.email.ToLower().Contains(email.ToLower())).ToList();
                }
                if (!location.Trim().Equals(""))
                {
                    list = list.Where(x => x.location.ToLower().Contains(location.ToLower())).ToList();
                }
                if (!position.Trim().Equals(""))
                {
                    list = list.Where(x => x.positionList.Count > 0).ToList();
                    list = list.Where(x => x.positionList.Last().name.ToLower().Contains(position.ToLower())).ToList();
                }
                if (!yearExp.Trim().Equals(""))
                {
                    list = list.Where(x => x.positionList.Count > 0).ToList();
                    list = list.Where(x => x.positionList.Last().time.ToLower().Contains(yearExp.ToLower())).ToList();
                }
                if (!language.Trim().Equals(""))
                {
                    list = list.Where(x => x.languageList.Count > 0).ToList();
                    foreach (var item in list)
                    {
                        string lang = "";
                        foreach (var item2 in item.languageList)
                        {
                            lang += item2.name + ", ";
                        }
                        item.language = lang;
                    }
                    list = list.Where(x => x.language.Trim().ToLower().Contains(language.ToLower())).ToList();
                }
                totalItems = list.Count;
                list = list.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
            }
            catch
            {

            }
            return list;
        }



        public List<RcCandidate> GetAllCandidateByStep(int step)
        {
            List<RcCandidate> list = new List<RcCandidate>();
            try
            {
                using var context = new CapstoneProject2022Context();
                list = context.RcCandidates.Where(x => x.StepCv == step).ToList();
            }
            catch
            {
            }
            return list;
        }

        public RcCandidate GetCandidateByCode(string code)
        {
            RcCandidate candidate = new RcCandidate();
            try
            {
                using var context = new CapstoneProject2022Context();
                candidate = context.RcCandidates.Where(x => x.Code == code).SingleOrDefault();
            }
            catch
            {

            }
            return candidate;
        }

        public RcCandidate GetCandidateByID(int id)
        {
            RcCandidate candidate = new RcCandidate();
            try
            {
                using var context = new CapstoneProject2022Context();
                candidate = context.RcCandidates.Where(x => x.Id == id).SingleOrDefault();
            }
            catch
            {

            }
            return candidate;
        }

        public RcCandidateCv GetCandidateCVbyID(int? id)
        {
            RcCandidateCv cv = new RcCandidateCv();
            try
            {
                using var context = new CapstoneProject2022Context();
                cv = context.RcCandidateCvs.Where(x => x.CandidateId == id).SingleOrDefault();
                return cv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public RcCandidateEdu GetCandidateEdubyID(int id)
        {
            RcCandidateEdu edu = new RcCandidateEdu();
            try
            {
                using var context = new CapstoneProject2022Context();
                edu = context.RcCandidateEdus.Where(x => x.CandidateId == id).SingleOrDefault();
                return edu;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public List<RcCandidateSkill> GetCandidateSkillbyID(int id)
        {
            List<RcCandidateSkill> list = new List<RcCandidateSkill>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.RcCandidateSkills.Where(x => x.RcCandidateId == id).ToList();
                list = list.Where(x => x.TypeSkill == 15 || x.TypeSkill == 16 || x.TypeSkill == 18 || x.TypeSkill == 25 || x.TypeSkill == 26).ToList();
                return list;
            }
            catch
            {
                return null;
            }

        }





        public bool ViewFailedCandidate(int CandidateID)
        {
            try
            {
                using var context = new CapstoneProject2022Context();


                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<OtherListType> GetSkillType(int type)
        {
            List<OtherListType> list = new List<OtherListType>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.OtherListTypes.Where(x => x.TypeSkill == type).ToList();
            }
            catch
            {

            }
            return list;
        }

        public bool AddRcCandidateExp(List<RcCandidateExp> r)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {

                    context.RcCandidateExps.AddRange(r);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<RcCandidateExp> GetCandidateExpbyID(int id)
        {
            List<RcCandidateExp> list = new List<RcCandidateExp>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.RcCandidateExps.Where(x => x.RcCandidate == id).ToList();
            }
            catch
            {

            }
            return list;
        }

        public Province GetLocation(int? id)
        {
            Province p = new Province();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Provinces.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return null;
            }
        }

        //public string GetSkill(int? candidateID)
        //{
        //    string skill = "";
        //    try
        //    {
        //        using (var context = new CapstoneProject2022Context())
        //        {
        //            List<RcCandidateSkill> list = context.RcCandidateSkills.Where(x => x.RcCandidateId == candidateID && x.TypeSkill == 14).ToList();
        //            var group = list.GroupBy(x => x.Type);
        //            foreach (var item in group)
        //            {
        //                OtherList o = context.OtherLists.Where(x => x.Id == item.Key).SingleOrDefault();
        //                if (o != null)
        //                {
        //                    skill += o.Name + ",";
        //                }
        //            }


        //        }
        //        return skill;

        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public string Position(int? candidateID)
        //{
        //    string position = "";
        //    try
        //    {
        //        using (var context = new CapstoneProject2022Context())
        //        {
        //            List<RcCandidateExp> list = context.RcCandidateExps.Where(x => x.RcCandidate == candidateID).ToList();
        //            if (list.Count == 0)
        //            {
        //                position = "";
        //            }
        //            else
        //            {
        //                position = list.Take(1).FirstOrDefault().Position;


        //            }
        //        }
        //    }
        //    catch
        //    {
        //        position = "";
        //    }
        //    return position;
        //}

        //public string Exp(int? candidateID)
        //{
        //    string exp = "";
        //    try
        //    {
        //        using (var context = new CapstoneProject2022Context())
        //        {
        //            List<RcCandidateExp> list = context.RcCandidateExps.Where(x => x.RcCandidate == candidateID).ToList();
        //            if (list.Count == 0)
        //            {
        //                exp = "";
        //            }
        //            else
        //            {
        //                exp = list.Take(1).FirstOrDefault().Time;


        //            }
        //        }
        //    }
        //    catch
        //    {
        //        exp = "";
        //    }
        //    return exp;
        //}


        public checkResponse checkDuplicateCandidate(CheckDuplicateCandidateModel obj)
        {
            checkResponse objReturn = new checkResponse();
            objReturn.mess = "";
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    List<CheckDuplicateCandidateModel> list = new List<CheckDuplicateCandidateModel>();
                    var query = from c in context.RcCandidates
                                from cv in context.RcCandidateCvs.Where(x => x.CandidateId == c.Id)
                                select new CheckDuplicateCandidateModel
                                {
                                    email = cv.Email,
                                    faceBook = cv.Facebook,
                                    linkIn = cv.LinkedIn,
                                    phone = cv.Phone,
                                    skype = cv.Skype,
                                    twitter = cv.Twiter,
                                    website = cv.Website,
                                    zalo = cv.Zalo
                                };


                    if (!obj.email.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.email.Equals("") && x.email.Trim().ToLower().Equals(obj.email)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Email information ;";
                        }
                    }
                    if (!obj.faceBook.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.faceBook.Equals("") && x.faceBook.Trim().ToLower().Equals(obj.faceBook)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Facebook information ;";
                        }
                    }
                    if (!obj.linkIn.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.linkIn.Equals("") && x.linkIn.Trim().ToLower().Equals(obj.linkIn)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " LinkIn information ;";
                        }
                    }
                    if (!obj.phone.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.phone.Equals("") && x.phone.Trim().ToLower().Equals(obj.phone)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Phone Number information ;";
                        }
                    }
                    if (!obj.skype.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.skype.Equals("") && x.skype.Trim().ToLower().Equals(obj.skype)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Skype information ;";
                        }
                    }
                    if (!obj.twitter.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.twitter.Equals("") && x.twitter.Trim().ToLower().Equals(obj.twitter)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Twitter information ;";
                        }
                    }
                    if (!obj.website.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.website.Equals("") && x.website.Trim().ToLower().Equals(obj.website)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Website information ;";
                        }
                    }
                    if (!obj.zalo.Trim().Equals(""))
                    {
                        list = query.ToList();
                        list = list.Where(x => !x.zalo.Equals("") && x.zalo.Trim().ToLower().Equals(obj.zalo)).ToList();
                        if (list.Count > 0)
                        {
                            objReturn.mess += " Zalo information ;";
                        }
                    }
                    if (!objReturn.mess.Trim().Equals(""))
                    {
                        objReturn.check = false;
                        objReturn.mess += " already exists in the candidate's profile";
                    }
                    else
                    {
                        objReturn.check = true;
                        objReturn.mess = "";
                    }
                }
            }
            catch
            {
            }
            return objReturn;
        }


        #region matching REquesst
        public bool MatchingCandidate(int requestID, List<int> lstCandidateID)
        {
            List<int> list = new List<int>();

            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var listcheck = (from rc in context.RcRequestCandidates.Where(x => x.RequestId == requestID)
                                     from c in context.RcCandidates.Where(x => x.Id == rc.CandidateId).DefaultIfEmpty()
                                     select new checkDuplicateMatching
                                     {
                                         candidateId = c.Id,
                                         candidateName = c.FullName
                                     }).ToList();
                    list = listcheck.Select(x => x.candidateId).Distinct().ToList();
                    var lst = lstCandidateID.Except(list);

                    if (requestID != 0)
                    {
                        foreach (var id in lst)
                        {
                            // add request 
                            RcRequestCandidate obj = new RcRequestCandidate();
                            obj.CandidateId = id;
                            obj.RequestId = requestID;
                            context.RcRequestCandidates.Add(obj);

                            // dong thoi add luon vao candidatePV
                            RcCandidatePv pv = new RcCandidatePv();
                            pv.CandidateId = id;
                            pv.RequestId = requestID;
                            pv.StepNow = 1;
                            context.RcCandidatePvs.Add(pv);
                        }
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
                return false;
            }
        }

        public bool CheckDuplicateMatching(int requestID, List<int> candidateID, ref string mess)
        {
            mess = "";
            try
            {
                List<checkDuplicateMatching> list = new List<checkDuplicateMatching>();
                using (var context = new CapstoneProject2022Context())
                {
                    list = (from rc in context.RcRequestCandidates.Where(x => x.RequestId == requestID)
                            from c in context.RcCandidates.Where(x => x.Id == rc.CandidateId).DefaultIfEmpty()
                            where candidateID.Contains(c.Id)
                            select new checkDuplicateMatching
                            {
                                candidateName = c.FullName
                            }).ToList();
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            mess += item.candidateName + " ";
                        }
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                mess += "check duplicate Wrong!";
                return false;
            }
        }

        public List<CandidateResponeServices> GetCandidateByRequest(int requestID, int index, int size, string name, int yob, string phone, string email, string location, string position, string yearExp, string language, int status, ref int totalItems)
        {
            List<CandidateResponeServices> list = new List<CandidateResponeServices>();
            try
            {
                using var context = new CapstoneProject2022Context();
                var query = from a in context.RcRequestCandidates.Where(x => x.RequestId == requestID)
                            from c in context.RcCandidates.Where(x => x.Id == a.CandidateId).DefaultIfEmpty()
                            from cv in context.RcCandidateCvs.Where(x => x.CandidateId == c.Id).DefaultIfEmpty()
                            from na in context.Nations.Where(x => x.Id == cv.NationLive).DefaultIfEmpty()
                            from pr in context.Provinces.Where(x => x.Id == cv.PorvinceLive).DefaultIfEmpty()
                            select new CandidateResponeServices
                            {
                                id = c.Id,
                                name = c.FullName,
                                code = c.Code,
                                yob = cv.Dob.Value.Year,
                                dob = cv.Dob,
                                dobString = Convert.ToDateTime(cv.Dob).ToString("dd/MM/YYYY"),
                                phoneNumber = cv.Phone,
                                email = cv.Email,
                                nation = na.Name,
                                province = pr.Name,
                                nationID = na.Id,
                                provinceID = pr.Id,
                                location = na.Name + " - " + pr.Name,
                                status = c.RecordStatus.ToString(),
                                statusId = c.RecordStatus,
                                positionList = (from p in context.RcCandidateExps.Where(x => x.RcCandidate == c.Id)
                                                select new positionObj { id = p.Id, name = p.Position, time = p.Time }).ToList(),
                                languageList = (from lstla in context.RcCandidateSkills.Where(x => x.RcCandidateId == c.Id)
                                                from ot in context.OtherLists.Where(x => x.Id == lstla.Type).DefaultIfEmpty()
                                                where ot.TypeId == 14
                                                select new languageObj { name = ot.Name }).ToList(),
                                statusName = c.RecordStatus == 1 ? "Active" : "Draft"
                            };

                list = query.ToList();
                if (!name.Trim().Equals(""))
                {
                    list = list.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
                }
                if (yob != 0)
                {
                    list = list.Where(x => x.yob == yob).ToList();
                }
                if (!phone.Trim().Equals(""))
                {
                    list = list.Where(x => x.phoneNumber.ToLower().Contains(phone.ToLower())).ToList();
                }
                if (!email.Trim().Equals(""))
                {
                    list = list.Where(x => x.email.ToLower().Contains(email.ToLower())).ToList();
                }
                if (!location.Trim().Equals(""))
                {
                    list = list.Where(x => x.location.ToLower().Contains(location.ToLower())).ToList();
                }
                if (!position.Trim().Equals(""))
                {
                    list = list.Where(x => x.positionList.Count > 0).ToList();
                    list = list.Where(x => x.positionList.Last().name.ToLower().Contains(position.ToLower())).ToList();
                }
                if (!yearExp.Trim().Equals(""))
                {
                    list = list.Where(x => x.positionList.Count > 0).ToList();
                    list = list.Where(x => x.positionList.Last().time.ToLower().Contains(yearExp.ToLower())).ToList();
                }
                if (!language.Trim().Equals(""))
                {
                    list = list.Where(x => x.languageList.Count > 0).ToList();
                    foreach (var item in list)
                    {
                        string lang = "";
                        foreach (var item2 in item.languageList)
                        {
                            lang += item2.name + ", ";
                        }
                        item.language = lang;
                    }
                    list = list.Where(x => x.language.Trim().ToLower().Contains(language.ToLower())).ToList();
                }
                totalItems = list.Count;
                list = list.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
            }
            catch
            {

            }
            return list;
        }
        public bool CheckQuantity(int requestID, List<int> lstCandidateID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    if (requestID != 0)
                    {
                        int count = lstCandidateID.Count;
                        int countInList = context.RcRequestCandidates.Where(x => x.RequestId == requestID).Count();
                        RcRequest request = context.RcRequests.Where(x => x.Id == requestID).FirstOrDefault();
                        if (count + countInList > request.Number)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCandidateRequest(List<int> listID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {

                    foreach (var id in listID)
                    {
                        RcRequestCandidate obj = context.RcRequestCandidates.Where(x => x.Id == id).FirstOrDefault();
                        context.RcRequestCandidates.Remove(obj);
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OtherListType GetOtherListTypesCandidate(int id)
        {
            OtherListType other = new OtherListType();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    other = context.OtherListTypes.Where(x => x.Id == id).SingleOrDefault();

                }
                return other;
            }
            catch
            {
                return null;
            }

        }

        public OtherList GetOtherListCandidate(int id)
        {
            OtherList other = new OtherList();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    other = context.OtherLists.Where(x => x.Id == id).SingleOrDefault();

                }
                return other;
            }
            catch
            {
                return null;
            }

        }

        public Nation GetNation(int? id)
        {
            Nation p = new Nation();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Nations.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return null;
            }
        }

        public District GetDistrict(int? id)
        {
            District p = new District();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Districts.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return null;
            }
        }

        public Ward GetWard(int? id)
        {
            Ward p = new Ward();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Wards.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<RcCandidateSkill> GetCandidateLanguagebyID(int id)
        {
            List<RcCandidateSkill> list = new List<RcCandidateSkill>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.RcCandidateSkills.Where(x => x.RcCandidateId == id && x.TypeSkill == 14).ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<RcCandidateExp> GetExpOneCandidate(int id, int type)
        {
            List<RcCandidateExp> list = new List<RcCandidateExp>();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    list = context.RcCandidateExps.Where(x => x.RcCandidate == id && x.TypeId == type).ToList();
                }
                return list;
            }
            catch
            {
                return null;
            }

        }


        #endregion

        #region "Step"


        public CandidatePV_infor GetCandidateRequestInf(int candidateId, int requestId)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from r in context.RcRequestCandidates.Where(x => x.CandidateId == candidateId && x.RequestId == requestId)
                                from c in context.RcCandidates.Where(x => x.Id == r.CandidateId).DefaultIfEmpty()
                                from cv in context.RcCandidateCvs.Where(x => x.CandidateId == c.Id).DefaultIfEmpty()
                                from rq in context.RcRequests.Where(x => x.Id == r.RequestId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == rq.OrgnizationId).DefaultIfEmpty()
                                from p in context.Positions.Where(x => x.Id == rq.PositionId).DefaultIfEmpty()
                                from ot in context.OtherLists.Where(x => x.Id == rq.Project).DefaultIfEmpty()
                                from step in context.RcCandidatePvs.Where(x => x.CandidateId == candidateId && x.RequestId == requestId).DefaultIfEmpty()
                                select new CandidatePV_infor
                                {
                                    Department = o.Address,
                                    Position = p.Name,
                                    PositionId = p.Id,
                                    Email = cv.Email,
                                    Phone = cv.Phone,
                                    CandidateId = c.Id,
                                    Name = c.FullName,
                                    Project = ot.Name,
                                    RequestId = rq.Id,
                                    RequestName = rq.Name,
                                    StepNow = step.StepNow,
                                    Result = step.Result,
                                    Step3Score = step.ResultStep3Test == null ? null : step.ResultStep3Test,
                                    Step3Test = step.ResultStep3InterView == null ? null : step.ResultStep3InterView,
                                    Step3InterNote = step.NoteRstep3InterView,
                                    Step3TestNote = step.NoteRstep3Test,
                                    Offer= step.FinalOffer.ToString(),
                                    NoteOffer= step.NoteFinalOffer

                                };
                    return query.FirstOrDefault();
                }
            }
            catch
            {
                return new CandidatePV_infor();
            }
        }

        public List<RequestResponseServices> GetAllRequestByCandidateID(int id)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from q in context.RcRequestCandidates.Where(x => x.CandidateId == id)
                                from r in context.RcRequests.Where(x => x.Id == q.RequestId).DefaultIfEmpty()
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from e in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
                                from pro in context.OtherLists.Where(x => x.Id == r.Project).DefaultIfEmpty()
                                select new RequestResponseServices
                                {
                                    id = r.Id,
                                    code = r.Code,
                                    name = r.Name,
                                    department = o.Name,
                                    position = p.Name,
                                    positionID = r.PositionId,
                                    quantity = r.Number,
                                    createdOn = r.EffectDate,
                                    createdOnString = Convert.ToDateTime(r.EffectDate).ToString("dd/M/yyyy"),
                                    Deadline = r.ExpireDate,
                                    DeadlineString = Convert.ToDateTime(r.ExpireDate).ToString("dd/M/yyyy"),
                                    Office = o.Address,
                                    StatusID = r.Status,
                                    Status = r.Status == 1 ? "Draft" : r.Status == 2 ? "Submited" : r.Status == 3 ? "Cancel" : r.Status == 4 ? "Approved" : r.Status == 5 ? "Rejected" : "",
                                    parentId = r.ParentId,
                                    rank = r.Rank,
                                    note = r.Note,
                                    comment = r.Comment,
                                    HrInchangeId = r.HrInchange,
                                    HrInchange = e.FullName,
                                    signID = r.SignId,
                                    OrgnizationName = o.Name,
                                    OrgnizationID = r.OrgnizationId,
                                    otherSkill = r.OtherSkill,
                                    otherSkillname = skill.Name,
                                    projectID = pro.Id,
                                    projectname = pro.Name
                                };
                    return query.ToList();
                }
            }
            catch
            {
                return new List<RequestResponseServices>();
            }
        }

        public bool AddStep1(SetStep1 pv)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidatePv candidatePV = context.RcCandidatePvs.Where(x => x.CandidateId == pv.CandidateId && x.RequestId == pv.RequestId).SingleOrDefault();
                    if (candidatePV != null)
                    {
                        candidatePV.Step1 = pv.Step1;
                        candidatePV.NoteStep1 = pv.NoteStep1;
                        if (pv.Step1 == 1)
                        {
                            candidatePV.StepNow = 2;
                            candidatePV.Result = 1;
                        }
                        else
                        {
                            candidatePV.Result = 0;
                        }

                        context.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddStep2(SetStep2 pv)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidatePv candidatePV = context.RcCandidatePvs.Where(x => x.CandidateId == pv.CandidateId && x.RequestId == pv.RequestId).SingleOrDefault();
                    if (candidatePV != null)
                    {
                        // dung de bt lich no khi nao test va inter view

                        candidatePV.Step2InterView = pv.Step2InterView;
                        candidatePV.NoteStepInterView2 = pv.NoteStepInterView2;
                        candidatePV.Step2Test = pv.Step2Test;
                        candidatePV.NoteStep2Test = pv.NoteStep2Test;

                        if (pv.Step2Test == 1 || pv.Step2InterView == 1)
                        {
                            candidatePV.StepNow = 3;
                            candidatePV.Result = 1;
                        }
                        else
                        {
                            candidatePV.Result = 0;
                        }

                        context.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddStep3(List<ScheduleRes> pv)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    foreach (ScheduleRes item in pv)
                    {
                        RcEvent e = context.RcEvents.Where(x => x.Id == item.Id).SingleOrDefault();
                        if (e != null)
                        {
                            e.Score = item.Score;
                            e.Note = item.Note;
                            context.SaveChanges();
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddStep4(SetStep4 pv)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidatePv candidatePV = context.RcCandidatePvs.Where(x => x.CandidateId == pv.CandidateId && x.RequestId == pv.RequestId).SingleOrDefault();
                    if (candidatePV != null)
                    {
                   
                        candidatePV.FinalOffer = pv.FinalOffer;
                        candidatePV.NoteFinalOffer = pv.NoteFinalOffer;


                        if (pv.Step4Result == 1)
                        {
                            candidatePV.StepNow = 5;
                            candidatePV.Result = 1;
                        }
                        else
                        {
                            candidatePV.Result = 0;
                        }

                        context.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddStep5(SetStep5 pv)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidatePv candidatePV = context.RcCandidatePvs.Where(x => x.CandidateId == pv.CandidateId && x.RequestId == pv.RequestId).SingleOrDefault();
                    if (candidatePV != null)
                    {



                        if (pv.Step5Result == 1)
                        {
                            candidatePV.StepNow = 6;
                            candidatePV.Result = 1;
                        }
                        else
                        {
                            candidatePV.Result = 0;
                        }

                        context.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region Onboard

        public bool Onboard(int candidateId, int requestId)
        {
            ICommon common = new CommonImpl();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from r in context.RcRequestCandidates.Where(x => x.CandidateId == candidateId && x.RequestId == requestId)
                                from c in context.RcCandidates.Where(x => x.Id == r.CandidateId).DefaultIfEmpty()
                                from cv in context.RcCandidateCvs.Where(x => x.CandidateId == c.Id).DefaultIfEmpty()
                                from rq in context.RcRequests.Where(x => x.Id == r.RequestId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == rq.OrgnizationId).DefaultIfEmpty()
                                from p in context.Positions.Where(x => x.Id == rq.PositionId).DefaultIfEmpty()
                                from ot in context.OtherLists.Where(x => x.Id == rq.Project).DefaultIfEmpty()
                                from step in context.RcCandidatePvs.Where(x => x.CandidateId == candidateId && x.RequestId == requestId).DefaultIfEmpty()
                                select new CandidatePV_infor
                                {
                                    Department = o.Address,
                                    Position = p.Name,
                                    PositionId = p.Id,
                                    Email = cv.Email,
                                    Phone = cv.Phone,
                                    CandidateId = c.Id,
                                    Name = c.FullName,
                                    Project = ot.Name,
                                    RequestId = rq.Id,
                                    RequestName = rq.Name,
                                    StepNow = step.StepNow,
                                    OrgId = o.Id,
                                    Gender = cv.Gender,
                                    Dob = cv.Dob,
                                    NoiSinh = cv.NoiSinh,
                                    NationOb = cv.NationOb,
                                    DistrictOb = cv.DistrictOb,
                                    WardOb = cv.WardOb,
                                    ProvinceOb = cv.PorvinceOb,
                                    CMND = cv.Cmnd,
                                    CMNDPlace = cv.Cmndplace
                                };

                    CandidatePV_infor obj = query.FirstOrDefault();
                    Employee e = new Employee();
                    e.Code = common.autoGenCode3character("Employee", "EMP");
                    e.FirstName = obj.Name;
                    e.LastName = obj.Name;
                    e.JoinDate = DateTime.UtcNow;
                    e.Status = 1;
                    e.IsFronmRecruit = -1;
                    e.OrgnizationId = obj.OrgId;
                    e.PositionId = obj.PositionId;
                    e.CreateDate = DateTime.UtcNow;
                    e.CreateBy = "SYSTEM";
                    context.Employees.Add(e);


                    EmployeeCv ecv = new EmployeeCv();
                    ecv.EmployeeId = e.Id;
                    ecv.Gender = obj.Gender;
                    ecv.Dob = obj.Dob;
                    ecv.NoiSinh = obj.NoiSinh;
                    ecv.NationOb = obj.NationOb;
                    ecv.DistrictOb = obj.DistrictOb;
                    ecv.WardOb = obj.WardOb;
                    ecv.ProvinceOb = obj.ProvinceOb;
                    ecv.Cmnd = obj.CMND;
                    ecv.Cmndplace = obj.CMNDPlace;
                    ecv.NoiO = obj.NoiO;
                    ecv.NationLive = obj.NationLive;
                    ecv.DistrictLive = obj.DistrictLive;
                    ecv.WardLive = obj.WardLive;
                    ecv.ProvinceLive = obj.ProvinceLive;
                    context.EmployeeCvs.Add(ecv);



                    EmployeeEdu edu = new EmployeeEdu();



                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion
        public bool EditCandidateInfor(InforCandidateEdit e)
        {
            using (var context = new CapstoneProject2022Context())
            {

                try
                {
                    bool check = false;
                    List<RcCandidateCv> list = context.RcCandidateCvs.Where(x => x.CandidateId != e.ID).ToList();
                    foreach (RcCandidateCv item in list)
                    {
                        if (item.Phone == e.Phone || item.Zalo == e.Zalo || item.Email == e.Email)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check == false)
                    {


                        RcCandidate c = context.RcCandidates.Where(x => x.Id == e.ID).SingleOrDefault();
                        RcCandidateCv r1 = context.RcCandidateCvs.Where(x => x.CandidateId == e.ID).SingleOrDefault();
                        RcCandidateEdu edu = context.RcCandidateEdus.Where(x => x.CandidateId == e.ID).SingleOrDefault();
                        if (c != null && r1 != null)
                        {

                            c.FullName = e.FullName;
                            context.RcCandidates.Update(c);
                            // cv
                            r1.Dob = e.Dob;
                            r1.Gender = e.Gender;
                            r1.Phone = e.Phone;
                            r1.Zalo = e.Zalo;
                            r1.Email = e.Email;
                            r1.LinkedIn = e.LinkedIn;
                            r1.Facebook = e.Facebook;
                            r1.Twiter = e.Twiter;
                            r1.NoiO = e.NoiO;
                            r1.Skype = e.Skype;
                            r1.Website = e.Website;
                            r1.NationLive = e.NationLive;
                            r1.PorvinceLive = e.PorvinceLive;
                            context.RcCandidateCvs.Update(r1);
                            // edu
                            if (e.Major != null)
                            {
                                edu.Major1 = e.Major;
                            }

                            if (e.Graduate != null)
                            {
                                edu.Graduate1 = e.Graduate;
                            }
                            if (e.School != null)
                            {
                                edu.School1 = e.School;
                            }

                            edu.Gpa1 = e.Gpa;
                            if (e.Awards != null)
                            {
                                edu.Awards1 = e.Awards;
                            }

                            context.RcCandidateEdus.Update(edu);
                            context.SaveChanges();
                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }
            }
        }

        public string CheckInforCandidateEdit(CandidateEdit e)
        {
            string check = "";
            int count = 0;
            using (var context = new CapstoneProject2022Context())
            {
                List<RcCandidateCv> list = context.RcCandidateCvs.Where(x => x.CandidateId != e.ID).ToList();
                if (!e.Email.Trim().Equals(""))
                {
                    List<RcCandidateCv> list1 = list.Where(x => x.Email == e.Email).ToList();
                    if (list1.Count > 0)
                    {
                        check += " Email";
                        count++;
                    }
                }

                if (!e.Phone.Trim().Equals(""))
                {
                    List<RcCandidateCv> list1 = list.Where(x => x.Phone == e.Phone).ToList();
                    if (list1.Count > 0)
                    {
                        if (count > 0)
                        {
                            check += ";";
                        }
                        check += " Phone Number ";
                    }
                }



            }
            return check;
        }

        public List<ResultStep3> GetAllResultStep3(int requestID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcCandidatePvs.Where(x => x.RequestId == requestID && x.StepNow == 3).ToList()
                               let candidate = context.RcCandidates.Where(x => x.Id == c.CandidateId).SingleOrDefault()
                               select new ResultStep3
                               {
                                   CandidateID = candidate.Id,
                                   RequestID = c.RequestId,
                                   Name = candidate.FullName,
                                
                               };
                    return list.ToList();
                }
            }
            catch
            {
                return new List<ResultStep3>();
            }
        }

        public bool PassStep3_4(PassStep3 e)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidatePv pv = context.RcCandidatePvs.Where(x => x.CandidateId == e.CandidateID && x.RequestId == e.RequestID).SingleOrDefault();
                    if (pv != null)
                    {
                        if (e.Result == 1)
                        {
                            pv.StepNow = 4;
                            pv.Result = 1;
                        }
                        else
                        {
                            pv.Result = 0;
                        }
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
    }
}