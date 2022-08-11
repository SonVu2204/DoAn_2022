using API.ResponseModel.Orgnization;
using ModelAuto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ResponseModel.Common;
using Services.CandidateService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonAPIController : ControllerBase
    {
        private ICommon p = new CommonImpl();


        [HttpPost("autoGenCode3character")]
        public IActionResult autoGenCode3character(AutogenCode3Response obj)
        {
            return Ok(p.autoGenCode3character(obj.table, obj.code));
        }

        [HttpPost("autoGenCode")]
        public IActionResult autoGenCode(AutogenCodeResponse obj)
        {
            return Ok(p.autoGenCode(obj.table, obj.rank, obj.collumName, obj.ParentId));
        }

        [HttpPost("GetOtherListType")]
        public IActionResult GetOtherListType(int phanHe)
        {
            List<OtherListType> list = new List<OtherListType>();
            // nhớ tách phân hệ
            list = p.GetOtherListType().ToList();
            var listReturn = from l in list
                             select new
                             {
                                 name= l.Name,
                                 coed= l.Code,
                                 note=l.Note,
                                 statusName = l.Status==-1?"Active": "Deactive",
                                 id= l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        [HttpPost("CheckUsinginDatabase")]
        public IActionResult CheckUsinginDatabase(int id, string table)
        {
            List<OtherListType> list = new List<OtherListType>();
            // nhớ tách phân hệ
            list = p.GetOtherListType().ToList();
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 coed = l.Code,
                                 note = l.Note,
                                 statusName = l.Status == -1 ? "Active" : "Deactive",
                                 id = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        #region getbyID
        [HttpPost("GetTitleByID")]
        public IActionResult GetTitleByID(int ID)
        {
            Title obj = p.getTitleByID(ID);
            if (obj != null)
                return Ok(new
                {
                    Status = true,
                    Data = obj
                });
            else
                return StatusCode(200, "Obj is Null");
        }
        #endregion

        #region "Tham số hệ thống"
        [HttpPost("GetOtherList")]
        public IActionResult GetOtherList(string code , int index, int size)
        {
            List<OtherList> list = new List<OtherList>();
            list = p.GetOtherListsCombo(code, index, size);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 note = l.Note,
                                 statusName = l.Status == -1 ? "Active" : "Deactive",
                                 id = l.Id
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = p.GetOtherListsCombo(code,0, Int32.MaxValue).Count(),
                    Data = listReturn
                });
            }
            return Ok(new
            {
                TotalItem = p.GetOtherListsCombo(code, 0, Int32.MaxValue).Count(),
                Data = new List<OtherList>()
            });
        }


        [HttpPost("GetOtherListByAttribute")]
        public IActionResult GetOtherListByAttribute(int id)
        {

            ICandidate rc = new CandidateImpl();
            List<OtherList> list = new List<OtherList>();
            list = rc.GetOtherListByAttribute(id);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 note = l.Note,
                                 statusName = l.Status == -1 ? "Active" : "Deactive",
                                 id = l.Id
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Data = listReturn
                });
            }
            return Ok(new
            {
                Data = new List<OtherList>()
            });
        }

        

        [HttpPost("GetAllOtherList")]
        public IActionResult GetAllOtherList(string code, int index, int size)
        {
            List<OtherList> list = new List<OtherList>();
            list = p.GetOtherList(code, index, size);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 note = l.Note,
                                 statusName = l.Status == -1 ? "Active" : "Deactive",
                                 id = l.Id,
                                 attribute1= l.Atribute1
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = p.GetOtherListsCombo(code, 0, Int32.MaxValue).Count(),
                    Data = listReturn
                });
            }
            return Ok(new
            {
                TotalItem = p.GetOtherListsCombo(code, 0, Int32.MaxValue).Count(),
                Data = new List<OtherList>()
            });
        }


        [HttpPost("ActiveOtherList")]
        public IActionResult ActiveOtherList(List<int>ListID)
        {
            try
            {
               
                var check = p.ActiveOrDeActiveOtherList(ListID, -1);
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


        [HttpPost("DeActiveOtherList")]
        public IActionResult DeActiveOtherList(List<int> ListID)
        {
            try
            {
                var check = p.ActiveOrDeActiveOtherList(ListID, 0);
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


        [HttpPost("DeleteOtherList")]
        public IActionResult DeleteOtherList([FromBody] List<int> ListID)
        {
            try
            {
                var check = p.DeleteOtherList(ListID);
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


        [HttpPost("InsertOtherList")]
        public IActionResult InsertOtherList([FromBody] OtherListResponse objresponse)
        {
            try
            {
                OtherList obj = new OtherList();
                obj.Atribute1 = objresponse.Atribute1;
                obj.Atribute2 = objresponse.Atribute2;
                obj.Atribute3 = objresponse.Atribute3;
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.Name = objresponse.Name;
                obj.Code = objresponse.Code;
                obj.TypeId = objresponse.TypeID;
                var check = p.InsertOtherList(obj);
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


        [HttpPut("ModifyOtherList")]
        public IActionResult ModifyOtherList([FromBody] OtherListResponse objresponse)
        {
            try
            {
                OtherList obj = new OtherList();
                obj.Id = objresponse.Id;
                obj.Atribute1 = objresponse.Atribute1;
                obj.Atribute2 = objresponse.Atribute2;
                obj.Atribute3 = objresponse.Atribute3;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                var check = p.ModifyOtherList(obj);
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
    }
}
