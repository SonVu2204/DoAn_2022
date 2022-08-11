using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
    public partial class ProfileImpl : IProfile
    {

        #region Nation

        public List<Nation> GetNationList()
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Nation> list = context.Nations.ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Nation>();
            }
        }
        public bool InsertNation(Nation T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Nation tobj = new Nation();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Nation", "QG");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.CreateBy = T.CreateBy;
                tobj.CreateDate = DateTime.UtcNow;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Nations.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyNation(Nation T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Nation tobj = context.Nations.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.UpdateBy = T.UpdateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteNation(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Nation tobj = new Nation();
                        tobj = context.Nations.Where(x => x.Id == item).FirstOrDefault();
                        context.Nations.Remove(tobj);
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
        public bool ActiveOrDeActiveNation(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Nation tobj = new Nation();
                        tobj = context.Nations.Where(x => x.Id == item).FirstOrDefault();
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

        #region Province

        public List<Province> GetProvinceListByNationID(int ID)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Province> list = context.Provinces.Where(x=>x.NationId==ID).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Province>();
            }
        }
        public bool InsertProvince(Province T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Province tobj = new Province();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Province", "T/TP");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.NationId = T.NationId;
                tobj.CreateDate = DateTime.UtcNow;
                tobj.CreateBy = T.CreateBy;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Provinces.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyProvince(Province T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Province tobj = context.Provinces.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.NationId = T.NationId;
                    tobj.UpdateBy = T.UpdateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProvince(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Province tobj = new Province();
                        tobj = context.Provinces.Where(x => x.Id == item).FirstOrDefault();
                        context.Provinces.Remove(tobj);
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
        public bool ActiveOrDeActiveProvince(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Province tobj = new Province();
                        tobj = context.Provinces.Where(x => x.Id == item).FirstOrDefault();
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

        #region District

        public List<District> GetDistrictListByProvinceID(int ID)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<District> list = context.Districts.Where(x => x.ProvinceId == ID).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<District>();
            }
        }

        public bool InsertDistrict(District T)
        {
            ICommon c = new CommonImpl();
            try
            {
                District tobj = new District();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("District", "QH");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.ProvinceId = T.ProvinceId;
                tobj.CreateBy = T.CreateBy;
                tobj.CreateDate = DateTime.UtcNow;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Districts.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyDistrict(District T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    District tobj = context.Districts.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.ProvinceId = T.ProvinceId;
                    tobj.UpdateBy = T.UpdateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDistrict(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        District tobj = new District();
                        tobj = context.Districts.Where(x => x.Id == item).FirstOrDefault();
                        context.Districts.Remove(tobj);
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
        public bool ActiveOrDeActiveDistrict(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        District tobj = new District();
                        tobj = context.Districts.Where(x => x.Id == item).FirstOrDefault();
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

        #region Ward

        public List<Ward> GetWardListByDistrictID(int ID)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Ward> list = context.Wards.Where(x => x.DistrictId == ID).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Ward>();
            }
        }
        public bool InsertWard(Ward T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Ward tobj = new Ward();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Ward", "X/P");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.DistrictId = T.DistrictId;
                tobj.CreateBy = T.CreateBy;
                tobj.CreateDate =DateTime.UtcNow;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Wards.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyWard(Ward T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Ward tobj = context.Wards.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.DistrictId = T.DistrictId;
                    tobj.UpdateBy = T.UpdateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteWard(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Ward tobj = new Ward();
                        tobj = context.Wards.Where(x => x.Id == item).FirstOrDefault();
                        context.Wards.Remove(tobj);
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
        public bool ActiveOrDeActiveWard(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Ward tobj = new Ward();
                        tobj = context.Wards.Where(x => x.Id == item).FirstOrDefault();
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

        #region DM loai hop dong
        public List<ContractType> GetContractTypeList(int index, int size){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<ContractType> list = context.ContractTypes.Where(x=>x.Status==-1).Skip(size * index).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<ContractType>();
            }
        }
        public List<ContractType> GetAllContractTypeList(int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<ContractType> list = context.ContractTypes.Skip(size * index).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<ContractType>();
            }
        }
        public bool InsertContractType(ContractType T){
            ICommon c = new CommonImpl();
            try
            {
                ContractType tobj = new ContractType();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Contract_Type", "LHD");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.Bhtn = T.Bhtn;
                tobj.Bhxh = T.Bhxh;
                tobj.Bhyt = T.Bhyt;
                tobj.Term = T.Term;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.ContractTypes.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyContractType(ContractType T){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    ContractType tobj = context.ContractTypes.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.Bhtn = T.Bhtn;
                    tobj.Bhxh = T.Bhxh;
                    tobj.Bhyt = T.Bhyt;
                    tobj.Term = T.Term;
                    tobj.UpdateBy = T.UpdateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteContractType(List<int> list){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        ContractType tobj = new ContractType();
                        tobj = context.ContractTypes.Where(x => x.Id == item).FirstOrDefault();
                        context.ContractTypes.Remove(tobj);
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
        public bool ActiveOrDeActiveContractType(List<int> list, int status){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        ContractType tobj = new ContractType();
                        tobj = context.ContractTypes.Where(x => x.Id == item).FirstOrDefault();
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

    }
}
