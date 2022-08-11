using ModelAuto.Models;
using Services.CommonModel;
using Services.ResponseModel.OrgnizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonServices
{
    public interface ICommon
    {
        #region AUtoGen code
        string autoGenCode(string tableName, int? rank, string nameColumn, int? parentID);
        string autoGenCode3character(string tableName, string firstCode);
        #endregion

        #region GetByID
        OrgnizationResponseServices getOrgByID(int id);
        Title getTitleByID(int id);
        Position getPositionByID(int id);
        #endregion

        #region other_list_type
        List<OtherListType> GetOtherListType();
        #endregion

        #region sendmail
        bool sendMail(MailDTO mail);
        #endregion

        #region "Ma hoa mat khau"
        string sha256_hash(string pass);
        #endregion






        #region "Request"
        public int getTotalRecord(string tableName, bool isRank);
        #endregion




        #region OTherList
        List<OtherList> GetOtherListsCombo(string code, int index, int size);
        List<OtherList> GetOtherList(string code, int index, int size);
        bool InsertOtherList(OtherList T);
        bool ModifyOtherList(OtherList T);
        bool DeleteOtherList(List<int> list);
        bool ActiveOrDeActiveOtherList(List<int> list, int status);
        #endregion
    }
}
