using ModelAuto.Models;
using Services.ResponseModel.OrgnizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    public interface IOrgnization
    {
        #region List

        #region"Title"
         List<Title> GetAllTitle( int index, int size);
         bool InsertTitle(Title T);
         bool ModifyTitle(Title T);
         bool DeleteTitle(List<int> list);
         bool ActiveOrDeActiveTitle(List<int> list, int status);
        #endregion

        #region"Position"
         List<Position> GetAllPosition(int index, int size);
         bool InsertPosition(Position T);
         bool ModifyPosition(Position T);
         bool DeletePosition(List<int> list);
         bool ActiveOrDeActivePosition(List<int> list, int status);
        #endregion

        #region "Địa điểm"

        List<NationResponseServices> GetAllNation(int index, int size, ref int totalItems);
        List<ProvinceResponseServices> GetAllProvince(int index, int size, ref int totalItems);
        List<DistrictResponseServices> GetAllDistrict(int index, int size, ref int totalItems);
        List<WardResponseServices> GetAllWard(int index, int size, ref int totalItems);

        #endregion

        #endregion

        #region business
        #region"Org"
        List<Orgnization> GetAllOrgnization();
         bool InsertOrg(Orgnization T);
         bool ModifyOrg(Orgnization T);
         bool DeleteOrg(int orgID);
         bool ActiveOrDeActiveOrg(int orgID, int status);
        List<Orgnization> GetListOrgByOrgID(int ID);
        #endregion

        #region Thiet lap vi tri cv cho phong ban
        List<PositionInOrgResponse> GetAllPositionOrg(int index, int size, ref int total);
        bool InsertPositionOrg(PositionOrg T);
        bool ModifyPositionOrg(PositionOrg T);
        bool DeletePositionOrg(List<int> list);
        bool ActiveOrDeActivePositionOrg(List<int> list, int status);
        bool CheckPositionExist(int orgId, int positionId);
        #endregion

        #endregion
    }
}
