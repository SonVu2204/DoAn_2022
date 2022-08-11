using ModelAuto.Models;
using Services.CommonModel;
using Services.ResponseModel.ProfileModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
    public interface IProfile
    {

        #region "Account"
        Account GetAccount(Account a);
        bool ChangePass(Account a);
        bool ResetPass(string userName, string emailCheck, MailDTO mailobj);

        #endregion


        #region "List"


        #region "DM dia diem, dia chi"
        List<Nation> GetNationList();
        bool InsertNation(Nation T);
        bool ModifyNation(Nation T);
        bool DeleteNation(List<int> list);
        bool ActiveOrDeActiveNation(List<int> list, int status);


        List<Province> GetProvinceListByNationID(int ID);
        bool InsertProvince(Province T);
        bool ModifyProvince(Province T);
        bool DeleteProvince(List<int> list);
        bool ActiveOrDeActiveProvince(List<int> list, int status);


        List<District> GetDistrictListByProvinceID(int ID);
        bool InsertDistrict(District T);
        bool ModifyDistrict(District T);
        bool DeleteDistrict(List<int> list);
        bool ActiveOrDeActiveDistrict(List<int> list, int status);


        List<Ward> GetWardListByDistrictID(int ID);
        bool InsertWard(Ward T);
        bool ModifyWard(Ward T);
        bool DeleteWard(List<int> list);
        bool ActiveOrDeActiveWard(List<int> list, int status);

        #endregion

        #region dm loai HD
        List<ContractType> GetContractTypeList(int index, int size);
        bool InsertContractType(ContractType T);
        bool ModifyContractType(ContractType T);
        bool DeleteContractType(List<int> list);
        bool ActiveOrDeActiveContractType(List<int> list, int status);
        List<ContractType> GetAllContractTypeList(int index, int size);
        #endregion


        #endregion


        #region "Business"

        List<Position> GetListPositionByOrgID(int ID);
        List<EmployeeResponseServices> GetListEmployeeByOrgID(int OrgID, int index, int size);
        List<EmployeeResponseServices> GetListEmployeeByOrgIDByFilter(int OrgID, int index, int size, string code, string name, string orgName, string title, string position, DateTime joindate, string status, ref int totalItem);
        Employee GetEmployeeByID(int? ID);
        EmployeeCv GetEmployeeCvByEmpID(int? ID);
        EmployeeEdu GetEmployeeEduByEmpID(int? ID);
        List<EmployeeContract> GetListEmployeeContractByEmpID(int? ID);
        int getTotalEmployee(int OrgID);
        EmployeeProfileResponseServices getEmployeeProfile(int? ID);
        List<ContractEmployeeResponse> GetContractEmployee(int index, int size, ref int totalItem);
        List<ContractEmployeeResponse> GetContractEmployeeByFilter(int index, int size, ref int totalItem,string name, string code, string orgName, string contractNo, string contractType, string position, DateTime effectDate, DateTime exDate, string status );
       
        
        
        bool InsertContractEmployee(ContractEmployeeResponse obj);
        bool ModifyContractEmployee(ContractEmployeeResponse obj);
        bool DeleteContractEmployee(List<int> list);
        bool ActiveOrDeActiveEmployeeContract(List<int> list, int status);
        ContractEmployeeResponse getContractEmployeeById(int id);

        #endregion

    }
}