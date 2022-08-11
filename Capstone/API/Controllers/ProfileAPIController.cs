using ModelAuto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using API.ResponseModel.Common;
using API.ResponseModel.Profile;
using Services.ResponseModel.ProfileModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileAPIController : AuthorizeByIDController
    {
        private ICommon p = new CommonImpl();

        private IProfile profile = new ProfileImpl();
        #region list


        #region DM loai HOP DONG
        [Authorize(Roles = "1,0")]
        [HttpPost("GetContractType")]
        public IActionResult GetContractType(int index, int size)
        {
            List<ContractType> list = profile.GetContractTypeList(index, size);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 id = l.Id,
                                 note = l.Note,
                                 term = l.Term
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "List is Null");
        }

        [Authorize(Roles = "1,0")]
        [HttpPost("GetAllContractType")]
        public IActionResult GetAllContractType(int index, int size)
        {
            List<ContractType> list = profile.GetAllContractTypeList(index, size);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 id = l.Id,
                                 note = l.Note,
                                 term = l.Term,
                                 status = l.Status == -1 ? "Active" : "Deactive"
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "List is Null");
        }

        [Authorize(Roles = "1,0")]
        [HttpPost("InsertContractType")]
        public IActionResult InsertContractType([FromBody] ContractTypeResponse objresponse)
        {
            try
            {
                Account a = GetCurrentUser();
                ContractType obj = new ContractType();
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.CreateBy = a.Employee?.FullName;
                obj.Term = objresponse.Term;
                var check = profile.InsertContractType(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1,0")]
        [HttpPost("DeleteContractType")]
        public IActionResult DeleteContractType(List<int> ListID)
        {
            try
            {
                var check = profile.DeleteContractType(ListID);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("ActiveContractType")]
        public IActionResult ActiveContractType(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveContractType(ListID, -1);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("DeActiveContractType")]
        public IActionResult DeActiveContractType(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveContractType(ListID, 0);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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




        [Authorize(Roles = "1,0")]
        [HttpPost("ModifyContractType")]
        public IActionResult ModifyContractType([FromBody] ContractTypeResponse objresponse)
        {
            try
            {
                Account a = GetCurrentUser();
                ContractType obj = new ContractType();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.UpdateBy = a.Employee?.FullName;
                obj.Term = objresponse.Term;
                var check = profile.ModifyContractType(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        #region Danh muc địa điểm

        [HttpPost("GetNation")]
        public IActionResult GetNation()
        {
            List<Nation> list = profile.GetNationList();

            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 id = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("GetProvinceByNationId")]
        public IActionResult GetProvinceByNationId(int nationID)
        {
            List<Province> list = profile.GetProvinceListByNationID(nationID);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ID = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("GetDistrictByProvinceId")]
        public IActionResult GetDistrictByProvinceId(int provinceId)
        {
            List<District> list = profile.GetDistrictListByProvinceID(provinceId);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ID = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("GetWardByDistrictId")]
        public IActionResult GetWardByDistrictId(int DistrictID)
        {
            List<Ward> list = profile.GetWardListByDistrictID(DistrictID);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ID = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("InsertNation")]
        public IActionResult InsertNation([FromBody] NationResponse objresponse)
        {
            try
            {
                Nation obj = new Nation();
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.CreateBy = "HUNGNX";
                var check = profile.InsertNation(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [HttpPost("InsertProvince")]
        public IActionResult InsertProvince([FromBody] ProvinceResponse objresponse)
        {
            try
            {
                Province obj = new Province();
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.NationId = objresponse.NationId;
                obj.CreateBy = "HUNGNX";
                var check = profile.InsertProvince(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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
        [HttpPost("InsertDistrict")]
        public IActionResult InsertDistrict([FromBody] DistrictResponse objresponse)
        {
            try
            {
                District obj = new District();
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.ProvinceId = objresponse.ProvinceId;
                obj.CreateBy = "HUNGNX";
                var check = profile.InsertDistrict(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [HttpPost("InsertWard")]
        public IActionResult InsertWard([FromBody] WardResponse objresponse)
        {
            try
            {
                Ward obj = new Ward();
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.DistrictId = objresponse.DistrictId;
                obj.CreateBy = "HUNGNX";
                var check = profile.InsertWard(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [HttpPost("ModifyNation")]
        public IActionResult ModifyNation([FromBody] NationResponse objresponse)
        {
            try
            {
                Nation obj = new Nation();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.UpdateBy = "HUNGNX";
                var check = profile.ModifyNation(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [HttpPost("ModifyProvince")]
        public IActionResult ModifyProvince([FromBody] ProvinceResponse objresponse)
        {
            try
            {
                Province obj = new Province();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.NationId = objresponse.NationId;
                obj.UpdateBy = "HUNGNX";
                var check = profile.ModifyProvince(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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
        [HttpPost("ModifyDistrict")]
        public IActionResult ModifyDistrict([FromBody] DistrictResponse objresponse)
        {
            try
            {
                District obj = new District();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.ProvinceId = objresponse.ProvinceId;
                obj.UpdateBy = "HUNGNX";
                var check = profile.ModifyDistrict(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [HttpPost("ModifyWard")]
        public IActionResult ModifyWard([FromBody] WardResponse objresponse)
        {
            try
            {
                Ward obj = new Ward();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                obj.DistrictId = objresponse.DistrictId;
                obj.UpdateBy = "HUNGNX";
                var check = profile.ModifyWard(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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



        [Authorize(Roles = "1")]
        [HttpPost("DeleteNation")]
        public IActionResult DeleteNation(List<int> ListID)
        {
            try
            {
                var check = profile.DeleteNation(ListID);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("ActiveNation")]
        public IActionResult ActiveNation(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveNation(ListID, -1);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("DeActiveNation")]
        public IActionResult DeActiveNation(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveNation(ListID, 0);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [Authorize(Roles = "1")]
        [HttpPost("DeleteProvince")]
        public IActionResult DeleteProvince(List<int> ListID)
        {
            try
            {
                var check = profile.DeleteProvince(ListID);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("ActiveProvince")]
        public IActionResult ActiveProvince(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveProvince(ListID, -1);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("DeActiveProvince")]
        public IActionResult DeActiveProvince(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveProvince(ListID, 0);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [Authorize(Roles = "1")]
        [HttpPost("DeleteDistrict")]
        public IActionResult DeleteDistrict(List<int> ListID)
        {
            try
            {
                var check = profile.DeleteDistrict(ListID);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("ActiveDistrict")]
        public IActionResult ActiveDistrict(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveDistrict(ListID, -1);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("DeActiveDistrict")]
        public IActionResult DeActiveDistrict(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveDistrict(ListID, 0);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [Authorize(Roles = "1")]
        [HttpPost("DeleteWard")]
        public IActionResult DeleteWard(List<int> ListID)
        {
            try
            {
                var check = profile.DeleteWard(ListID);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("ActiveWard")]
        public IActionResult ActiveWard(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveWard(ListID, -1);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("DeActiveWard")]
        public IActionResult DeActiveWard(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveWard(ListID, 0);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        #endregion





        #region Business

        [HttpPost("GetListPositionByOrgID")]
        public IActionResult GetListPositionByOrgID(int ID)
        {
            List<Position> list = profile.GetListPositionByOrgID(ID);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ID = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "Obj is Null");
        }

        [HttpPost("GetListEmployeeByOrgID")]
        public IActionResult GetListEmployeeByOrgID(int id, int index, int size)
        {
            List<EmployeeResponseServices> list = profile.GetListEmployeeByOrgID(id, index, size);
            if (list.Count > 0)
                return Ok(new
                {
                    TotalItem = profile.getTotalEmployee(id),
                    Data = list
                });
            else
                return StatusCode(200, "Obj is Null");
        }

        [HttpPost("GetListEmployeeByOrgIDByFilter")]
        public IActionResult GetListEmployeeByOrgIDByFilter([FromBody] EmployeResponse obj)
        {
            int totalItem = 0;
            List<EmployeeResponseServices> list = profile.GetListEmployeeByOrgIDByFilter(obj.orgID, obj.index, obj.size, obj.Code, obj.Name, obj.OrgName, obj.TitleName, obj.PositionName, obj.JoinDate, obj.Status, ref totalItem);
            if (list.Count > 0)
                return Ok(new
                {
                    TotalItem = totalItem,
                    Data = list
                });
            else
                return StatusCode(200, "Obj is Null");
        }


        [HttpPost("GetAllInforOfEmployee")]
        public IActionResult GetAllInforOfEmployee(int empID)
        {

            Employee e = profile.GetEmployeeByID(empID);
            EmployeeCv cv = profile.GetEmployeeCvByEmpID(empID);
            EmployeeEdu edu = profile.GetEmployeeEduByEmpID(empID);
            List<EmployeeContract> listEmpContract = profile.GetListEmployeeContractByEmpID(empID);
            var employeeReturn = new
            {
                //e
                firstname = e.FirstName,
                lastName = e.LastName,
                fullName = e.FullName,
                joinDate = e.JoinDate,
                lastDate = e.LastDate,
                statusEmp = e.StatusNavigation?.Name,
                statusEmpId = e.Status,
                isFromRecuirement = e.IsFronmRecruit,
                orgName = e.Orgnization?.Name,
                orgId = e.OrgnizationId,
                positionName = e.Position?.Name,
                positionId = e.PositionId,

                //CV
                gender = cv.GenderNavigation?.Name,
                genderId = cv.Gender,
                image = cv.Image,
                dateOfBirth = cv.Dob,
                cmnd = cv.Cmnd,
                cmndPlace = cv.Cmndplace,
                email = cv.Email,
                emailWork = cv.EmailWork,
                phoneNumber = cv.Phone,
                hokhau = cv.HoKhau,
                nationHK = cv.NationHk,
                provinceHK = cv.ProvinceHk,
                districtHK = cv.DistrictHk,
                noisinh = cv.NoiSinh,
                nationBirth = cv.NationOb,
                provinceBirth = cv.ProvinceOb,
                districtBirth = cv.DistrictOb,
                noiO = cv.NoiO,
                nationLive = cv.NationLive,
                provinceLive = cv.ProvinceLive,
                districtLive = cv.DistrictLive,


                //edu
                learningLevelMax = edu.LearningLevelNavigation?.Name,
                learningLevelMaxId = edu.LearningLevel,
                SchoolName1 = edu.School1,
                SchoolName2 = edu.School1,
                SchoolName3 = edu.School1,
                major1 = edu.Major1,
                major2 = edu.Major2,
                major3 = edu.Major3,
                degree1 = edu.DeeGree1,
                degree2 = edu.DeeGree2,
                degree3 = edu.DeeGree3,
                degreeId1 = edu.DeeGree1,
                degreeId2 = edu.DeeGree2,
                degreeId3 = edu.DeeGree3,
                informatic1 = edu.InforMaticsLevel1Navigation?.Name,
                informatic2 = edu.InforMaticsLevel2Navigation?.Name,
                informatic3 = edu.InforMaticsLevel3Navigation?.Name,
                informaticId1 = edu.InforMaticsLevel1,
                informaticId2 = edu.InforMaticsLevel2,
                informaticId3 = edu.InforMaticsLevel3,
                GPA1 = "",
                GPA2 = "",
                GPA3 = "",
                Award1 = "",
                Award2 = "",
                Award3 = "",
                language1 = edu.Language1Navigation?.Name,
                language2 = edu.Language2Navigation?.Name,
                language3 = edu.Language3Navigation?.Name,
                language1Id = edu.Language1,
                language2Id = edu.Language2,
                language3Id = edu.Language3,
                EmpContract = from lst in listEmpContract
                              select new
                              {
                                  contractNo = lst.ContractNo,
                                  contractType = lst.ContractType?.Name,
                                  effectdate = lst.EffectDate,
                                  expiredate = lst.ExpireDate,
                                  signName = lst.Sign?.FullName,
                                  signDate = lst.SignDate,
                                  status = lst.Status,
                                  note = lst.Note,
                                  positionName = lst.Position?.Name,
                                  orgname = lst.Orgnization?.Name
                              }
            };
            return Ok(new
            {
                Data = employeeReturn
            });
        }



        [HttpPost("GetProfileOfEmployee")]
        public IActionResult GetProfileOfEmployee(int empID)
        {
            EmployeeProfileResponseServices obj = new EmployeeProfileResponseServices();
            obj = profile.getEmployeeProfile(empID);
            return Ok(new
            {
                Data = obj
            });
        }

        [HttpPost("GetContractEmployee")]
        public IActionResult GetContractEmployee(int index, int size)
        {
            List<ContractEmployeeResponse> list = new List<ContractEmployeeResponse>();
            int total = 0;
            list = profile.GetContractEmployee(index, size,ref total);
            return Ok(new
            {
                Data = list,
                TotalItem= total
            });
        }

        [HttpPost("GetContractEmployeeByFilter")]
        public IActionResult GetContractEmployeeByFilter([FromBody] ContractEmpResponse obj )
        {
            List<ContractEmployeeResponse> list = new List<ContractEmployeeResponse>();
            int total = 0;
            list = profile.GetContractEmployeeByFilter(obj.index, obj.size, ref total,obj.Name, obj.Code, obj.OrgnizationName, obj.ContractNo,obj.ContractType,obj.Position,obj.EffectDate, obj.ExpireDate,obj.Status);
            return Ok(new
            {
                Data = list,
                TotalItem = total
            });
        }

        [Authorize(Roles = "1,0")]
        [HttpPost("InsertContractEmployee")]
        public IActionResult InsertContractEmployee([FromBody] ContractEmpResponse T)
        {
            try
            {
                Account a = GetCurrentUser();
                ContractEmployeeResponse obj = new ContractEmployeeResponse();
                obj.ContractNo = T.ContractNo;
                obj.ContractTypeId = T.ContractTypeId;
                obj.Effect = T.EffectDate;
                obj.Expire = T.ExpireDate;
                obj.OrgnizationId = T.OrgnizationId;
                obj.PositionId = T.PositionId;
                obj.EmployeeId = T.EmployeeId;
                var check = profile.InsertContractEmployee(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1,0")]
        [HttpPost("ModifyContractEmployee")]
        public IActionResult ModifyContractEmployee([FromBody] ContractEmpResponse T)
        {
            try
            {
                Account a = GetCurrentUser();
                ContractEmployeeResponse obj = new ContractEmployeeResponse();
                obj.ID = T.Id;
                obj.ContractNo = T.ContractNo;
                obj.ContractTypeId = T.ContractTypeId;
                obj.Effect = T.EffectDate;
                obj.Expire = T.ExpireDate;
                obj.OrgnizationId = T.OrgnizationId;
                obj.PositionId = T.PositionId;
                obj.EmployeeId = T.EmployeeId;
                var check = profile.ModifyContractEmployee(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("ActiveContractEmployee")]
        public IActionResult ActiveContractEmployee(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveEmployeeContract(ListID, -1);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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

        [Authorize(Roles = "1")]
        [HttpPost("DeActiveContractEmployee")]
        public IActionResult DeActiveContractEmployee(List<int> ListID)
        {
            try
            {
                var check = profile.ActiveOrDeActiveEmployeeContract(ListID, 0);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
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


        [HttpPost("getContractEmployeeById")]
        public IActionResult getContractEmployeeById(int id)
        {
            return Ok(new
            {
                Data = profile.getContractEmployeeById(id)
            });
        }

            #endregion




        }
    }