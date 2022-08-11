using ModelAuto.Models;
using Services.ResponseModel.CandidateModel;
using Services.ResponseModel.RequestModel;
using Services.ResponseModel.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
    public interface ICandidate
    {
        List<OtherList> GetOtherListByAttribute(int? ID);

        #region thao tác candidate
        string AddRcCandidate(RcCandidate r);
        bool AddRcCandidateCV(RcCandidateCv r);

        bool AddRcCandidateEdu(RcCandidateEdu r);

        bool AddRcCandidateSkill(List<RcCandidateSkill> r);

        bool AddRcCandidateExp(List<RcCandidateExp> r);

        bool deleteCandidate(List<int> list);

        bool activeCandidate(List<int> list);

        bool deactiveCandidate(List<int> list, string comment);
        bool EditCandidateInfor(InforCandidateEdit e);
        string CheckInforCandidateEdit(CandidateEdit e);

        #endregion

        #region  de thuc hien 5 man phong van
        bool AddStep1(SetStep1 pv);
        bool AddStep2(SetStep2 pv);
        bool AddStep3(List<ScheduleRes> pv);
        bool AddStep4(SetStep4 pv);
        bool AddStep5(SetStep5 pv);
        List<ResultStep3> GetAllResultStep3(int requestID);
        bool PassStep3_4(PassStep3 e);


        #endregion

        #region GetInforofCandiddate
        List<CandidateResponeServices> GetAllCandidate(int page, int total, int status);
        List<CandidateResponeServices> GetAllCandidateByFillter(int index, int size, string name, int yob, string phone, string email, string location, string position, string yearExp, string language, int status, ref int totalItems);
        List<RcCandidate> GetAllCandidateByStep(int step);
        RcCandidate GetCandidateByID(int id);
        RcCandidate GetCandidateByCode(string code);
        RcCandidateCv GetCandidateCVbyID(int? id);
        RcCandidateEdu GetCandidateEdubyID(int id);


        List<OtherListType> GetSkillType(int type);


        List<RcCandidateSkill> GetCandidateSkillbyID(int id);
        List<RcCandidateSkill> GetCandidateLanguagebyID(int id);
        List<RcCandidateExp> GetCandidateExpbyID(int id);


        Province GetLocation(int? id);
        Nation GetNation(int? id);
        District GetDistrict(int? id);
        Ward GetWard(int? id);
        #endregion


        //string GetSkill(int? candidateID);
        //string Position(int? candidateID);
        //string Exp(int? candidateID);
        OtherListType GetOtherListTypesCandidate(int id);
        OtherList GetOtherListCandidate(int id);
        List<RcCandidateExp> GetExpOneCandidate(int id, int type);
        checkResponse checkDuplicateCandidate(CheckDuplicateCandidateModel obj);


        #region "matching request"
        /// <summary>
        /// matching request voi candidate xong roi add candidatePV de pv cac buoc
        /// </summary>
        /// <param name="requestID"></param>
        /// <param name="lstCandidateID"></param>
        /// <returns></returns>
        bool MatchingCandidate(int requestID, List<int> lstCandidateID);
        List<CandidateResponeServices> GetCandidateByRequest(int requestID, int index, int size, string name, int yob, string phone, string email, string location, string position, string yearExp, string language, int status, ref int totalItems);
        bool CheckQuantity(int requestID, List<int> lstCandidateID);
        bool DeleteCandidateRequest(List<int> listID);
        bool CheckDuplicateMatching(int requestID, List<int> candidateID, ref string mess);
        #endregion


        #region "Step"
        List<RequestResponseServices> GetAllRequestByCandidateID(int id);
        CandidatePV_infor GetCandidateRequestInf(int candidateId, int requestId);

        bool Onboard(int candidateId, int requestId);
        #endregion
    }
}
