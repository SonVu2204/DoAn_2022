using ModelAuto;
using ModelAuto.Models;
using Services.ResponseModel.ProfileModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Services.ProfileServices
{
    public partial class ProfileImpl : IProfile
    {
        public List<Position> GetListPositionByOrgID(int ID)
        {
            List<Position> list = new List<Position>();
            DataTable dt = DAOContext.GetListPositionByOrgID(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Position o = new Position();
                DataRow row = dt.Rows[i];
                o.Name = row["Name"].ToString();
                o.Code = row["Code"].ToString();
                o.Id = Convert.ToInt32(row["PositionID"].ToString());
                list.Add(o);
            }
            return list;
        }

        public List<EmployeeResponseServices> GetListEmployeeByOrgID(int OrgID, int index, int size)
        {
            List<EmployeeResponseServices> list = new List<EmployeeResponseServices>();
            DataTable dt = DAOContext.GetListEmployeeByOrgID(OrgID, index, size);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                EmployeeResponseServices o = new EmployeeResponseServices
                {
                    FullName = row["FullName"].ToString(),
                    Code = row["Code"].ToString(),
                    ID = Convert.ToInt32(row["Id"].ToString()),
                    OrgId = Convert.ToInt32(row["OrgnizationID"].ToString()),
                    PositionId = Convert.ToInt32(row["PositionID"].ToString()),
                    StatusName = row["StatusName"].ToString(),
                    OrgnizationName = row["ORG_NAME"].ToString(),
                    PositionName = row["PositionName"].ToString(),
                    TitleName = row["TitleName"].ToString(),
                    ContractNo = row["ContractNo"].ToString(),
                    JoinDate = Convert.ToDateTime(row["JoinDate"].ToString()).ToString("dd/MM/yyyy"),
                    StatusId = Convert.ToInt32(row["StatusId"].ToString()),
                    TitleId = Convert.ToInt32(row["TitleId"].ToString()),

                };
                list.Add(o);
            }
            return list;
        }

        public List<EmployeeResponseServices> GetListEmployeeByOrgIDByFilter(int OrgID, int index, int size, string code, string name, string orgName, string title, string position, DateTime joindate, string status, ref int totalItem)
        {
            List<EmployeeResponseServices> list = new List<EmployeeResponseServices>();
            DataTable dt = DAOContext.GetListEmployeeByOrgID(OrgID, 0, Int32.MaxValue);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                EmployeeResponseServices o = new EmployeeResponseServices
                {
                    FullName = row["FullName"].ToString(),
                    Code = row["Code"].ToString(),
                    ID = Convert.ToInt32(row["Id"].ToString()),
                    OrgId = Convert.ToInt32(row["OrgnizationID"].ToString()),
                    PositionId = Convert.ToInt32(row["PositionID"].ToString()),
                    StatusName = row["StatusName"].ToString(),
                    OrgnizationName = row["ORG_NAME"].ToString(),
                    PositionName = row["PositionName"].ToString(),
                    TitleName = row["TitleName"].ToString(),
                    ContractNo = row["ContractNo"].ToString(),
                    JoinDate = Convert.ToDateTime(row["JoinDate"].ToString()).ToString("dd/MM/YYYY"),
                    StatusId = Convert.ToInt32(row["StatusId"].ToString()),
                    TitleId = Convert.ToInt32(row["TitleId"].ToString()),

                };
                list.Add(o);
            }
            if (!code.Trim().Equals(""))
            {
                list = list.Where(x => x.Code.ToLower().Contains(code.Trim().ToLower())).ToList();
            }
            if (!name.Trim().Equals(""))
            {
                list = list.Where(x => x.FullName.ToLower().Contains(name.Trim().ToLower())).ToList();
            }
            if (!orgName.Trim().Equals(""))
            {
                list = list.Where(x => x.OrgnizationName.ToLower().Contains(orgName.Trim().ToLower())).ToList();
            }
            if (!title.Trim().Equals(""))
            {
                list = list.Where(x => x.TitleName.ToLower().Contains(title.Trim().ToLower())).ToList();
            }
            if (!position.Trim().Equals(""))
            {
                list = list.Where(x => x.PositionName.ToLower().Contains(position.Trim().ToLower())).ToList();
            }
            if (!status.Trim().Equals(""))
            {
                list = list.Where(x => x.StatusName.ToLower().Contains(status.Trim().ToLower())).ToList();
            }
            if (joindate.Year != 1000)
            {
                list = list.Where(x => x.JoinDate == joindate.ToString("dd/MM/YYYY")).ToList();
            }
            totalItem = list.Count;
            list = list.Skip(index * size).Take(size).ToList();
            return list;
        }

        public int getTotalEmployee(int OrgID)
        {
            List<Employee> list = new List<Employee>();
            DataTable dt = DAOContext.GetListEmployeeByOrgID(OrgID, 0, Int32.MaxValue);
            return dt.Rows.Count;
        }

        public EmployeeCv GetEmployeeCvByEmpID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    EmployeeCv e = context.EmployeeCvs.Where(x => x.EmployeeId == ID).FirstOrDefault();
                    if (e != null)
                        return e;
                    else
                        return new EmployeeCv();
                }
            }
            catch
            {
                return new EmployeeCv();
            }
        }

        public EmployeeEdu GetEmployeeEduByEmpID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    EmployeeEdu e = context.EmployeeEdus.Where(x => x.EmployeeId == ID).FirstOrDefault();
                    if (e != null)
                        return e;
                    else
                        return new EmployeeEdu();
                }
            }
            catch
            {
                return new EmployeeEdu();
            }
        }

        public List<EmployeeContract> GetListEmployeeContractByEmpID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<EmployeeContract> listContract = context.EmployeeContracts.Where(x => x.EmployeeId == ID).ToList();
                    return listContract;
                }
            }
            catch
            {
                return new List<EmployeeContract>();
            }
        }


        public EmployeeProfileResponseServices getEmployeeProfile(int? ID)
        {
            try
            {
                EmployeeProfileResponseServices obj = new EmployeeProfileResponseServices();

                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = (from e in context.Employees.Where(x => x.Id == ID)
                                 from cv in context.EmployeeCvs.Where(x => x.EmployeeId == e.Id).DefaultIfEmpty()
                                 from edu in context.EmployeeEdus.Where(x => x.EmployeeId == e.Id).DefaultIfEmpty()
                                 from p in context.Positions.Where(x => x.Id == e.PositionId).DefaultIfEmpty()
                                 from o in context.Orgnizations.Where(x => x.Id == e.OrgnizationId).DefaultIfEmpty()
                                 select new EmployeeProfileResponseServices
                                 {
                                     FullName = e.FullName,
                                     FirstName = e.FirstName,
                                     LastName = e.LastName,
                                     Code = e.Code,
                                     StatusId = e.Status,
                                     CMND = cv.Cmnd,
                                     CMND_Place = cv.Cmndplace,
                                     DanToc = cv.DanToc,
                                     QuocTich = cv.QuocTich,
                                     DOB = cv.Dob,
                                     ID = e.Id,
                                     Email = cv.Email,
                                     WorkEmail = cv.EmailWork,
                                     HoKhau = cv.HoKhau,
                                     Gender = cv.Gender,
                                     JoinDate = e.JoinDate,
                                     OutDate = e.LastDate,
                                     NoiO = cv.NoiO,
                                     PositionName = p.Name,
                                     School = edu.School1,
                                     Degree = edu.DeeGree1,
                                     Major = edu.Major1,
                                     Award = edu.Award1,
                                     Language1 = edu.Language1,
                                     Language2 = edu.Language2,
                                     Score1 = edu.LanScore1,
                                     Score2 = edu.LanScore2,
                                     DistrictHK = cv.DistrictHk,
                                     DistrictNoiO = cv.DistrictLive,
                                     NationNoiO = cv.NationLive,
                                     NationHK = cv.NationHk,
                                     OrgnizationName = o.Name,
                                     WardHK = cv.WardHk,
                                     WardNoiO = cv.WardLive,
                                     ProvinceHK = cv.ProvinceHk,
                                     ProvinceNoiO = cv.PorvinceLive,
                                     PhoneNumber = cv.Phone,
                                     informaticLV = edu.InforMaticsLevel1,
                                     LearningLV = edu.LearningLevel,
                                     Skill1 = edu.LanSkill1,
                                     Skill2 = edu.LanSkill2,
                                 }).FirstOrDefault();
                    obj = query;
                }
                return obj;
            }
            catch
            {
                return new EmployeeProfileResponseServices();
            }
        }

        public List<ContractEmployeeResponse> GetContractEmployee(int index, int size, ref int totalItem)
        {
            List<ContractEmployeeResponse> list = new List<ContractEmployeeResponse>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = (from c in context.EmployeeContracts
                                 from e in context.Employees.Where(x => x.Id == c.EmployeeId).DefaultIfEmpty()
                                 from o in context.Orgnizations.Where(x => x.Id == e.OrgnizationId).DefaultIfEmpty()
                                 from p in context.Positions.Where(x => x.Id == e.PositionId).DefaultIfEmpty()
                                 from con in context.ContractTypes.Where(x => x.Id == c.ContractTypeId).DefaultIfEmpty()
                                 select new ContractEmployeeResponse
                                 {
                                     ContractNo = c.ContractNo,
                                     ContractType = con.Name,
                                     EffectDate = Convert.ToDateTime(c.EffectDate).ToString("dd/MM/yyyy"),
                                     ExpireDate = c.ExpireDate == null ? "" : Convert.ToDateTime(c.ExpireDate).ToString("dd/MM/yyyy"),
                                     ID = c.Id,
                                     Note = c.Note,
                                     OrgnizationName = o.Name,
                                     Position = p.Name,
                                     Status = c.Status == -1 ? "Approved" : "Reject"
                                 }).ToList();
                    totalItem = query.Count();
                    list = query.OrderByDescending(x => x.ID).Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
            }
            return list;
        }


        public List<ContractEmployeeResponse> GetContractEmployeeByFilter(int index, int size, ref int totalItem, string name, string code, string orgName, string contractNo, string contractType, string position, DateTime effectDate, DateTime exDate, string status)
        {
            List<ContractEmployeeResponse> list = new List<ContractEmployeeResponse>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = (from c in context.EmployeeContracts
                                 from e in context.Employees.Where(x => x.Id == c.EmployeeId).DefaultIfEmpty()
                                 from o in context.Orgnizations.Where(x => x.Id == e.OrgnizationId).DefaultIfEmpty()
                                 from p in context.Positions.Where(x => x.Id == e.PositionId).DefaultIfEmpty()
                                 from con in context.ContractTypes.Where(x => x.Id == c.ContractTypeId).DefaultIfEmpty()
                                 select new ContractEmployeeResponse
                                 {
                                     Name = e.FullName,
                                     Code = e.Code,
                                     ContractNo = c.ContractNo,
                                     ContractType = con.Name,
                                     EffectDate = Convert.ToDateTime(c.EffectDate).ToString("dd/MM/yyyy"),
                                     ExpireDate = c.ExpireDate == null ? "" : Convert.ToDateTime(c.ExpireDate).ToString("dd/MM/yyyy"),
                                     ID = c.Id,
                                     Note = c.Note,
                                     OrgnizationName = o.Name,
                                     Position = p.Name,
                                     Status = c.Status == -1 ? "Approved" : "Reject"
                                 }).ToList();
                    totalItem = query.Count();
                    list = query.ToList();

                    if (!name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower())).ToList();
                    }
                    if (!code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Code.ToLower().Contains(code.Trim().ToLower())).ToList();
                    }
                    if (!orgName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.OrgnizationName.ToLower().Contains(orgName.Trim().ToLower())).ToList();
                    }
                    if (!contractNo.Trim().Equals(""))
                    {
                        list = list.Where(x => x.ContractNo.ToLower().Contains(contractNo.Trim().ToLower())).ToList();
                    }
                    if (!contractType.Trim().Equals(""))
                    {
                        list = list.Where(x => x.ContractType.ToLower().Contains(contractType.Trim().ToLower())).ToList();
                    }
                    if (!position.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Position.ToLower().Contains(position.Trim().ToLower())).ToList();
                    }
                    if (effectDate.Year != 1000)
                    {
                        list = list.Where(x => x.EffectDate == effectDate.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (exDate.Year != 1000)
                    {
                        list = list.Where(x => x.ExpireDate == exDate.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (!status.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Status.ToLower().Contains(status.Trim().ToLower())).ToList();
                    }
                    list = list.OrderByDescending(x => x.ID).Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
            }
            return list;
        }

        public bool InsertContractEmployee(ContractEmployeeResponse T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    EmployeeContract obj = new EmployeeContract();
                    obj.ContractNo = T.ContractNo;
                    obj.ContractTypeId = T.ContractTypeId;
                    obj.EffectDate = T.Effect;
                    if (T.Expire.Value.Year != 1000)
                    {
                        obj.ExpireDate = T.Expire;
                    }
                    obj.OrgnizationId = T.OrgnizationId;
                    obj.PositionId = T.PositionId;
                    obj.EmployeeId = T.EmployeeId;
                    obj.Status = -1;
                    obj.Note = T.Note;
                    context.EmployeeContracts.Add(obj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public bool ModifyContractEmployee(ContractEmployeeResponse T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    EmployeeContract obj = context.EmployeeContracts.Where(x => x.Id == T.ID).FirstOrDefault();
                    obj.ContractNo = T.ContractNo;
                    obj.ContractTypeId = T.ContractTypeId;
                    obj.EffectDate = T.Effect;
                    obj.ExpireDate = T.Expire;
                    obj.OrgnizationId = T.OrgnizationId;
                    obj.PositionId = T.PositionId;
                    obj.EmployeeId = T.EmployeeId;
                    obj.Note = T.Note;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public bool DeleteContractEmployee(List<int> list)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        EmployeeContract tobj = new EmployeeContract();
                        tobj = context.EmployeeContracts.Where(x => x.Id == item).FirstOrDefault();
                        context.EmployeeContracts.Remove(tobj);
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

        public bool ActiveOrDeActiveEmployeeContract(List<int> list, int status)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        EmployeeContract tobj = new EmployeeContract();
                        tobj = context.EmployeeContracts.Where(x => x.Id == item).FirstOrDefault();
                        tobj.Status = status;
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

        public ContractEmployeeResponse getContractEmployeeById(int id)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from c in context.EmployeeContracts.Where(x => x.Id == id)
                                from e in context.Employees.Where(x => x.Id == c.EmployeeId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == e.OrgnizationId).DefaultIfEmpty()
                                from p in context.Positions.Where(x => x.Id == e.PositionId).DefaultIfEmpty()
                                from con in context.ContractTypes.Where(x => x.Id == c.ContractTypeId).DefaultIfEmpty()
                                select new ContractEmployeeResponse
                                {
                                    Name = e.FullName,
                                    ContractNo = c.ContractNo,
                                    ContractTypeId = c.ContractTypeId,
                                    OrgnizationName = o.Name,
                                    OrgnizationId = c.OrgnizationId,
                                    PositionId = c.PositionId,
                                    Position = p.Name,
                                    EffectDate = Convert.ToDateTime(c.EffectDate).ToString("yyyy-MM-dd"),
                                    ExpireDate = c.ExpireDate == null ? "" : Convert.ToDateTime(c.ExpireDate).ToString("yyyy-MM-dd"),
                                    Note = c.Note
                                };

                    return query.FirstOrDefault();
                }
            }
            catch
            {
                return new ContractEmployeeResponse();
            }
        }



    }
}
