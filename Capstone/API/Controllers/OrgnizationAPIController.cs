using API.ResponseModel.Common;
using API.ResponseModel.Orgnization;
using ModelAuto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.OrgnizationServiecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.CommonServices;
using Services.ResponseModel.OrgnizationModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgnizationAPIController : AuthorizeByIDController
    {
        private IOrgnization p = new OrgnizationImpl();
        private ICommon c = new CommonImpl();
        #region List


        #region DM chuc danh
        [Authorize]
        [HttpPost("GetAllTitle")]
        public IActionResult GetAllTitle(int index, int size)
        {
            List<Title> list = p.GetAllTitle(index, size).Where(x => x.Status == -1).ToList();
            var ListResponse = from l in list
                               select new
                               {
                                   id = l.Id,
                                   name = l.Name,
                                   code = l.Code,
                                   status = l.Status == -1 ? "Active" : "Deactive",
                                   note = l.Note
                               };

            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Title", false),
                    Data = ListResponse
                });
            }
            return StatusCode(200, "List is Null");
        }

        [Authorize]
        [HttpPost("GetAllOfTitle")]
        public IActionResult GetAllOfTitle(int index, int size)
        {
            List<Title> list = p.GetAllTitle(index, size);
            var ListResponse = from l in list
                               select new
                               {
                                   id = l.Id,
                                   name = l.Name,
                                   code = l.Code,
                                   status = l.Status == -1 ? "Active" : "Deactive",
                                   note = l.Note
                               };

            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Title", false),
                    Data = ListResponse
                });
            }
            return StatusCode(200, "List is Null");
        }

        [Authorize(Roles = "0,1")]
        [HttpPost("ActiveTitle")]
        public IActionResult ActiveTitle(List<int> listID)
        {
            try
            {
                var check = p.ActiveOrDeActiveTitle(listID, -1);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeActiveTitle")]
        public IActionResult DeActiveTitle(List<int> ListID)
        {
            try
            {
                var check = p.ActiveOrDeActiveTitle(ListID, 0);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeleteTitle")]
        public IActionResult DeleteTitle(List<int> ListID)
        {
            try
            {
                var check = p.DeleteTitle(ListID);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("InsertTitle")]
        public IActionResult InsertTitle([FromBody] TitleResponse objresponse)
        {
            try
            {
                Title obj = new Title();
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.Name = objresponse.Name;
                obj.Code = objresponse.Code;
                var check = p.InsertTitle(obj);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("ModifyTitle")]
        public IActionResult ModifyTitle([FromBody] TitleResponse objresponse)
        {
            try
            {
                Title obj = new Title();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                var check = p.ModifyTitle(obj);
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
        #endregion

        #region DM vi tri cong viec
        [Authorize]
        [HttpPost("GetAllPosition")]
        public IActionResult GetAllPosition(int index, int size)
        {
            List<Position> list = p.GetAllPosition(index, size).Where(x => x.Status == -1).ToList();
            var listReturn = from l in list
                             select new
                             {
                                 id = l.Id,
                                 name = l.Name,
                                 code = l.Code,
                                 note = l.Note,
                                 title = l.Title?.Name,
                                 titleId = l.TitleId,
                                 basicSalary = l.BasicSalary,
                                 otherSkill = l.OtherSkill,
                                 workForm = l.FormWorkingNavigation?.Name,
                                 workFormID = l.FormWorking,
                                 statusName = l.Status == -1 ? "Active" : "Deactive"
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Position", false),
                    Data = listReturn
                });
            }
            return StatusCode(200, "List is Null");
        }
        [Authorize]
        [HttpPost("GetAllOfPosition")]
        public IActionResult GetAllOfPosition(int index, int size)
        {
            List<Position> list = p.GetAllPosition(index, size);
            var listReturn = from l in list
                             select new
                             {
                                 id = l.Id,
                                 name = l.Name,
                                 code = l.Code,
                                 note = l.Note,
                                 title = l.Title?.Name,
                                 titleId = l.TitleId,
                                 basicSalary = l.BasicSalary,
                                 otherSkill = l.OtherSkill,
                                 workForm = l.FormWorkingNavigation?.Name,
                                 workFormID = l.FormWorking,
                                 statusName = l.Status == -1 ? "Active" : "Deactive"
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Position", false),
                    Data = listReturn
                });
            }
            return StatusCode(200, "List is Null");
        }

        [Authorize(Roles = "0,1")]
        [HttpPost("ActivePosition")]
        public IActionResult ActivePosition(List<int> ListID)
        {
            try
            {

                var check = p.ActiveOrDeActivePosition(ListID, -1);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeActivePosition")]
        public IActionResult DeActivePosition(List<int> ListID)
        {
            try
            {

                var check = p.ActiveOrDeActivePosition(ListID, 0);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeletePosition")]
        public IActionResult DeletePosition(List<int> ListID)
        {
            try
            {
                var check = p.DeletePosition(ListID);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("InsertPosition")]
        public IActionResult InsertPosition([FromBody] PositionResponse objresponse)
        {
            try
            {
                Position tobj = new Position();
                tobj.Name = objresponse.Name;
                tobj.Note = objresponse.Note;
                tobj.TitleId = objresponse.TitleID;
                tobj.OtherSkill = objresponse.OtherSkill;
                tobj.FormWorking = objresponse.FormWorking;
                tobj.BasicSalary = objresponse.BasicSalary;
                tobj.LearningLevel = objresponse.Learning_level;
                tobj.YearExperience = objresponse.year_exp;
                tobj.MajorGroup = objresponse.majorGroup;
                tobj.Language = objresponse.language;
                tobj.LanguageLevel = objresponse.language_level;
                tobj.InformationLevel = objresponse.Information_level;
                var check = p.InsertPosition(tobj);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("ModifyPosition")]
        public IActionResult ModifyPosition([FromBody] PositionResponse objresponse)
        {
            try
            {
                Position tobj = new Position();
                tobj.Id = objresponse.Id;
                tobj.Name = objresponse.Name;
                tobj.Note = objresponse.Note;
                tobj.TitleId = objresponse.TitleID;
                tobj.OtherSkill = objresponse.OtherSkill;
                tobj.FormWorking = objresponse.FormWorking;
                tobj.BasicSalary = objresponse.BasicSalary;
                tobj.LearningLevel = objresponse.Learning_level;
                tobj.YearExperience = objresponse.year_exp;
                tobj.MajorGroup = objresponse.majorGroup;
                tobj.Language = objresponse.language;
                tobj.LanguageLevel = objresponse.language_level;
                tobj.InformationLevel = objresponse.Information_level;
                var check = p.ModifyPosition(tobj);
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
        #endregion

        #region Danh muc dia diem

        [HttpPost("GetNationList")]
        public IActionResult GetNation(int index, int size)
        {
            int totalItems = 0;
            List<NationResponseServices> list = p.GetAllNation(index, size, ref totalItems);
            if (list.Count > 0)
                return Ok(new
                {
                    TotalItem = totalItems,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("GetProvinceList")]
        public IActionResult GetProvinceList(int index, int size)
        {
            int totalItems = 0;
            List<ProvinceResponseServices> list = p.GetAllProvince(index, size, ref totalItems);
            if (list.Count > 0)
                return Ok(new
                {
                    TotalItem = totalItems,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("GetDistrictList")]
        public IActionResult GetDistrictList(int index, int size)
        {
            int totalItems = 0;
            List<DistrictResponseServices> list = p.GetAllDistrict(index, size, ref totalItems);
            if (list.Count > 0)
                return Ok(new
                {
                    TotalItem = totalItems,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("GetWardList")]
        public IActionResult GetWardList(int index, int size)
        {
            int totalItems = 0;
            List<WardResponseServices> list = p.GetAllWard(index, size, ref totalItems);
            if (list.Count > 0)
                return Ok(new
                {
                    TotalItem = totalItems,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        #endregion

        #endregion

        #region Business

        #region Quan ly to chuc

        [Authorize]
        [HttpPost("getOrgByID")]
        public IActionResult getOrgByID(int Id)
        {
            OrgnizationResponseServices x = c.getOrgByID(Id);
            if (x != null)
            {
                return Ok(new
                {
                    Status = true,
                    Data = x
                });
            }
            return StatusCode(200, "obj is Null");
        }

        [Authorize]
        [HttpPost("GetAllOrg")]
        public IActionResult GetAllOrg()
        {
            GetChildOrgnization g = new GetChildOrgnization();
            List<Orgnization> list = p.GetAllOrgnization();
            var ListReturn = list.Where(x => x.Level == 1).Select(x => new OrgResponse()
            {
                Name = x.Name,
                Id = x.Id,
                Code = x.Code,
                Level = x.Level,
                ParentID = x.ParentId,
                Children = g.GetChildOrg(list, x.Id),
            }).ToList();
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Status = true,
                    Data = ListReturn
                });
            }
            return StatusCode(200, "List is Null");
        }


        [Authorize(Roles = "0,1")]
        [HttpPost("ActiveOrg")]
        public IActionResult ActiveOrg([FromBody] int ID)
        {
            try
            {
                var check = p.ActiveOrDeActiveOrg(ID, -1);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeActiveOrg")]
        public IActionResult DeActiveOrg([FromBody] int ID)
        {
            try
            {
                var check = p.ActiveOrDeActiveOrg(ID, 0);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeleteOrg")]
        public IActionResult DeleteOrg([FromBody] int ID)
        {
            try
            {

                var check = p.DeleteOrg(ID);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("InsertOrg")]
        public IActionResult InsertOrg([FromBody] OrgResponse1 objresponse)
        {
            try
            {
                Account a = GetCurrentUser();
                Orgnization obj = new Orgnization();
                obj.Name = objresponse.Name;
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.CreateDate = objresponse.CreateDate;
                obj.Effectdate = objresponse.EfectDate;
                if (!objresponse.DissolutionDate.ToString("yyyy").Equals("1000"))
                {
                    obj.DissolutionDate = objresponse.DissolutionDate;
                }
                obj.ParentId = objresponse.ParentID;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.Note = objresponse.Note;
                obj.Fax = objresponse.Fax;
                obj.Email = objresponse.Email;
                obj.Phone = objresponse.Mobile;
                obj.NumberBussines = objresponse.NumberBussines;
                obj.Address = objresponse.Address;
                if (objresponse.NationID != 0)
                {
                    obj.NationId = objresponse.NationID;
                }
                if (objresponse.ProvinceID != 0)
                {
                    obj.ProvinceId = objresponse.ProvinceID;
                }
                if (objresponse.DistrictID != 0)
                {
                    obj.DistrictId = objresponse.DistrictID;
                }
                if (objresponse.WardID != 0)
                {
                    obj.WardId = objresponse.WardID;
                }
                obj.CreateBy = a.Employee?.FullName;
                if (objresponse.ManagerID != 0 && objresponse.ManagerID != null)
                {
                    obj.ManagerId = objresponse.ManagerID;
                }

                var check = p.InsertOrg(obj);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("ModifyOrg")]
        public IActionResult ModifyOrg([FromBody] OrgResponse1 objresponse)
        {
            try
            {
                Account a = GetCurrentUser();
                Orgnization obj = new Orgnization();
                obj.Id = objresponse.Id;
                obj.Name = objresponse.Name;
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.CreateDate = objresponse.CreateDate;
                obj.Effectdate = objresponse.EfectDate;
                if (!objresponse.DissolutionDate.ToString("yyyy").Equals("1000"))
                {
                    obj.DissolutionDate = objresponse.DissolutionDate;
                }
                obj.ParentId = objresponse.ParentID;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.Note = objresponse.Note;
                obj.Fax = objresponse.Fax;
                obj.Email = objresponse.Email;
                obj.Phone = objresponse.Mobile;
                obj.NumberBussines = objresponse.NumberBussines;
                obj.Address = objresponse.Address;
                if (objresponse.NationID != 0)
                {
                    obj.NationId = objresponse.NationID;
                }
                if (objresponse.ProvinceID != 0)
                {
                    obj.ProvinceId = objresponse.ProvinceID;
                }
                if (objresponse.DistrictID != 0)
                {
                    obj.DistrictId = objresponse.DistrictID;
                }
                if (objresponse.WardID != 0)
                {
                    obj.WardId = objresponse.WardID;
                }
                obj.CreateBy = a.Employee?.FullName;
                if (objresponse.ManagerID != 0 && objresponse.ManagerID != null)
                {
                    obj.ManagerId = objresponse.ManagerID;
                }

                var check = p.ModifyOrg(obj);
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

        #region Thiet lap vi tri cong viec cho phong ban


        [HttpPost("CheckPositionExist")]
        public IActionResult CheckPositionExist(int orgId, int positionId)
        {
            return Ok(new
            {
                Status = p.CheckPositionExist(orgId, positionId)
            });
        }


        [Authorize]
        [HttpPost("GetAllPositionOrg")]
        public IActionResult GetAllPositionOrg(int index, int size)
        {
            int total = 0;
            List<PositionInOrgResponse> list = p.GetAllPositionOrg(index, size, ref total);
           
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = total,
                    Data = list
                });
            }
            return StatusCode(200, "List is Null");
        }

        [Authorize(Roles = "0,1")]
        [HttpPost("ActivePositionOrg")]
        public IActionResult ActivePositionOrg([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.ActiveOrDeActivePositionOrg(lst, -1);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeActivePositionOrg")]
        public IActionResult DeActivePositionOrg([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.ActiveOrDeActivePositionOrg(lst, 0);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("DeletePositionOrg")]
        public IActionResult DeletePositionOrg(List<int> lst)
        {
            try
            {
                var check = p.DeletePositionOrg(lst);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("InsertPositionOrg")]
        public IActionResult InsertPositionOrg([FromBody] PositionOrgResponse objresponse)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.Status = -1;
                tobj.OrgId = objresponse.OrgID;
                tobj.PositionId = objresponse.positionID;
                tobj.Note = objresponse.Note;
                tobj.CreateBy = "HUNGNX";
                var check = p.InsertPositionOrg(tobj);
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

        [Authorize(Roles = "0,1")]
        [HttpPost("ModifyPositionOrg")]
        public IActionResult ModifyPositionOrg([FromBody] PositionOrgResponse objresponse)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.Id = objresponse.Id;
                tobj.Note = objresponse.Note;
                tobj.OrgId = objresponse.OrgID;
                tobj.PositionId = objresponse.positionID;
                tobj.UpdateBy = "HUNGNX";
                var check = p.ModifyPositionOrg(tobj);
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

        [Authorize]
        [HttpPost("GetListOrgByOrgID")]
        public IActionResult GetListOrgByOrgID(int ID)
        {
            List<Orgnization> list = p.GetListOrgByOrgID(ID);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ParentId = l.ParentId,
                                 Level = l.Level,
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


        #endregion


        #endregion
    }
}
