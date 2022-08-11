using ModelAuto.Models;
using Services.ResponseModel.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
   public interface IRequest
    {
        #region RcRequest
        List<RequestResponseServices> GetAllRequest(int index, int size);
        List<RequestResponseServices> GetAllRequestByFillter( int index, int size, string Code, string Name, string OrgName, string PositionName, int Quantity, string Status,  string HrInchange, DateTime CreateOn, DateTime DeadLine, string otherSkill);
        List<RequestResponseServices> GetChildRequestById(int ID);
        bool InsertRequest(RcRequest T);
        bool ModifyRequest(RcRequest T);
        bool DeleteRequest(List<int> list);
        bool ActiveOrDeActiveRequest(List<int> list, int status, string actionBy);
        RequestResponseServices GetRequestByID(int ID);
        int getTotalRequestRecord(string column , int? signID);
        List<RcRequest> GetListRequestByID(int ID);
        bool SendComment(RcRequest T);
        bool setHrInchange(RcRequest T);
        #endregion
    }
}
