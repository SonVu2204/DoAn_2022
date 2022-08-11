
using ModelAuto.Models;
using Services.CommonServices;
using Services.ResponseModel.OrgnizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    public partial class OrgnizationImpl : IOrgnization
    {


        #region"Title"
        public List<Title> GetAllTitle(int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Title> list = context.Titles.ToList().Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Title>();
            }
        }
        public bool InsertTitle(Title T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Title tobj = new Title();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Title", "CD");
                tobj.Status = -1;
                tobj.Note = T.Note;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Titles.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyTitle(Title T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Title tobj = context.Titles.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteTitle(List<int> list)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Title tobj = new Title();
                        tobj = context.Titles.Where(x => x.Id == item).FirstOrDefault();
                        context.Titles.Remove(tobj);
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
        public bool ActiveOrDeActiveTitle(List<int> list, int status)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Title tobj = new Title();
                        tobj = context.Titles.Where(x => x.Id == item).FirstOrDefault();
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
        #endregion



        #region"Position"

        public List<Position> GetAllPosition(int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Position> list = context.Positions.Skip(index * size).Take(size).ToList();
                    foreach (var item in list)
                    {
                        item.Title = context.Titles.Where(x => x.Id == item.TitleId).FirstOrDefault();
                        item.FormWorkingNavigation = context.OtherLists.Where(x => x.Id == item.FormWorking).FirstOrDefault();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Position>();
            }
        }

        public bool InsertPosition(Position T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Position tobj = new Position();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Position", "VTCV");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.TitleId = T.TitleId;
                tobj.OtherSkill = T.OtherSkill;
                if (T.FormWorking != 0)
                {
                    tobj.FormWorking = T.FormWorking;
                }
                tobj.BasicSalary = T.BasicSalary;
                tobj.LearningLevel = T.LearningLevel;
                tobj.YearExperience = T.YearExperience;
                tobj.MajorGroup = T.MajorGroup;
                tobj.Language = T.Language;
                tobj.LanguageLevel = T.LanguageLevel;
                tobj.InformationLevel = T.InformationLevel;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Positions.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyPosition(Position T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Position tobj = context.Positions.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.TitleId = T.TitleId;
                    tobj.OtherSkill = T.OtherSkill;
                    tobj.FormWorking = T.FormWorking;
                    tobj.OtherSkill = T.OtherSkill;
                    if (T.FormWorking != 0)
                    {
                        tobj.FormWorking = T.FormWorking;
                    }
                    tobj.BasicSalary = T.BasicSalary;
                    tobj.LearningLevel = T.LearningLevel;
                    tobj.YearExperience = T.YearExperience;
                    tobj.MajorGroup = T.MajorGroup;
                    tobj.Language = T.Language;
                    tobj.LanguageLevel = T.LanguageLevel;
                    tobj.InformationLevel = T.InformationLevel;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePosition(List<int> list)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Position tobj = new Position();
                        tobj = context.Positions.Where(x => x.Id == item).FirstOrDefault();
                        context.Positions.Remove(tobj);
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
        public bool ActiveOrDeActivePosition(List<int> list, int status)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Position tobj = new Position();
                        tobj = context.Positions.Where(x => x.Id == item).FirstOrDefault();
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
        #endregion


        #region Dia diem

        public List<NationResponseServices> GetAllNation(int index, int size, ref int totalItems)
        {
            List<NationResponseServices> list = new List<NationResponseServices>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from nation in context.Nations
                                select new NationResponseServices
                                {
                                    name = nation.Name,
                                    code = nation.Code,
                                    id = nation.Id,
                                    note = nation.Note
                                };
                    totalItems = query.ToList().Count;
                    list = query.Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return list;
            }
        }


        public List<ProvinceResponseServices> GetAllProvince(int index, int size, ref int totalItems)
        {
            List<ProvinceResponseServices> list = new List<ProvinceResponseServices>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from pro in context.Provinces
                                from na in context.Nations.Where(x=>x.Id== pro.NationId).DefaultIfEmpty()
                                select new ProvinceResponseServices
                                {
                                    name = pro.Name,
                                    code = pro.Code,
                                    id = pro.Id,
                                    note = pro.Note,
                                    nationID= pro.NationId,
                                    nationName= na.Name
                                };
                    totalItems = query.ToList().Count;
                    list = query.Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return list;
            }
        }


        public List<DistrictResponseServices> GetAllDistrict(int index, int size, ref int totalItems)
        {
            List<DistrictResponseServices> list = new List<DistrictResponseServices>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from di in context.Districts
                                from pro in context.Provinces.Where(x=>x.Id== di.ProvinceId).DefaultIfEmpty()
                                from na in context.Nations.Where(x => x.Id == pro.NationId).DefaultIfEmpty()
                                select new DistrictResponseServices
                                {
                                    name = di.Name,
                                    code = di.Code,
                                    id = di.Id,
                                    note = di.Note,
                                    nationID = na.Id,
                                    nationName = na.Name,
                                    provinceID= pro.Id,
                                    provinceName= pro.Name
                                };
                    totalItems = query.ToList().Count;
                    list = query.Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return list;
            }
        }


        public List<WardResponseServices> GetAllWard(int index, int size, ref int totalItems)
        {
            List<WardResponseServices> list = new List<WardResponseServices>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from wa in context.Wards
                                from di in context.Districts.Where(x=>x.Id== wa.DistrictId).DefaultIfEmpty()
                                from pro in context.Provinces.Where(x => x.Id == di.ProvinceId).DefaultIfEmpty()
                                from na in context.Nations.Where(x => x.Id == pro.NationId).DefaultIfEmpty()
                                select new WardResponseServices
                                {
                                    name = wa.Name,
                                    code = wa.Code,
                                    id = wa.Id,
                                    note = wa.Note,
                                    nationID = na.Id,
                                    nationName = na.Name,
                                    provinceID = pro.Id,
                                    provinceName = pro.Name,
                                    districtID= di.Id,
                                    districtName= di.Name
                                };
                    totalItems = query.ToList().Count;
                    list = query.Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return list;
            }
        }

        #endregion

    }
}
