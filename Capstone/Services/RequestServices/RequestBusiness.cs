using ModelAuto;
using ModelAuto.Models;
using Services.CommonModel;
using Services.CommonServices;
using Services.ResponseModel.RequestModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
    public class Request : IRequest
    {
        private ICommon c = new CommonImpl();
        public bool ActiveOrDeActiveRequest(List<int> list, int status, string actionBy)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        List<int> ListRCID = new List<int>();
                        ListRCID = GetListRequestByID(item).Select(x => x.Id).ToList();
                        foreach (var rcId in ListRCID)
                        {
                            RcRequest tobj = new RcRequest();
                            tobj = context.RcRequests.Where(x => x.Id == rcId).FirstOrDefault();
                            tobj.Status = status;
                            if (status == 4 || status == 5)
                            {
                                ICommon c = new CommonImpl();
                                EmployeeCv em = context.EmployeeCvs.Where(x => x.EmployeeId == tobj.SignId).FirstOrDefault();
                                if (em != null)
                                {
                                    if (em.EmailWork != ""&& em.EmailWork!=null)
                                    {
                                        MailDTO mailDTO = new MailDTO();
                                        string statusName = status == 4 ? "Approved" : status == 5 ? "Rejected" : "";
                                        mailDTO.content = "Your Request '" + tobj.Name + "' has been " + statusName + " by " + actionBy + " If there is feedback, please give feedback to the manager";
                                        mailDTO.subject = "Notice the status of your recruitment request";
                                        mailDTO.fromMail = "aisolutionssum22@gmail.com";
                                        mailDTO.pass = "miztlfnbereqmeko";
                                        mailDTO.listCC = new List<string>();
                                        mailDTO.listBC = new List<string>();
                                        mailDTO.tomail = em?.EmailWork;
                                        c.sendMail(mailDTO);
                                    }
                                }
                            }
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

        public bool DeleteRequest(List<int> list)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        RcRequest tobj = new RcRequest();
                        tobj = context.RcRequests.Where(x => x.Id == item).FirstOrDefault();
                        context.RcRequests.Remove(tobj);
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

        public List<RequestResponseServices> GetAllRequest(int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from r in context.RcRequests.Where(x => x.Rank == 1)
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
                                    projectID= pro.Id,
                                    projectname= pro.Name
                                };
                    return query.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
                return new List<RequestResponseServices>();
            }
        }



        public List<RequestResponseServices> GetAllRequestByFillter(int index, int size, string Code, string Name, string OrgName, string PositionName, int Quantity, string Status, string HrInchange, DateTime CreateOn, DateTime DeadLine, string otherSkill)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<RequestResponseServices> list = new List<RequestResponseServices>();
                    var query = from r in context.RcRequests.Where(x => x.Rank == 1)
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
                    list = query.ToList();

                    if (!Code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.code.ToLower().Contains(Code.ToLower())).ToList();
                    }
                    if (!Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.name.ToLower().Contains(Name.ToLower())).ToList();
                    }
                    if (!OrgName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.department.ToLower().Contains(OrgName.ToLower())).ToList();
                    }
                    if (!PositionName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.position.ToLower().Contains(PositionName.ToLower())).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("draft"))
                    {
                        list = list.Where(x => x.StatusID == 1).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("submited"))
                    {
                        list = list.Where(x => x.StatusID == 2).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("cancel"))
                    {
                        list = list.Where(x => x.StatusID == 3).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("approved"))
                    {
                        list = list.Where(x => x.StatusID == 4).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("rejected"))
                    {
                        list = list.Where(x => x.StatusID == 5).ToList();
                    }
                    if (!HrInchange.Trim().Equals(""))
                    {
                        list = list.Where(x => x.HrInchangeId != null).ToList();
                        list = list.Where(x => x.HrInchange.ToLower().Contains(HrInchange.ToLower())).ToList();
                    }
                    if (Quantity != 0)
                    {
                        list = list.Where(x => x.quantity == Quantity).ToList();
                    }
                    if (CreateOn.Year != 1000)
                    {
                        list = list.Where(x => x.createdOn?.ToString("dd/MM/YYYY") == CreateOn.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (DeadLine.Year != 1000)
                    {
                        list = list.Where(x => x.Deadline?.ToString("dd/MM/YYYY") == DeadLine.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (!otherSkill.Trim().Equals(""))
                    {
                        list = list.Where(x => x.otherSkill != null).ToList();
                        list = list.Where(x => x.otherSkillname.ToLower().Contains(otherSkill.ToLower())).ToList();
                    }
                    return list.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
                return new List<RequestResponseServices>();
            }
        }

        public List<RequestResponseServices> GetChildRequestById(int ID)
        {
            List<RequestResponseServices> listReturn = new List<RequestResponseServices>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    var query = from r in context.RcRequests.Where(x => x.ParentId == ID)
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from e in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
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
                                    otherSkillname = skill.Name
                                };
                    listReturn = query.ToList();
                    return listReturn;
                }
            }
            catch
            {
                return listReturn.ToList();
            }
        }

        public RequestResponseServices GetRequestByID(int ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from r in context.RcRequests.Where(x => x.Id == ID)
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from typ in context.OtherLists.Where(x => x.Id == r.Type).DefaultIfEmpty()
                                from Project in context.OtherLists.Where(x => x.Id == r.Project).DefaultIfEmpty()
                                from Org in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from Sign in context.Employees.Where(x => x.Id == r.SignId).DefaultIfEmpty()
                                from Lev in context.OtherLists.Where(x => x.Id == r.Level).DefaultIfEmpty()
                                from Hr in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
                                from rele in context.OtherLists.Where(x => x.Id == r.RequestLevel).DefaultIfEmpty()
                                select new RequestResponseServices
                                {
                                    id = r.Id,
                                    code = r.Code,
                                    name = r.Name,
                                    requestLevel = rele.Name,
                                    department = Org.Name,
                                    position = p.Name,
                                    positionID = r.PositionId,
                                    quantity = r.Number,
                                    createdOn = r.EffectDate,
                                    createdOnString = Convert.ToDateTime(r.EffectDate).ToString("dd/M/yyyy"),
                                    Deadline = r.ExpireDate,
                                    DeadlineString = Convert.ToDateTime(r.ExpireDate).ToString("dd/M/yyyy"),
                                    Office = Org.Address,
                                    StatusID = r.Status,
                                    Status = r.Status == 1 ? "Draft" : r.Status == 2 ? "Submited" : r.Status == 3 ? "Cancel" : r.Status == 4 ? "Approved" : r.Status == 5 ? "Rejected" : "",
                                    parentId = r.ParentId,
                                    rank = r.Rank,
                                    note = r.Note,
                                    comment = r.Comment,
                                    HrInchangeId = r.HrInchange,
                                    HrInchange = Hr.FullName,
                                    signID = r.SignId,
                                    typeID = r.RequestLevel,
                                    typename = rele.Name,
                                    OrgnizationName = Org.Name,
                                    OrgnizationID = r.OrgnizationId,
                                    projectname = Project.Name,
                                    projectID = r.Project,
                                    experience = r.YearExperience,
                                    level = r.Level,
                                    levelName = Lev.Name,
                                    CreateBy = r.CreateBy,
                                    CreateDate = r.CreateDate,
                                    UpdateBy = r.UpdateBy,
                                    UpdateDate = r.UpdateDate,
                                    otherSkill = r.OtherSkill,
                                    otherSkillname = skill.Name
                                };
                    return query.FirstOrDefault();
                }
            }
            catch
            {
                return new RequestResponseServices();
            }
        }

        public bool InsertRequest(RcRequest T)
        {
            RcRequest rc = new RcRequest();
            rc.Name = T.Name;
            rc.EffectDate = T.EffectDate;
            rc.ExpireDate = T.ExpireDate;
            rc.Number = T.Number;
            rc.OrgnizationId = T.OrgnizationId;
            rc.SignId = T.SignId;
            rc.Note = T.Note;
            rc.Number = T.Number;
            rc.YearExperience = T.YearExperience;
            rc.Project = T.Project;
            rc.PositionId = T.PositionId;
            rc.Type = T.Type;
            rc.Comment = T.Comment;
            rc.ParentId = T.ParentId;
            rc.Level = T.Level;
            rc.RequestLevel = T.RequestLevel;
            rc.Budget = T.Budget;
            rc.Status = T.Status;
            rc.Comment = T.Comment;
            rc.CreateDate = DateTime.Now;
            rc.CreateBy = T.CreateBy;
            rc.OtherSkill = T.OtherSkill;
            if (rc.ParentId != null && rc.ParentId > 0)
            {
                rc.Rank = GetRequestByID((int)rc.ParentId).rank + 1;
            }
            else
            {
                rc.Rank = 1;
            }
            rc.Code = c.autoGenCode("Rc_Request", rc.Rank, "Rank", rc.ParentId);
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.RcRequests.Add(rc);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ModifyRequest(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();
                    rc.Name = T.Name;
                    rc.EffectDate = T.EffectDate;
                    rc.ExpireDate = T.ExpireDate;
                    rc.Number = T.Number;
                    rc.OrgnizationId = T.OrgnizationId;
                    rc.SignId = T.SignId;
                    rc.Note = T.Note;
                    rc.Number = T.Number;
                    rc.YearExperience = T.YearExperience;
                    rc.Project = T.Project;
                    rc.PositionId = T.PositionId;
                    rc.Type = T.Type;
                    rc.Comment = T.Comment;
                    rc.Level = T.Level;
                    rc.Budget = T.Budget;
                    rc.UpdateDate = DateTime.Now;
                    rc.UpdateBy = T.UpdateBy;
                    rc.HrInchange = T.HrInchange;
                    rc.OtherSkill = T.OtherSkill;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool SendComment(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();

                    rc.Comment = T.Comment;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool setHrInchange(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();

                    rc.HrInchange = T.HrInchange;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //for check total request
        public List<RcRequest> GetListRequestByID(int ID)
        {
            List<RcRequest> list = new List<RcRequest>();
            DataTable dt = DAOContext.GetListRequestByID(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RcRequest o = new RcRequest();
                DataRow row = dt.Rows[i];
                o.Id = Convert.ToInt32(row["ID"].ToString());
                o.Number = Convert.ToInt32(row["Number"].ToString());
                list.Add(o);
            }
            return list;
        }

        public int getTotalRequestRecord(string column, int? signID)
        {
            string query = "select count(*) COUNT from RC_Request where Rank=1 and " + column + " = " + signID;
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int COUNT = Convert.ToInt32(lastRow["COUNT"]);
            return COUNT;
        }
    }
}
